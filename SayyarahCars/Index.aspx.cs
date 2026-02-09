using COMMON;
using DAL;
using ENTITY;
using System;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace SayyarahCars
{
    public partial class Index : System.Web.UI.Page
    {
        public CommonFunction cmf = new CommonFunction();
        clsClients cls = new clsClients();
        entClient obj = new entClient();
        public string uid = "0";
        SellerModel sellerModel = new SellerModel();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnContinue_Click(object sender, EventArgs e)
        {

            if (btnContinue.Text == "Submit")
            {
                string email = txtEmail.Text.Trim();
                if (cls.IsEmailExists(email))
                {
                    CommonFunction.MessageBox(this, "E", "Email already exists. Please use a different email.");
                    return;
                }
                string fullName = txtfullname.Text.Trim();
                string fname = "";
                string lname = "";
                string[] namePart = fullName.Split(' ');
                if (namePart.Length > 0)
                    fname = namePart[0];
                if (namePart.Length > 1)
                    lname = string.Join(" ", namePart.Skip(1));

                obj.fname = fname;
                obj.lname = lname;
                obj.emailid = txtEmail.Text.Trim();
                obj.contact = txtContact.Text.Trim();
                cls.InsertClientData(obj);

                string str = string.Empty;
                str = "Hi " + txtfullname.Text.Trim();
                str += "<br>Your request has been sent to the admin for approval. ";
                str += "You will will get your username and password after the approval of the portal admin.";
                str += "<br>Thanks and Regards";
                str += "<br>Team Sayyarah";

                StringBuilder strr = new StringBuilder();
                strr.Append("Hi Admin");
                strr.Append("<br>I am interested in your portal.");
                strr.Append("Please approval my request asap.");
                strr.Append("<br>Thanks and Regards");
                strr.Append("<br>" + txtfullname.Text.Trim());

                SendMail sm = new SendMail();
                sm.SendMailtoUser(txtEmail.Text.Trim(), "99bizupon@gmail.com", "Your request has been sent to admin", str);

                sm.SendMailtoUser("99bizupon@gmail.com", txtEmail.Text.Trim(), "Account creation request!!", strr.ToString());
                CommonFunction.MessageBox(this, "S", "Your request has been sent successfully. Please check your email for further details!!");
            }
            txtfullname.Text = "";
            txtEmail.Text = "";
            txtContact.Text = "";
        }

        
        protected void btnSeller_Click(object sender, EventArgs e)
        {
            try
            {
                string[] splitName = txtSellerName.Text.Split(' ');
                sellerModel.FirstName = splitName[0];
                sellerModel.LastName = splitName.Length > 1 ? splitName[1] : "";
                sellerModel.Email = txtSellerEmail.Text;
                sellerModel.UserName = txtSellerEmail.Text;
                sellerModel.MobileNo = txtSellerContact.Text;
                int temp = cls.AddSeller(sellerModel);

                if (temp != 0 && temp != -1)
                {
                    Session["SID"] = temp;
                    string OTP = cls.GetnerateOTP();
                    int tempOTP = cls.addOTP(sellerModel.Email, OTP);
                    if (tempOTP == 1)
                    {

                        SendMail sm = new SendMail();
                        string body = $@"
                        <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid rgba(221, 221, 221, 1); border-radius: 5px'>
                            <h1 style='color: rgba(44, 62, 80, 1); font-size: 24px'>Your Verification Code</h1>
                            <p>Use the following code to verify your account:</p>
                            <div style='background-color: rgba(247, 247, 247, 1); padding: 15px; border-radius: 5px; text-align: center; margin: 20px 0'>
                                <h2 style='font-size: 32px; letter-spacing: 5px; margin: 0; color: rgba(51, 51, 51, 1)'>{OTP}</h2>
                            </div>
                            <p>This code will expire in 10 minutes.</p>
                            <p>If you didn't request this code, please ignore this email.</p>
                            <hr style='border-top: 1px solid rgba(221, 221, 221, 1); border-right: none; border-bottom: none; border-left: none; margin: 20px 0'>
                            <p style='font-size: 12px; color: rgba(153, 153, 153, 1)'>
                                This is an automated message, please do not reply to this email.
                            </p>
                        </div>";
                        sm.SendMailtoUser(sellerModel.Email, "99bizupon@gmail.com", "Your Verification Code", body);
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#popup_seller').modal('show'); }, 200);", true);
                        pnlSellerRegisterForm.Visible = false;
                        pnlOTPSeller.Visible = true;
                        lblEmailId.InnerText = sellerModel.Email;
                        hdnEmailId.Value = sellerModel.Email;
                        hdnFullName.Value = sellerModel.FirstName + ' ' + sellerModel.LastName;
                    }
                }
                if (temp == -1)
                {
                    CommonFunction.MessageBox(this, "E", "Email already exists. Please use a different email.");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#popup_seller').modal('show'); }, 200);", true);
                    cmf.ClearAllControls(Page);
                    return;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected void btnVerifySellerOTP_Click(object sender, EventArgs e)
        {
            try
            {
                bool temp = cls.VerifyOTP(hdnEmailId.Value, txtsellereOTP.Text);
                if (temp == true)
                {
                    int result = cls.updateOTP(hdnEmailId.Value);
                    if (result == 1)
                    {
                        string Password = cls.GetRandomPassword(8);
                        string fullName = hdnFullName.Value;
                        string body = $@"
                                <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid rgba(221, 221, 221, 1); border-radius: 5px'>
                                    <h1 style='color: rgba(44, 62, 80, 1); font-size: 24px'>Welcome to Sayyarah Cars</h1>
                                    <p>Dear {fullName},</p>
                                    <p>Thank you for registering with us. Below are your login credentials:</p>

                                    <div style='background-color: rgba(247, 247, 247, 1); padding: 15px; border-radius: 5px; margin: 20px 0'>
                                        <p style='margin: 5px 0; font-size: 16px'><strong>Username:</strong> {hdnEmailId.Value}</p>
                                        <p style='margin: 5px 0; font-size: 16px'><strong>Password:</strong> {Password}</p>
                                    </div>

                                    <p>You can now log in to your account and start using our services.</p>
                                    <p>If you did not sign up for this account, please ignore this email.</p>
                                    <hr style='border-top: 1px solid rgba(221, 221, 221, 1); margin: 20px 0'>

                                    <p style='font-size: 12px; color: rgba(153, 153, 153, 1)'>
                                        Regards,<br>
                                        Team Sayyarah Cars<br>
                                        This is an automated message, please do not reply.
                                    </p>
                                </div>";
                        SendMail sm = new SendMail();
                        int sendmail = sm.SendMailtoUser(hdnEmailId.Value, "99bizupon@gmail.com", "Your Username and password : ", body);
                        if (sendmail == 1)
                        {
                            int temppwd = cls.updatePassword(hdnEmailId.Value, Password);
                            if (temppwd == 1)
                            {
                                Session["successMail"] = "Username and password has been sent to your email address.";
                            }
                        }
                        Response.Redirect("~/Seller/MyProfile");
                    }
                }
                else
                {
                    CommonFunction.MessageBox(this, "E", "OTP is invalid or expired");
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "ShowModal", "setTimeout(function () { $('#popup_seller').modal('show'); }, 200);", true);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
