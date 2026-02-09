<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="OtherChargesType.aspx.cs" Inherits="SayyarahCars.CommonMasters.OtherChargesType" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Auction Buying Other Type</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="form-group row align-items-center">
                                <label for="txtbuyingName" class="control-label">
                                    <b>Buying Name</b>
                                </label>
                                <div class="col-sm-6">
                                    <asp:TextBox ID="txtbuyingName" runat="server" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtbuyingNameerror" ClientIDMode="Static"
                                        Placeholder="Enter Other Buyer Name"></asp:TextBox>
                                    <p id="txtbuyingNameerror" class="error-message">Please enter Other Type Buying</p>
                                </div>
                                <div class="col-sm-3">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary px-4" OnClick="btnSubmit_Click" OnClientClick="return ValidateFormData();" Text="Save" />
                                    <asp:HiddenField ID="hdnId" runat="server" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header d-flex justify-content-between align-items-center py-2  px-2  ">
                    <h5 class="mb-0">Auction Buying Master</h5>
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
                    <div class="col-lg-12 col-md-12 col-12">
                        <div class="table-responsive">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
                                AutoGenerateColumns="False" EmptyDataText="No Record Added."
                                AllowPaging="true" PageSize="10" PagerSettings-Position="Bottom"
                                Width="100%" GridLines="Vertical">
                                <PagerSettings Mode="Numeric" Position="Bottom" />
                                <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" S.No">
                                        <HeaderStyle Width="80px" />
                                        <ItemTemplate>
                                             <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Buying Name ">
                                        <ItemTemplate>
                                            <%# Eval("Name") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <div class="text-end">
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit" CommandArgument='<%# Eval("ID") %>'><i class="ti ti-pencil"></i></asp:LinkButton>
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
    </div>
</asp:Content>
