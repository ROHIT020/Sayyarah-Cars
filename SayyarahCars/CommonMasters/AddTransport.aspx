<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddTransport.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddTransport" %>

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
                <label class="form-label">Enter Transport Name</label>
                <asp:TextBox ID="txtTransportName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtTransportNameError" placeholder="Enter Transport Name" ClientIDMode="Static"></asp:TextBox>
                 <p id="txtTransportNameError" class="error-message">Please enter Transport name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Address</label>
                <asp:TextBox ID="txtAddress" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAddressError" placeholder="Enter Address" ClientIDMode="Static"></asp:TextBox>
                <p id="txtAddressError" class="error-message">Please enter Address</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Email</label>
                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="email" data-error-id="txtEmailError" placeholder="Enter Email ID" ClientIDMode="Static"></asp:TextBox>
                 <p id="txtEmailError" class="error-message">Please enter Email ID</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Fax No.</label>
                <asp:TextBox ID="txtFaxNo" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtFaxNoError" placeholder="Enter Fax No" ClientIDMode="Static"></asp:TextBox>
                <p id="txtFaxNoError" class="error-message">Please enter Fax No</p>
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
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-sm mt-4 align-content-center" OnClientClick="return ValidateFormData();" Text="Save" OnClick="btnSubmit_Click" />
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>
    </div>
</asp:Content>
