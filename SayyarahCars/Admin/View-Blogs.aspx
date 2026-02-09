<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="View-Blogs.aspx.cs" Inherits="SayyarahCars.Admin.View_Blogs" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/lightbox.min.css" rel="stylesheet" />
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
    <script type="text/javascript">
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 col-md-12 col-12">
        <div class="card">
            <div class="card-header">
                <h5>View Blogs</h5>
                <a class="btn btn-secondary" href="javascript:void(0);" title="my title" onclick="openCSSPopup('Add-Blog.aspx','Add Blog','50vw','54vh')"><i class="ti ti-circle-plus-filled"></i>Add Blog</a>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                        Width="100%" GridLines="Vertical">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:TemplateField HeaderText="S.No">
                                <HeaderStyle Width="80px" />
                                <ItemTemplate>
                                    <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" Select">
                                <HeaderTemplate>
                                    <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                    <asp:HiddenField ID="hdnid" runat="server" Value='<%# Eval("ID") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Blog Topic">
                                <ItemTemplate>
                                    <%# Eval("Topic") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Blog Title">
                                <ItemTemplate>
                                    <%# Eval("BlogTitle") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Blog URL">
                                <ItemTemplate>
                                    <%# Eval("BlogURL") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Blog Date">
                                <ItemTemplate>
                                    <%# Eval("BlogDate","{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Blog Image">
                                <ItemTemplate>
                                    <a href='<%#Eval("BlogImage") %>' data-lightbox="car-gallery" runat="server" id="alight">
                                        <asp:Image ID="Image1" runat="server" Width="40px" ImageUrl='<%#Eval("BlogImage") %>' Visible='<%# !string.IsNullOrEmpty(Eval("BlogImage").ToString()) %>' />
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Author">
                                <ItemTemplate>
                                    <%# Eval("AuthorName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Meta Data">
                                <ItemTemplate>
                                    <div class="text-end">
                                        <a class="avtar edit" href="javascript:void(0);" title="Meta data" onclick="openCSSPopup('/CommonMasters/UpdateMetaData.aspx?pageid=6&id=<%#cmf.Encrypt(Eval("Id").ToString()) %>','Update Meta Tags')"><i class="ti ti-tag"></i></a>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                             <asp:TemplateField HeaderText="Preview">
                                <ItemTemplate>
                                    <div class="text-end">
                                        <a class="avtar edit" href="javascript:void(0);" title="Preview blog" onclick="openCSSPopup('Blog-Preview.aspx?pageid=6&id=<%#cmf.Encrypt(Eval("Id").ToString()) %>','Preview Blog')"><i class="ti ti-eye"></i></a>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <div class="text-end">
                                        <a class="avtar edit" href="javascript:void(0);" title="my title" onclick="openCSSPopup('Add-Blog.aspx?id=<%#cmf.Encrypt(Eval("id").ToString()) %>','Edit Blogs Details')"><i class="ti ti-pencil"></i></a>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false"
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
                <fieldset class="fieldset">
                    <legend>Assign Author</legend>
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <asp:DropDownList ID="ddlAuthor" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlAuthorError" data-validation-group="A" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddlAuthorError" class="error-message">Please select Author Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <label class="form-label">&nbsp;</label>
                            <asp:Button ID="btnAssignAuthor" runat="server" CssClass="btn btn-primary" Text="Submit" OnClientClick="return ValidateFormData('A');" OnClick="btnAssignAuthor_Click" />
                        </div>
                    </div>
                </fieldset>
            </div>
        </div>
    </div>
    <div style="display: none">
        <asp:Button ID="btnreload" runat="server" OnClick="btnreload_Click" />
    </div>
    <script src="../Contents/admin/js/lightbox.min.js"></script>
    <script src="../Contents/Popup/defaultpopup.js"></script>
    <script type="text/javascript">
        function closePopup() {
            document.getElementById("popupOverlay").classList.add("hidden");
            document.getElementById("popupIframe").src = "";
            document.getElementById("<%=btnreload.ClientID%>").click();
        }
    </script>
</asp:Content>
