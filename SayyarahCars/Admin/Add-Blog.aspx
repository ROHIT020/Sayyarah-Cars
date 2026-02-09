<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="Add-Blog.aspx.cs" Inherits="SayyarahCars.Admin.Add_Blog" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
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
                                <label class="form-label" for="user">Blog Topic</label>
                                <asp:DropDownList ID="ddlTopic" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlTopicError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddlTopicError" class="error-message">Please select Blog Topic</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Blog Title (60 Characters Only)</label>
                                <asp:TextBox ID="txtBlogTitle" runat="server" autocomplete="off" MaxLength="60" CssClass="validate form-control" data-error-id="txtBlogTitleError" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtBlogTitleError" class="error-message">Please enter Blog Title</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Blog URL</label>
                                <asp:TextBox ID="txtBlogURL" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="txtBlogURLError" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtBlogURLError" class="error-message">Please enter Blog URL</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Blog Date</label>
                                <asp:TextBox ID="txtBlogDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Browse Blog Image</label>
                                <div class="browse-file">
                                    <asp:FileUpload ID="flpblog" runat="server" CssClass="validate form-control" data-type="fileupload" ClientIDMode="Static" />
                                    <asp:Image ID="imgPreview" runat="server" Width="150px" Height="50px" Visible="false" />
                                    <asp:HiddenField ID="hdnOldImage" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <label class="form-label">&nbsp;</label>
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-2" Text="Submit" OnClientClick="return ValidateFormData();" OnClick="btnSubmit_Click" />
                            <asp:HiddenField ID="hdnId" runat="server" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
