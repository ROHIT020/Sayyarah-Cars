<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddPortPrice.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddPortPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Select Country From</label>
                <asp:DropDownList ID="ddlCountryfrom" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryfromError" ClientIDMode="Static"></asp:DropDownList>
                 <p id="ddlCountryfromError" class="error-message">Please select Country From</p>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Select Country To</label>
                <asp:DropDownList ID="ddlCountryTo" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryToError" ClientIDMode="Static"></asp:DropDownList>
                <p id="ddlCountryToError" class="error-message">Please select Country To</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Inspection Price</label>
                <asp:TextBox ID="NumInspectionPrice" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="NumInspectionPriceError" ClientIDMode="Static" Placeholder="Enter Inspection Price" TextMode="Number"></asp:TextBox>
                   <p id="NumInspectionPriceError" class="error-message">Please enter Inspection Price</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Radiation Price</label>
                <asp:TextBox ID="NumRadiationPrice" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="NumRadiationPriceError" ClientIDMode="Static" Placeholder="Enter Radiation Price" TextMode="Number"></asp:TextBox>
                <p id="NumRadiationPriceError" class="error-message">Please enter radiation Price</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Port Price</label>
               <asp:TextBox ID="NumPortPrice" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="NumPortPriceError" ClientIDMode="Static" Placeholder="Enter Port Price" TextMode="Number"></asp:TextBox>
               <p id="NumPortPriceError" class="error-message">Please enter Port Price</p>
            </div>
        </div>
        <div class="col-lg-6 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Misc Price</label>
               <asp:TextBox ID="NumMiscPrice" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="NumMiscPriceError" ClientIDMode="Static" Placeholder="Enter Misc Price" TextMode="Number"></asp:TextBox>
                <p id="NumMiscPriceError" class="error-message">Please enter Misc Price</p>
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
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-sm mt-4 align-content-center" OnClientClick="return ValidateFormData();" Text="Save" OnClick="btnSubmit_Click"/>
            <asp:HiddenField ID="hdnId" runat="server" />
        </div>
    </div>


</asp:Content>
