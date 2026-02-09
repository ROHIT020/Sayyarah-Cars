<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Document-Rikuji-Reports.aspx.cs" Inherits="SayyarahCars.Admin.Document_Rikuji_Reports" %>

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
                                <label class="form-label">Chassis No</label>
                                <asp:TextBox ID="txtchassis" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Port Name</label>
                                <asp:DropDownList ID="ddlPortName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
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

                        <div class="col-lg-2 col-md-2 col-12">
                            <div class="form-group">
                                <label class="form-label">Sort By</label>
                                <asp:DropDownList ID="ddlSortBy" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="5000">5000</asp:ListItem>
                                    <asp:ListItem Value="10000">10000</asp:ListItem>
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
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle" OnPageIndexChanging="GridView1_PageIndexChanging"
                            AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="True" PageSize="50" EmptyDataText="No Record Added."
                            Width="100%" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText=" S.No.">
                                    <HeaderStyle Width="50px" />
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chassis No">
                                    <ItemTemplate>
                                        <a href="add-purchase.aspx?Id=<%# cmf.Encrypt(Eval("ID").ToString()) %>" target="_blank" style="color: Red"><%# Eval("Chassis No")    %></a>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <%# Eval("Product Name") %>  / <%# Eval("OrderType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S-Company">
                                    <ItemTemplate>
                                        <%# Eval("Shipping Company") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="PortFrom">
                                    <ItemTemplate>
                                        <%# Eval("PortFrom") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sold Price">
                                    <ItemTemplate>
                                        <%# Eval("Sold Price") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Name">
                                    <ItemTemplate>
                                        <%# Eval("Client Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Rikujidate">
                                    <ItemTemplate>
                                        <%# Eval("Rikujidate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="R_Date">
                                    <ItemTemplate>
                                        <%# Eval("Rgdate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="M Date">
                                    <ItemTemplate>
                                        <%# Eval("Manufacturer Date") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Urgent">
                                    <ItemTemplate>
                                        <%# Eval("Urgent") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <%--<asp:TemplateField HeaderText="Another Status">
                                    <ItemTemplate>
                                        <%# Eval("Anstatus") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Sale Country">
                                    <ItemTemplate>
                                        <%# Eval("countryName") %>
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

        };
    </script>
</asp:Content>
