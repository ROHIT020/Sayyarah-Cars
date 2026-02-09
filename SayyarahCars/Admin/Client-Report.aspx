<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Client-Report.aspx.cs" Inherits="SayyarahCars.Admin.Client_Report" %>

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
                    <h5>Client Report</h5>
                </div>
                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Client Name</label>
                                        <asp:DropDownList ID="ddlClient" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Voucher type</label>
                                        <asp:DropDownList ID="ddlVoucher" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                            <asp:ListItem Value="A">All  Voucher</asp:ListItem>
                                            <asp:ListItem Value="J">General  Voucher</asp:ListItem>
                                            <asp:ListItem Value="R">Receipt  Voucher</asp:ListItem>
                                            <asp:ListItem Value="P">Payment Voucher</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Date From</label>
                                        <uc:DateSelector ID="txtDFrom" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />

                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Date To</label>
                                        <uc:DateSelector ID="txtDTo" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />

                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group mb-0">
                                        <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-primary mt-4" OnClick="btnSearch_Click" />
                                    </div>
                                </div>

                                <div class="row" runat="server" id="Divb" visible="True">
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

                                                <asp:TemplateField HeaderText="Voucher No">
                                                    <ItemTemplate>
                                                        <%--<%# Eval("VoucherN") %>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Client-Name">
                                                    <ItemTemplate>
                                                        <%# Eval("ClientName") %>
                                                    </ItemTemplate>
                                                </asp:TemplateField>


                                                <asp:TemplateField HeaderText="Amount">
                                                    <ItemTemplate>
                                                        <%--<%# Eval("Amount") %>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="DOP">
                                                    <ItemTemplate>
                                                        <%-- <%# Eval("DOP") %>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Transaction No">
                                                    <ItemTemplate>
                                                        <%-- <%# Eval("Transaction No") %>--%>
                                                    </ItemTemplate>
                                                </asp:TemplateField>

                                                <asp:TemplateField HeaderText="Narration">
                                                    <ItemTemplate>
                                                        <%--<%# Eval("Narration") %>--%>
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
    </div>


    <script>


</script>

</asp:Content>
