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
    public partial class Manage_Dealers : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        public CommonFunction cmf = new CommonFunction();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetAllDealerRegistration();
            }
            if (Session["updateMessage"] != null)
            {
                CommonFunction.MessageBox(this, "S", Session["updateMessage"].ToString());
                Session.Remove("updateMessage");
            }
        }

        public void GetAllDealerRegistration()
        {
            try
            {
                ds = clsAdmin.getAllDealerReg();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    GridView1.DataSource = ds;
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
                    string Id = e.CommandArgument.ToString();
                    int temp = clsAdmin.deleteDealerRegById(Convert.ToInt32(Id), Session["AID"].ToString());
                    if (temp != 0)
                    {
                        CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                        GetAllDealerRegistration();
                    }
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

    }
}