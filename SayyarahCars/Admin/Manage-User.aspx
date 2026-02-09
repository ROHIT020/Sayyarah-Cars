<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Manage-User.aspx.cs" Inherits="SayyarahCars.Admin.Manage_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>View User</h5>
                    <a class="btn btn-secondary" href="Add-user.aspx" title="my title"><i class="ti ti-circle-plus-filled"></i>Add User</a>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Department</label>
                                <asp:DropDownList ID="ddldepartment" runat="server" class="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Designation</label>
                                <asp:DropDownList ID="ddldesignation" runat="server" class="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Name</label>
                                <asp:TextBox ID="txtname" runat="server" CssClass="form-control auto-search" data-proc="USP_SearchStaffName"></asp:TextBox>
                                <ul class="list-group mt-1 shadow-sm suggest" style="display: none;"></ul>
                            </div>
                        </div>
                        <div class="col-lg-2 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">Page Size</label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" class="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPageSize_SelectedIndexChanged">
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="200">200</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">500</asp:ListItem>
                                    <asp:ListItem Value="1500">500</asp:ListItem>
                                    <asp:ListItem Value="-1">Custom</asp:ListItem>
                                </asp:DropDownList>
                                <asp:TextBox ID="txtpagesize" runat="server" Text="2000" TextMode="Number" CssClass="form-control" Visible="false"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-3 col-12">
                            <asp:Button ID="btnsearch" ValidationGroup="ram" runat="server" Text="Search" class="btn btn-primary float-end mt-4" OnClick="btnsearch_Click" />
                        </div>
                    </div>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                            AllowCustomPaging="true" PageSize="100" PagerSettings-Mode="Numeric" AllowPaging="True"
                            OnPageIndexChanging="GridView1_PageIndexChanging" PagerSettings-Position="TopAndBottom"
                            Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No">
                                    <HeaderStyle Width="80px" />
                                    <ItemTemplate>
                                        <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="<input type='checkbox' id='checkAll' class='checkAll' />">
                                    <ItemTemplate>
                                        <input type="checkbox" name="checkRow" class="rowCheckbox" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="FName">
                                    <ItemTemplate>
                                        <%# Eval("Fname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="LName">
                                    <ItemTemplate>
                                        <%# Eval("Lname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="UserName">
                                    <ItemTemplate>
                                        <%# Eval("username") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Email">
                                    <ItemTemplate>
                                        <%# Eval("Email") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Department">
                                    <ItemTemplate>
                                        <%# Eval("Department") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Designation">
                                    <ItemTemplate>
                                        <%# Eval("Designation") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' CssClass='<%# Eval("Status").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <a class="avtar edit" href='<%# "Add-user.aspx?id=" + cmf.Encrypt(Eval("ID").ToString()) %>' title="my title"><i class="ti ti-pencil"></i></a>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("ID") %>' UseSubmitBehavior="false"
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
        <script src="../Contents/admin/js/fetchTextData.js"></script>
</asp:Content>
