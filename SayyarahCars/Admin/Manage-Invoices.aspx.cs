using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Manage_Invoices : System.Web.UI.Page
    {
       public CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetClientData();
            }
        }

        public void GetClientData()
        {
            try
            {
                ds = clsAdmin.GetMakeInvoiceMasterData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCustomer.DataSource = ds.Tables["Table"];
                    ddlCustomer.DataTextField = "Name";
                    ddlCustomer.DataValueField = "id";
                    ddlCustomer.DataBind();
                    ddlCustomer.Items.Insert(0, new ListItem("Select Customer", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetAllInvoiceData()
        {
            try
            {
                ds = clsAdmin.GetAllInvoiceData(ddlCustomer.SelectedValue, txtDateFrom.Text, txtDateTo.Text);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.PageSize = Convert.ToInt32(ddlShortBy.SelectedValue);
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds;
                    GridView1.DataBind();
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
            GetAllInvoiceData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                int temp = clsAdmin.DeleteInvoiceData(Id, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                    GetAllInvoiceData();
                }
            }
        }
    }
}