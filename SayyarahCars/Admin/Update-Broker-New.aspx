<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Update-Broker-New.aspx.cs" Inherits="SayyarahCars.Admin.Update_Broker_New" %>

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
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Broker</h5>
                </div>
                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Category</label>
                                        <asp:DropDownList ID="ddlCategory" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Select Product</label>
                                        <asp:DropDownList ID="ddlProduct" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Client Name</label>
                                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Ship Name</label>
                                        <asp:DropDownList ID="ddlShip" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Auction House</label>
                                        <asp:DropDownList ID="ddlAuctionH" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Auction Date</label>
                                        <uc:DateSelector ID="txtADate" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />

                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="control-label"><b>Sort By</b></label>
                                        <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="chosen-select form-control">
                                            <asp:ListItem Value="500">500</asp:ListItem>
                                            <asp:ListItem Value="1000">1000</asp:ListItem>
                                            <asp:ListItem Value="1500">1500</asp:ListItem>
                                            <asp:ListItem Value="2000">2000</asp:ListItem>
                                            <asp:ListItem Value="5000">5000</asp:ListItem>
                                            <asp:ListItem Value="10000">10000</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-12">
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
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group mb-0">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary mt-4" OnClick="btnSubmit_Click" />
                                    </div>
                                </div>

                                <div class="row" runat="server" id="Divb" visible="false">
                                    <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                                        <asp:GridView ID="GridView1" runat="server" CellPadding="3" CssClass="table table-striped align-middle"
                                            ForeColor="Black" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                            GridLines="Vertical" AllowCustomPaging="true" AllowPaging="True" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging">
                                            <Columns>

                                                <asp:TemplateField Visible="false">
                                                    <ItemTemplate>
                                                        <asp:Label ID="lblID" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                        
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

                                                <asp:TemplateField HeaderText="Chassis">
                                                    <ItemTemplate>
                                                        <%# Eval("ChassisNo") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="ClienName">
                                                    <ItemTemplate>
                                                        <%# Eval("ClientName") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Broker Details Name">
                                                    <ItemTemplate>
                                                        <%# Eval("BrokerName") %>
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
                                    <div class="row">
                                        <div class="col-lg-3 col-md-3 col-12">
                                            <div class="form-group">
                                                <label class="form-label">Broker Name</label>
                                                <asp:DropDownList ID="ddlbrokerName" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                            </div>
                                        </div>

                                        <div class="col-md-3 ">
                                            <div class="form-group mb-0">
                                                <asp:Button ID="btnUpdate" runat="server" Text="Update Broker Same Broker Name" CssClass="btn btn-primary mt-4" OnClick="btnUpdate_Click" />
                                            </div>
                                        </div>
                                    </div>
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
            AllChassisNo: '<%= txtAllChassisNo.ClientID %>'
        };
    </script>

</asp:Content>
