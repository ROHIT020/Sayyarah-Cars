<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="DealerRegistration.aspx.cs" Inherits="SayyarahCars.Admin.DealerRegistration" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Business Information</h5>

                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Business Name </label>
                                <asp:TextBox ID="txtBusinessName" runat="server" autocomplete="off" class="form-control" placeholder="Enter Business Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="ProductType">Trade Name </label>
                                <asp:TextBox ID="txtTradeName" runat="server" autocomplete="off" class="form-control" placeholder="Enter Trade Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Business Type </label>
                                <asp:TextBox ID="txtBusinessType" runat="server" autocomplete="off" class="form-control" placeholder="Enter Business Type"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Date of Establishment</label>
                                <uc:DateSelector ID="txtDateOfEstablish" runat="server" CssClass="form-control" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Industry Type</label>
                                <asp:TextBox ID="txtIndustryType" runat="server" autocomplete="off" class="form-control" placeholder="Enter Industry Type"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Products/Services </label>
                                <asp:TextBox ID="txtProductServices" runat="server" autocomplete="off" class="form-control" placeholder="Enter Products/Services"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Business Address</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Street Address</label>
                                <asp:TextBox ID="txtStreetAdress" runat="server" autocomplete="off" class="form-control" placeholder="Enter Street Address"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">City</label>
                                <asp:TextBox ID="txtCity" runat="server" autocomplete="off" class="form-control" placeholder="Enter City"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">State/Province</label>
                                <asp:TextBox ID="txtStateProvince" runat="server" autocomplete="off" class="form-control" placeholder="Enter State Province"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">ZIP/Postal Code</label>
                                <asp:TextBox ID="txtZip" runat="server" autocomplete="off" class="form-control" placeholder="Enter ZIP Postal Code"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Country</label>
                                <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Tax and Legal Details</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Tax Identification Number (TIN) / VAT Number</label>
                                <asp:TextBox ID="txtTaxIdentification" runat="server" autocomplete="off" class="form-control" placeholder="Tax Identification Number (TIN)"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Business License Number</label>
                                <asp:TextBox ID="txtBusinessLicense" runat="server" autocomplete="off" class="form-control" placeholder="Enter Business License Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Reseller Certificate Number (if applicable)</label>
                                <asp:TextBox ID="txtResellerCertificate" runat="server" autocomplete="off" class="form-control" placeholder="Enter Reseller Certificate Number"></asp:TextBox>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Banking & Financial Details (if required for billing or payments)</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Bank Name</label>
                                <asp:TextBox ID="txtBankName" runat="server" autocomplete="off" class="form-control" placeholder="Enter Bank Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Bank Account Number</label>
                                <asp:TextBox ID="txtBankAccount" runat="server" autocomplete="off" class="form-control" placeholder="Enter Bank Account Number"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Account Holder Name</label>
                                <asp:TextBox ID="txtAccountHolder" runat="server" autocomplete="off" class="form-control" placeholder="Enter Account Holder Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Bank Branch / IFSC / SWIFT Code</label>
                                <asp:TextBox ID="txtBranchIFSC" runat="server" autocomplete="off" class="form-control" placeholder="Enter Bank Branch / IFSC / SWIFT Code"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Operational Details</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Number of Employees</label>
                                <asp:TextBox ID="txtNumberofEmp" runat="server" autocomplete="off" class="form-control" placeholder="Enter Number of Employees"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Annual Revenue (optional)</label>
                                <asp:TextBox ID="txtAnnualRevenue" runat="server" autocomplete="off" TextMode="Number" step="any" class="form-control" placeholder="Enter Annual Revenue"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Geographical Area of Operation</label>
                                <asp:TextBox ID="txtGeographicalArea" runat="server" autocomplete="off" class="form-control" placeholder="Enter Geographical Area of Operation"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Type of Dealership Sought</label>
                                <asp:TextBox ID="txtTypeofDealership" runat="server" autocomplete="off" class="form-control" placeholder="Enter Type of Dealership Sought"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Contact Information</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Primary Contact Person Name</label>
                                <asp:TextBox ID="txtPrimaryContact" runat="server" autocomplete="off" class="form-control" placeholder="Enter Primary Contact Person Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Job Title</label>
                                <asp:TextBox ID="txtJobTitle" runat="server" autocomplete="off" class="form-control" placeholder="Enter Job Title"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Phone Number (Office / Mobile)</label>
                                <asp:TextBox ID="txtPhoneNumber" runat="server" autocomplete="off" class="form-control" placeholder="Enter Phone Number (Office / Mobile)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Fax Number (if applicable)</label>
                                <asp:TextBox ID="txtFaxNumber" runat="server" autocomplete="off" class="form-control" placeholder="Enter Fax Number (if applicable)"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Email Address</label>
                                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" class="form-control" placeholder="Enter Email Address"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Website URL</label>
                                <asp:TextBox ID="txtWebsiteURL" runat="server" autocomplete="off" class="form-control" placeholder="Enter Website URL"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Attachments / Documents Upload</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Business License / Registration Certificate</label>
                                <asp:FileUpload ID="fileBusinessLicense" runat="server" class="form-control form-control-lg" />
                                <asp:Image ID="imgBusinessLicense" runat="server" Width="90px" Height="60px" Visible="false" />
                                <asp:HiddenField ID="hdnBusinessLicense" runat="server" />
                                <asp:HyperLink ID="lnkBusinessLicense" runat="server" Target="_blank" Visible="false">
                                   <img src="pdf-icon.png" alt="PDF" />
                                </asp:HyperLink>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Tax/VAT Certificate</label>
                                <asp:FileUpload ID="fileTaxVATCertificate" runat="server" class="form-control form-control-lg" />
                                <asp:Image ID="imgTaxVATCertificate" runat="server" Width="90px" Height="60px" Visible="false" />
                                <asp:HiddenField ID="hdnTaxVATCertificate" runat="server" />
                                <asp:HyperLink ID="lnkVatCertificate" runat="server" Target="_blank" Visible="false">
                                   <img src="pdf-icon.png" alt="PDF" />
                                </asp:HyperLink>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">ID Proof of Owner/Director</label>
                                <asp:FileUpload ID="fileIdProofofOwner" runat="server" class="form-control form-control-lg" />
                                <asp:Image ID="imgIdProofofOwner" runat="server" Width="90px" Height="60px" Visible="false" />
                                <asp:HiddenField ID="hdnIdProofofOwner" runat="server" />
                                <asp:HyperLink ID="lnkProofofOwner" runat="server" Target="_blank" Visible="false">
                                   <img src="pdf-icon.png" alt="PDF" />
                                </asp:HyperLink>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Signed Dealer Agreement (if pre-required)</label>
                                <asp:FileUpload ID="fileSignedDealer" runat="server" class="form-control form-control-lg" />
                                <asp:Image ID="imgSignedDealer" runat="server" Width="90px" Height="60px" Visible="false" />
                                <asp:HiddenField ID="hdnSignedDealer" runat="server" />
                                <asp:HyperLink ID="lnkSignedDealer" runat="server" Target="_blank" Visible="false">
                                   <img src="pdf-icon.png" alt="PDF" />
                                </asp:HyperLink>
                            </div>
                        </div>
                        <div class="col-xl-12 col-lg-12 col-md-12 col-12">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ValidateFormData();" class="btn btn-primary float-end mt-4" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CssClass="btn btn-primary float-end mt-4" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnDealerRegId" runat="server" />

</asp:Content>
