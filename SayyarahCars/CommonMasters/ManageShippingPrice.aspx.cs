using COMMON;
using DAL;
using System;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class ManageShippingPrice : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AID"] != null)
            {
                if (!Page.IsPostBack)
                {
                    getAllMasterData();
                    getAllShipingPriceData();
                }
            }
            else
            {
                Response.Redirect("~/Index.aspx", false);
            }
        }

        public void getAllMasterData()
        {
            try
            {
                ds = clsAdmin.getShipingPriceMasterData();

                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlShipingCompany.Items.Clear();
                    ddlShipingCompany.DataSource = ds.Tables["Table"];
                    ddlShipingCompany.DataTextField = "ShippingName";
                    ddlShipingCompany.DataValueField = "Id";
                    ddlShipingCompany.DataBind();
                    ddlShipingCompany.Items.Insert(0, new ListItem("Select shipping company", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void getAllShipingPriceData()
        {
            try
            {
                ds = clsAdmin.getAllShipinPriceData(ddlShipingCompany.SelectedValue);
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
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            try
            {
                if (e.CommandName == "DeleteRow")
                {
                    string Id = e.CommandArgument.ToString();
                    string UID = Session["AID"].ToString();
                    DataSet ds = clsAdmin.deleteShipingPrice(Convert.ToInt32(Id), Convert.ToInt32(UID));
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "toastr", "toastr.success('Record deleted successfully!!');", true);
                    getAllShipingPriceData();
                }
                else
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "toastr", "toastr.error('Record not deleted successfully!!');", true);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void btnsearch_Click(object sender, EventArgs e)
        {
            getAllShipingPriceData();
        }
    }
}