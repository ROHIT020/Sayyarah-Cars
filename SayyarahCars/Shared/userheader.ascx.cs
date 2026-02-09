using DAL;
using System;
using System.Data;
using System.Web;

namespace SayyarahCars.Shared
{
    public partial class userheader : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["CID"] != null)
            {
                clsMasters cls = new clsMasters();
                DataSet ds = cls.getUserLoginDetails(HttpContext.Current.Session["CID"].ToString());
                if (ds.Tables[0].Rows.Count > 0)
                {
                    user.InnerText = ds.Tables[0].Rows[0]["name"].ToString();
                }
            }
            else
            {
                Response.Redirect("/Index", false);
            }
        }
    }
}