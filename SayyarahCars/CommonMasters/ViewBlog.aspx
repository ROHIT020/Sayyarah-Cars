<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ViewBlog.aspx.cs" Inherits="SayyarahCars.Admin.ViewBlog1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>View Blog</h5>
                </div>
                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card-header d-flex justify-content-end align-items-center bg-light py-2">
                        <asp:DropDownList
                            ID="ddlpages"
                            runat="server"
                            CssClass="form-control sort-by w-10 float-end"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlpages_SelectedIndexChanged">
                            <asp:ListItem Value="1">1</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" OnRowCommand="GridView1_RowCommand"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnPageIndexChanging="GridView1_PageIndexChanging" AllowPaging="true" PageSize="10"
                            Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="Select">
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:CheckBox ID="Chk" runat="server" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp; Blog Title/Topic">
                                    <ItemTemplate>
                                        &nbsp;   <%# Eval("btitle") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="&nbsp; Blog Date">
                                    <ItemTemplate>
                                        &nbsp;   <%# Eval("bdate","{0:dd/MM/yyyy}") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Blog Status">
                                    <ItemTemplate>
                                        <%# Eval("status") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href='<%# "AddBlog.aspx?id=" + cmf.Encrypt(Eval("id").ToString()) %>' title="Edit"><i class="ti ti-pencil"></i></a>
                                            <a class="avtar preview" href='<%# "PreviewProfile.aspx?id=" + cmf.Encrypt(Eval("id").ToString()) %>' title="Preview Profile"> <i class="ti ti-eye"></i> </a>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false"
                                             ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);"><i class="ti ti-trash"></i></asp:LinkButton>
                                            </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center"  CssClass="custom-pager"/>
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
</asp:Content>
