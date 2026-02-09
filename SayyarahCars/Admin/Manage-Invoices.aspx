<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Manage-Invoices.aspx.cs" Inherits="SayyarahCars.Admin.Manage_Invoices" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Select Customer</label>
                                <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-12">
                            <div class="form-group">
                                <label class="form-label">Date From</label>
                                <asp:TextBox ID="txtDateFrom" runat="server" autocomplete="off" CssClass="validate form-control" TextMode="Date" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-12">
                            <div class="form-group">
                                <label class="form-label">Date To</label>
                                <asp:TextBox ID="txtDateTo" runat="server" autocomplete="off" CssClass="validate form-control" TextMode="Date" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-12">
                            <div class="form-group">
                                <label class="form-label">Sort By</label>
                                <asp:DropDownList ID="ddlShortBy" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="50">50</asp:ListItem>
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="150">150</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" PageSize="10" EmptyDataText="No Record Added."
                        AllowPaging="True" OnRowCommand="GridView1_RowCommand"
                        Width="100%" GridLines="Vertical">
                        <Columns>
                            <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="S.No">
                                <ItemTemplate>
                                    <%# Container.DataItemIndex + 1 %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Client Name">
                                <ItemTemplate>
                                    <%# Eval("ClientName") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Sender Name">
                                <ItemTemplate>
                                    <%# Eval("SenderName") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Amount">
                                <ItemTemplate>
                                    <%# Eval("Symbol") %><%# Eval("Amount") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Other Charges">
                                <ItemTemplate>
                                    <%# Eval("OtherCharges") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Bank">
                                <ItemTemplate>
                                    <%# Eval("BankName") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Message">
                                <ItemTemplate>
                                    <%# Eval("Address") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Date">
                                <ItemTemplate>
                                    <%# Eval("DOE","{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Receipt">
                                <ItemTemplate>
                                    <%--<a href="download-receipt.aspx?ID=<%# Eval("Rimage") %>" target="_blank">View Receipt
                                    </a>--%>
                                    <a href="print-invoice.aspx?Id=<%#cmf.Encrypt(Eval("Id").ToString()) %>" target="_blank">View Invoive
                                    </a>
                                </ItemTemplate>
                            </asp:TemplateField>

                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <div class="text-end">
                                        <a class="avtar edit" href="Make-Invoice.aspx?id=<%#cmf.Encrypt(Eval("Id").ToString()) %>" data-bs-toggle="tooltip"
                                            data-bs-placement="top" data-bs-original-title="Edit"><i class="ti ti-pencil"></i></a>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>'
                                            UseSubmitBehavior="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Delete"
                                            ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);"><i class="ti ti-trash"></i></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>

                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
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

</asp:Content>
