using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;


namespace COMMON
{
    public class SendMail
    {
        private MailMessage mail_obj;
        public string checkvalidemailid(string EMail)
        {
            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
            if (!(EMail != ""))
                return "false";
            Match match = new Regex("(?<user>[^@]+)@(?<host>.+)").Match(EMail);
            return !match.Success || EMail.Length != match.Length ? "false" : "true";
        }


        public int SendMailtoUser(string to, string from, string sub, string body)
        {
            this.mail_obj = new System.Net.Mail.MailMessage();
            this.mail_obj.To.Add(to);
            this.mail_obj.From = new MailAddress(from);
            this.mail_obj.Subject = sub;
            this.mail_obj.Body = body;
            this.mail_obj.IsBodyHtml = true;
            try
            {
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = ConfigurationManager.AppSettings["smtpUser"];
                networkCredential.Password = ConfigurationManager.AppSettings["smtppwd"];
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                smtpClient.Credentials = (ICredentialsByHost)networkCredential;
                smtpClient.Send(this.mail_obj);
                return 1;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                return 0;              
            }
        }
        public void SendMailtoUser(string to, string from, string sub, AlternateView av)
        {
            this.mail_obj = new System.Net.Mail.MailMessage();
            this.mail_obj.To.Add(to);
            this.mail_obj.From = new MailAddress(from);
            this.mail_obj.Subject = sub;
            this.mail_obj.AlternateViews.Add(av);
            this.mail_obj.IsBodyHtml = true;
            try
            {
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = ConfigurationManager.AppSettings["smtpUser"];
                networkCredential.Password = ConfigurationManager.AppSettings["smtppwd"];
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                smtpClient.Credentials = (ICredentialsByHost)networkCredential;
                smtpClient.Send(this.mail_obj);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
        }
        public void SendMailtoUser(string to, string from, string sub, string cc, string body)
        {
            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
            this.mail_obj = new System.Net.Mail.MailMessage(from, to, sub, body);
            this.mail_obj.CC.Add(cc);
            try
            {
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = ConfigurationManager.AppSettings["smtpUser"];
                networkCredential.Password = ConfigurationManager.AppSettings["smtppwd"];
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                smtpClient.Credentials = (ICredentialsByHost)networkCredential;
                smtpClient.Send(this.mail_obj);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
        }

        public void SendMailtoUser(string to, string from, string cc, string bcc, string sub, string body)
        {
            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
            this.mail_obj = new System.Net.Mail.MailMessage(from, to, sub, body);
            this.mail_obj.CC.Add(cc);
            this.mail_obj.Bcc.Add(bcc);
            try
            {
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = ConfigurationManager.AppSettings["smtpUser"];
                networkCredential.Password = ConfigurationManager.AppSettings["smtppwd"];
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                smtpClient.Credentials = (ICredentialsByHost)networkCredential;
                smtpClient.Send(this.mail_obj);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
        }

        private MailAddressCollection Address(string name)
        {
            SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
            MailAddressCollection addressCollection = new MailAddressCollection();
            char[] chArray = new char[1]
            {
        ','
            };
            foreach (string addresses in name.Split(chArray))
                addressCollection.Add(addresses);
            return addressCollection;
        }

        public int SendMailtoUserwithatt(string to, string from, string sub, string body, string file_name)
        {
            this.mail_obj = new System.Net.Mail.MailMessage(from, to, sub, body);
            this.mail_obj.IsBodyHtml = true;
            string[] filearry = file_name.Split(',');
            for (int i = 0; i < filearry.Length; i++)
            {
                this.mail_obj.Attachments.Add(new Attachment(filearry[i]));
            }

            try
            {
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = ConfigurationManager.AppSettings["smtpUser"];
                networkCredential.Password = ConfigurationManager.AppSettings["smtppwd"];
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                smtpClient.Credentials = (ICredentialsByHost)networkCredential;
                smtpClient.Send(this.mail_obj);
                return 1;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                return 0;
            }
        }
        public void SendMailtoUserwithatt(string to, string from, string sub, AlternateView av, string file_name)
        {
            this.mail_obj = new System.Net.Mail.MailMessage();
            this.mail_obj.To.Add(to);
            this.mail_obj.From = new MailAddress(from);
            this.mail_obj.Subject = sub;
            this.mail_obj.AlternateViews.Add(av);
            this.mail_obj.IsBodyHtml = true;
            this.mail_obj.Attachments.Add(new Attachment(file_name));
            try
            {
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                NetworkCredential networkCredential = new NetworkCredential();
                networkCredential.UserName = ConfigurationManager.AppSettings["smtpUser"];
                networkCredential.Password = ConfigurationManager.AppSettings["smtppwd"];
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);
                smtpClient.Credentials = (ICredentialsByHost)networkCredential;
                smtpClient.Send(this.mail_obj);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
            }
        }

        public int SendMailtoUserwithatt(string to, string from, string subject, string body, Stream attachmentStream, string attachmentFileName)
        {
            MailMessage mailMessage = new MailMessage(from, to, subject, body);
            mailMessage.IsBodyHtml = true;

            if (attachmentStream != null && !string.IsNullOrEmpty(attachmentFileName))
            {
                attachmentStream.Position = 0;
                Attachment attachment = new Attachment(attachmentStream, attachmentFileName);
                mailMessage.Attachments.Add(attachment);
            }

            try
            {
                SmtpClient smtpClient = new SmtpClient(ConfigurationManager.AppSettings["smtpAddress"]);
                smtpClient.Port = Convert.ToInt32(ConfigurationManager.AppSettings["smtpPort"]);
                smtpClient.UseDefaultCredentials = false;
                smtpClient.EnableSsl = Convert.ToBoolean(ConfigurationManager.AppSettings["EnableSsl"]);

                NetworkCredential networkCredential = new NetworkCredential
                {
                    UserName = ConfigurationManager.AppSettings["smtpUser"],
                    Password = ConfigurationManager.AppSettings["smtppwd"]
                };

                smtpClient.Credentials = networkCredential;
                smtpClient.Send(mailMessage);
                return 1;
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(ex.Message);
                return 0;
            }
        }

    }
}
