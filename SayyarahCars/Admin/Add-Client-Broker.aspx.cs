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
    public partial class Add_Client_Broker : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        entClientBroker obj = new entClientBroker();
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
                    BindBrokerCompany();
                    BindClinet();
                    BindSearchBrokerCompany();
                    BindSearchClinet();
                    BindGrid();
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
            DataSet ds = cls.BrokerCNameBind();
            cmf.BindDropDownList(ddlbCompany, ds, "BCName", "Id");
            ListItem li = new ListItem("--Select Broker Company--", "0");
            ddlbCompany.Items.Insert(0, li);
        }
        protected void BindBrokerName(int BrokerId)
        {
            DataSet ds = cls.BrokerNameBind(BrokerId);
            cmf.BindDropDownList(ddlBname, ds, "BrokerDetails", "Id");
            ListItem li = new ListItem("--Select Broker Name--", "0");
            ddlBname.Items.Insert(0, li);
        }
        protected void BindClinet()
        {
            DataSet ds = cls.ClinetBind();
            cmf.BindDropDownList(ddlClient, ds, "ClientName", "Id");
            ListItem li = new ListItem("--Select Client Name--", "0");
            ddlClient.Items.Insert(0, li);
        }
      
        protected void BindSearchBrokerCompany()
        {
            DataSet ds = cls.BrokerCNameBind();
            cmf.BindDropDownList(ddlBCSearch, ds, "BCName", "Id");
            ListItem li = new ListItem("--Select Broker Company--", "0");
            ddlBCSearch.Items.Insert(0, li);
        }
        protected void BindSearchClinet()
        {
            DataSet ds = cls.ClinetBind();
            cmf.BindDropDownList(ddlClientSearch, ds, "ClientName", "Id");
            ListItem li = new ListItem("--Select Client Name--", "0");
            ddlClientSearch.Items.Insert(0, li);
        }
        protected void BindSearchBrokerName(int BrokerId)
        {
            DataSet ds = cls.BrokerNameBind(BrokerId);
            cmf.BindDropDownList(ddlBnameSearch, ds, "BrokerDetails", "Id");
            ListItem li = new ListItem("--Select Broker Name--", "0");
            ddlBnameSearch.Items.Insert(0, li);
        }
        private void BindGrid(int pageNo = 1)
        {
            try
            {

                obj.PageNumber = pageNo.ToString();
                DataSet ds = cls.SelectClientBroker();
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
        protected void TabContainer1_ActiveTabChanged(object sender, EventArgs e)
        {

        }

        protected void ddlbCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BrokerId = Convert.ToInt32(ddlbCompany.SelectedValue);
            if (BrokerId > 0)
            {
                BindBrokerName(BrokerId);
            }
            else
            {
                ddlBname.Items.Clear();
                ddlBname.Items.Insert(0, new ListItem("--select Broker Name--", "0"));
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (btnSubmit.Text != "Update")
            {
                obj.BCompanyId = Convert.ToInt32(ddlbCompany.SelectedValue);
                obj.BrokerId = Convert.ToInt32(ddlBname.SelectedValue);
                obj.ClientId = Convert.ToInt32(ddlClient.SelectedValue);
                cls.AddClientBroker(obj);
                CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                cmf.ClearAllControls(Page);
                BindGrid();
            }
            else
            {

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
                cls.DeleteClientBroker(obj);
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                BindGrid();
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

        protected void btnFilter_Click(object sender, EventArgs e)
        {
            try
            {
                int BID = 0;
                int BCID = Convert.ToInt32(ddlBCSearch.SelectedValue);
                if (BCID > 0)
                {
                     BID = Convert.ToInt32(ddlBnameSearch.SelectedValue);
                }
                int CID = Convert.ToInt32(ddlClientSearch.SelectedValue);
                DataSet ds = cls.ClientBrokerSearch(BCID,BID,CID);
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
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlBCSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            int BrokerId = Convert.ToInt32(ddlBCSearch.SelectedValue);
            if (BrokerId > 0)
            {
                BindSearchBrokerName(BrokerId);
            }
            else
            {
                ddlBname.Items.Clear();
                ddlBname.Items.Insert(0, new ListItem("--select Broker Name--", "0"));
            }
           
        }
    }
}