<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManageFeatures.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManageFeatures" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <h5>Manage Features</h5>
                    </div>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Category
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlcategory" InitialValue="0" ErrorMessage="Required??" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationGroup="a" />
                                </label>
                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged">                                  
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Feature Group
                                     <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="ddlpid" InitialValue="-1" ErrorMessage="Required??" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationGroup="a" />
                                </label>
                                <asp:DropDownList ID="ddlpid" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlpid_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">
                                    Feature/Sub Feature
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfeature" ErrorMessage="Required??" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationGroup="a" />
                                </label>
                                <asp:TextBox ID="txtfeature" runat="server" AutoCompleteType="None" CssClass="form-control" placeholder="Name"></asp:TextBox>
                            </div>
                        </div>                      
                        
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary mt-4" ValidationGroup="a" Text="Submit" OnClick="btnsubmit_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header justify-content-end">
                    <asp:DropDownList ID="ddlpages" runat="server" CssClass="form-control sort-by w-10 float-end" AutoPostBack="true" OnSelectedIndexChanged="ddlpages_SelectedIndexChanged">
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
                            AllowCustomPaging="true" AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
                            Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                         <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Feature">
                                    <ItemTemplate>
                                        <%# Eval("FeatureName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>                                 
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CausesValidation="false"
                                                CommandArgument='<%# Eval("ID") %>' CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit"><i class="ti ti-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CausesValidation="false" OnClientClick="return confirmDelete(this);"
                                                CommandArgument='<%# Eval("ID") %>' CssClass="avtar delete" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Delete"><i class="ti ti-trash"></i></asp:LinkButton>
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
