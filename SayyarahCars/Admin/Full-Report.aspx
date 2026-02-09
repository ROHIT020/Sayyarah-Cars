<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Full-Report.aspx.cs" Inherits="SayyarahCars.Admin.Full_Report" %>

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
                                <label class="form-label">Auction Date</label>
                                <uc:DateSelector ID="txtAuctionDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Auction Name</label>
                                <asp:DropDownList ID="ddlAuctionName" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Port From</label>
                                <asp:DropDownList ID="ddlPortFrom" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
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
                                <label class="form-label">Rikuji Date</label>
                                <uc:DateSelector ID="txtRikujiDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
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
                                <label class="form-label">Shipping</label>
                                <asp:DropDownList ID="ddlShipping" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
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
                                <label class="form-label">Sort By</label>
                                <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
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
                             AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                            PageSize="50" EmptyDataText="No Record Added." Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText=" S.No.">
                                    <HeaderStyle Width="50px" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Chassis No.">
                                    <ItemTemplate>
                                        <%# Eval("Chassis No") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <%# Eval("Product Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Port History">
                                    <ItemTemplate>
                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Port Name">
                                                    <ItemTemplate>
                                                        <%# Eval("PortFrom") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Change Date">
                                                    <ItemTemplate>
                                                        <%# Eval("Change Date") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Change By">
                                                    <ItemTemplate>
                                                        <%# Eval("Updated By") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Shipping History">
                                    <ItemTemplate>
                                        <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Shipping Company">
                                                    <ItemTemplate>
                                                        <%# Eval("Shipping Company") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Change Date">
                                                    <ItemTemplate>
                                                        <%# Eval("Change Date") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Change By">
                                                    <ItemTemplate>
                                                        <%# Eval("Updated By") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Auction Date">
                                    <ItemTemplate>
                                        <%# Eval("Adate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Transport">
                                    <ItemTemplate>
                                        <%# Eval("Transport") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Inquiry">
                                    <ItemTemplate>
                                        <%# Eval("Inqdate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Another Status">
                                    <ItemTemplate>
                                        <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" BorderStyle="Solid" GridLines="Horizontal">
                                            <Columns>
                                                <asp:TemplateField HeaderText="Status">
                                                    <ItemTemplate>
                                                        <%# Eval("AStatus") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Rikuji Date">
                                                    <ItemTemplate>
                                                        <%# Eval("rikujidate") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Chnage Date">
                                                    <ItemTemplate>
                                                        <%# Eval("Change Date") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Change By">
                                                    <ItemTemplate>
                                                        <%# Eval("Updated By") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Product IN">
                                    <ItemTemplate>
                                        <%# Eval("Pindate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="W Product In">
                                    <ItemTemplate>
                                        <%# Eval("Wpindate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Arrival Date">
                                    <ItemTemplate>
                                        <%# Eval("Arrival Date") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sold Country">
                                    <ItemTemplate>
                                        <%# Eval("SoldCountry") %>
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

                                <asp:TemplateField HeaderText="ShippingCompany">
                                    <ItemTemplate>
                                        <asp:Label ID="lblShippingCompany" runat="server" Text='<%# Eval("ShippingCompany") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Port From">
                                    <ItemTemplate>
                                        <%# Eval("PortFrom") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Yard Name">
                                    <ItemTemplate>
                                        <%# Eval("YardName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="PortRemark">
                                    <ItemTemplate>
                                        <%# Eval("PortRemark") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Port To">
                                    <ItemTemplate>
                                        <%# Eval("PortTo") %>
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
</asp:Content>
