<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="UploadDocument.aspx.cs" Inherits="SayyarahCars.Admin.UploadDocument" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Upload Bill </h5>
                </div>
                <div class="card-body">
                    <div class="row ">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="country">Select Document</label>
                                <asp:DropDownList ID="ddldocument" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddldocument_SelectedIndexChanged" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddldocumenterror" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddldocumenterror" class="error-message">Please select document</p>
                            </div>
                        </div>
                        <div class="col-md-3" id="DivAuction" runat="server" visible="false">
                            <div class="form-group">
                                <label class="form-label" for="country">Auction House</label>
                                <asp:DropDownList ID="ddlauction" runat="server" AutoPostBack="true" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlauctionerror" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddlauctionerror" class="error-message">Please select auction house</p>
                            </div>
                        </div>
                        <div class="col-md-3" id="DivShipping" runat="server" visible="false">
                            <div class="form-group">
                                <label class="form-label" for="country">Shipping Company</label>
                                <asp:DropDownList ID="ddlshipping" runat="server" AutoPostBack="true" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlshippingerror" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddlshippingerror" class="error-message">Please select shipping house</p>
                            </div>
                        </div>
                        <div class="col-md-3" id="DivTransport" runat="server" visible="false">
                            <div class="form-group">
                                <label class="form-label" for="country">Transport Bill</label>
                                <asp:DropDownList ID="ddltransport" runat="server" AutoPostBack="true" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddltransporterror" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddltransporterror" class="error-message">Please select transport house</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Bill Date</label>
                                <uc:DateSelector ID="txtbilldate" runat="server" CssClass="validate form-control" DataErrorId="txtbilldaterror" DataRequired="true" DataType="calendar" />
                                <p id="txtbilldaterror" class="error-message">Please enter Bill Date</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <label class="form-label">Browse Document</label>
                            <div class="profile-sec" id="profile">
                                <asp:FileUpload ID="docFile" CssClass="form-control mt-0" data-required="true" data-type="pimage" runat="server" />

                            </div>
                        </div>
                    <div class="col-md-4">
                        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary btn-sm mt-4 float-center" OnClick="btnSave_Click" OnClientClick="return ValidateFormData();" />
                        <asp:HiddenField ID="hdnId" runat="server" />
                    </div>

                    </div>
                </div>

            </div>
        </div>
    </div>


</asp:Content>
