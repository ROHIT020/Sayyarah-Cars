<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManageCategory.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManageCategory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <h5>Manage Category</h5>
                    </div>
                </div>
                <div class="card-body">

                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Type</label>
                                <asp:DropDownList ID="ddltype" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Category</asp:ListItem>
                                    <asp:ListItem Value="2">Sub Category</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12" id="divPid" runat="server" visible="false">
                            <div class="form-group mb-0">
                                <label class="form-label">Category</label>
                                <asp:DropDownList ID="ddlpid" runat="server" CssClass="validate chosen-select form-control" data-error-id="errddlpid" data-required="true" data-type="dropdown" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlpid_SelectedIndexChanged"></asp:DropDownList>
                                <p id="errddlpid" class="error-message">Please select Category</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">
                                    <asp:Label ID="lbltitle" runat="server" Text="Category Name"></asp:Label>
                                </label>
                                <asp:TextBox ID="txtName" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errName" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errName" class="error-message">Please enter Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="countryName">Icon</label>
                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                <asp:Image ID="imgPreview" runat="server" Width="150px" Height="90px" Visible="false" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Active/De-Active</label>
                                <div class="custom-radiobox">
                                    <asp:RadioButtonList ID="RadioAD" runat="server" CssClass="form-control" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="False">Active &nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="True"> De-Active </asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary mt-4" OnClientClick="return ValidateFormData();" Text="Save" OnClick="btnsubmit_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Found." OnRowCommand="GridView1_RowCommand"
                            AllowCustomPaging="true" AllowPaging="true" PageSize="10" PagerSettings-Position="TopAndBottom"
                            Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No">
                                    <HeaderStyle Width="80px" />
                                    <ItemTemplate>
                                         <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Name ">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;   <%# Eval("CategoryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Icon">
                                    <ItemTemplate>
                                        <asp:Image ID="Image1" runat="server" Width="40px" ImageUrl='<%# Eval("CategoryIcon") %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Archive").ToString().Trim() == "False" ? "Active" : "Deactive" %>' CssClass='<%# Eval("Archive").ToString().Trim() == "False" ? "status active" : "status deactive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meta Data">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href="javascript:void(0);" title="Meta data" onclick="openCSSPopup('/CommonMasters/UpdateMetaData.aspx?pageid=1&id=<%#cmf.Encrypt(Eval("Id").ToString()) %>','Update Meta Tags')"><i class="ti ti-tag"></i></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CausesValidation="false"
                                                CommandArgument='<%# Eval("ID") %>' CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit"><i class="ti ti-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CausesValidation="false" OnClientClick="return confirmDelete(this);"
                                                CommandArgument='<%# Eval("ID") %>' CssClass="avtar delete" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Delete"><i class="ti ti-trash"></i></asp:LinkButton>
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
    <script src="../Contents/Popup/defaultpopup.js"></script>
    <script src="../Contents/Popup/defaultpopup.js"></script>
    <script type="text/javascript">
        function closePopup() {
            document.getElementById("popupOverlay").classList.add("hidden");
            document.getElementById("popupIframe").src = "";   
        }
    </script>
</asp:Content>
