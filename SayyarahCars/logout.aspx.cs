using System;

namespace SayyarahCars
{
    public partial class logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("/index");
        }
    }
}