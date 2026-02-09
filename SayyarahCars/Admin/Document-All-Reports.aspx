<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Document-All-Reports.aspx.cs" Inherits="SayyarahCars.Admin.Document_All_Reports" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table 
        {
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
                                <label class="form-label">Auction From Date</label>
                                <uc:DateSelector ID="txtAuctionDateFrom" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Auction Date To</label>
                                <uc:DateSelector ID="txtAuctionDateTo" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Auction Name</label>
                                <asp:DropDownList ID="ddlAuctionName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Port From</label>
                                <asp:DropDownList ID="ddlPortFrom" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
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
                                <asp:DropDownList ID="ddlSoldCountry" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Transport</label>
                                <asp:DropDownList ID="ddlTransport" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <%--<div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Another Status</label>
                                <asp:DropDownList ID="ddlAnotherStatus" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>--%>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">No Plate</label>
                                <asp:DropDownList ID="ddlNoPlate" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="0">No Plate</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
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
                                <label class="form-label">Invoice Type</label>
                                <asp:DropDownList ID="ddlInvoiceType" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="0">All</asp:ListItem>
                                    <asp:ListItem Value="1">Normal</asp:ListItem>
                                    <asp:ListItem Value="2">Constructor</asp:ListItem>
                                    <asp:ListItem Value="3">Container</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Reauction</label>
                                <asp:DropDownList ID="ddlReauction" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="0">Reauction</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Car Status</label>
                                <asp:DropDownList ID="ddlCarStatus" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">                                    
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Sort By</label>
                                <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="150">150</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
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

                        <div class="col-lg-5 col-md-5 col-12">
                            <div class="form-group">
                                <label class="form-label">Chassis No</label>
                                <asp:TextBox ID="txtallchno" runat="server" autocomplete="off" TextMode="MultiLine" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnDownload" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Download" OnClick="Button1_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle" OnPageIndexChanging="GridView1_PageIndexChanging"
                        AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="True" PageSize="50" EmptyDataText="No Record Added."
                        Width="100%" GridLines="Vertical">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText=" Select">
                                        <HeaderStyle Width="50px" />
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" Text='<%# Eval("ID") %>' />
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText=" S.No.">
                                        <HeaderStyle Width="50px" />
                                        <ItemTemplate>
                                            <%# Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chassis No.">
                                        <ItemTemplate>
                                            <a href="add-purchase.aspx?id=<%# cmf.Encrypt(Eval("id").ToString()) %>" target="_blank" style="color: Red"><%# Eval("Chassis No") %></a><br />
                                            <%# Eval("carstatus") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%--<asp:TemplateField HeaderText="Another Status">
                                        <ItemTemplate>
                                            <%# Eval("Anstatus") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Product Name">
                                        <ItemTemplate>
                                            <%# Eval("Product Name") %>  / <%# Eval("OrderType") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Loading">
                                        <ItemTemplate>
                                            <%# Eval("Loading") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="A_Date">
                                        <ItemTemplate>
                                            <%# Eval("Adate","{0:dd/MM/yyyy}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="R_Date">
                                        <ItemTemplate>
                                            <%# Eval("Rgdate") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Auction Name">
                                        <ItemTemplate>
                                            <%# Eval("AuctionName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Lot No.">
                                        <ItemTemplate>
                                            <%# Eval("LotNo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shipping Company">
                                        <ItemTemplate>
                                            <asp:Label ID="lblShippingCompany" runat="server" Text='<%# Eval("ShippingCompany") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Port Name">
                                        <ItemTemplate>
                                            <%# Eval("PortFrom") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transport">
                                        <ItemTemplate>
                                            <%# Eval("Transport") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sold Country">
                                        <ItemTemplate>
                                            <%# Eval("countryName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sold Date">
                                        <ItemTemplate>
                                            <%# Eval("Solddate","{0:dd/MM/yyyy}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Invoice No">
                                        <ItemTemplate>
                                            <%# Eval("InvNo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Sold price">
                                        <ItemTemplate>
                                            <%# Eval("soldprice","{0:0,0}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client name">
                                        <ItemTemplate>
                                            <%# Eval("ClientName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="DocToShipDate">
                                        <ItemTemplate>
                                            <%# Eval("DocToShipDate","{0:dd/MM/yyyy}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Rikuji date">
                                        <ItemTemplate>
                                            <%# Eval("Rickujidate","{0:dd/MM/yyyy}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Shonendo">
                                        <ItemTemplate>
                                            <%# Eval("Shonendo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Recycle ammount">
                                        <ItemTemplate>
                                            <%# Eval("Ramount") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="N. Plate">
                                        <ItemTemplate>
                                            <%# Eval("Numberplate") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Document in">
                                        <ItemTemplate>
                                            <%# Eval("Pindate","{0:dd/MM/yyyy}") %>
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
