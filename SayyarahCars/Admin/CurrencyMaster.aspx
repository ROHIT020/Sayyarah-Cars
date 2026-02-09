<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="CurrencyMaster.aspx.cs" Inherits="SayyarahCars.Admin.CurrencyMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="col-lg-12 col-md-12 col-12">
        <div class="card">
            <div class="card-header">
                <h5></h5>
                <asp:Button ID="btnUpdate" ValidationGroup="ram" runat="server" Text="Update" class="btn btn-primary float-end mt-4" OnClick="btnUpdate_Click" />
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                        AllowCustomPaging="true" AllowPaging="true" PageSize="10" PagerSettings-Position="TopAndBottom"
                        Width="100%" GridLines="Vertical">
                        <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                        <Columns>

                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="lblid" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
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

                            <asp:TemplateField HeaderText="Currency Type">
                                <ItemTemplate>
                                    <%# Eval("Ctype") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Symbol">
                                <ItemTemplate>
                                    <%# Eval("Symbol") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField>
                                <HeaderTemplate>
                                    <abbr title="Rate Bizupone">Rate</abbr>
                                </HeaderTemplate>
                                <ItemTemplate>
                                    <asp:TextBox ID="txtRate" runat="server" autocomplete="off" Text='<%# Eval("Rate") %>' class="table-input-control"></asp:TextBox>
                                </ItemTemplate>
                            </asp:TemplateField>
                            
                            <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false"
                                             ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
                        <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
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

    <script>
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }

        $(document).ready(function () {
            $('#<%=GridView1.ClientID%>').on('change', '.employee input:checkbox', function () {
            var allCheckboxes = $('#<%=GridView1.ClientID%>').find('.employee input:checkbox');
            var allChecked = allCheckboxes.length === allCheckboxes.filter(':checked').length;
            $('#<%=GridView1.ClientID%>').find('#checkAll').prop('checked', allChecked);
        });
    });
    </script>



</asp:Content>
