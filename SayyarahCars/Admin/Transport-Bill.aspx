<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Transport-Bill.aspx.cs" Inherits="SayyarahCars.Admin.Transport_Bill" %>

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
                    <div class="row">
                        <h5>Transport Bill</h5>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="control-label">Category</label>
                                <asp:DropDownList ID="ddlCategory" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static" OnSelectedIndexChanged="ddlCategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>


                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="control-label">Select Product</label>
                                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="control-label">Auction House</label>
                                <asp:DropDownList ID="ddlAuctionH" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="control-label">Transport Name</label>
                                <asp:DropDownList ID="ddlTransport" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Transport Date</label>
                                <uc:DateSelector ID="txttransport" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />
                                <%-- <p id="errADate" class="error-message">Please enter Auction Date</p>--%>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Sort By</b></label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="chosen-select form-control">
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="1500">1500</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="5000">5000</asp:ListItem>
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
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary mt-4" OnClick="btnSubmit_Click" />
                            </div>
                        </div>



                        <div class="row" runat="server" id="Divb" visible="false">
                            <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                                <asp:GridView ID="GridView1" runat="server" CellPadding="3" CssClass="table table-striped align-middle"
                                    ForeColor="Black" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                    GridLines="Vertical" AllowCustomPaging="true" AllowPaging="True" PageSize="1000" OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>

                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblID" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                                <asp:Label ID="lblTID" runat="server" Text='<%# Eval("TID") %>'></asp:Label>
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
                                        <asp:TemplateField HeaderText="Chassis No">
                                            <ItemTemplate>
                                                <%# Eval("Cno") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Transport">
                                            <ItemTemplate>
                                                <%# Eval("TransportName") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Debit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txttrcharges" runat="server" Text="0" CssClass="form-control"></asp:TextBox>
                                                <br />
                                                <asp:TextBox ID="txttransporttax" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Debit(Non Tax)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtothercharges" runat="server" Text="0" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>

                                        <asp:TemplateField HeaderText="Credit">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txttdiscount" runat="server" Text="0" CssClass="form-control"></asp:TextBox>
                                                <br />
                                                <asp:TextBox ID="txtotheratax" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Credit(Non Tax)">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtexamount" runat="server" Text="0" CssClass="form-control"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Total">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txttotal" runat="server" CssClass="form-control" Text="0"></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Remark">
                                            <ItemTemplate>
                                                <asp:TextBox ID="txtRemark" runat="server" CssClass="form-control"></asp:TextBox>
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

                                <asp:HiddenField ID="HiddenField1" runat="server" Value="1" />

                            </div>

                            <div class="col-lg-4 col-md-6 col-12">
                                <div class="form-group">
                                    <label class="form-label">Transport Bill Date</label>
                                    <uc:DateSelector ID="txtDate" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />

                                </div>
                            </div>

                            <div class="col-lg-4 col-md-6 col-12">
                                <div class="form-group mb-0">
                                    <asp:Button ID="UpdateTranportBill" runat="server" Text="Update Transport Bill" CssClass="btn btn-primary mt-4" OnClick="UpdateTranportBill_Click" />
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

    <script type="text/javascript">

        $("#<%= GridView1.ClientID %> input[id*='txttrcharges']").change(function () {
            var TRP = ($("[id*=txttrcharges]", $(this).closest("tr")).val());
            var TRPtax = (parseFloat(TRP) / 10);
            $("[id*=txttransporttax]", $(this).closest("tr")).val(TRPtax)
            var Othch = ($("[id*=txttdiscount]", $(this).closest("tr")).val());
            var Othchtax = (parseFloat(Othch) / 10);
            $("[id*=txtotheratax]", $(this).closest("tr")).val(Othchtax)
            var odebit = ($("[id*=txtothercharges]", $(this).closest("tr")).val());
            var ocredit = ($("[id*=txtexamount]", $(this).closest("tr")).val());
            var total = parseFloat(TRP) + parseFloat(TRPtax) + parseFloat(odebit) - parseFloat(Othch) - parseFloat(Othchtax) - parseFloat(ocredit);
            $("[id*=txttotal]", $(this).closest("tr")).val(total)
        });

        $("#<%= GridView1.ClientID %> input[id*='txttdiscount']").change(function () {

            var TRP = ($("[id*=txttrcharges]", $(this).closest("tr")).val());
            var TRPtax = (parseFloat(TRP) / 10);
            $("[id*=txttransporttax]", $(this).closest("tr")).val(TRPtax)

            var Othch = ($("[id*=txttdiscount]", $(this).closest("tr")).val());
            var Othchtax = (parseFloat(Othch) / 10);
            $("[id*=txtotheratax]", $(this).closest("tr")).val(Othchtax)

            var odebit = ($("[id*=txtothercharges]", $(this).closest("tr")).val());
            var ocredit = ($("[id*=txtexamount]", $(this).closest("tr")).val());
            var total = parseFloat(TRP) + parseFloat(TRPtax) + parseFloat(odebit) - parseFloat(Othch) - parseFloat(Othchtax) - parseFloat(ocredit);
            $("[id*=txttotal]", $(this).closest("tr")).val(total)

        });

        $("#<%= GridView1.ClientID %> input[id*='txtothercharges']").change(function () {

            var TRP = ($("[id*=txttrcharges]", $(this).closest("tr")).val());
            var TRPtax = (parseFloat(TRP) / 10);
            $("[id*=txttransporttax]", $(this).closest("tr")).val(TRPtax)

            var Othch = ($("[id*=txttdiscount]", $(this).closest("tr")).val());
            var Othchtax = (parseFloat(Othch) / 10);
            $("[id*=txtotheratax]", $(this).closest("tr")).val(Othchtax)

            var odebit = ($("[id*=txtothercharges]", $(this).closest("tr")).val());
            var ocredit = ($("[id*=txtexamount]", $(this).closest("tr")).val());
            var total = parseFloat(TRP) + parseFloat(TRPtax) + parseFloat(odebit) - parseFloat(Othch) - parseFloat(Othchtax) - parseFloat(ocredit);
            $("[id*=txttotal]", $(this).closest("tr")).val(total)
        });

        $("#<%= GridView1.ClientID %> input[id*='txtexamount']").change(function () {

            var TRP = ($("[id*=txttrcharges]", $(this).closest("tr")).val());
            var TRPtax = (parseFloat(TRP) / 10);
            $("[id*=txttransporttax]", $(this).closest("tr")).val(TRPtax)

            var Othch = ($("[id*=txttdiscount]", $(this).closest("tr")).val());
            var Othchtax = (parseFloat(Othch) / 10);
            $("[id*=txtotheratax]", $(this).closest("tr")).val(Othchtax)

            var odebit = ($("[id*=txtothercharges]", $(this).closest("tr")).val());
            var ocredit = ($("[id*=txtexamount]", $(this).closest("tr")).val());
            var total = parseFloat(TRP) + parseFloat(TRPtax) + parseFloat(odebit) - parseFloat(Othch) - parseFloat(Othchtax) - parseFloat(ocredit);
            $("[id*=txttotal]", $(this).closest("tr")).val(total)
        });


    </script>

</asp:Content>
