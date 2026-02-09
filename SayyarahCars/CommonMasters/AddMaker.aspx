<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddMaker.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddMaker" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Enter Maker Name</label>
                <asp:TextBox ID="txtMakerName" runat="server" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="errorName" ClientIDMode="Static" placeholder="Enter Maker Name"></asp:TextBox>
                <span id="errorName" class="error-message">Please enter Maker Name.</span>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Browse Maker Logo</label>
                <div class="browse-file">
                    <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control form-control-lg" ClientIDMode="Static" accept="image/*" />
                    <br />
                    <asp:Image ID="imgPreview" runat="server" Width="90px" Height="60px" Visible="false" />
                    <asp:HiddenField ID="hdnOldFileName" runat="server" />
                    <asp:Image ID="imglogo" runat="server" CssClass="img" Style="max-height: 200px;" />
                </div>
            </div>
        </div>
        
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Status</label>
                <div class="custom-radiobox validate" data-type="radiogroup" data-required="true" data-error-id="statusError">
                    <label class="radio-block">
                        <asp:RadioButton ID="rdoactive" runat="server" GroupName="Status" Text="Active" />
                    </label>
                    <label class="radio-block">
                        <asp:RadioButton ID="rdodeActive" runat="server" GroupName="Status" Text="De-Active" />
                    </label>
                </div>
                <span id="statusError" class="error-message">Please select a status.</span>
            </div>
        </div>
        <div class="card-header justify-content-end">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-sm mt-4 align-content-center" OnClientClick="return ValidateFormData();" Text="Save" OnClick="btnSubmit_Click" />
            <asp:HiddenField ID="hdnId" runat="server" Value="0" />
        </div>
    </div>



</asp:Content>
