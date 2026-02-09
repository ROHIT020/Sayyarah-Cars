<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Update-Inner.aspx.cs" Inherits="SayyarahCars.Admin.Update_Inner" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Inner Details </h5>
                </div>
                <div class="card-body">
                    <div class="row ">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Product Type</label>
                                <asp:DropDownList ID="ddlproducttype" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlproducttype_SelectedIndexChanged" data-required="true" data-type="dropdown"  ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Product Name</label>
                                <asp:DropDownList ID="ddlproductname" runat="server" CssClass="chosen-select form-control" data-required="true" data-type="dropdown"  ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Client Name</label>
                                <asp:DropDownList ID="ddlclientname" runat="server" CssClass="chosen-select form-control" data-required="true" data-type="dropdown"  ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Auction House</label>
                                <asp:DropDownList ID="ddlauctionhouse" runat="server" AutoPostBack="true" CssClass="chosen-select form-control" data-required="true" data-type="dropdown"  ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Auction Date</label>
                                <uc:DateSelector ID="txtauctiondate" runat="server" CssClass="form-control"  DataRequired="true" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label"><b>Sort By</b></label>
                                <asp:DropDownList ID="ddlsort" runat="server" CssClass="chosen-select form-control">
                                    <asp:ListItem Value="5">5</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="150">150</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label"><b>Chassis No.</b></label>
                                <asp:TextBox ID="txtChassisNo" runat="server" autocomplete="off" CssClass="form-control" data-required="true" data-type="text" ClientIDMode="Static" data-error-id="txtChassisNoError" placeholder="Enter Chassis No"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label"><b>All Chassis No </b></label>
                                <asp:TextBox ID="txtAllChassisNo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-md-6">
                                <asp:Button ID="btnSave" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnSave_Click" OnClientClick="return ValidateFormData();" />
                            </div>
                            <div class="col-md-6 d-flex justify-content-end">
                                <asp:Button ID="btnDownload" runat="server" Text="Download Excel" CssClass="btn btn-primary" Visible="false" OnClick="btnDownload_Click" />
                            </div>
                        </div>
                    </div>
                </div>
                
            </div>
            <div id="Divserver" runat="server">
                    <div class="row">
                        <div class="col-md-12">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnPageIndexChanging="GridView1_PageIndexChanging"
                            AllowCustomPaging="true" AllowPaging="true" PageSize="10"
                            Width="100%" GridLines="Vertical">
                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                <AlternatingRowStyle BackColor="WhiteSmoke" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
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
                                            <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Chassis No.">
                                        <ItemTemplate>
                                            <%# Eval("ChassisNo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Client Name">
                                        <ItemTemplate>
                                            <%# Eval("ClientName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Product In Date">
                                        <ItemTemplate>
                                            <%# Eval("Adate","{0:dd/MM/yyyy}") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inner Name">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtiname" runat="server" CssClass="form-control txtiname" placeholder="Iname" Text='<%# Eval("Iname") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Inner Weight">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtiweight" runat="server" CssClass="form-control txtiweight" placeholder="Iweight" Text='<%# Eval("Iweight") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Inner Price">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtiprice" runat="server" CssClass="form-control txtiprice " placeholder="Amount" Text='<%# Eval("Iprice") %>'></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <%-- <asp:TemplateField HeaderText="P_I">
                                        <ItemTemplate>
                                            <asp:Label ID="ptype" runat="server">Yes</asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>--%>
                                    <asp:TemplateField HeaderText="Product Image">
                                        <ItemTemplate>
                                            <a href="pimages.aspx?PID=<%# Eval("ID") %>" target="_blank">View Images</a>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#CCCCCC" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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
                            <asp:Button ID="btnUpdate" runat="server" Text="Update Inner" CssClass="btn btn-primary" OnClick="btnUpdate_Click" />
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
</asp:Content>
