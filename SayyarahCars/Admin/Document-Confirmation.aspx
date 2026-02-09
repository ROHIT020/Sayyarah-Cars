<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Document-Confirmation.aspx.cs" Inherits="SayyarahCars.Admin.Document_Confirmation" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
    <script type="text/javascript">
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Ship Name</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Shipping Company</label>
                                <asp:DropDownList ID="ddlShippingC" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Port Name</label>
                                <asp:DropDownList ID="ddlPortName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Ship Name</label>
                                <asp:DropDownList ID="ddlShipName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Loading</label>
                                <asp:DropDownList ID="ddlloading" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="0">Loading</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Urgent</label>
                                <asp:DropDownList ID="ddlurgent" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="0">Urgent</asp:ListItem>
                                    <asp:ListItem Value="10">Yes</asp:ListItem>
                                    <asp:ListItem Value="50">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Customer Name</label>
                                <asp:DropDownList ID="ddlcustomer" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Product In Date</label>
                                <uc:DateSelector ID="txtPInDate" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Product In Status</label>
                                <asp:DropDownList ID="ddlProductInStatus" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="0">Product In Status</asp:ListItem>
                                    <asp:ListItem Value="10">Yes</asp:ListItem>
                                    <asp:ListItem Value="50">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Order by</label>
                                <asp:DropDownList ID="ddlOrderBy" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="ASC">New First</asp:ListItem>
                                    <asp:ListItem Value="ASC">New First</asp:ListItem>
                                    <asp:ListItem Value="DESC">OLd First </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Rikuji Date</label>
                                <uc:DateSelector ID="txtRikuji" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Sold Country</label>
                                <asp:DropDownList ID="ddlScountry" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Invoice Type</label>
                                <asp:DropDownList ID="ddlInvoicetype" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="0">Invoice Type</asp:ListItem>
                                    <asp:ListItem Value="1">Normal</asp:ListItem>
                                    <asp:ListItem Value="2">Constructor</asp:ListItem>
                                    <asp:ListItem Value="3">Container</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Documents Status</label>
                                <asp:DropDownList ID="ddldocumentStatus" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="0">Documents Status</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Date From</label>
                                <uc:DateSelector ID="txtdateFrom" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Date To</label>
                                <uc:DateSelector ID="txtDateto" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Transport</label>
                                <asp:DropDownList ID="ddltransport" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Car Status</label>
                                <asp:DropDownList ID="ddlCarStatus" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Sort By</label>
                                <asp:DropDownList ID="ddlshortby" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="150">150</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Chassis No.</label>
                                <asp:TextBox ID="txtChassisNo" runat="server" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">All Chassis No </label>
                                <asp:TextBox ID="txtAllChassisNo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click" />
                                </div>
                            </div>
                              <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="btnExport" runat="server" Text="Download Excel" CssClass="btn btn-primary fa-pull-right" OnClick="btnExport_Click"/>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div id="Divserver" runat="server">
                <div class="row">
                    <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnPageIndexChanging="GridView1_PageIndexChanging"
                            AllowCustomPaging="true" AllowPaging="true" PageSize="10"
                            Width="100%" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpid" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                        <asp:Label ID="lbluid" runat="server" Text='<%# Eval("Uid") %>'></asp:Label>
                                        <asp:Label ID="lblslock" runat="server" Text='<%# Eval("Shiplock") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Select">
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" S.No.">
                                    <ItemTemplate>
                                        <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chassis No">
                                    <ItemTemplate>
                                        <%# Eval("ChassisNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Auction Date">
                                    <ItemTemplate>
                                        <%# Eval("ADate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product In">
                                    <ItemTemplate>
                                        <%# Eval("ProductIn","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rickuji Date">
                                    <ItemTemplate>
                                        <%# Eval("Rickujidate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Port Name">
                                    <ItemTemplate>
                                        <%# Eval("PortName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Urgent">
                                    <ItemTemplate>
                                        <%# Eval("Urgent") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <%# Eval("ProductName") %>/
                                        <%# Eval("ProductType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Name">
                                    <ItemTemplate>
                                        <%# Eval("ClientName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loading">
                                    <ItemTemplate>
                                        <%# Eval("Loading") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year">
                                    <ItemTemplate>
                                        <%# Eval("MDate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period">
                                    <ItemTemplate>
                                        <%# Eval("Period") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ShippingCompany">
                                    <ItemTemplate>
                                        <%# Eval("ShippingName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Auction">
                                    <ItemTemplate>
                                        <%# Eval("AuctionName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transport">
                                    <ItemTemplate>
                                        <%# Eval("TransportName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sold Country">
                                    <ItemTemplate>
                                        <%# Eval("Countryname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sold Price">
                                    <ItemTemplate>
                                        <%# Eval("FinalSoldPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Freight">
                                    <ItemTemplate>
                                        <%# Eval("FreightCharge") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="T_charges">
                                    <ItemTemplate>
                                        <%# Eval("RecycleAmount") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <%# Eval("TotalPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ship Name">
                                    <ItemTemplate>
                                        <%# Eval("ShipName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="	W_S_Date">
                                    <ItemTemplate>
                                        <%# Eval("WishShipDate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="W_A_Date">
                                    <ItemTemplate>
                                        <%# Eval("WishArrivalDate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DR-LO day">
                                    <ItemTemplate>
                                        <%# Eval("DrLoDay") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PIN-AUC day">
                                    <ItemTemplate>
                                        <%# Eval("PInAucDay") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AUC-LO day">
                                    <ItemTemplate>
                                        <%# Eval("AucLoDay") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PIN-LO day">
                                    <ItemTemplate>
                                        <%# Eval("PInLoDay") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle CssClass="grid-footer" />
                            <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" CssClass="custom-pager" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </div>
                <div class="col-md-3">
                    <div class="form-group m-4">
                        <asp:Button ID="lockship" runat="server" Text="Lock Ship Name" CssClass="btn btn-primary" OnClick="lockship_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>

    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtChassisNo.ClientID %>',
            AllChassisNo: '<%= txtAllChassisNo.ClientID %>'
        };
    </script>

</asp:Content>
