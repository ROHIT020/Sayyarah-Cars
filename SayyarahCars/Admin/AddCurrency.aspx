<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="AddCurrency.aspx.cs" Inherits="SayyarahCars.Admin.AddCurrency" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">                       
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Select Currency Type<span style="color:red">*</span></label>
                                <%--<asp:TextBox ID="txtCurrencyType" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtCurrencyTypeError" placeholder="Enter Currenct Type" style="display:none"></asp:TextBox>--%>
                                <%--<p id="txtCurrencyTypeError" class="error-message" style="display:none">Please enter Currency Type</p>--%>
                                <asp:DropDownList ID="ddlCurrencyType" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCurrencyTypeError" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddlCurrencyTypeError" class="error-message">Please select Currency type</p>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Select Symbol<span style="color:red">*</span></label>
                                <asp:DropDownList ID="ddlsymbol" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlsymbolError" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddlsymbolError" class="error-message">Please select Symbol</p>
                                <%--<asp:TextBox ID="txtSymbol" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="ddlSymbolError" placeholder="Select"></asp:TextBox>
                                <p id="ddlSymbolError" class="error-message">Please enter Symbol</p>--%>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Rate<span style="color:red">*</span></label>
                                <asp:TextBox ID="txtRate" runat="server" autocomplete="off" TextMode="Number" step="any" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtRateBError" placeholder="Enter Rate B"></asp:TextBox>
                                <p id="txtRateBError" class="error-message">Please enter Rate</p>
                            </div>
                        </div>

                        <%--<div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Rate<span style="color:red">*</span></label>
                                <asp:TextBox ID="txtRateL" runat="server" autocomplete="off" TextMode="Number" step="any" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtRateLError" placeholder="Enter Rate L"></asp:TextBox>
                                <p id="txtRateLError" class="error-message">Please enter Rate L</p>
                            </div>
                        </div>--%>
                        <div class="col-xl-1 col-lg-12 col-md-12 col-12">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ValidateFormData();" class="btn btn-primary float-end mt-4" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Contents/admin/js/ValidateControls.js" type="text/javascript"></script>
</asp:Content>
