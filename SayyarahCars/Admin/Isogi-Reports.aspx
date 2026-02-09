<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Isogi-Reports.aspx.cs" Inherits="SayyarahCars.Admin.Isogi_Reports" %>

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
                                <label class="form-label">Chassis No.</label>
                                <asp:TextBox ID="txtChassis" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Shipping Company</label>
                                <asp:DropDownList ID="ddlShippingCompany" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Country</label>
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Client Name</label>
                                <asp:DropDownList ID="ddlClientName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Port Name</label>
                                <asp:DropDownList ID="ddlPortName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Ship Name</label>
                                <asp:DropDownList ID="ddlShipName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                </asp:DropDownList>
                            </div>
                        </div>

                        

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Surrender</label>
                                <asp:DropDownList ID="ddlSurrender" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="0">Surrender</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Date From</label>
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
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="150">150</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Submit" />
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnDownload" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Download" />
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
                            AutoGenerateColumns="False" AllowPaging="True" AllowCustomPaging="True" PageSize="50"
                            EmptyDataText="No Record Added." Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />

                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblpid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                         <asp:Label ID="lblchno" runat="server" Text='<%# Eval("Chassis No") %>'></asp:Label>
                                         <asp:Label ID="lblpname" runat="server" Text='<%# Eval("Product Name") %>'></asp:Label>
                                         <asp:Label ID="lblcname" runat="server" Text='<%# Eval("clientname") %>'></asp:Label>
                                          <asp:Label ID="lblShipname" runat="server" Text='<%# Eval("Shipname") %>'></asp:Label>
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
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Auction date">
                                    <ItemTemplate>
                                       <%# Eval("Adate") %> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chassis No.">
                                    <ItemTemplate>
                                       <%# Eval("Chassis No") %> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Surrender">
                                    <ItemTemplate>
                                         <%# Eval("surrender") %>   
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loading">
                                    <ItemTemplate>
                                         <%# Eval("loading") %>   
                                    </ItemTemplate>
                                </asp:TemplateField>
                                  <asp:TemplateField HeaderText="Period">
                                    <ItemTemplate>
                                       <%# Eval("Period") %>  
                                    </ItemTemplate>
                                </asp:TemplateField> 
                                <asp:TemplateField HeaderText="Car Name">
                                    <ItemTemplate>
                                     <%# Eval("Product Name") %>  
                                    </ItemTemplate>
                                </asp:TemplateField>


                                <%--<asp:TemplateField HeaderText="Client Name">
                                    <ItemTemplate>
                                        <%# Eval("clientname") %>/<%# Eval("CustCode") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>

                                <asp:TemplateField HeaderText="D Send Date">
                                    <ItemTemplate>
                                        <%# Eval("D Send Date") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year">
                                    <ItemTemplate>
                                        <%# Eval("Mdate") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                              
                                <asp:TemplateField HeaderText="Product In">
                                    <ItemTemplate>
                                        <%# Eval("Product In") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Sold Price">
                                    <ItemStyle HorizontalAlign="Right" />
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
                               
                                 <asp:TemplateField HeaderText="Recycle">
                                <ItemTemplate>
                                    <%# Eval("Ramount") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="D_tle">
                                <ItemTemplate>
                                   <%# Eval("dismantling") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="I_AMT">
                                <ItemTemplate>
                                  <%# Eval("Insurance") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="T_AMT">
                                <ItemTemplate>
                                    <%# Eval("Tcharges") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                                <asp:TemplateField HeaderText="Discount">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <%# Eval("Discount") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemStyle HorizontalAlign="Right" />
                                    <ItemTemplate>
                                        <%# Eval("TotalPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inner">
                                    <ItemTemplate>
                                        <%# Eval("Inner") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inner Weight">
                                    <ItemTemplate>
                                        <%# Eval("Inner Weight") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Inner Price">
                                    <ItemTemplate>
                                        <%# Eval("Inner Price") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Consignee Name">
                                    <ItemTemplate>
                                        <%# Eval("Consignee Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Consignee Address">
                                    <ItemTemplate>
                                        <%# Eval("Consignee Address") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Costomer Broker">
                                    <ItemTemplate>
                                        <%# Eval("Customer Broker") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Custom Address">
                                    <ItemTemplate>
                                        <%# Eval("Custom Address") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                   <asp:TemplateField HeaderText="Departure">
                                    <ItemTemplate>
                                       <%# Eval("Loading Date") %> 
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ship Name">
                                    <ItemTemplate>
                                        <%# Eval("Shipname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                 <asp:TemplateField HeaderText="Port Name">
                                    <ItemTemplate>
                                        <%# Eval("PortName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="B/L No">
                                    <ItemTemplate>
                                        <%# Eval("BLno") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bizupon Memo">
                                    <ItemTemplate>
                                        <%# Eval("Bizupon Memo") %>
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
            ChassisNo: '<%= txtChassis.ClientID %>',
        };
    </script>
</asp:Content>
