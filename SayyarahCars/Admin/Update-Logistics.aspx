<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Update-Logistics.aspx.cs" Inherits="SayyarahCars.Admin.Update_Logistics" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table {
            overflow: visible
        }
    </style>

    <script type="text/javascript">
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>

    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Country Name</label>
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddlCountryError" class="error-message">Please select country name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Client Name</label>
                                <asp:DropDownList ID="ddlClientName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Auction House</label>
                                <asp:DropDownList ID="ddlAuctionHouse" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                                <p id="ddlAuctionHouseError" class="error-message">Please select auction house</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Shipping Company</label>
                                <asp:DropDownList ID="ddlShippingCompany" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Ship Name</label>
                                <asp:DropDownList ID="ddlShipName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
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
                                <label class="form-label">Transport</label>
                                <asp:DropDownList ID="ddlTransport" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Broker</label>
                                <asp:DropDownList ID="ddlBroker" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Urgent</label>
                                <asp:DropDownList ID="ddlUrgent" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="100"> Urgent </asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">No Plate</label>
                                <asp:DropDownList ID="ddlNoPlate" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="100"> Urgent </asp:ListItem>
                                    <asp:ListItem Value="100"> No Plate </asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Surrender</label>
                                <asp:DropDownList ID="ddlSurrender" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="100">Surrender</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
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
                                <label class="form-label">Rikuji Date</label>
                                <uc:DateSelector ID="txtRikujiDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Product In</label>
                                <asp:DropDownList ID="ddlProductIn" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="1">Product In</asp:ListItem>
                                    <asp:ListItem Value="2">Yes</asp:ListItem>
                                    <asp:ListItem Value="3">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Loading</label>
                                <asp:DropDownList ID="ddlLoading" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="0">Select Loading </asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Car Status</label>
                                <asp:DropDownList ID="ddlCarStatus" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="100">All</asp:ListItem>
                                    <asp:ListItem Value="0">Unsold</asp:ListItem>
                                    <asp:ListItem Value="1">Unsold Ship</asp:ListItem>
                                    <asp:ListItem Value="2">Ship Back</asp:ListItem>
                                    <asp:ListItem Value="4">Reserved</asp:ListItem>
                                    <asp:ListItem Value="5">Sold</asp:ListItem>
                                    <asp:ListItem Value="3">Cancel By Client</asp:ListItem>
                                    <asp:ListItem Value="6">Client Changed</asp:ListItem>
                                    <asp:ListItem Value="7">Shipped</asp:ListItem>
                                    <asp:ListItem Value="8">Delivered</asp:ListItem>
                                    <asp:ListItem Value="9">Cancel</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Sort By</label>
                                <asp:DropDownList ID="ddlShortBy" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="50">50</asp:ListItem>
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

                        <div class="col-lg-9 col-md-9 col-12">
                            <div class="form-group">
                                <label class="form-label">Chassis No</label>
                                <asp:TextBox ID="txtallchno" runat="server" autocomplete="off" TextMode="MultiLine" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" AllowPaging="True" PageSize="10" EmptyDataText="No Record Added."
                        Width="100%" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblpid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    <asp:Label ID="lblRickujidate" runat="server" Text='<%# Eval("Rickujidate") %>'></asp:Label>
                                    <asp:Label ID="lbldsdate" runat="server" Text='<%# Eval("Dsdate") %>'></asp:Label>
                                    <asp:Label ID="lbluregid" runat="server" Text='<%# Eval("UserId") %>'></asp:Label>
                                    <%--<asp:Label ID="lblaremark" runat="server" Text='<%# Eval("Aremark") %>'></asp:Label>
                                    <asp:Label ID="lblRremark" runat="server" Text='<%# Eval("Rremark") %>'></asp:Label>
                                    <asp:Label ID="lblPremark" runat="server" Text='<%# Eval("Premark") %>'></asp:Label>
                                    <asp:Label ID="lblNplate" runat="server" Text='<%# Eval("Nplate") %>'></asp:Label>
                                    <asp:Label ID="lblNPRemark" runat="server" Text='<%# Eval("NPRemark") %>'></asp:Label>
                                    <asp:Label ID="lbloremark" runat="server" Text='<%# Eval("Oremark") %>'></asp:Label>--%>
                                    <asp:Label ID="lblshipid" runat="server" Text='<%# Eval("ShipId") %>'></asp:Label>
                                    <asp:Label ID="lblShipname" runat="server" Text='<%# Eval("ShipName") %>'></asp:Label>
                                    <asp:Label ID="lbluid" runat="server" Text='<%# Eval("UID") %>'></asp:Label>
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
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <table style="width: 100%">
                                        <tr>
                                            <td><b>Urgent</b></td>
                                            <td><%# Eval("Urgent") %></td>
                                            <td><b>Chassis No </b></td>
                                            <td><%# Eval("ChassisNo") %> </td>
                                            <td><b>Product Name </b></td>
                                            <td><%# Eval("ProductName") %>/<%# Eval("OrderType") %>  </td>

                                        </tr>
                                        <tr>
                                            <td><b>Lot No</b></td>
                                            <td><%# Eval("LotNo") %></td>
                                            <td><b>Year</b></td>
                                            <td><%# Eval("MDate","{0:MM/dd/yyyy}") %></td>
                                            <td><b>Auction</b></td>
                                            <td><%# Eval("Auction Name") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>Source</b></td>
                                            <td><%# Eval("Auction Source") %></td>
                                            <td><b>Auction ID</b></td>
                                            <td><%# Eval("AuctionID") %></td>
                                            <td><b>Sold Country</b></td>
                                            <td><%# Eval("CountryName") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>Client Name</b></td>
                                            <td><%# Eval("clientname") %></td>
                                            <td><b>Sold Price</b></td>
                                            <td><%# Eval("FinalSoldPrice") %></td>
                                            <td><b>Freight Price</b></td>
                                            <td><%# Eval("FreightCharge") %></td>

                                        </tr>
                                        <tr>
                                            <td><b>TotalPrice</b></td>
                                            <td><%# Eval("TotalPrice") %></td>
                                            <td><b>Transport </b></td>
                                            <td><%# Eval("TransportName")%></td>
                                            <td><b>Plan Date</b></td>
                                            <td><%# Eval("PPidate","{0:MM/dd/yyyy}") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>W-P-I Date</b></td>
                                            <td><%# Eval("Wpindate") %></td>
                                            <td><b>P-I Date</b></td>
                                            <td><%# Eval("Pindate") %></td>
                                            <td><b>W-S Date</b></td>
                                            <td><%# Eval("Wshipdate") %></td>
                                        </tr>

                                        <tr>
                                            <td><b>W-A Date</b></td>
                                            <td><%# Eval("Warrivaldate") %></td>
                                            <td><b>Rikuji Date </b></td>
                                            <td><%# Eval("Rickujidate") %></td>
                                            <td><b>D-S Date</b></td>
                                            <td><%# Eval("Dsdate") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>S_Company </b></td>
                                            <td><%# Eval("SHipping Company") %> </td>
                                            <td><b>Shipname</b></td>
                                            <td><%# Eval("Shipname") %></td>
                                            <td><b>L Date</b></td>
                                            <td><%# Eval("Ldate") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>A Date</b></td>
                                            <td><%# Eval("SAdate") %></td>
                                            <td><b>Port From </b></td>
                                            <td><%# Eval("PortFrom") %> </td>
                                            <td><b>Port To </b></td>
                                            <td><%# Eval("PortTo") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>Surrender</b></td>
                                            <td><%# Eval("surrender") %></td>
                                            <td><b>Loading</b></td>
                                            <td><%# Eval("loading") %></td>
                                            <td><b>Customer Broker</b></td>
                                            <td><%# Eval("Customer Broker") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>Custom Address</b></td>
                                            <td><%# Eval("Custom Address") %></td>
                                            <td><b>Consignee Name</b></td>
                                            <td><%# Eval("ConsigneeName") %></td>
                                            <td><b>Consignee Address</b></td>
                                            <td><%# Eval("Consignee Address") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>CFS</b></td>
                                            <td><%# Eval("CFS") %></td>
                                            <td><b>Notify</b></td>
                                            <td><%--<%# Eval("Notify") %>--%></td>
                                            <td><b>N Contact</b></td>
                                            <td><%--<%# Eval("Notify Contact") %>--%></td>
                                        </tr>
                                        <tr>
                                            <td><b>N-E Address</b></td>
                                            <td><%--<%# Eval("Notify Email Address") %>--%></td>
                                            <td><b>New Auction</b></td>
                                            <td><%# Eval("New Auction") %></td>
                                            <td><b>A Date</b></td>
                                            <td><%# Eval("NAdate") %></td>
                                        </tr>
                                        <tr>
                                            <td><b>Auction No.</b></td>
                                            <td><%--<%# Eval("Ano") %>--%></td>
                                            <td><b>Yard Name</b></td>
                                            <td><%# Eval("Yardname") %></td>
                                            <td><b>ReAuction</b></td>
                                            <td><%# Eval("ReAuction") %></td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <asp:TextBox ID="txtAremark" runat="server" placeholder="Auction Remark" CssClass="form-control" Text='<%# Eval("AuctionRemark") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtRremark" runat="server" placeholder="Rikshaw Remark" CssClass="form-control" Text='<%# Eval("RikshawRemark") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtportremrk" runat="server" placeholder="Port Remark" CssClass="form-control" Text='<%# Eval("PortRemark") %>'></asp:TextBox>
                                            </td>
                                            <td>
                                                <asp:TextBox ID="txtnpalte" runat="server" placeholder="No Plate" CssClass="form-control" Text='<%# Eval("NoPlate") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtNPRemark" runat="server" placeholder="No Plate Remark" CssClass="form-control" Text='<%# Eval("NoPlateRemark") %>'></asp:TextBox></td>
                                            <td>
                                                <asp:TextBox ID="txtoremark" runat="server" placeholder="Other Remark" CssClass="form-control" Text='<%# Eval("OtherRemark") %>'></asp:TextBox></td>
                                        </tr>
                                    </table>
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

        <div id="divUpdateFooter" runat="server">
            <div class="col-lg-12 col-md-12 col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Product In Date</label>
                                    <uc:DateSelector ID="txtProductInDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Wish Plan Date</label>
                                    <uc:DateSelector ID="txtWishPlanDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Wish P In Date</label>
                                    <uc:DateSelector ID="txtWishPInDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Wish Ship Date</label>
                                    <uc:DateSelector ID="txtWishShipDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Wish Arrival Date</label>
                                    <uc:DateSelector ID="txtWishArrivalDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Ship Name</label>
                                    <asp:DropDownList ID="ddlShipNme" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Surrender</label>
                                    <asp:RadioButtonList ID="RadioSurrender" runat="server" CssClass="form-control" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Value="0">&nbsp;Yes &nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="1">&nbsp;No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="col-lg-3 col-md-3 col-12">
                                <div class="form-group">
                                    <label class="form-label">Loading</label>
                                    <asp:RadioButtonList ID="RadioLoading" runat="server" CssClass="form-control" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Value="0">&nbsp;Yes &nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="1">&nbsp;No</asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>

                            <div class="col-lg-1 col-md-1 col-12">
                                <asp:Button ID="btnUpdate" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Update" OnClick="btnUpdate_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="HiddenField1" runat="server" />


    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtchassis.ClientID %>',
            AllChassisNo: '<%= txtallchno.ClientID %>'
        };
    </script>
</asp:Content>
