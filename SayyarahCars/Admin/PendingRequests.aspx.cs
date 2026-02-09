using COMMON;
using DAL;
using ENTITY;
using System;
using System.Data;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class PendingRequests : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsClients cls = new clsClients();
        entClient obj = new entClient();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["AID"] != null)
            {
                uid = Session["AID"].ToString();
            }
            if (!IsPostBack)
            {
                bindGrid();
            }
        }
        protected void gvPendingRequests_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = Convert.ToInt32(e.CommandArgument);
            if (e.CommandName == "Approve")
            {
                ApproveClient(id);
                CommonFunction.MessageBox(this, "S", "Account has been approved.");
                bindGrid();
            }
            else if (e.CommandName == "Disapprove")
            {
                DisapproveClient(id);
                CommonFunction.MessageBox(this, "E", "Account has been disapproved.!!");
                bindGrid();
            }
        }
        private int ApproveClient(int id)
        {
            int result = 0;
            DataSet ds = cls.GetClientById(id);
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                string email = ds.Tables[0].Rows[0]["emailid"].ToString();
                string password = cmf.GenerateRandomPassword(8);
                result = cls.ApproveClient(id, password);
                SendMail mail = new SendMail();
                string body = $"Dear Client,<br/><br/>Your account has been approved.<br/>" +
                              $"Username: <b>{email}</b><br/>Password: <b>{password}</b><br/><br/>" +
                              $"<a href='#'>Click here to login</a>.";
                mail.SendMailtoUser(email, "99bizupon@gmail.com", "Client Account Approved", body);
            }
            return result;
        }
        private int DisapproveClient(int id)
        {
            return cls.DisapproveClient(id);

        }
        private void bindGrid(int pageNo = 1)
        {
            DataSet ds = cls.GetPendingClients();
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                int pageSize = Convert.ToInt32(ddlpages.SelectedValue);
                obj.PageNumber = pageNo.ToString();
                obj.PageSize = pageSize.ToString();
                gvPendingRequests.PageSize = int.Parse(ddlpages.SelectedValue);
                gvPendingRequests.DataSource = ds;
                gvPendingRequests.DataBind();
            }
            else
            {
                gvPendingRequests.DataSource = null;
                gvPendingRequests.DataBind();
                lblMessage.Text = "No pending requests found.";
            }
        }

        protected void ddlpages_SelectedIndexChanged(object sender, EventArgs e)
        {
            bindGrid();
        }

        protected void gvPendingRequests_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gvPendingRequests.PageIndex = e.NewPageIndex;
            bindGrid(e.NewPageIndex + 1);
        }
    }
}