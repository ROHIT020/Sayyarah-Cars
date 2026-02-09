using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.CommonMasters
{
    public partial class ManageShipDetails : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        AddShip addShip = new AddShip();
        public CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getShipingCompany();
                getShipDetailsData();
            }
        }

        public void getShipingCompany()
        {
            DataSet ds = new DataSet();
            try
            {
                ds = clsAdmin.getShipingPortTAndCountryData();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShipingCompany.Items.Clear();
                    ddlShipingCompany.DataSource = ds.Tables["Table"];
                    ddlShipingCompany.DataTextField = "ShippingName";
                    ddlShipingCompany.DataValueField = "Id";
                    ddlShipingCompany.DataBind();
                    ddlShipingCompany.Items.Insert(0, new ListItem("Select Shipping Company", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void getShipDetailsData()
        {
            DataSet ds = new DataSet();
            try
            {

                ds = clsAdmin.ViewaShipDetails(ddlShipingCompany.SelectedValue);
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
                else
                {
                    GridView1.DataSource = ds.Tables["Table"];
                    GridView1.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            getShipDetailsData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                DataSet ds = clsAdmin.DeleteShipDetail(Convert.ToInt32(Id), Convert.ToInt32(UID));
                CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                getShipDetailsData();
            }

        }
        
        protected void btnreload_Click(object sender, EventArgs e)
        {
            getShipDetailsData();
        }
    }
}