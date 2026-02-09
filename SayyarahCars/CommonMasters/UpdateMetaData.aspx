<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="UpdateMetaData.aspx.cs" Inherits="SayyarahCars.CommonMasters.UpdateMetaData" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-sm-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Title Tag Value</label>
                                <asp:TextBox ID="txtTitle" runat="server" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="errorTitle" ClientIDMode="Static" placeholder="Enter Title"></asp:TextBox>
                                <span id="errorTitle" class="error-message">Please enter Title Tag Value.</span>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Keyword Tag Value</label>
                                <asp:TextBox ID="txtKeyword" runat="server" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="errorKeyword" ClientIDMode="Static" placeholder="Enter Keywords"></asp:TextBox>
                                <span id="errorKeyword" class="error-message">Please enter Keyword Tag Value.</span>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-sm-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Description Tag Value</label>
                                <asp:TextBox ID="txtDescription" runat="server" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="errorDescription" ClientIDMode="Static" placeholder="Enter Description"></asp:TextBox>
                                <span id="errorDescription" class="error-message">Please enter Description Tag Value.</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Page Content</label>
                                <CKEditor:CKEditorControl ID="txtPageContent" runat="server" Width="100%" Height="400px"></CKEditor:CKEditorControl>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12 d-flex justify-content-center">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-sm mt-4"
                                Text="Save" OnClick="btnSubmit_Click" OnClientClick="return ValidateFormData();" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    
</asp:Content>
