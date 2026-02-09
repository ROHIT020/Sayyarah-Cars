using COMMON;
using DAL;
using ENTITY;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Broker_Address : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        entBrokerAddress obj = new entBrokerAddress();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["AID"] != null)
                {
                    uid = Session["AID"].ToString();

                }
                if (!IsPostBack)
                {
                   
                    BindGrid();
                    BindBrokerCompany();
                    BindBrokerSerachCompany();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void BindBrokerCompany()
        {
            DataSet ds = cls.BrokerCompanyBind();
            cmf.BindDropDownList(ddlbCompany, ds, "BCName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlbCompany.Items.Insert(0, li);
        }
        protected void BindBrokerSerachCompany()
        {
            DataSet ds = cls.BrokerCompanyBind();
            cmf.BindDropDownList(ddlBCSearch, ds, "BCName", "Id");
            ListItem li = new ListItem("--Select Country--", "0");
            ddlBCSearch.Items.Insert(0, li);
        }
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                obj.BCompanyId = Convert.ToInt32(ddlbCompany.SelectedValue);
                obj.BName = txtBname.Text.Trim();
                obj.ContactNo = txtcontact.Text.Trim();
                obj.EmailID = txtemail.Text.Trim();
                obj.BAddress = txtBAddress.Text.Trim();
                cls.AddBrokerAddress(obj);
                CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                cmf.ClearAllControls(Page);
                BindGrid();
            }
            else
            {
                obj.Id = Convert.ToInt32(hdnId.Value);
                obj.BCompanyId = Convert.ToInt32(ddlbCompany.SelectedValue);
                obj.BName = txtBname.Text.Trim();
                obj.ContactNo = txtcontact.Text.Trim();
                obj.EmailID = txtemail.Text.Trim();
                obj.BAddress = txtBAddress.Text.Trim();
                cls.UpdateBrokerAddress(obj);
                CommonFunction.MessageBox(this, "S", "Record Updated successfully!!");
                cmf.ClearAllControls(Page);
                BindGrid();
                btnSubmit.Text = "Submit";
                ddlbCompany.Enabled = true;

            }
        }
        private void BindGrid(int pageNo = 1)
        {
            try
            {

                obj.PageNumber = pageNo.ToString();
                DataSet ds = cls.SelectBrokerAddress();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {

                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    DeleteItem(id);
                }
                else if (e.CommandName == "EditRow")
                {
                    int id = Convert.ToInt32(e.CommandArgument);
                    LoadBrokerDetails(id);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        private void DeleteItem(int id)
        {
            try
            {
                obj.Id = id;
                obj.uid = uid;
                cls.DeleteBrokerAddress(obj);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                BindGrid();
                TabInput.Attributes.Add("class", "nav-link ");
                TabInput.Attributes.Add("aria-selected", "false");
                inputBox.Attributes.Add("class", "tab-pane fade ");

                TabShow.Attributes.Add("class", "nav-link active");
                TabShow.Attributes.Add("aria-expanded", "true");
                showBox.Attributes.Add("class", "tab-pane fade  active show");
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
        protected void LoadBrokerDetails(int id)
        {
            obj.Id = id;
            DataSet ds = cls.SelectBrokerAddressById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                ddlbCompany.SelectedValue = ds.Tables[0].Rows[0]["BCompanyId"].ToString();
                txtBname.Text = ds.Tables[0].Rows[0]["BName"].ToString();
                txtcontact.Text = ds.Tables[0].Rows[0]["ContactNo"].ToString();
                txtemail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtBAddress.Text = ds.Tables[0].Rows[0]["BAddress"].ToString();
                ddlbCompany.Enabled = false;
                hdnId.Value = id.ToString();
                btnSubmit.Text = "Update";
            }
            TabInput.Attributes.Add("class", "nav-link active");
            TabInput.Attributes.Add("aria-selected", "true");
            inputBox.Attributes.Add("class", "tab-pane fade  active show");

            TabShow.Attributes.Add("class", "nav-link");
            TabShow.Attributes.Add("aria-expanded", "false");
            showBox.Attributes.Add("class", "tab-pane fade ");
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1);
        }

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(ddlBCSearch.SelectedValue);
                string date = txtdatefrom.Text.Trim();
                DataSet ds = cls.SelectBCompanyById(id,date);
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = null;
                    GridView1.DataBind();
                }
                TabInput.Attributes.Add("class", "nav-link ");
                TabInput.Attributes.Add("aria-selected", "false");
                inputBox.Attributes.Add("class", "tab-pane fade ");

                TabShow.Attributes.Add("class", "nav-link active");
                TabShow.Attributes.Add("aria-expanded", "true");
                showBox.Attributes.Add("class", "tab-pane fade  active show");
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}