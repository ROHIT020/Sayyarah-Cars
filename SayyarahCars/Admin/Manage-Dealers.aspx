<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Manage-Dealers.aspx.cs" Inherits="SayyarahCars.Admin.Manage_Dealers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Dealer Registrations</h5>
                    <a href="DealerRegistration.aspx" type="submit" class="btn btn-secondary">Add Dealer</a>
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
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No">
                                    <HeaderStyle Width="80px" />
                                    <ItemTemplate>
                                         <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business Name">
                                    <ItemTemplate>
                                        <%# Eval("BusinessName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Business Type">
                                    <ItemTemplate>
                                        <%# Eval("BusinessType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Services">
                                    <ItemTemplate>
                                        <%# Eval("ProductsServices") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Primary Contact">
                                    <ItemTemplate>
                                        <%# Eval("PrimaryContact") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%# Eval("Email") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="WebsiteURL">
                                    <ItemTemplate>
                                        <asp:HyperLink ID="hlWebsiteURL" runat="server" Text='<%# Eval("WebsiteURL") %>' Target="_blank"
                                            NavigateUrl='<%# Eval("WebsiteURL") %>' Visible='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("WebsiteURL"))) %>' Style="color: blue; text-decoration: underline;" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Documents">
                                    <ItemTemplate>
                                        <button type="button" class="btn btn-primary dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false">
                                            Download <i class="las la-angle-down ms-1"></i>
                                        </button>
                                        <div class="dropdown-menu">
                                            <asp:HyperLink ID="hlBusinessLicense" runat="server"
                                                NavigateUrl='<%# Eval("BusinessLicense") %>'
                                                Text="Business Document" Target="_blank"
                                                Visible='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("BusinessLicense"))) %>'
                                                CssClass="dropdown-item" />

                                            <asp:HyperLink ID="hlCertificate" runat="server"
                                                NavigateUrl='<%# Eval("VATCertificate") %>'
                                                Text="VAT Certificate" Target="_blank"
                                                Visible='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("VATCertificate"))) %>'
                                                CssClass="dropdown-item" />

                                            <asp:HyperLink ID="HyperLink1" runat="server"
                                                NavigateUrl='<%# Eval("IDProofofOwner") %>'
                                                Text="ID Proof of Owner" Target="_blank"
                                                Visible='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("IDProofofOwner"))) %>'
                                                CssClass="dropdown-item" />

                                            <asp:HyperLink ID="HyperLink2" runat="server"
                                                NavigateUrl='<%# Eval("SignedDealerAgreement") %>'
                                                Text="Signed Dealer Agreement" Target="_blank"
                                                Visible='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("SignedDealerAgreement"))) %>'
                                                CssClass="dropdown-item" />
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a href="DealerRegistration.aspx?Id=<%#cmf.Encrypt(Eval("Id").ToString()) %>" class="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit"><i class="ti ti-pencil"></i></a>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Delete"
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
    </div>
</asp:Content>
