using COMMON;
using DAL;
using System;
using System.Web.UI;

namespace SayyarahCars.Users
{
    public partial class ChangePassword : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        public string uid = "0";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["CID"] != null)
            {
                uid = Session["CID"].ToString();
            }
            if (!Page.IsPostBack)
            {

            }
        }

        protected void btnchangePassword_Click(object sender, EventArgs e)
        {
            if ((txtnewpassword.Text != "" || txtnewpassword.Text != null) && (txtconfrimpwd.Text != "" || txtconfrimpwd.Text != null))
            {
                if (txtnewpassword.Text.Length < 8)
                {
                    CommonFunction.MessageBox(this, "E", "Password should be of more than 8 characters!!");
                    return;
                }
            }
            if (txtCaptcha.Text == null || txtCaptcha.Text == "")
            {
                CommonFunction.MessageBox(this, "E", "Enter Security Key Required.!!");
                return;
            }
            if (txtCaptcha.Text.Trim() != Session["CaptchaText"].ToString())
            {
                CommonFunction.MessageBox(this, "E", "Security Key did not match. Please enter correct Security Key!!");
                return;
            }
            clsMasters cls = new clsMasters();
            int rtval = cls.ChangeUserPassword(uid, txtcurrentpwd.Text.Trim(), txtnewpassword.Text.Trim());
            if (rtval > 0)
            {
                txtcurrentpwd.Text = "";
                txtnewpassword.Text = "";
                txtcurrentpwd.Text = "";
                txtCaptcha.Text = "";
                CommonFunction.MessageBox(this, "S", "Your password has been changed successfully!!");
            }
            else
            {
                CommonFunction.MessageBox(this, "E", "Your current password is not matching. Enter correct password!!");
            }

        }
    }
}