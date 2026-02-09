<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Print-Client-Voucher.aspx.cs" Inherits="SayyarahCars.Admin.Print_Client_Voucher" %>

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
                                <label class="form-label">Country Name</label>
                                <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Select Client</label>
                                <asp:DropDownList ID="ddlClient" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Product Name</label>
                                <asp:TextBox ID="txtProductName" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Chassis No</label>
                                <asp:TextBox ID="txtChassisNo" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Voucher No</label>
                                <asp:TextBox ID="txtVoucherNo" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Date from</label>
                                <uc:DateSelector ID="txtDateFrom" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
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
                                <label class="form-label">Sort By</label>
                                <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="5000">5000</asp:ListItem>
                                    <asp:ListItem Value="10000">10000</asp:ListItem>
                                    <asp:ListItem Value="20000">20000</asp:ListItem>
                                    <asp:ListItem Value="50000">50000</asp:ListItem>
                                    <asp:ListItem Value="100000">100000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Search" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="True" PageSize="50" EmptyDataText="No Record Added."
                        
                        Width="100%" GridLines="Vertical">
                        <Columns>

                            <asp:TemplateField HeaderText="ID" Visible="false">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <%# Eval("ID") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText=" S.No.">
                                <HeaderStyle Width="50px" />
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Auction Date">
                                <ItemTemplate>
                                    <asp:Label ID="lblportname" runat="server" Text='<%# Eval("Auction Date","{0:dd/MM/yyyy}") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Auction Name">
                                <ItemTemplate>
                                    <asp:Label ID="lblauctionname" runat="server" Text='<%# Eval("Auction Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Lot No.">
                                <ItemTemplate>
                                    <asp:Label ID="lbllno" runat="server" Text='<%# Eval("LotNo") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Product Name">
                                <ItemTemplate>
                                    <asp:Label ID="lbllpname" runat="server" Text='<%# Eval("Product Name") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chassis">
                                <ItemTemplate>
                                    <asp:Label ID="lblcno" runat="server" Text='<%# Eval("Chassis No") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Auction Source">
                                <ItemTemplate>
                                    <%# Eval("Auctionsource") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Urgent">
                                <ItemTemplate>
                                    <asp:Label ID="lblurgent" runat="server" Text='<%# Eval("Urgent") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="M Date">
                                <ItemTemplate>
                                    <%# Eval("Manufacturer Date","{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remark">
                                <ItemTemplate>
                                    <asp:Label ID="lblShippingCompany" runat="server" Text='<%# Eval("AuctionRemark") %>'></asp:Label>
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
    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtChassisNo.ClientID %>',
        };
    </script>
</asp:Content>
