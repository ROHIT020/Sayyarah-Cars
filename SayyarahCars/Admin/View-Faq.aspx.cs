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
    public partial class View_Faq : System.Web.UI.Page
    {
        clsAdmin clsAdmin = new clsAdmin();
        DataSet ds = new DataSet();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                getAllFaq();

                if (Session["UpdateMessage"] != null)
                {
                    CommonFunction.MessageBox(this, "S", "Record updated successfully!!");
                    Session.Remove("UpdateMessage");
                }
            }
        }

        public void getAllFaq()
        {
            try
            {
                ds = clsAdmin.getAllFaq(Session["AID"].ToString());

                if (ds.Tables[0].Rows.Count > 0)
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

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "DeleteRow")
            {
                string Id = e.CommandArgument.ToString();
                string UID = Session["AID"].ToString();
                int temp = clsAdmin.deleteFaqById(Convert.ToInt32(Id), Convert.ToInt32(UID));
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record deleted successfully!!");
                    getAllFaq();
                }
            }
        }
    }
}