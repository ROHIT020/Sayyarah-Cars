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
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.html.simpleparser;

namespace SayyarahCars.Admin
{
    public partial class GenerateInvoice : System.Web.UI.Page
    {
        CommonFunction cmf = new CommonFunction();
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        public string uid = "0";
        string InvNo = string.Empty;
        SendMail sm = new SendMail();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                if (Session["InvoiceNo"] != null)
                {
                    GetBankDetails();
                    GetInvoiceDataById();
                }
                else
                {
                    Response.Redirect("Invoice.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                }
            }
        }

        public void GetBankDetails()
        {
            InvNo = Session["InvoiceNo"].ToString();
            try
            {
                ds = clsAdmin.GetBankDetailsByInvNo(Convert.ToInt32(InvNo));
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblbankname.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                    lblbranch.Text = ds.Tables[0].Rows[0]["BranchName"].ToString();
                    lblswift.Text = ds.Tables[0].Rows[0]["SwiftName"].ToString();
                    lblaccount.Text = ds.Tables[0].Rows[0]["AccountNo"].ToString();
                    lblaccountname.Text = ds.Tables[0].Rows[0]["AccountName"].ToString();
                    lblbaddress.Text = ds.Tables[0].Rows[0]["Address"].ToString();
                    lblcutomername.Text = ds.Tables[0].Rows[0]["FullName"].ToString() + ", " + ds.Tables[0].Rows[0]["StateName"].ToString() + ", " + ds.Tables[0].Rows[0]["CountryName"].ToString();
                    lblcutomername1.Text = ds.Tables[0].Rows[0]["FullName"].ToString();
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void GetInvoiceDataById()
        {
            try
            {
                string curency = string.Empty;
                ds = clsAdmin.GetInvoiceDataByInvNo(InvNo);
                if (ds.Tables[0].Rows.Count > 0)
                {
                    lblCustomerCode.Text = ds.Tables[0].Rows[0]["ShortCountry"].ToString() + "/" + ds.Tables[0].Rows[0]["CustomerCode"].ToString();
                    lblInvoiceDate.Text = ds.Tables[0].Rows[0]["InvoiceDate"].ToString();
                    lblduedate.Text = ds.Tables[0].Rows[0]["InvoiceDueDate"].ToString();
                    pname.InnerHtml = ds.Tables[0].Rows[0]["ProductName"].ToString();
                    lblChasisNo.Text = "Chassis Number -" + ds.Tables[0].Rows[0]["ChasisNo"].ToString();
                    lblInvoiceNo.Text = "#" + ds.Tables[0].Rows[0]["InvoiceNo"].ToString();
                    lblLodingPort.Text = ds.Tables[0].Rows[0]["PortFrom"].ToString();
                    lblArrivalPort.Text = ds.Tables[0].Rows[0]["PortToName"].ToString();
              //      HEmail.Value = ds.Tables[0].Rows[0]["emailid"].ToString();
                    HEmail.Value = "biz@yopmail.com";//ds.Tables[0].Rows[0]["emailid"].ToString();
                    curency = ds.Tables[0].Rows[0]["Symbol"].ToString();
                    DateTime invoiceDate = Convert.ToDateTime(lblInvoiceDate.Text);
                    DateTime invoiceTillDate = invoiceDate.AddDays(45);
                    lblDeliverTill.Text = invoiceTillDate.ToString("dd/MM/yyyy");
                    //Show All Price
                    decimal pushPrice = Convert.ToDecimal(ds.Tables[0].Rows[0]["Fprice"]);
                    decimal freight = Convert.ToDecimal(ds.Tables[0].Rows[0]["FreightCharge"]);
                    decimal recycle = Convert.ToDecimal(ds.Tables[0].Rows[0]["RecycleAmount"]);
                    decimal dismantling = Convert.ToDecimal(ds.Tables[0].Rows[0]["OtherService"]);
                    decimal insurance = Convert.ToDecimal(ds.Tables[0].Rows[0]["Insurance2"]);
                    decimal customs = Convert.ToDecimal(ds.Tables[0].Rows[0]["CustomClePrice"]);
                    decimal transport = Convert.ToDecimal(ds.Tables[0].Rows[0]["Transport"]);
                    decimal discount = Convert.ToDecimal(ds.Tables[0].Rows[0]["Discount"]);
                    if (pushPrice == 0)
                    {
                        TRPushPrice.Visible = false;
                    }
                    if (recycle == 0)
                    {
                        TRrecycleCharges.Visible = false;
                    }
                    if (dismantling == 0)
                    {
                        TRotherServices.Visible = false;
                    }
                    if (insurance == 0)
                    {
                        TRdinsuranceCharges.Visible = false;
                    }
                    if (customs == 0)
                    {
                        TRcustomClearance.Visible = false;
                    }
                    if (transport == 0)
                    {
                        TRtransport.Visible = false;
                    }
                    if (discount == 0)
                    {
                        TRpositivediscount.Visible = false;
                    }
                    BulletedList1.Items.Clear();
                    BulletedList1.Items.Add("100% payment must be received within 5 calendar days.");
                    BulletedList1.Items.Add("Shipping Schedule and arrival date may vary [condition apply.]");
                    lblPushPrice.Text = pushPrice.ToString("N2");
                    lblfreight.Text = freight.ToString("N2");
                    lblrecycleCharge.Text = recycle.ToString("N2");
                    lblOtherServices.Text = dismantling.ToString("N2");
                    lblInsuranceCharges.Text = insurance.ToString("N2");
                    lblcustomeClearance.Text = customs.ToString("N2");
                    lbltransport.Text = transport.ToString("N2");
                    
                    lblPositiveDiscount.Text = discount.ToString("N2");
                    decimal total = pushPrice + freight + recycle + dismantling + insurance + customs + transport - discount;
                    lblinvamout.Text = curency + " " + total.ToString("N2");
                    lbltotalamtbeforetax.Text = curency + " " + total.ToString("N2");
                }
            }
            catch (Exception ex)
            {
                CommonFunction.MessageBox(this, "E", ex.Message);
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
                StrExport.Append(@"<body lang=EN-US style='mso-element:header' id=h1><span style='mso--code:DATE'></span><div class=Section1>");
                StrExport.Append("<div style='font-size:12px; width:1000px'>");
                StringWriter sw = new StringWriter();
                HtmlTextWriter w = new HtmlTextWriter(sw);
                Grid.RenderControl(w);
                string sss = sw.GetStringBuilder().ToString();
                StrExport.Append(sss);
                StrExport.Append("</div></body></html>");
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

        /// <summary>
        /// btnExport_Click generated invoice in pdf but not correct design
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnExport_Click(object sender, EventArgs e)
        {
            string fileName = DateTime.Now.ToString("yyMMddHHmmss") + ".pdf";
            StringWriter stw = new StringWriter();
            HtmlTextWriter hw = new HtmlTextWriter(stw);
            Grid.RenderControl(hw);
            string gridHtml = stw.ToString();
            string imageUrl = "~/Contents/admin/images/logo.png";
            gridHtml = gridHtml.Replace("~/Contents/admin/images/logo.png", imageUrl);
            gridHtml = gridHtml.Replace("<img", "<img style='width:100px; height:50px;'");
            string cssStyle = "<style>body { font-size: 2px; }</style>";
            gridHtml = cssStyle + gridHtml;
            byte[] pdfBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                using (Document doc = new Document(PageSize.A4, 1f, 1f, 1f, 1f))
                {
                    PdfWriter writer = PdfWriter.GetInstance(doc, ms);
                    doc.Open();
                    StringReader sr = new StringReader(gridHtml);
                    iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, sr);
                    doc.Close();
                }
                pdfBytes = ms.ToArray();
            }
            // Send Email
            MemoryStream mAtt = new MemoryStream(pdfBytes);
            mAtt.Position = 0;
            string body = $@"
            <div style='max-width: 600px; margin: 0 auto; padding: 20px; border: 1px solid rgba(221, 221, 221, 1); border-radius: 5px'>
            <img src='{imageUrl}' alt='Sayyarah cars Logo' style='width:100px;height:50px;' />
            <hr style='border-top: 1px solid rgba(221, 221, 221, 1);' />
            <p>Dear {lblcutomername1.Text},</p>
            <p><b>Hope this email finds you well.</b></p>
            <p>Please check the attachment for the Detailed Invoice.<br/>
            For any further questions, visit <a href='https://www.sayyarah.com'>www.sayyarah.com</a> or contact us at 
            <a href='mailto:mail@sayyarah.com'>mail@bizupon.com</a>.</p>
            <p>Thanks,<br/><b>The Sayyarah cars Team</b></p>
            <hr style='border-top: 1px solid rgba(221, 221, 221, 1); margin: 20px 0' />
            <p style='font-size: 12px; color: rgba(153, 153, 153, 1)'>
                This is an automated message, please do not reply to this email.
            </p>
            </div>";
            int result = sm.SendMailtoUserwithatt(HEmail.Value, "99bizupon@gmail.com", "Sayyarah cars Invoice", body, mAtt, fileName);
            if (result == 1)
            {
                CommonFunction.MessageBox(this, "S", "The invoice has been sent to your email address = " + HEmail.Value);
            }
        }
    }
}