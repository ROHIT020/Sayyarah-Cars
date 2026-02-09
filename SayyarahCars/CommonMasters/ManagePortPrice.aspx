<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManagePortPrice.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManagePortPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Port Price Master</h5>
                    <a class="btn btn-secondary" href="javascript:void(0);" title="my title" onclick="openCSSPopup('AddPortPrice.aspx','AddPortPrice','50vw','90vh')"><i class="ti ti-circle-plus-filled"></i>Add Port Price</a>
                </div>
                <div class="card-header justify-content-end">
                    <asp:DropDownList ID="ddlpages" runat="server" CssClass="form-control sort-by w-10 float-end" AutoPostBack="true" OnSelectedIndexChanged="ddlpages_SelectedIndexChanged">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="150">150</asp:ListItem>
                        <asp:ListItem Value="200">200</asp:ListItem>
                        <asp:ListItem Value="500">500</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                            AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                            Width="100%" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="<input type='checkbox' id='checkAll' class='checkAll' />">
                                    <ItemTemplate>
                                        <input type="checkbox" name="checkRow" class="rowCheckbox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country From">
                                    <ItemTemplate>
                                        <%# Eval("CountryFrom") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country To">
                                    <ItemTemplate>
                                        <%# Eval("CountryTo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Inspection">
                                    <ItemTemplate>
                                        <%# Eval("InspectionPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Radiation">
                                    <ItemTemplate>
                                        <%# Eval("RadiationPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Port Price">
                                    <ItemTemplate>
                                        <%# Eval("PortPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Misc Price">
                                    <ItemTemplate>
                                        <%# Eval("MiscPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' CssClass='<%# Eval("Status").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href="javascript:void(0);" title="my title" onclick="openCSSPopup('AddPortPrice.aspx?id=<%#cmf.Encrypt(Eval("ID").ToString()) %>','Edit PortPrice','50vw','90vh')"><i class="ti ti-pencil"></i></a>
                                               <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false"
                                             ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </div>
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
    </div>
    <div style="display: none">
        <asp:Button ID="btnreload" runat="server" OnClick="btnreload_Click" />
    </div>
    <script src="../Contents/Popup/defaultpopup.js"></script>
    <script type="text/javascript">
        function closePopup() {
            document.getElementById("popupOverlay").classList.add("hidden");
            document.getElementById("popupIframe").src = "";
            document.getElementById("<%=btnreload.ClientID%>").click();
        }
    </script>

</asp:Content>
