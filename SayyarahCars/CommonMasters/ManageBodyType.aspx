<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManageBodyType.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManageBodyType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Master Body Type</h5>
                    <a class="btn btn-secondary" href="javascript:void(0);" title="my title" onclick="openCSSPopup('AddBodyType.aspx','Add Body Type','50vw','60vh')"><i class="ti ti-circle-plus-filled"></i>Add Body Type</a>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gvBodyType" runat="server" AutoGenerateColumns="False" CssClass="table table-hover table-striped align-middle" EmptyDataText="No Record Added." DataKeyNames="Id" OnRowCommand="gvBodyType_RowCommand">
                            <Columns>
                                <asp:TemplateField HeaderText="<input type='checkbox' id='checkAll' class='checkAll' />">
                                    <ItemTemplate>
                                        <input type="checkbox" name="checkRow" class="rowCheckbox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Body Type Name">
                                    <ItemTemplate>
                                        <%# Eval("BodyTypeName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Body Type Icon">
                                    <ItemTemplate>
                                        <asp:Image ID="imglogo" runat="server" Width="40px" ImageUrl='<%#Eval("BodyTypeIcon") %>' Visible='<%# !string.IsNullOrEmpty(Eval("BodyTypeIcon") as string) %>' />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' CssClass='<%# Eval("Status").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Meta Data">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href="javascript:void(0);" title="Meta data" onclick="openCSSPopup('/CommonMasters/UpdateMetaData.aspx?pageid=3&id=<%#cmf.Encrypt(Eval("Id").ToString()) %>','Update Meta Tags')"><i class="ti ti-tag"></i></a>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href="javascript:void(0);" title="my title" onclick="openCSSPopup('AddBodyType.aspx?id=<%#cmf.Encrypt(Eval("Id").ToString()) %>','Edit Body Type','50vw','60vh')"><i class="ti ti-pencil"></i></a>
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
