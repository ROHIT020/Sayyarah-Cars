using DAL;
using System;
using System.Data;
using System.Web;

namespace SayyarahCars.Shared
{
    public partial class adminheader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AID"] != null)
            {
                clsMasters cls = new clsMasters();
                DataSet ds = cls.getAdminLoginDetails(HttpContext.Current.Session["AID"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    user.InnerText = ds.Tables[0].Rows[0]["name"].ToString();
                    designation.InnerText = ds.Tables[0].Rows[0]["designation"].ToString();
                }
            }
            else
            {
                Response.Redirect("/Index", false);
            }
        }
    }
}