<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="AuctionToPortDays.aspx.cs" Inherits="SayyarahCars.CommonMasters.AuctionToPortDays" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Auction to Port Days</h5>
                </div>
                <div class="card-body">
                    <div class="col-md-12">
                        <div class="col-lg-4 " runat="server">
                            <div class="form-group">
                                <label class="form-label" for="country">Select Port</label>
                                <asp:DropDownList ID="ddlAllPortName" runat="server" CssClass="validate chosen-select form-control" AutoPostBack="true" data-required="true" data-type="dropdown" OnSelectedIndexChanged="ddlAllPortName_SelectedIndexChanged1" data-error-id="ddlAllPortNameError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddlAllPortNameError" class="error-message">Please select Port</p>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            ForeColor="Black" AutoGenerateColumns="False"
                            BackColor="White" BorderColor="#999999" OnRowDataBound="GridView1_RowDataBound" PageSize="200" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <AlternatingRowStyle BackColor="#CCCCCC" />
                            <Columns>
                                <asp:TemplateField HeaderText=" Select">
                                    <HeaderStyle Width="50px" />
                                    <HeaderTemplate>
                                        <%--<asp:CheckBox ID="checkAll" runat="server" CssClass="checkAll" />--%>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="SNo.">
                                    <ItemTemplate>
                                        <%# Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Auction Name">
                                    <ItemTemplate>
                                        <%#Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Days">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtdays" runat="server" Text='<%# Eval("days") %>' CssClass="form-control" Width="100px" TextMode="Number"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <HeaderStyle BackColor="Black" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" CssClass="custom-pager" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                    <div class="col-md-3">
                        <div class="form-group" style="margin-top: 25px">
                            <asp:ValidationSummary ID="ValidationSummary2" runat="server" ShowMessageBox="True" ShowSummary="False" ValidationGroup="ram" />
                            <asp:Button ID="btnsubmit" runat="server" ValidationGroup="ram" Text="Submit" CssClass="btn btn-primary" OnClientClick="return validateGrid();" OnClick="btnsubmit_Click" />

                        </div>
                    </div>
                </div>

            </div>

        </div>
    </div>
    <script type="text/javascript">
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>
</asp:Content>
