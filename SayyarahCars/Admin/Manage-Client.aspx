<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Manage-Client.aspx.cs" Inherits="SayyarahCars.Admin.Manage_Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-header">
                <h5>Manage Client</h5>
                <a class="btn btn-secondary" href="javascript:void(0);" title="my title" onclick="openCSSPopup('AddClient.aspx','Add Client Details')"><i class="ti ti-circle-plus-filled"></i>Add Client</a>
            </div>
            <div class="card-header justify-content-left">
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="form-group">
                        <label class="form-label" for="country"><b>Select Country</b></label>
                        <asp:DropDownList ID="ddlcountry" runat="server" CssClass="chosen-select form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-6 col-12">
                    <div class="form-group">
                        <label class="form-label" for="client"><b>Select Client Name</b></label>
                        <asp:DropDownList ID="ddlclientsearch" runat="server" CssClass="chosen-select form-control"></asp:DropDownList>
                    </div>
                </div>
                <div class="col-lg-3 col-md-3 col-12">
                    <asp:Button ID="btnFilter" runat="server" Text="Search" CssClass="btn btn-primary btn-sm mt-2 float-center" OnClick="btnFilter_Click1" />
                </div>
                <asp:DropDownList
                    ID="ddlpages"
                    runat="server"
                    CssClass="form-control sort-by w-10 float-end"
                    AutoPostBack="true"
                    OnSelectedIndexChanged="ddlpages_SelectedIndexChanged">
                    <asp:ListItem Value="5">5</asp:ListItem>
                    <asp:ListItem Value="10">10</asp:ListItem>
                    <asp:ListItem Value="15">15</asp:ListItem>
                    <asp:ListItem Value="20">20</asp:ListItem>
                    <asp:ListItem Value="25">25</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="gvClient" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" EmptyDataText="No Record Added."
                        AllowPaging="True" PageSize="2" OnPageIndexChanging="gvClient_PageIndexChanging" DataKeyNames="id"
                        Width="100%" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField HeaderText="<input type='checkbox' id='checkAll' class='checkAll' />">
                                <ItemTemplate>
                                    <input type="checkbox" name="checkRow" class="rowCheckbox" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S.No.">
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Profile Image">
                                <ItemTemplate>
                                    <asp:Image ID="pimage" runat="server" ImageUrl='<%# Eval("pimage") %>' Width="60px" Height="55px" CssClass="img-thumbnail" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Name">
                                <ItemTemplate>
                                    <%# Eval("ClientName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Email">
                                <ItemTemplate>
                                    <%# Eval("emailid") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Contact">
                                <ItemTemplate>
                                    <%# Eval("contact") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <%# Eval("CountryName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Registered Date">
                                <ItemTemplate>
                                    <%# Eval("regdate","{0:yyyy-MM-dd}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" CssClass="custom-pager" />
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

    <script src="../Contents/Popup/defaultpopup.js"></script>
    <script type="text/javascript">
        function closePopup() {
            document.getElementById("popupOverlay").classList.add("hidden");
            document.getElementById("popupIframe").src = "";

        }
    </script>
</asp:Content>
