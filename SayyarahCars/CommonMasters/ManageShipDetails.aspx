<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManageShipDetails.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManageShipDetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Shipping Company</label>
                                <asp:DropDownList ID="ddlShipingCompany" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-12">
                            <asp:Button ID="btnsearch" ValidationGroup="ram" runat="server" Text="Search" class="btn btn-primary float-end mt-4" OnClick="btnsearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12 col-md-12 col-12">
        <div class="card">
            <div class="card-header">
                <h5>Manage Ship Details</h5>
                <a class="btn btn-secondary" href="javascript:void(0);" title="my title" onclick="openCSSPopup('Add-Ship.aspx','Add Ship Details')"><i class="ti ti-circle-plus-filled"></i>Add Ship</a>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                        AllowCustomPaging="true" AllowPaging="true" PageSize="10" PagerSettings-Position="TopAndBottom"
                        Width="100%" GridLines="Vertical">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S.No">
                                <HeaderStyle Width="80px" />
                                <ItemTemplate>
                                     <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Shipping Company">
                                <ItemTemplate>
                                    <%# Eval("ShippingName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Port Name">
                                <ItemTemplate>
                                    <%# Eval("PortName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Terminal Name">
                                <ItemTemplate>
                                    <%# Eval("Tcname") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Country">
                                <ItemTemplate>
                                    <%# Eval("CountryName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ship Name">
                                <ItemTemplate>
                                    <%# Eval("ShipName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <abbr title="Departure Date">D Date</abbr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# Eval("DepartureDate" , "{0:MM-dd-yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <abbr title="Arrival Date">A Date</abbr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <%# Eval("ArrivalDate","{0:MM-dd-yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ship Freight">
                                <ItemTemplate>
                                    <%# Eval("ShipFreight") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Loading Capacity">
                                <ItemTemplate>
                                    <%# Eval("ShipCapacity") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ship Type">
                                <ItemTemplate>
                                    <%# Eval("Ship Type") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Ship Use">
                                <ItemTemplate>
                                    <%#Eval("Ship Use") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <div class="text-end">
                                        <a class="avtar edit" href="javascript:void(0);" title="my title" onclick="openCSSPopup('Add-Ship?id=<%#cmf.Encrypt(Eval("ID").ToString()) %>','Edit Ship Details')"><i class="ti ti-pencil"></i></a>
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
    <asp:HiddenField ID="hdnshipId" runat="server" />
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
