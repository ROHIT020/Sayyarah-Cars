<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Ship-Confirmation-Report.aspx.cs" Inherits="SayyarahCars.Admin.Ship_Confirmation_Report" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table {
            overflow: visible
        }
    </style>

    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Shipping Company</label>
                                <asp:DropDownList ID="ddlShippingCompany" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Port Name</label>
                                <asp:DropDownList ID="ddlPortName" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Ship Name</label>
                                <asp:DropDownList ID="ddlShipName" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Loading</label>
                                <asp:DropDownList ID="ddlLoading" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="0">Select Loading </asp:ListItem>
                                    <asp:ListItem Value="Yes"> Yes </asp:ListItem>
                                    <asp:ListItem Value="No"> No </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Urgent</label>
                                <asp:DropDownList ID="ddlUrgent" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="0">Urgent</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Customer Name</label>
                                <asp:DropDownList ID="ddlCustomerName" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Product In Date</label>
                                <uc:DateSelector ID="txtProductInDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Product In Status</label>
                                <asp:DropDownList ID="ddlProductInStatus" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Product In Status</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="2">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Order by</label>
                                <asp:DropDownList ID="ddlOrderby" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="ASC">New First</asp:ListItem>
                                    <asp:ListItem Value="DESC">OLd First </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Rikuji Date</label>
                                <uc:DateSelector ID="txtRikujiDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Sold Country</label>
                                <asp:DropDownList ID="ddlSoldCountry" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Invoice Type</label>
                                <asp:DropDownList ID="ddlInvoiceType" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Invoice Type</asp:ListItem>
                                    <asp:ListItem Value="1">Normal</asp:ListItem>
                                    <asp:ListItem Value="2">Constructor</asp:ListItem>
                                    <asp:ListItem Value="3">Container</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Documents Status</label>
                                <asp:DropDownList ID="ddlDocumentsStatus" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Documents Status</asp:ListItem>
                                    <asp:ListItem Value="2">Yes</asp:ListItem>
                                    <asp:ListItem Value="1">No </asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Date from</label>
                                <uc:DateSelector ID="txtDatefrom" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Date To</label>
                                <uc:DateSelector ID="txtDateTo" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Transport</label>
                                <asp:DropDownList ID="ddlTransport" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Car Status</label>
                                <asp:DropDownList ID="ddlCarStatus" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Chassis No</label>
                                <asp:TextBox ID="txtchassis" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>

                        <div class="col-lg-6 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">All Chassis No</label>
                                <asp:TextBox ID="txtallchno" runat="server" autocomplete="off" TextMode="MultiLine" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Sort By</label>
                                <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="300">300</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnDownload" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Download" OnClick="btnDownload_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" AllowPaging="True" AllowCustomPaging="True" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                            EmptyDataText="No Record Added." Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />

                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                        <asp:Label ID="lblshname" runat="server" Text='<%# Eval("Shipname") %>'></asp:Label>
                                        <asp:Label ID="lbluid" runat="server" Text='<%# Eval("UID") %>'></asp:Label>
                                        <%--<asp:Label ID="lblslock" runat="server" Text='<%# Eval("Slock") %>'></asp:Label>--%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" Select">
                                    <HeaderStyle Width="50px" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" S.No.">
                                    <HeaderStyle Width="50px" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chassis">
                                    <ItemTemplate>
                                        <%# Eval("Chassis No") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Adate">
                                    <ItemTemplate>
                                        <%# Eval("Adate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product In">
                                    <ItemTemplate>
                                        <%# Eval("ProductIn") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Rickuji Date">
                                    <ItemTemplate>
                                        <%# Eval("Rickujidate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Port Name">
                                    <ItemTemplate>
                                        <%# Eval("ProtName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Urgent">
                                    <ItemTemplate>
                                        <%# Eval("Urgent") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <%# Eval("Product Name") %> /
                                          <%# Eval("OrderType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Name">
                                    <ItemTemplate>
                                        <%# Eval("clientname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loading">
                                    <ItemTemplate>
                                        <%# Eval("loading") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year">
                                    <ItemTemplate>
                                        <%# Eval("Year") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period">
                                    <ItemTemplate>
                                        <%# Eval("Period") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="ShippingCompany">
                                    <ItemTemplate>
                                        <%# Eval("ShippingCompany") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Auction">
                                    <ItemTemplate>
                                        <%# Eval("Auction") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transport">
                                    <ItemTemplate>
                                        <%# Eval("Transport") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sold Country">
                                    <ItemTemplate>
                                        <%# Eval("Countryname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sold Price">
                                    <ItemTemplate>
                                        <%# Eval("SoldPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Freight">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <%# Eval("freightprice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="T_charges">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <%# Eval("Tcharges") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <%# Eval("TotalPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ship Name">
                                    <ItemTemplate>
                                        <%# Eval("Shipname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="W_S_Date">
                                    <ItemTemplate>
                                        <%# Eval("Wshipdate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="W_A_Date">
                                    <ItemTemplate>
                                        <%# Eval("Warrivaldate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="DR-LO day">
                                    <ItemTemplate>
                                        <%# Eval("DR-LO day") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PIN-AUC day">
                                    <ItemTemplate>
                                        <%# Eval("PIN-AUC day") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="AUC-LO day">
                                    <ItemTemplate>
                                        <%# Eval("AUC-LO day") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PIN-LO day">
                                    <ItemTemplate>
                                        <%# Eval("PIN-LO day") %>
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
    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtchassis.ClientID %>',
            AllChassisNo: '<%= txtallchno.ClientID %>'
        };
    </script>
</asp:Content>
