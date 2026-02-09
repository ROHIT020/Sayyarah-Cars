<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="View-Author.aspx.cs" Inherits="SayyarahCars.Admin.View_Author" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/lightbox.min.css" rel="stylesheet" />
        <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Add Author</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Author Name</b></label>
                                <asp:TextBox ID="txtAuthor" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAuthorError" ClientIDMode="Static" Placeholder="Enter Author Name"></asp:TextBox>
                                <p id="txtAuthorError" class="error-message">Please enter Author Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Browse Author Image</b></label>
                                <asp:FileUpload ID="authorImage" CssClass="  form-control " runat="server" />
                                <asp:Image ID="imgPreview" runat="server" Width="90px" Height="60px" Visible="false" />
                                <asp:HiddenField ID="HiddenFieldOldImage" runat="server" />
                                <p id="authorImageError" class="error-message">Please upload author image</p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Description</b></label>
                                <asp:TextBox ID="txtDescriptions" runat="server" autocomplete="off" TextMode="MultiLine" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtDescriptionError" ClientIDMode="Static" Placeholder="Enter Author Description"></asp:TextBox>
                                <p id="txtDescriptionError" class="error-message">Please enter Author Description</p>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-6 col-12">
                            <div class="form-group">
                                <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-sm mt-4 align-content-center" OnClientClick="return ValidateFormData();" Text="Save" OnClick="btnSubmit_Click" />
                                <asp:HiddenField ID="hdnId" runat="server" />
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-header">
                    <h5>Manage Author</h5>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                            AllowCustomPaging="true" AllowPaging="True"
                            Width="100%" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="Sr. No.">
                                    <ItemTemplate>
                                        <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author Name">
                                    <ItemTemplate>
                                        <%# Eval("AuthorName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Description">
                                    <ItemTemplate>
                                        <%# Eval("Description") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Author Image">
                                    <ItemTemplate>
                                        <a href='<%#Eval("AuthorImg") %>' data-lightbox="car-gallery" runat="server" id="alight">
                                            <asp:Image ID="Image1" runat="server" Width="40px" ImageUrl='<%#Eval("AuthorImg") %>' Visible='<%# !string.IsNullOrEmpty(Eval("AuthorImg").ToString()) %>' />
                                        </a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meta Data">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href="javascript:void(0);" title="Meta data" onclick="openCSSPopup('/CommonMasters/UpdateMetaData.aspx?pageid=4&id=<%#cmf.Encrypt(Eval("Id").ToString()) %>','Update Meta Tags')"><i class="ti ti-tag"></i></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CausesValidation="false"
                                                CommandArgument='<%# Eval("ID") %>' CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit"><i class="ti ti-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("ID") %>' UseSubmitBehavior="false"
                                                ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script src="../Contents/admin/js/lightbox.min.js"></script>
    <script src="../Contents/Popup/defaultpopup.js"></script>
    
</asp:Content>
