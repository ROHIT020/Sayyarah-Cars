<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddTerminal.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddTerminal" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Port Name</label>
                <asp:DropDownList ID="ddlPort" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlPortError" ClientIDMode="Static"></asp:DropDownList>
                <p id="ddlPortError" class="error-message">Please select Port Name</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label">Terminal Company Name</label>
                <asp:TextBox ID="txttcname" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txttcnameError" ClientIDMode="Static" placeholder="Enter Terminal Company Name"></asp:TextBox>
                <p id="txttcnameError" class="error-message">Please enter Company Name</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label">Terminal Name</label>
                <asp:TextBox ID="txttname" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txttnameError" ClientIDMode="Static" placeholder="Enter Terminal Name"></asp:TextBox>
                <p id="txttnameError" class="error-message">Please enter Terminal Name</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label">Contact Person</label>
                <asp:TextBox ID="txtCperson" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtCpersonError" ClientIDMode="Static" placeholder="Enter Contact Person"></asp:TextBox>
                <p id="txtCpersonError" class="error-message">Please enter Contact Person</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label">Contact Number</label>
                <asp:TextBox ID="txtContactNo" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtContactNoError" ClientIDMode="Static" placeholder="Enter Contact Number"></asp:TextBox>
                <p id="txtContactNoError" class="error-message">Please enter Contact No</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label">Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="email" data-error-id="txtEmailError" ClientIDMode="Static" placeholder="Enter Email"></asp:TextBox>
                <p id="txtEmailError" class="error-message">Please enter Email ID</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label">Terminal Address</label>
                <asp:TextBox ID="txttaddress" runat="server" TextMode="MultiLine" Rows="2" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txttaddressError" ClientIDMode="Static" placeholder="Enter Terminal Address"></asp:TextBox>
                <p id="txttaddressError" class="error-message">Please enter Terminal Address</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-6 col-12">
            <div class="form-group">
                <label class="form-label">Price</label>
                <asp:TextBox ID="txtprice" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtpriceError" ClientIDMode="Static" Placeholder="Enter Price" TextMode="Number"></asp:TextBox>
                <p id="txtpriceError" class="error-message">Please enter Price</p>
            </div>
        </div>
        <div class="card-header justify-content-end">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary float-end mt-4" OnClientClick="return ValidateFormData();" OnClick="btnSubmit_Click" />
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>
    </div>
</asp:Content>
