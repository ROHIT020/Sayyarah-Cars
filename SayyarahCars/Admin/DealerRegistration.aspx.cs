using COMMON;
using DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ENTITY;
using System.IO;

namespace SayyarahCars.Admin
{
    public partial class DealerRegistration : System.Web.UI.Page
    {
        DataSet ds = new DataSet();
        clsAdmin clsAdmin = new clsAdmin();
        DealerRegistrationModel dealerRegistration = new DealerRegistrationModel();
        CommonFunction commonFunction = new CommonFunction();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetCountry();

                if (Request.QueryString["Id"] != null)
                {
                    getDealerDataById();
                }
            }
        }

        public void GetCountry()
        {
            try
            {
                ds = clsAdmin.getCountry();

                if (ds.Tables[0].Rows.Count > 0)
                {
                    ddlCountryName.Items.Clear();
                    ddlCountryName.DataSource = ds;
                    ddlCountryName.DataTextField = "CountryName";
                    ddlCountryName.DataValueField = "Id";
                    ddlCountryName.DataBind();
                    ddlCountryName.Items.Insert(0, new ListItem("Select Country", "0"));
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                dealerRegistration.BusinessName = txtBusinessName.Text.Trim();
                dealerRegistration.TradeName = txtTradeName.Text.Trim();
                dealerRegistration.BusinessType = txtBusinessType.Text.Trim();
                dealerRegistration.EstablishmentDate = txtDateOfEstablish.Text.Trim();
                dealerRegistration.IndustryType = txtIndustryType.Text.Trim();
                dealerRegistration.ProductsServices = txtProductServices.Text.Trim();
                dealerRegistration.StreetAddress = txtStreetAdress.Text.Trim();
                dealerRegistration.City = txtCity.Text.Trim();
                dealerRegistration.StateProvince = txtStateProvince.Text.Trim();
                dealerRegistration.ZIP = txtZip.Text.Trim();
                dealerRegistration.Country = ddlCountryName.SelectedValue;
                dealerRegistration.PrimaryContact = txtPrimaryContact.Text.Trim();
                dealerRegistration.JobTitle = txtJobTitle.Text.Trim();
                dealerRegistration.Phone = txtPhoneNumber.Text.Trim();
                dealerRegistration.FaxNumber = txtFaxNumber.Text.Trim();
                dealerRegistration.Email = txtEmail.Text.Trim();
                dealerRegistration.WebsiteURL = txtWebsiteURL.Text.Trim();
                dealerRegistration.TaxIdentification = txtTaxIdentification.Text.Trim();
                dealerRegistration.LicenseNumber = txtBusinessLicense.Text.Trim();
                dealerRegistration.CertificateNumber = txtResellerCertificate.Text.Trim();
                dealerRegistration.BankName = txtBankName.Text.Trim();
                dealerRegistration.AccountNumber = txtBankAccount.Text.Trim();
                dealerRegistration.AccountHolder = txtAccountHolder.Text.Trim();
                dealerRegistration.BranchIFSCSWIFTCode = txtBranchIFSC.Text.Trim();
                dealerRegistration.NumberofEmployees = txtNumberofEmp.Text.Trim();
                dealerRegistration.AnnualRevenue = txtAnnualRevenue.Text.Trim();
                dealerRegistration.GeographicalArea = txtGeographicalArea.Text.Trim();
                dealerRegistration.DealershipSought = txtTypeofDealership.Text.Trim();
                //----------------------Start uploading Business license proof-----------------------------
                if (fileBusinessLicense.HasFiles)
                {
                    string messageBusinessLicense = "", filepathBusinessLicense = "";
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream" };
                    int result = FileUploadUtility.ValidateFile(fileBusinessLicense, "Dealer Doc", allowedMimeTypes, 200, out messageBusinessLicense);
                    if (result == 0)
                    {
                        filepathBusinessLicense = FileUploadUtility.UploadFile(fileBusinessLicense, "File", "DealerRegistration", out messageBusinessLicense);
                        if (string.IsNullOrEmpty(filepathBusinessLicense))
                        {
                            CommonFunction.MessageBox(this, "E", filepathBusinessLicense);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", filepathBusinessLicense);
                        return;
                    }
                    dealerRegistration.BusinessLicense = filepathBusinessLicense;
                }
                else
                {
                    dealerRegistration.BusinessLicense = fileBusinessLicense.FileName;
                }
                //----------------------End uploading Business license proof-----------------------------

                //-----------Start Uplaod Vat doc-----------------------------------------
                if (fileTaxVATCertificate.HasFiles)
                {
                    string messageVAT = "", filepathTaxVATCertificate = "";
                    string[] allowedMimeTypesVat = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream" };
                    int resultVat = FileUploadUtility.ValidateFile(fileTaxVATCertificate, "Dealer Doc", allowedMimeTypesVat, 200, out messageVAT);
                    if (resultVat == 0)
                    {
                        filepathTaxVATCertificate = FileUploadUtility.UploadFile(fileTaxVATCertificate, "File", "DealerRegistration", out messageVAT);
                        if (string.IsNullOrEmpty(filepathTaxVATCertificate))
                        {
                            CommonFunction.MessageBox(this, "E", filepathTaxVATCertificate);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", filepathTaxVATCertificate);
                        return;
                    }
                    dealerRegistration.VATCertificate = filepathTaxVATCertificate;
                }
                else
                {
                    dealerRegistration.VATCertificate = fileTaxVATCertificate.FileName;
                }
                //-----------END Uplaod Vat doc-----------------------------------------


                //----------------------Start uploading Proof Owner-----------------------------
                if (fileIdProofofOwner.HasFiles)
                {
                    string messageProof = "", filepathProofofOwner = "";
                    string[] allowedMimeTypesOwner = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream" };
                    int resultProof = FileUploadUtility.ValidateFile(fileIdProofofOwner, "Dealer Doc", allowedMimeTypesOwner, 200, out messageProof);
                    if (resultProof == 0)
                    {
                        filepathProofofOwner = FileUploadUtility.UploadFile(fileIdProofofOwner, "File", "DealerRegistration", out messageProof);
                        if (string.IsNullOrEmpty(filepathProofofOwner))
                        {
                            CommonFunction.MessageBox(this, "E", filepathProofofOwner);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", filepathProofofOwner);
                        return;
                    }
                    dealerRegistration.IDProofofOwner = filepathProofofOwner;
                }
                else
                {
                    dealerRegistration.IDProofofOwner = fileIdProofofOwner.FileName;
                }
                //----------------------End uploading Proof Owner-----------------------------


                //----------------------Start uploading Signed DealerProof-----------------------------
                if (fileSignedDealer.HasFiles)
                {
                    string messageSigDealer = "", filepathSignedDealer = "";
                    string[] allowedMimeTypesSigned = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream" };
                    int resultSigned = FileUploadUtility.ValidateFile(fileSignedDealer, "Dealer Doc", allowedMimeTypesSigned, 200, out messageSigDealer);
                    if (resultSigned == 0)
                    {
                        filepathSignedDealer = FileUploadUtility.UploadFile(fileSignedDealer, "File", "DealerRegistration", out messageSigDealer);
                        if (string.IsNullOrEmpty(filepathSignedDealer))
                        {
                            CommonFunction.MessageBox(this, "E", filepathSignedDealer);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", filepathSignedDealer);
                        return;
                    }
                    dealerRegistration.SignedDealerAgreement = filepathSignedDealer;
                }
                else
                {
                    dealerRegistration.SignedDealerAgreement = fileSignedDealer.FileName;
                }
                //----------------------End uploading Signed DealerProof-----------------------------

                int temp = clsAdmin.addDealer(dealerRegistration, Session["AID"].ToString());
                if (temp != 0)
                {
                    CommonFunction.MessageBox(this, "S", "Record saved successfully!!");
                    commonFunction.ClearAllControls(Page);
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }

        public void getDealerDataById()
        {
            string Id = Request.QueryString["Id"].ToString();
            
            ds = clsAdmin.getAllDealerRegistrationById(commonFunction.Decrypt(Id));
            if (ds.Tables[0].Rows.Count > 0)
            {
                btnSubmit.Visible = false;
                btnUpdate.Visible = true;

                hdnDealerRegId.Value = ds.Tables[0].Rows[0]["Id"].ToString();
                txtBusinessName.Text = ds.Tables[0].Rows[0]["BusinessName"].ToString();
                txtTradeName.Text = ds.Tables[0].Rows[0]["TradeName"].ToString();
                txtBusinessType.Text = ds.Tables[0].Rows[0]["BusinessType"].ToString();
                txtDateOfEstablish.Text = ds.Tables[0].Rows[0]["EstablishmentDate"].ToString();
                txtIndustryType.Text = ds.Tables[0].Rows[0]["IndustryType"].ToString();
                txtProductServices.Text = ds.Tables[0].Rows[0]["ProductsServices"].ToString();
                txtStreetAdress.Text = ds.Tables[0].Rows[0]["StreetAddress"].ToString();
                txtCity.Text = ds.Tables[0].Rows[0]["City"].ToString();
                txtStateProvince.Text = ds.Tables[0].Rows[0]["StateProvince"].ToString();
                txtZip.Text = ds.Tables[0].Rows[0]["ZIP"].ToString();
                ddlCountryName.SelectedValue = ds.Tables[0].Rows[0]["Country"].ToString();
                txtTaxIdentification.Text = ds.Tables[0].Rows[0]["TaxIdentification"].ToString();
                txtBusinessLicense.Text = ds.Tables[0].Rows[0]["LicenseNumber"].ToString();
                txtResellerCertificate.Text = ds.Tables[0].Rows[0]["CertificateNumber"].ToString();
                txtBankName.Text = ds.Tables[0].Rows[0]["BankName"].ToString();
                txtBankAccount.Text = ds.Tables[0].Rows[0]["AccountNumber"].ToString();
                txtAccountHolder.Text = ds.Tables[0].Rows[0]["AccountHolder"].ToString();
                txtBranchIFSC.Text = ds.Tables[0].Rows[0]["BranchIFSCSWIFTCode"].ToString();
                txtNumberofEmp.Text = ds.Tables[0].Rows[0]["NumberofEmployees"].ToString();
                txtAnnualRevenue.Text = ds.Tables[0].Rows[0]["AnnualRevenue"].ToString();
                txtGeographicalArea.Text = ds.Tables[0].Rows[0]["GeographicalArea"].ToString();
                txtTypeofDealership.Text = ds.Tables[0].Rows[0]["DealershipSought"].ToString();
                txtPrimaryContact.Text = ds.Tables[0].Rows[0]["PrimaryContact"].ToString();
                txtJobTitle.Text = ds.Tables[0].Rows[0]["JobTitle"].ToString();
                txtPhoneNumber.Text = ds.Tables[0].Rows[0]["Phone"].ToString();
                txtFaxNumber.Text = ds.Tables[0].Rows[0]["FaxNumber"].ToString();
                txtEmail.Text = ds.Tables[0].Rows[0]["Email"].ToString();
                txtWebsiteURL.Text = ds.Tables[0].Rows[0]["WebsiteURL"].ToString();

                string businessLicense = ds.Tables[0].Rows[0]["BusinessLicense"].ToString();
                hdnBusinessLicense.Value = ds.Tables[0].Rows[0]["BusinessLicense"].ToString();
                if (!string.IsNullOrEmpty(businessLicense))
                {
                    string extension = Path.GetExtension(businessLicense).ToLower();
                    if (extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".gif")
                    {
                        imgBusinessLicense.ImageUrl = businessLicense;
                        imgBusinessLicense.Visible = true;
                    }
                    else
                    {
                        lnkBusinessLicense.NavigateUrl = businessLicense;
                        lnkBusinessLicense.Text = "Business Document";
                        lnkBusinessLicense.Visible = true;
                        lnkBusinessLicense.Style["color"] = "blue";
                        lnkBusinessLicense.Style["text-decoration"] = "underline";
                        lnkBusinessLicense.Style["font-weight"] = "bold";
                    }
                }

                string vatCertificate = ds.Tables[0].Rows[0]["VATCertificate"].ToString();
                hdnTaxVATCertificate.Value = ds.Tables[0].Rows[0]["VATCertificate"].ToString();
                if (!string.IsNullOrEmpty(vatCertificate))
                {
                    string extn = Path.GetExtension(vatCertificate).ToLower();
                    if (extn == ".jpg" || extn == ".jpeg" || extn == ".png" || extn == ".gif")
                    {
                        imgTaxVATCertificate.ImageUrl = vatCertificate;
                        imgTaxVATCertificate.Visible = true;
                    }
                    else
                    {
                        lnkVatCertificate.NavigateUrl = vatCertificate;
                        lnkVatCertificate.Target = "_blank";
                        lnkVatCertificate.Text = "VAT Certificate";
                        lnkVatCertificate.Visible = true;
                        lnkVatCertificate.Attributes["style"] = "color:blue;text-decoration:underline;font-weight:bold;";
                    }
                }

                string idProofOwner = ds.Tables[0].Rows[0]["IDProofofOwner"].ToString();
                hdnIdProofofOwner.Value = ds.Tables[0].Rows[0]["IDProofofOwner"].ToString();
                if (!string.IsNullOrEmpty(idProofOwner))
                {
                    string exten = Path.GetExtension(idProofOwner).ToLower();
                    if (exten == ".jpg" || exten == ".jpeg" || exten == ".png" || exten == ".gif")
                    {
                        imgIdProofofOwner.ImageUrl = idProofOwner;
                        imgIdProofofOwner.Visible = true;
                    }
                    else
                    {
                        lnkProofofOwner.NavigateUrl = idProofOwner;
                        lnkProofofOwner.Text = "Id proof of Owner";
                        lnkProofofOwner.Visible = true;
                        lnkProofofOwner.Style["color"] = "blue";
                        lnkProofofOwner.Style["text-decoration"] = "underline";
                        lnkProofofOwner.Style["font-weight"] = "bold";
                    }
                }

                string signedDealerAgreement = ds.Tables[0].Rows[0]["SignedDealerAgreement"].ToString();
                hdnSignedDealer.Value = ds.Tables[0].Rows[0]["SignedDealerAgreement"].ToString();
                if (!string.IsNullOrEmpty(signedDealerAgreement))
                {
                    string extens = Path.GetExtension(signedDealerAgreement).ToLower();
                    if (extens == ".jpg" || extens == ".jpeg" || extens == ".png" || extens == ".gif")
                    {

                        imgSignedDealer.ImageUrl = signedDealerAgreement;
                        imgSignedDealer.Visible = true;
                    }
                    else
                    {
                        lnkSignedDealer.NavigateUrl = signedDealerAgreement;
                        lnkSignedDealer.Text = "Signed Dealer Agreement";
                        lnkSignedDealer.Visible = true;
                        lnkSignedDealer.Style["color"] = "blue";
                        lnkSignedDealer.Style["text-decoration"] = "underline";
                        lnkSignedDealer.Style["font-weight"] = "bold";
                    }
                }
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                dealerRegistration.Id = Convert.ToInt32(hdnDealerRegId.Value);
                dealerRegistration.BusinessName = txtBusinessName.Text.Trim();
                dealerRegistration.TradeName = txtTradeName.Text.Trim();
                dealerRegistration.BusinessType = txtBusinessType.Text.Trim();
                dealerRegistration.EstablishmentDate = txtDateOfEstablish.Text.Trim();
                dealerRegistration.IndustryType = txtIndustryType.Text.Trim();
                dealerRegistration.ProductsServices = txtProductServices.Text.Trim();
                dealerRegistration.StreetAddress = txtStreetAdress.Text.Trim();
                dealerRegistration.City = txtCity.Text.Trim();
                dealerRegistration.StateProvince = txtStateProvince.Text.Trim();
                dealerRegistration.ZIP = txtZip.Text.Trim();
                dealerRegistration.Country = ddlCountryName.SelectedValue;
                dealerRegistration.PrimaryContact = txtPrimaryContact.Text.Trim();
                dealerRegistration.JobTitle = txtJobTitle.Text.Trim();
                dealerRegistration.Phone = txtPhoneNumber.Text.Trim();
                dealerRegistration.FaxNumber = txtFaxNumber.Text.Trim();
                dealerRegistration.Email = txtEmail.Text.Trim();
                dealerRegistration.WebsiteURL = txtWebsiteURL.Text.Trim();
                dealerRegistration.TaxIdentification = txtTaxIdentification.Text.Trim();
                dealerRegistration.LicenseNumber = txtBusinessLicense.Text.Trim();
                dealerRegistration.CertificateNumber = txtResellerCertificate.Text.Trim();
                dealerRegistration.BankName = txtBankName.Text.Trim();
                dealerRegistration.AccountNumber = txtBankAccount.Text.Trim();
                dealerRegistration.AccountHolder = txtAccountHolder.Text.Trim();
                dealerRegistration.BranchIFSCSWIFTCode = txtBranchIFSC.Text.Trim();
                dealerRegistration.NumberofEmployees = txtNumberofEmp.Text.Trim();
                dealerRegistration.AnnualRevenue = txtAnnualRevenue.Text.Trim();
                dealerRegistration.GeographicalArea = txtGeographicalArea.Text.Trim();
                dealerRegistration.DealershipSought = txtTypeofDealership.Text.Trim();
                //----------------------Start uploading Business license proof-----------------------------
                string messageBusinessLicense = "", filepathBusinessLicense = "";
                if (hdnBusinessLicense.Value != "")
                {
                    filepathBusinessLicense = hdnBusinessLicense.Value;
                }
                if (fileBusinessLicense.HasFiles)
                {
                    string[] allowedMimeTypes = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream", "application/x-zip-compressed" };
                    int result = FileUploadUtility.ValidateFile(fileBusinessLicense, "Dealer Doc", allowedMimeTypes, 200, out messageBusinessLicense);
                    if (result == 0)
                    {
                        filepathBusinessLicense = FileUploadUtility.UploadFile(fileBusinessLicense, "File", "DealerRegistration", out messageBusinessLicense);
                        if (string.IsNullOrEmpty(filepathBusinessLicense))
                        {
                            CommonFunction.MessageBox(this, "E", messageBusinessLicense);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", messageBusinessLicense);
                        return;
                    }
                    dealerRegistration.BusinessLicense = filepathBusinessLicense;
                }
                else
                {
                    dealerRegistration.BusinessLicense = filepathBusinessLicense;
                }
                //----------------------End uploading Business license proof-----------------------------

                //-----------Start Uplaod Vat doc-----------------------------------------
                string messageVAT = "", filepathTaxVATCertificate = "";
                if (hdnTaxVATCertificate.Value != "")
                {
                    filepathTaxVATCertificate = hdnTaxVATCertificate.Value;
                }
                if (fileTaxVATCertificate.HasFiles)
                {

                    string[] allowedMimeTypesVat = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream", "application/x-zip-compressed" };
                    int resultVat = FileUploadUtility.ValidateFile(fileTaxVATCertificate, "Dealer Doc", allowedMimeTypesVat, 200, out messageVAT);
                    if (resultVat == 0)
                    {
                        filepathTaxVATCertificate = FileUploadUtility.UploadFile(fileTaxVATCertificate, "File", "DealerRegistration", out messageVAT);
                        if (string.IsNullOrEmpty(filepathTaxVATCertificate))
                        {
                            CommonFunction.MessageBox(this, "E", messageVAT);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", messageVAT);
                        return;
                    }
                    dealerRegistration.VATCertificate = filepathTaxVATCertificate;
                }
                else
                {
                    dealerRegistration.VATCertificate = filepathTaxVATCertificate;
                }
                //-----------END Uplaod Vat doc-----------------------------------------


                //----------------------Start uploading Proof Owner-----------------------------
                string messageProof = "", filepathProofofOwner = "";
                if (hdnIdProofofOwner.Value != "")
                {
                    filepathProofofOwner = hdnIdProofofOwner.Value;
                }
                if (fileIdProofofOwner.HasFiles)
                {
                    string[] allowedMimeTypesOwner = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream", "application/x-zip-compressed" };
                    int resultProof = FileUploadUtility.ValidateFile(fileIdProofofOwner, "Dealer Doc", allowedMimeTypesOwner, 200, out messageProof);
                    if (resultProof == 0)
                    {
                        filepathProofofOwner = FileUploadUtility.UploadFile(fileIdProofofOwner, "File", "DealerRegistration", out messageProof);
                        if (string.IsNullOrEmpty(filepathProofofOwner))
                        {
                            CommonFunction.MessageBox(this, "E", messageProof);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", messageProof);
                        return;
                    }
                    dealerRegistration.IDProofofOwner = filepathProofofOwner;
                }
                else
                {
                    dealerRegistration.IDProofofOwner = filepathProofofOwner;
                }
                //----------------------End uploading Proof Owner-----------------------------


                //----------------------Start uploading Signed DealerProof-----------------------------
                string messageSigDealer = "", filepathSignedDealer = "";
                if (hdnSignedDealer.Value != "")
                {
                    filepathSignedDealer = hdnSignedDealer.Value;
                }
                if (fileSignedDealer.HasFiles)
                {

                    string[] allowedMimeTypesSigned = { "image/JPG", "image/JPEG", "image/PNG", "image/x-png", "image/pjpeg", "application/pdf", "application/msword", "application/vnd.openxmlformats-officedocument.wordprocessingml.document", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "application/vnd.ms-excel", "application/octet-stream", "application/x-zip-compressed" };
                    int resultSigned = FileUploadUtility.ValidateFile(fileSignedDealer, "Dealer Doc", allowedMimeTypesSigned, 200, out messageSigDealer);
                    if (resultSigned == 0)
                    {
                        filepathSignedDealer = FileUploadUtility.UploadFile(fileSignedDealer, "File", "DealerRegistration", out messageSigDealer);
                        if (string.IsNullOrEmpty(filepathSignedDealer))
                        {
                            CommonFunction.MessageBox(this, "E", messageSigDealer);
                            return;
                        }
                    }
                    else
                    {
                        CommonFunction.MessageBox(this, "E", messageSigDealer);
                        return;
                    }
                    dealerRegistration.SignedDealerAgreement = filepathSignedDealer;
                }
                else
                {
                    dealerRegistration.SignedDealerAgreement = filepathSignedDealer;
                }
                //----------------------End uploading Signed DealerProof-----------------------------
                int temp = clsAdmin.updateDealer(dealerRegistration, Session["AID"].ToString());
                if (temp != 0)
                {
                    Session["updateMessage"] = "Record updated successfully!!";
                    Response.Redirect("Manage-Dealers.aspx");
                }
            }
            catch (Exception ex)
            {
                CommonFunction.DisplayAlert(this, ex.Message);
                ExceptionLogging.SendErrorToText(ex);
            }
        }
    }
}