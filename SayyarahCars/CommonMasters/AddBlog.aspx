<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="AddBlog.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddBlog" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <h5>Add Blog</h5>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Blog Language</b></label>
                                <asp:DropDownList ID="ddllanguage" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddllanguagerror" ClientIDMode="Static">
                                    <asp:ListItem Value="1">English</asp:ListItem>
                                    <asp:ListItem Value="2">Other</asp:ListItem>
                                </asp:DropDownList>
                                <p id="ddllanguagerror" class="error-message">Please select language</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Enter Blog Topic</b></label>
                                <asp:DropDownList ID="ddltopic" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddltopicerror" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddltopicerror" class="error-message">Select Blog Topic</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Enter Blog Title (60 Characters Only)</b></label>
                                <asp:TextBox ID="txtbtitle" runat="server" autocomplete="off" CssClass=" validate form-control" MaxLength="60" Display="Dynamic" data-required="true" data-type="text" data-error-id="txtbtitlerror" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtbtitlerror" class="error-message">Enter Blog Title</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Blog URL</b></label>
                                <asp:TextBox ID="txtburl" runat="server" autocomplete="off" CssClass="validate form-control" MaxLength="60" data-required="true" data-type="text" data-error-id="txtburlerror" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtburlerror" class="error-message">Enter Blog Url</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Enter Blog Date</b></label>
                                <asp:TextBox ID="txtdate" runat="server" autocomplete="off" CssClass="form-control" TextMode="Date" data-required="true" data-type="text" Display="Dynamic" ClientIDMode="Static"></asp:TextBox>
                                
                            </div>
                        </div>


                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Enter Page Title</b></label>
                                <asp:TextBox ID="txtptitle" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txttitlerror" ClientIDMode="Static" />
                                <p id="txttitlerror" class="error-message">Enter Page Title</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Enter Keyword Tag</b></label>
                                <asp:TextBox ID="txtkeyword" runat="server" autocomplete="off" CssClass=" validate form-control" data-required="true" data-type="text" data-error-id="txtkeyworderror" ClientIDMode="Static" />
                                <p id="txtkeyworderror" class="error-message">Enter Keyword Tag</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Enter Description Tag</b></label>
                                <asp:TextBox ID="txtdescription" runat="server" autocomplete="off" CssClass=" validate form-control" data-required="true" data-type="text" data-error-id="txtdescerror" ClientIDMode="Static" />
                                <p id="txtdescerror" class="error-message">Enter Description Tag</p>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Enter Blog Short Description (160 Characters Only)</b></label>
                                <asp:TextBox ID="txtbsd" runat="server" autocomplete="off" CssClass=" validate form-control" MaxLength="160" data-required="true" data-type="text" data-error-id="txtbsderror" ClientIDMode="Static" />
                                <p id="txtbsderror" class="error-message">Enter Blog Short Description</p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Browse Blog Image</b></label>
                                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control" data-required="true" data-type="image" ClientIDMode="Static" />
                                <asp:Image ID="imgPreview" runat="server" Width="90px" Height="60px" Visible="false" />
                                <asp:HiddenField ID="HiddenFieldOldImage" runat="server" />
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12 d-flex justify-content-md-center align-items-start mt-4" >
                            <div class="form-group">
                                <button type="button" class="btn btn-primary" style="display:none" data-toggle="modal" data-target="#con-detail" id="car_detail">Add anchor tag</button>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-lg-12 col-md-12 col-12">
                                <div class="form-group">
                                    <label class="form-label">Enter blog Details</label>
                                    <CKEditor:CKEditorControl ID="txtPageContent" runat="server" Width="100%" Height="400px"></CKEditor:CKEditorControl>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClientClick="return ValidateFormData()" OnClick="btnSubmit_Click" />
                                <asp:HiddenField ID="hdnId" runat="server" Value="0" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldID" runat="server" />
</asp:Content>
