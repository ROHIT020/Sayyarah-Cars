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
    public partial class Client_Report : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        CommonFunction cmf = new CommonFunction();
        clsAdmin cls = new clsAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindDropDown();

            }
        }

        public void BindDropDown()
        {
            ds = cls.GetDropDownClientReport();
            cmf.BindDropDownList(ddlClient, ds, "ClientName", "ID", 0);
            ddlClient.Items.Insert(0, new ListItem("Select Client", "0"));
        }

        public void BindAllData()
        {
            try
            {
                ds = cls.GetAllClientReport(ddlClient.SelectedValue);
                if (ds.Tables[0].Rows.Count > 0)
                {

                    GridView1.DataSource = ds.Tables[0];
                    GridView1.DataBind();
                   
                }
            }
            catch(Exception ex)
            {
                string s = ex.Message;
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            BindAllData();
        }

        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            BindAllData();
        }
    }
}