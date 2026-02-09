<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Update-Shipping-Details.aspx.cs" Inherits="SayyarahCars.Admin.Update_Shipping_Details" %>

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
                    <h5>Update Shipping Details</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Category</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Select Product</label>
                                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Auction House</label>
                                <asp:DropDownList ID="ddlAuctionhouse" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Auction date</label>
                                <uc:DateSelector ID="txtADate" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
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
                                            <asp:Label ID="lblTID" runat="server" Text='<%# Eval("TransportId") %>'></asp:Label>
                                            <asp:Label ID="lblSID" runat="server" Text='<%# Eval("ShippingId") %>'></asp:Label>
                                            <asp:Label ID="lblPT" runat="server" Text='<%# Eval("PortToId") %>'></asp:Label>
                                             <asp:Label ID="lblPF" runat="server" Text='<%# Eval("PortFromId") %>'></asp:Label>
                                            <asp:Label ID="lblscid" runat="server" Text='<%# Eval("CountryId") %>'></asp:Label>
                                                  
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
                                    <asp:TemplateField HeaderText="Product Name">
                                        <ItemTemplate>
                                            <%# Eval("ProductName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Transport">
                                        <ItemTemplate>
                                            <%#Eval("TransportName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="S_Company">
                                        <ItemTemplate>
                                            <%# Eval("ShippingName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Port From">
                                        <ItemTemplate>
                                             <%# Eval("Portfrom") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Port To">
                                        <ItemTemplate>
                                            <%# Eval("PortTo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="In Auction">
                                        <ItemTemplate>
                                            <%--<%# Eval("fDkescription") %>--%>
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
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Transport Name</label>
                                <asp:DropDownList ID="ddlTransport" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 25px">
                            <asp:Button ID="UpdateTransport" runat="server" Text="Update Transport" CssClass="btn btn-primary" OnClick="UpdateTransport_Click" />
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Shipping Company</label>
                                <asp:DropDownList ID="ddlshipping" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 25px">
                            <asp:Button ID="Updateshipping" runat="server" Text="Update Shipping" CssClass="btn btn-primary" OnClick="Updateshipping_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Port From</label>
                                <asp:DropDownList ID="ddlPortFrom" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 25px">
                            <asp:Button ID="UpdatePortfrom" runat="server" Text="Update Port From" CssClass="btn btn-primary" OnClick="UpdatePortfrom_Click" />
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Port To</label>
                                <asp:DropDownList ID="ddlPortTo" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 25px">
                            <asp:Button ID="UpdatePortTo" runat="server" Text="Update Port To" CssClass="btn btn-primary" OnClick="UpdatePortTo_Click" />
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Sold Country</label>
                                <asp:DropDownList ID="ddlsoldcountry" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3" style="margin-top: 25px">
                            <asp:Button ID="UpdateSoldCountry" runat="server" Text="Update Sold Country" CssClass="btn btn-primary" OnClick="UpdateSoldCountry_Click"  />
                        </div>
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
    <script src="../Contents/admin/js/fetchChassisNo.js" type="text/javascript"></script>
</asp:Content>
