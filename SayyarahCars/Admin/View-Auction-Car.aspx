<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="View-Auction-Car.aspx.cs" Inherits="SayyarahCars.Admin.View_Auction_Car" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .table {
            overflow: visible !important;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>View Auction Cars</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Category Type</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static" AutoPostBack="true" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Product Type</label>
                                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Auction House</label>
                                <asp:DropDownList ID="ddlAuctionhouse" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Auction Group</label>
                                <asp:DropDownList ID="ddlAuctionGroup" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Lot No </label>
                                <asp:TextBox ID="txtLotNo" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Auction Sale date</label>
                                <uc:DateSelector ID="txtADate" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Sort By</label>
                                <asp:DropDownList ID="ddlsort" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="150">150</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
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
            </div>
        </div>
    </div>
    <div>
        <div id="Divserver" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle" OnPageIndexChanging="GridView1_PageIndexChanging"
                        AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowDataBound="GridView1_RowDataBound" 
                        AllowCustomPaging="true" AllowPaging="true" PageSize="10"
                        Width="100%" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>                                    
                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("id") %>'></asp:Label>
                                    <asp:Label ID="lblpid" runat="server" Text='<%# Eval("productid") %>'></asp:Label>
                                    <asp:Label ID="lblAID" runat="server" Text='<%# Eval("AuctionId") %>'></asp:Label> 
                                    <asp:Label ID="lblTID" runat="server" Text='<%# Eval("TransportId") %>'></asp:Label> 
                                    
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
                            <asp:TemplateField HeaderText="Old Auction">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlOldAuction" runat="server" CssClass="chosen-select form-control" ReadOnly="true"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Port From">
                                <ItemTemplate>
                                    <%# Eval("PortName")%>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="New Auction">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlNewAuction" runat="server" CssClass="chosen-select form-control" data-live-search="true"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Transport Name">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlTransport" runat="server" CssClass="chosen-select form-control" data-live-search="true"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Auction Date">
                                <ItemTemplate>
                                    <uc:DateSelector ID="txtAuctionDate" runat="server" Text='<%# Eval("ADate") %>' CssClass="form-control" DataType="calendar" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Remark ">
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control" Text='<%# Eval("Remark") %>'></asp:TextBox>
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
                <div class="clearfix"></div>
            </div>
            <div class="row">
                <div class="col-md-3" style="margin-top: 25px">
                    <asp:Button ID="btnDelete" runat="server" Text="Delete Auction" CssClass="btn btn-primary" OnClick="btnDelete_Click" />
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
