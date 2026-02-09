using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Manage_Client : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsClients cls = new clsClients();
        entClient obj = new entClient();
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
                    bindCountryDropdown();
                    bindClientDropdown();
                    BindGrid();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }


        private void BindGrid(int pageNo = 1)
        {
            try
            {
                DataSet ds = cls.SelectClient();
                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    int pageSize = Convert.ToInt32(ddlpages.SelectedValue);
                    obj.PageNumber = pageNo.ToString();
                    obj.PageSize = pageSize.ToString();
                    gvClient.PageSize = int.Parse(ddlpages.SelectedValue);
                    gvClient.DataSource = ds;
                    gvClient.DataBind();
                }
                else
                {
                    gvClient.DataSource = null;
                    gvClient.DataBind();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            BindGrid();
        }

        protected void gvClient_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvClient.PageIndex = e.NewPageIndex;
            BindGrid(e.NewPageIndex + 1);
        }


        protected void bindCountryDropdown()
        {
            DataSet ds = cls.CountryBind();
            cmf.BindDropDownList(ddlcountry, ds, "CountryName", "Id");
            ListItem li = new ListItem("Select Country", "0");
            ddlcountry.Items.Insert(0, li);
        }

        protected void bindClientDropdown()
        {
            DataSet ds = cls.ClientBind();
            cmf.BindDropDownList(ddlclientsearch, ds, "ClientName", "Id");
            ListItem li = new ListItem("Select Client", "0");
            ddlclientsearch.Items.Insert(0, li);
        }

        protected void btnFilter_Click1(object sender, EventArgs e)
        {
            try
            {
                int countryId = Convert.ToInt32(ddlcountry.SelectedValue);
                int clientId = Convert.ToInt32(ddlclientsearch.SelectedValue);
                DataSet ds = cls.SelectClientByFilter(countryId, clientId);

                if (ds != null && ds.Tables[0].Rows.Count > 0)
                {
                    gvClient.DataSource = ds;
                    gvClient.DataBind();
                }
                else
                {
                    gvClient.DataSource = null;
                    gvClient.DataBind();
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