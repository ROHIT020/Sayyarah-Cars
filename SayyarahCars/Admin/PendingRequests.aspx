<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="PendingRequests.aspx.cs" Inherits="SayyarahCars.Admin.PendingRequests" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="card">
            <div class="card-header">
                <h5>Pending Client Requests</h5>
            </div>
            <div class="col-lg-12 col-md-12 col-12">
                <div class="card-header d-flex justify-content-end align-items-center bg-light py-2">
                    <asp:DropDownList
                        ID="ddlpages"
                        runat="server"
                        CssClass="form-control sort-by w-10 float-end"
                        AutoPostBack="true"
                        OnSelectedIndexChanged="ddlpages_SelectedIndexChanged">
                        <asp:ListItem Value="5">5</asp:ListItem>
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="15">15</asp:ListItem>
                        <asp:ListItem Value="20">20</asp:ListItem>
                        <asp:ListItem Value="25">25</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="gvPendingRequests" runat="server" AutoGenerateColumns="False" AllowPaging="True" CssClass="table table-hover table-striped align-middle" PageSize="2" EmptyDataText="No Record Added." DataKeyNames="id" OnRowCommand="gvPendingRequests_RowCommand" OnPageIndexChanging="gvPendingRequests_PageIndexChanging">
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                         <%# (gvPendingRequests.PageIndex * gvPendingRequests.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Full Name">
                                    <ItemTemplate>
                                        <%# Eval("FullName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%# Eval("emailid") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact">
                                    <ItemTemplate>
                                        <%# Eval("contact") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Actions">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkApprove" runat="server" CommandName="Approve" CommandArgument='<%# Eval("id") %>'
                                                CssClass="avtar approve me-2" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Approve">
                                                     <i class="ti ti-check"></i>
                                            </asp:LinkButton>
                                            <asp:LinkButton ID="lnkDisapprove" runat="server" CommandName="Disapprove" CommandArgument='<%# Eval("id") %>'
                                                CssClass="avtar disapprove" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Disapprove">
                                                    <i class="ti ti-x"></i>
                                            </asp:LinkButton>
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
    </div>



    <asp:Label ID="lblMessage" runat="server" ForeColor="Green"></asp:Label>
</asp:Content>
