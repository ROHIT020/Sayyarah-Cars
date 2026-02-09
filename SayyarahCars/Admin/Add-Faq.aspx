<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Add-Faq.aspx.cs" Inherits="SayyarahCars.Admin.Add_Faq" %>

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
                                <label class="form-label">Enter Question <span style="color:red">*</span></label>
                                <asp:TextBox ID="txtQuestion" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" ClientIDMode="Static" data-error-id="txtQuestionError" placeholder="Enter Question"></asp:TextBox>
                                <span id="txtQuestionError" style="color: red; display: none;">Please enter question.</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Answer <span style="color:red">*</span></label>
                                <CKEditor:CKEditorControl ID="txtAnswer" runat="server" ClientIDMode="Static" Width="100%" Height="400px"></CKEditor:CKEditorControl>
                                <span id="txtAnswerError" style="color: red; display: none;">Please enter answer.</span>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12 d-flex justify-content-center">
                            <asp:Button ID="btnSubmit" ValidationGroup="ram" runat="server" OnClientClick="return ValidateFormData();" Text="Save changes" class="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnFaqId" runat="server" />
    <script src="../Contents/admin/js/ValidateControls.js" type="text/javascript"></script>
</asp:Content>
