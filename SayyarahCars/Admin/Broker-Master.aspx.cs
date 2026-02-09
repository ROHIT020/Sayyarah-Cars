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
    public partial class Broker_Master : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        entBroker obj = new entBroker();
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

                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {

            if (btnSubmit.Text != "Update")
            {
                obj.Bcname = txtBCname.Text.Trim();
                obj.EmailID = txtemail.Text.Trim();
                obj.Password = txtpassword.Text.Trim();
                cls.AddBroker(obj);
                CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                cmf.ClearAllControls(Page);
                BindGrid();
            }
            else
            {
                obj.ID = Convert.ToInt32(hdnId.Value); ;
                obj.Bcname = txtBCname.Text.Trim();
                obj.EmailID = txtemail.Text.Trim();
                obj.Password = txtpassword.Text.Trim();
                cls.UpdateBroker(obj);
                CommonFunction.MessageBox(this, "S", "Record Updated successfully!!");
                cmf.ClearAllControls(Page);
                BindGrid();
                btnSubmit.Text = "Submit";
            }
        }

        
        private void BindGrid(int pageNo = 1)
        {
            try
            {
                
                obj.PageNumber = pageNo.ToString();
                DataSet ds = cls.SelectBroker();
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
        protected void LoadBrokerDetails(int id)
        {
            obj.ID = id;
            DataSet ds = cls.SelectBrokerById(obj);
            if (ds.Tables[0].Rows.Count > 0)
            {
                txtBCname.Text = ds.Tables[0].Rows[0]["Bcname"].ToString();
                txtemail.Text = ds.Tables[0].Rows[0]["EmailID"].ToString();
                txtpassword.Text = ds.Tables[0].Rows[0]["Password"].ToString();
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
        private void DeleteItem(int id)
        {
            try
            {
                obj.ID = id;
                obj.uid = uid;
                cls.DeleteBroker(obj);
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
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1);
        }
    }
}