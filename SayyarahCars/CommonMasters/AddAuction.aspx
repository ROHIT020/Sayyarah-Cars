<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddAuction.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddAction" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .add-new-item {
            color: blue;
            font-weight: bold;
            background-color: #f0f0f0;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Select Country Name</label>
                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryError" ClientIDMode="Static">
                </asp:DropDownList>
                <p id="ddlCountryError" class="error-message">Please select Country Name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Select Auction Group</label>
                <asp:DropDownList ID="ddlauctiongroup" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlauctiongroupError" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlauctiongroup_SelectedIndexChanged"></asp:DropDownList>
                <p id="ddlauctiongroupError" class="error-message">Please Select Auction Group</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12" id="Divgroup" runat="server" visible="false">
            <div class="form-group">
                <label class="form-label">Enter Auction Group Name</label>
                <asp:TextBox ID="txtGroup" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtGroupError" placeholder="Enter Name" ClientIDMode="Static"></asp:TextBox>
                <p id="txtGroupError" class="error-message">Please enter group Name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Name</label>
                <asp:TextBox ID="txtName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtShipNameError" placeholder="Enter Name" ClientIDMode="Static"></asp:TextBox>
                <p id="txtNameError" class="error-message">Please enter Name</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Address</label>
                <asp:TextBox ID="txtAddress" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAddressError" placeholder="Enter Address" ClientIDMode="Static"></asp:TextBox>
                <p id="txtAddressError" class="error-message">Please enter Addres</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Email ID</label>
                <asp:TextBox ID="txtEmail" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="email" data-error-id="txtEmailError" placeholder="Enter Email ID" ClientIDMode="Static"></asp:TextBox>
                <p id="txtEmailError" class="error-message">Please Enter Email ID</p>
            </div>

        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Contact No</label>
                <asp:TextBox ID="txtcontact" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtContactError" placeholder="Enter Contact No" ClientIDMode="Static"></asp:TextBox>
                <p id="txtContactError" class="error-message">Please Contact No</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Fax No.</label>
                <asp:TextBox ID="txtFaxNo" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtFaxNoError" placeholder="Enter Fax No" ClientIDMode="Static" TextMode="Number"></asp:TextBox>
                <p id="txtFaxNoError" class="error-message">Please Fax No</p>
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
            <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary btn-sm mt-4 align-content-center" OnClientClick="return ValidateFormData();" OnClick="btnSubmit_Click" />
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>
    </div>
</asp:Content>
