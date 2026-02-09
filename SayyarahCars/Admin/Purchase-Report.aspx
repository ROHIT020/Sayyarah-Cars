<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Purchase-Report.aspx.cs" Inherits="SayyarahCars.Admin.Purchase_Report" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Purchase Report</h5>
                </div>
                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Shipping Company</label>
                                        <asp:DropDownList ID="ddlShippingCom" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Auction House</label>
                                        <asp:DropDownList ID="ddlAyctionH" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="control-label">Chassis No.</label>
                                        <asp:TextBox ID="txtChassisNo" runat="server" CssClass="form-control"></asp:TextBox>
                                        <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label">From Date</label>
                                        <uc:DateSelector ID="txtFromDate" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />

                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label">To Date</label>
                                        <uc:DateSelector ID="txToDate" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />

                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="control-label"><b>Sort By</b></label>
                                        <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="chosen-select form-control">
                                            <asp:ListItem Value="100">100</asp:ListItem>
                                            <asp:ListItem Value="150">150</asp:ListItem>
                                            <asp:ListItem Value="200">200</asp:ListItem>
                                            <asp:ListItem Value="500">500</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                            </div>
                            <div class="col-md-12">
                                <div class="row">
                                    <div class="col-md-10">
                                        <div class="form-group">
                                            <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary mt-4" OnClick="btnSubmit_Click" />
                                        </div>
                                    </div>

                                    <div class="col-md-2">
                                        <div class="form-group">
                                            <asp:Button ID="btnDowExel" runat="server" Text="Download Exel" CssClass="btn btn-primary mt-4" OnClick="btnDowExel_Click" />
                                        </div>
                                    </div>
                                </div>
                            </div>


                            <div class="row" runat="server" id="Divb" visible="false">
                                <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                                    <asp:GridView ID="GridView1" runat="server" CellPadding="3" CssClass="table table-striped align-middle"
                                        ForeColor="Black" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                        GridLines="Vertical" AllowPaging="True" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging">
                                        <Columns>

                                            <asp:TemplateField HeaderText=" S.No.">
                                                <HeaderStyle Width="50px" />
                                                <ItemTemplate>
                                                    <%# Container.DataItemIndex + 1 %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="ID">
                                                <HeaderStyle Width="50px" />
                                                <ItemTemplate>
                                                    <%# Eval("ID") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Product-Name">
                                                <ItemTemplate>
                                                    <%# Eval("ProductName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Chassis No">
                                                <ItemTemplate>
                                                    <%# Eval("ChassisNo") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                            <asp:TemplateField HeaderText="Auction Date">
                                                <ItemTemplate>
                                                    <%# Eval("Adate") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="S_Company Name">
                                                <ItemTemplate>
                                                    <%# Eval("Shipping Company") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Ship Name">
                                                <ItemTemplate>
                                                    <%# Eval("ShipName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Departure-Date">
                                                <ItemTemplate>
                                                    <%# Eval("DepartureDate") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Arrival-Date">
                                                <ItemTemplate>
                                                    <%# Eval("ArrivalDate") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>


                                        </Columns>
                                        <FooterStyle BackColor="#CCCCCC" />
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
                        </div>
                    </div>
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
