<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddConsignee.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddConsignee" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Select Client Name</label>
                <asp:DropDownList ID="ddlClient" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlClientError" ClientIDMode="Static"></asp:DropDownList>
                <p id="ddlClientError" class="error-message">Please select Client Name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter CFS</label>
                <asp:TextBox ID="txtcfs" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtcfsError" placeholder="Enter CFS" ClientIDMode="Static"></asp:TextBox>
                <p id="txtcfsError" class="error-message">Please enter CFS</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Consignee Name</label>
                <asp:TextBox ID="txtconsigneename" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtconsigneenameError" placeholder="Enter Consignee Name" ClientIDMode="Static"></asp:TextBox>
                 <p id="txtconsigneenameError" class="error-message">Please enter Consignee Name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Email Address</label>
                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="email" data-error-id="txtEmailError" placeholder="Enter Email ID" ClientIDMode="Static"></asp:TextBox>
                 <p id="txtEmailError" class="error-message">Please enter Email ID</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Address</label>
                <asp:TextBox ID="txtAddress" runat="server" TextMode="MultiLine" Rows="3" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAddressError" ClientIDMode="Static"></asp:TextBox>
                <p id="txtAddressError" class="error-message">Please enter Address</p>
            </div>
        </div>

       
        <div class="card-header justify-content-end">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ValidateFormData();" CssClass="btn btn-primary btn-sm mt-4 align-content-center" ValidationGroup="a" OnClick="btnSubmit_Click" />
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>
    </div>
</asp:Content>
