using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Print_Client_Voucher : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetClientAndCountry();
            }
        }
        public void GetClientAndCountry()
        {
            try
            {
                ds = clsAdmin.GetClientAndCoountry();
                if (ds.Tables["Table"].Rows.Count > 0)
                {
                    ddlCountryName.Items.Clear();
                    ddlCountryName.DataSource = ds.Tables["Table"];
                    ddlCountryName.DataTextField = "CountryName";
                    ddlCountryName.DataValueField = "Id";
                    ddlCountryName.DataBind();
                    ddlCountryName.Items.Insert(0, new ListItem("Select country name", "0"));
                }
                if (ds.Tables["Table1"].Rows.Count > 0)
                {
                    ddlClient.Items.Clear();
                    ddlClient.DataSource = ds.Tables["Table1"];
                    ddlClient.DataTextField = "ClientName";
                    ddlClient.DataValueField = "id";
                    ddlClient.DataBind();
                    ddlClient.Items.Insert(0, new ListItem("Select client name", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}