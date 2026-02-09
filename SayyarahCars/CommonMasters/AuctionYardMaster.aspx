<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="AuctionYardMaster.aspx.cs" Inherits="SayyarahCars.CommonMasters.AuctionYardMaster" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

<link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">Select Auction Name</label>
                                <asp:DropDownList ID="ddlAuction" runat="server" CssClass="chosen-select form-control"></asp:DropDownList>
                                <div class="error-message">Please fill out this field.</div>
                            </div>
                        </div>
                          <div class="col-lg-3 col-md-3 col-12">
                                <asp:Button ID="btnFilter" runat="server" Text="Filter" CssClass="btn btn-primary btn-sm mt-4 float-end" OnClick="btnFilter_Click" />
                          </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Auction Yard Master</h5>
                    <a class="btn btn-secondary" href="AddAuctionYard.aspx" title="my title"><i class="ti ti-circle-plus-filled"></i>Add Auction Yard</a>
                </div>
                <div class="card-header justify-content-end">
                    <asp:DropDownList ID="ddlpages" runat="server" CssClass="form-control sort-by w-10 float-end" AutoPostBack="true" OnSelectedIndexChanged="ddlpages_SelectedIndexChanged">
                        <asp:ListItem Value="10">10</asp:ListItem>
                        <asp:ListItem Value="50">50</asp:ListItem>
                        <asp:ListItem Value="100">100</asp:ListItem>
                        <asp:ListItem Value="150">150</asp:ListItem>
                        <asp:ListItem Value="200">200</asp:ListItem>
                        <asp:ListItem Value="500">500</asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                            AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                            Width="100%" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField HeaderText="<input type='checkbox' id='checkAll' class='checkAll' />">
                                    <ItemTemplate>
                                        <input type="checkbox" name="checkRow" class="rowCheckbox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Auction Name">
                                    <ItemTemplate>
                                        <%# Eval("AuctionName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Yard Name">
                                    <ItemTemplate>
                                        <%# Eval("AuctionYard") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Lot No">
                                    <ItemTemplate>
                                        <%# Eval("LotNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%# Eval("EmailId") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Contact No">
                                    <ItemTemplate>
                                        <%# Eval("ContactNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href='<%# "AddAuctionYard.aspx?id=" + cmf.Encrypt(Eval("ID").ToString()) %>' title="my title"><i class="ti ti-pencil"></i></a>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("ID") %>' UseSubmitBehavior="false"
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
    </div>

</asp:Content>
