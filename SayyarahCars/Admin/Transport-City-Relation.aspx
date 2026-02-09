<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Transport-City-Relation.aspx.cs" Inherits="SayyarahCars.Admin.Transport_City_Relation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <h3>Assign City For Transport</h3>
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="country">Select Transport Name </label>
                                <asp:DropDownList ID="ddlTransport" runat="server" CssClass="validate chosen-select form-control"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-8 col-md-6 col-12">
                            <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary btn-sm mt-4 float-Center" OnClick="btnsearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="card">
            <div class="table-responsive">
                <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                    ForeColor="Black" AutoGenerateColumns="False"
                    BackColor="White" BorderColor="#999999" PageSize="200" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging">
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

                        <asp:TemplateField HeaderText="City Name">
                            <ItemTemplate>
                                <%#Eval("Name") %>
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
                 <asp:Button ID="btnSubmit" runat="server" Text="Assign Transport City" ValidationGroup="ram" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
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
