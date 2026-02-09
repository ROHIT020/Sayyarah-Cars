<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Unsold-Ship-Car.aspx.cs" Inherits="SayyarahCars.Admin.Unsold_Ship_Car" %>
<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Shipped Car Details </h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Shipping Company</label>
                                <asp:DropDownList ID="ddlShipComp" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static" ></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Country Name</label>
                                <asp:DropDownList ID="ddlCountry" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Client Name</label>
                                <asp:DropDownList ID="ddlClient" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Port Name</label>
                                <asp:DropDownList ID="ddlPort" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Ship Name</label>
                                <asp:DropDownList ID="ddlShipName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Chassis No.</label>
                                <asp:TextBox ID="txtChassisNo" runat="server" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>                    
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Surrender</label>
                                <asp:DropDownList ID="ddlSurrender" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="-1">Surrender</asp:ListItem>
                                    <asp:ListItem Value="1">Yes</asp:ListItem>
                                    <asp:ListItem Value="0">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>  
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Date From</label>
                                <uc:DateSelector ID="txtDateF" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Date To</label>
                                <uc:DateSelector ID="txtDateTo" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">Sort By</label>
                                <asp:DropDownList ID="ddlsortby" runat="server" CssClass="validate chosen-select form-control">
                                    <asp:ListItem Value="10">10</asp:ListItem>
                                    <asp:ListItem Value="50">50</asp:ListItem>
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
                            <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click"  />
                                </div>
                            </div>
                             <div class="col-md-6">
                                <div class="form-group">
                                    <asp:Button ID="btnExport" runat="server" Text="Download Excel" CssClass="btn btn-primary fa-pull-right" OnClick="btnExport_Click" />
                                </div>
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
                                        <asp:Label ID="lblchno" runat="server" Text='<%# Eval("ChassisNo") %>'></asp:Label>
                                         <asp:Label ID="lblpname" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                                         <asp:Label ID="lblcname" runat="server" Text='<%# Eval("ClientName") %>'></asp:Label>
                                          <asp:Label ID="lblShipname" runat="server" Text='<%# Eval("ShipName") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>                               
                                <asp:TemplateField HeaderText=" S.No.">
                                    <ItemTemplate>
                                        <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Auction Date">
                                    <ItemTemplate>
                                        <%# Eval("ADate","{0:dd-MM-yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chassis No">
                                    <ItemTemplate>
                                        <%# Eval("ChassisNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Surrender">
                                    <ItemTemplate>
                                        <%# Eval("Surrender") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Loading">
                                    <ItemTemplate>
                                        <%# Eval("Loading") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Period">
                                    <ItemTemplate>
                                       <%# Eval("Period") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Car Name">
                                    <ItemTemplate>
                                        <%# Eval("ProductName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Client Name">
                                    <ItemTemplate>
                                        <%# Eval("ClientName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="Doc Send Date">
                                    <ItemTemplate>
                                        <%# Eval("DSendDate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Year">
                                    <ItemTemplate>
                                        <%# Eval("MDate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product In">
                                    <ItemTemplate>
                                        <%# Eval("ProductIn","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Sold Price">
                                    <ItemTemplate>
                                        <%# Eval("Sold Price") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Freight Price">
                                    <ItemTemplate>
                                        <%# Eval("FreightCharge") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Recycle">
                                    <ItemTemplate>
                                        <%# Eval("RecycleAmount") %>
                                    </ItemTemplate>
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="Insurance Amount">
                                    <ItemTemplate>
                                        <%# Eval("InsuranceText") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Transaction Amount">
                                    <ItemTemplate>
                                        <%# Eval("Transport") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Total">
                                    <ItemTemplate>
                                        <%# Eval("TotalPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inner Name">
                                    <ItemTemplate>
                                        <%# Eval("IName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inner Weight">
                                    <ItemTemplate>
                                        <%# Eval("IWeight") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Inner Price">
                                    <ItemTemplate>
                                        <%# Eval("Iprice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Consignee Name">
                                    <ItemTemplate>
                                        <%# Eval("ConsigneeName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Consignee Address">
                                    <ItemTemplate>
                                        <%# Eval("Address") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Customer Broker">
                                    <ItemTemplate>
                                        <%# Eval("Customer Broker Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Custom Address">
                                    <ItemTemplate>
                                        <%# Eval("Custom Address") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
                                <asp:TemplateField HeaderText="Loading date">
                                    <ItemTemplate>
                                        <%# Eval("LoadingDate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ship Name">
                                    <ItemTemplate>
                                        <%# Eval("ShipName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Port Name">
                                    <ItemTemplate>
                                        <%# Eval("PortName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="B/L No">
                                    <ItemTemplate>
                                        <%# Eval("BillNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <%--<asp:TemplateField HeaderText="Bizupon Memo">
                                    <ItemTemplate>
                                        <%# Eval("Bizupon Memo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>--%>
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
               <%-- <div class="row mt-4">
                    <div class="col-md-3">
                        <asp:Button ID="btnSurrYes" runat="server" Text="Surrender Yes" CssClass="btn btn-primary"  />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnSurrNo" runat="server" Text="Surrender No" CssClass="btn btn-primary"  />
                    </div> 
                    <div class="col-md-3">
                        <asp:Button ID="btnloadYes" runat="server" Text="Loading Yes" CssClass="btn btn-primary"  />
                    </div>
                    <div class="col-md-3">
                        <asp:Button ID="btnloadNo" runat="server" Text="Loading No" CssClass="btn btn-primary"  />
                    </div>
                   <asp:HiddenField ID="HiddenField1" runat="server" />
                   <asp:HiddenField ID="HiddenField2" runat="server" />
                   <asp:HiddenField ID="HiddenField3" runat="server" />
                </div>--%>
            </div>
        </div>
    </div>   
</asp:Content>
