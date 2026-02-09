<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="BillMaster.aspx.cs" Inherits="SayyarahCars.CommonMasters.BillMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Bill Master</h5>
                    <a class="btn btn-secondary" href="javascript:void(0);" title="my title" onclick="openCSSPopup('AddBill.aspx','Add Bill','30vw','60vh')"><i class="ti ti-circle-plus-filled"></i>Add Bill</a>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gvBillMaster" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added."
                            AllowCustomPaging="true" AllowPaging="True"
                            Width="100%" GridLines="Vertical" OnRowCommand="gvBillMaster_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="<input type='checkbox' id='checkAll' class='checkAll' />">
                                    <ItemTemplate>
                                        <input type="checkbox" name="checkRow" class="rowCheckbox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Document Name">
                                    <ItemTemplate>
                                        <%# Eval("DocumentName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Bill Date">
                                    <ItemTemplate>
                                        <%# Eval("BillDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" OnClientClick="return confirmDelete(this);"
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
