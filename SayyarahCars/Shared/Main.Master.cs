using System;
using System.Web;

namespace SayyarahCars.Shared
{
    public partial class Main : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session["AID"] == null)
            {
                Response.Redirect("/Index", false);
            }
        }
    }
}