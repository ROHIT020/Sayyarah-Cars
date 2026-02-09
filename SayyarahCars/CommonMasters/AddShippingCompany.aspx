<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddShippingCompany.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddShippingCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Select Country Name</label>
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryError" ClientIDMode="Static"></asp:DropDownList>
                <p id="ddlCountryError" class="error-message">Please select Country Name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Shipping Name</label>
                <asp:TextBox ID="txtShippingName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtShippingNameError" ClientIDMode="Static" placeholder="Enter Shipping Name"></asp:TextBox>
               <p id="txtShippingNameError" class="error-message">Please enter Shipping Name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Shipping Rate</label>
                <asp:TextBox ID="txtShippingRate" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtShippingRateError"  ClientIDMode="Static" Placeholder="Enter Shipping Rate." TextMode="Number"></asp:TextBox>
               <p id="txtShippingRateError" class="error-message">Please enter Shipping rate</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Email</label>
                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="email" data-error-id="txtEmailError"  ClientIDMode="Static" placeholder="Enter Email"></asp:TextBox>
                <p id="txtEmailError" class="error-message">Please enter Email ID</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Contact</label>
                <asp:TextBox ID="txtContact" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtContactError" ClientIDMode="Static" Placeholder="Enter Contact" TextMode="Number"></asp:TextBox>
                <p id="txtContactError" class="error-message">Please enter Contact No</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Status</label>
                <div class="custom-radiobox">
                    <label class="radio-block">
                        <asp:RadioButton ID="rdoactive" runat="server" GroupName="Status" Text="Active" />
                    </label>
                    <label class="radio-block">
                        <asp:RadioButton ID="rdodeActive" runat="server" GroupName="Status" Text="De-Active" />
                    </label>
                </div>
            </div>
        </div>
        <div class="card-header justify-content-end">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" OnClientClick="return ValidateFormData();" Text="Submit" OnClick="btnSubmit_Click" />
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>
    </div>
</asp:Content>
