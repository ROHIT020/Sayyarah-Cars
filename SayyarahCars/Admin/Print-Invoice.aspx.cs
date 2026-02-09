using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SayyarahCars.Admin
{
    public partial class Print_Invoice : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Request.QueryString["Id"] != null)
                {
                    String Id = cmf.Decrypt(Request.QueryString["Id"].ToString());
                    bindinvoice(Id);
                }
            }
        }

        public void bindinvoice(string Id)
        {
            try
            {
                DataSet ds = new DataSet();
                ds = clsAdmin.bindtempinvoice(Id);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    
                    string Ctype = ds.Tables[0].Rows[0]["Symbol"].ToString();
                    lblinvno.Text = "#" + ds.Tables[0].Rows[0]["Id"].ToString().Trim();
                    BulletedList1.Items.Add("100% payment must be received within 5 calendar days.");
                    BulletedList1.Items.Add("Shipping Schedule and arrival date may vary [condition apply.]");
                    lblinvamout.Text = Ctype + " " + ds.Tables[0].Rows[0]["Amount"].ToString().Trim() + ".00";
                    lblcutomername.Text = ds.Tables[0].Rows[0]["SenderName"].ToString().Trim();
                    Lbladdress.Text = ds.Tables[0].Rows[0]["Address"].ToString().Trim();
                    lblinvnodate.Text = ds.Tables[0].Rows[0]["InvoiveDate"].ToString();
                    DateTime pdate = Convert.ToDateTime(ds.Tables[0].Rows[0]["InvoiveDate"]);
                    DateTime d2 = pdate.AddDays(3);
                    lblduedate.Text = d2.ToString("dd/MM/yyyy");
                    DateTime d3 = pdate.AddDays(25);
                    lbldays.Text = d3.ToString("dd/MM/yyyy");

                    lblcarprice.Text = Ctype + " " + ds.Tables[0].Rows[0]["Amount"].ToString().Trim();
                    lbltotalamtbeforetax.Text = lblinvamout.Text + ".00";
                    
                    pname.InnerText = ds.Tables[0].Rows[0]["MakerName"].ToString() + " (Normal)";
                    lblchno.Text = ds.Tables[0].Rows[0]["ChassisDetails"].ToString();
                    
                    lblccode.Text = ds.Tables[0].Rows[0]["UID"].ToString();
                    lblbankname.Text = ds.Tables[0].Rows[0]["BankName"].ToString() + " (" + Ctype + ")";
                    lblaccountname.Text = ds.Tables[0].Rows[0]["AccountName"].ToString();
                    lblaccount.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                    lblswift.Text = ds.Tables[0].Rows[0]["SwiftName"].ToString();
                    lblbranch.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                    lblbaddress.Text = ds.Tables[0].Rows[0]["BankAddress"].ToString();
                    lblOtherCharges.Text = Ctype + " " + ds.Tables[0].Rows[0]["OtherCharges"].ToString().Trim();

                    lblinvamout.Text = Ctype + " " + Convert.ToString(Convert.ToDouble(ds.Tables[0].Rows[0]["Amount"]) + Convert.ToDouble(ds.Tables[0].Rows[0]["OtherCharges"])) + ".00";
                    lbltotalamtbeforetax.Text = lblinvamout.Text;
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifies that the control is rendered */
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder StrExport = new StringBuilder();
                StrExport.Append(@" <html xmlns:x='urn:schemas-microsoft-com:office:excel'></br><head></br><!--[if gte mso 9]><xml></br><x:ExcelWorkbook></br><x:ExcelWorksheets><x:ExcelWorksheet><x:WorksheetOptions><x:Print><x:ValidPrinterInfo/></x:Print></x:WorksheetOptions></x:ExcelWorksheet></x:ExcelWorksheets></x:ExcelWorkbook></xml><![endif]--></head>");
                StrExport.Append(@"<body lang=EN_US style='mso-element:header' id=h1><span style='mso--code:DATE'></span><div class=Section1>");
                StringWriter sw = new StringWriter();
                HtmlTextWriter w = new HtmlTextWriter(sw);
                Grid.RenderControl(w);
                string sss = sw.GetStringBuilder().ToString();
                StrExport.Append(sss);
                StrExport.Append("</body></html>");
                string strFile = DateTime.Now.ToString("yymmddhhmmss") + ".xls";
                string strcontentType = "application/excel";
                UTF8Encoding utf8 = new UTF8Encoding();
                var preamble = utf8.GetPreamble();
                var data = utf8.GetBytes(StrExport.ToString());
                Response.ClearContent();
                Response.ClearHeaders();
                Response.BufferOutput = true;
                Response.ContentType = strcontentType;
                Response.AddHeader("Content-Disposition", "attachment; filename=" + strFile);
                Response.BinaryWrite(System.Text.Encoding.UTF8.GetPreamble());
                Response.Write(StrExport.ToString());
                Response.Flush();
                Response.Close();
                HttpContext.Current.Response.End();
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}