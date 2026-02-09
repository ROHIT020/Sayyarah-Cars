using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace COMMON
{
    public class CommonFunction
    {
        public byte[] lbtVector;
        public string encryptionKey;
        public TextInfo textInfo;
        public CultureInfo cultureInfo;
        private ListItem li;

        public CommonFunction()
        {
            this.lbtVector = new byte[8]
            {
    (byte) 240,
    (byte) 3,
    (byte) 45,
    (byte) 29,
    (byte) 0,
    (byte) 76,
    (byte) 173,
    (byte) 59
            };
            this.encryptionKey = "Biz##99@@Key";

            this.cultureInfo = Thread.CurrentThread.CurrentCulture;
            this.textInfo = this.cultureInfo.TextInfo;
        }
        public void bindddlwithno(DropDownList ddl, int stratingno, int endingno)
        {
            for (int index = stratingno; index <= endingno; ++index)
            {
                this.li = new ListItem(Convert.ToString(index), Convert.ToString(index));
                ddl.Items.Add(this.li);
            }
        }

        public void BindDropDownList(DropDownList ddl, DataSet dst, string dtext, string dvalue)
        {
            DataView defaultView = dst.Tables[0].DefaultView;
            ddl.DataSource = (object)defaultView;
            ddl.DataTextField = dtext.Trim();
            ddl.DataValueField = dvalue.Trim();
            ddl.DataBind();
        }
        public void BindDropDownList(DropDownList ddl, DataTable dst, string dtext, string dvalue)
        {
            DataView defaultView = dst.DefaultView;
            ddl.DataSource = (object)defaultView;
            ddl.DataTextField = dtext.Trim();
            ddl.DataValueField = dvalue.Trim();
            ddl.DataBind();
        }
        public void BindDropDownList(DropDownList ddl, DataSet dst, string dtext, string dvalue, int TableIndex)
        {
            DataView defaultView = dst.Tables[TableIndex].DefaultView;
            ddl.DataSource = (object)defaultView;
            ddl.DataTextField = dtext.Trim();
            ddl.DataValueField = dvalue.Trim();
            ddl.DataBind();
        }
        public void BindCheckBoxList(CheckBoxList ddl, DataSet dst, string dtext, string dvalue)
        {
            DataView defaultView = dst.Tables[0].DefaultView;
            ddl.DataSource = (object)defaultView;
            ddl.DataTextField = dtext;
            ddl.DataValueField = dvalue;
            ddl.DataBind();
        }
        public void BindRadioButtonList(RadioButtonList ddl, DataSet dst, string dtext, string dvalue)
        {
            DataView defaultView = dst.Tables[0].DefaultView;
            ddl.DataSource = (object)defaultView;
            ddl.DataTextField = dtext;
            ddl.DataValueField = dvalue;
            ddl.DataBind();
        }
        public string Encrypt(string encryptString)
        {
            string EncryptionKey = "ABCDEFGHIJKL0123456789MNOPQRSTUVWXYZ";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }
                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }
            return encryptString;
        }

        public string Decrypt(string cipherText)
        {
            string EncryptionKey = "ABCDEFGHIJKL0123456789MNOPQRSTUVWXYZ";
            cipherText = cipherText.Replace(" ", "+");
            byte[] cipherBytes = Convert.FromBase64String(cipherText);
            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76
        });
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);
                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                    {
                        cs.Write(cipherBytes, 0, cipherBytes.Length);
                        cs.Close();
                    }
                    cipherText = Encoding.Unicode.GetString(ms.ToArray());
                }
            }
            return cipherText;
        }
        public static float ConvertToZeroForFloatIfNull(object val)
        {
            if (val == null)
            {
                return 0;
            }

            var value = val.ToString().Trim();

            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            try
            {
                return Convert.ToSingle(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }
        public void ClearAllControls(Control parent)
        {
            foreach (Control ctrl in parent.Controls)
            {
                if (ctrl is TextBox)
                    ((TextBox)ctrl).Text = "";
                else if (ctrl is DropDownList)
                    ((DropDownList)ctrl).SelectedIndex = 0;
                else if (ctrl is CheckBox)
                    ((CheckBox)ctrl).Checked = false;               
                if (ctrl.HasControls())
                    ClearAllControls(ctrl);
            }
        }
        public static void RedirectIfNotLoggedIn(string sessionid, string url)
        {
            var aid = HttpContext.Current.Session[sessionid] as string;
            if (string.IsNullOrWhiteSpace(aid))
            {
                HttpContext.Current.Response.Redirect(url, false);
                HttpContext.Current.ApplicationInstance.CompleteRequest();
            }
        }
        public static void MessageBox(Page page, string type, string message, string url = "")
        {
            if (page == null || string.IsNullOrWhiteSpace(type) || string.IsNullOrWhiteSpace(message))
                return;

            var typeMap = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "S", "success" },
            { "E", "error" },
            { "I", "info" },
            { "W", "warning" }
        };

            var typeIcon = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
        {
            { "S", "<i class=\"fa fa-check-circle\" style=\"color:#004e00; margin-right:5px;\"></i>" },
            { "E", "<i class=\"fa fa-times-circle\" style=\"color:#f5f5f5; margin-right:5px;\"></i>" },
            { "I", "<i class=\"fa fa-info-circle\" style=\"color:#f5f5f5; margin-right:5px;\"></i>" },
            { "W", "<i class=\"fa fa-exclamation-triangle\" style=\"color:#915826; margin-right:5px;\"></i>" }
        };

            if (!typeMap.TryGetValue(type, out string notyType) || !typeIcon.TryGetValue(type, out string iconHtml))
                return;

            string safeMessage = message.Replace("'", "\\'");

            string script = $@"
            new Noty({{
                type: '{notyType}',
                layout: 'topCenter',
                text: '{iconHtml} {safeMessage}',
                timeout: 2000,
                progressBar: true,
                theme: 'metroui'
            }}).show();";

            if (!string.IsNullOrWhiteSpace(url) && url != "close")
            {
                string safeUrl = url.Replace("'", "\\'");
                script += $@"
            setTimeout(function() {{
                window.location.href = '{safeUrl}';
            }}, 4800);";
            }
            else if (url == "close")
            {
                script += @"
            setTimeout(function() {
                parent.closePopup();
            }, 1500);";
            }

            page.ClientScript.RegisterStartupScript(
                page.GetType(),
                "notyAlert",
                script,
                true
            );
        }





        public static decimal ConvertToZeroForDecimalIfNull(object val)
        {

            if (val == null)
            {
                return 0;
            }

            var value = val.ToString().Trim();

            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            try
            {
                return Convert.ToDecimal(value);
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public static double ConvertToZeroForDoubleIfNull(object val)
        {
            if (val == null)
            {
                return 0;
            }

            var value = val.ToString().Trim();

            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            try
            {
                return Convert.ToDouble(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static int ConvertToZeroForIntIfNull(object val)
        {
            if (val == null)
            {
                return 0;
            }

            var value = val.ToString().Trim();

            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            try
            {
                return Convert.ToInt32(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }



        public static long ConvertToZeroForLongIfNull(object val)
        {
            if (val == null)
            {
                return 0;
            }

            var value = val.ToString().Trim();

            if (string.IsNullOrEmpty(value))
            {
                return 0;
            }

            try
            {
                return Convert.ToInt64(value);
            }
            catch (Exception)
            {
                return 0;
            }
        }

        public static void DisplayAlert(Page page, string message, string redirectUrl = "")
        {
            string safeMessage = message.Replace("'", "\\'"); string script = string.Empty;
            if (redirectUrl != "")
            {
                script = $@"<script type='text/javascript'>alert('{safeMessage}');window.location = '{redirectUrl}';</script>";
            }
            else
            {
                script = $"<script type='text/javascript'>alert('{safeMessage}');</script>";
            }
            page.ClientScript.RegisterStartupScript(page.GetType(), "alert", script, false);
        }

        public static string GenerateOrderId()
        {
            var guid = Guid.NewGuid().ToString("N");
            var timestamp = DateTime.UtcNow.ToString("yyyyMMddHHmmssfff");
            return guid + timestamp;
        }

        public static string SaveImg(Page page, FileUpload fileUpload, string path, string urlPart = "")
        {
            if (fileUpload.HasFile)
            {
                string fileExtension = Path.GetExtension(fileUpload.FileName).ToLower();
                if (fileExtension == ".png" || fileExtension == ".jpg" || fileExtension == ".jpeg")
                {
                    try
                    {
                        string serverPath = HttpContext.Current.Server.MapPath(path);
                        if (!Directory.Exists(serverPath))
                        {
                            Directory.CreateDirectory(serverPath);
                        }
                        string randomFileName = Guid.NewGuid().ToString() + fileExtension;
                        string fullPath = Path.Combine(serverPath, randomFileName);
                        fileUpload.SaveAs(fullPath);

                        string baseUrl = $"{HttpContext.Current.Request.Url.Scheme}://{HttpContext.Current.Request.Url.Authority}";
                        string relativePath = $"{path.TrimStart('~').Replace("\\", "/")}/{randomFileName}";
                        string fullUrl = $"{baseUrl}/{relativePath}";
                        if (urlPart.ToLower() == "full")
                        {
                            return fullUrl;
                        }
                        else { return relativePath; }
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert(page, $"Error saving file: {ex.Message}");
                        return "";
                    }
                }
                else
                {
                    DisplayAlert(page, "Invalid file format. Only PNG, JPG, and JPEG are allowed.");
                    return "";
                }
            }
            return "";
        }
        public string GenerateRandomPassword(int length)
        {
            const string validChars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890!@#$%^&*()-_=+";
            StringBuilder password = new StringBuilder();
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] uintBuffer = new byte[sizeof(uint)];

                while (password.Length < length)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    password.Append(validChars[(int)(num % (uint)validChars.Length)]);
                }
            }
            return password.ToString();
        }
       
        public string dateConvert(string c_date)
        {
            if (string.IsNullOrWhiteSpace(c_date))
                return string.Empty;

            if (c_date == "1/1/1900 12:00:00 AM")
                return string.Empty;

            string[] strArray = c_date.Split(new char[1]
           {
       ' '
           })[0].Split(new char[1]
           {
       '/'
           });
            if (strArray.Length < 3)
                return c_date;
            if (strArray[1].Length == 1)
                strArray[1] = "0" + strArray[1];
            if (strArray[0].Length == 1)
                strArray[0] = "0" + strArray[0];
            return strArray[1] + "/" + strArray[0] + "/" + strArray[2];           
        }
        public string dateConvertShow(string c_date)
        {
            if (string.IsNullOrWhiteSpace(c_date))
                return string.Empty;

            if (c_date == "1/1/1900 12:00:00 AM")
                return string.Empty;

            string[] strArray = c_date.Split(new char[1] { ' ' });
            return strArray[0];
        }
    }
}