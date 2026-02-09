<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Manage-Products.aspx.cs" Inherits="SayyarahCars.Admin.Manage_Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Product Master</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Product</a>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Category</label>
                                <asp:DropDownList ID="ddlcategorysearch" runat="server" class="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Brand</label>
                                <asp:DropDownList ID="ddlbrandsearch" runat="server" class="chosen-select form-control">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Product Name</label>
                                <asp:TextBox ID="txtproduct" runat="server" CssClass="form-control auto-search" data-proc="USP_SelectProductList"></asp:TextBox>
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
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No">
                                    <HeaderStyle Width="80px" />
                                    <ItemTemplate>
                                         <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Category">
                                    <ItemTemplate>
                                        <%# Eval("CategoryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Brand">
                                    <ItemTemplate>
                                        <%# Eval("MakerName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <%# Eval("ProductName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("sActive") %>' CssClass='<%# Eval("sActive").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit" CommandArgument='<%# Eval("ID") %>'><i class="ti ti-pencil"></i></asp:LinkButton>
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
    </div>

    <div class="modal fade bd-example-modal-md" id="add_region" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-lg" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Add Product</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ti ti-x"></i>
                    </button>
                </div>
                <asp:HiddenField ID="HiddenFieldSID" runat="server" />
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-6 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Select Category</label>
                                <asp:DropDownList ID="ddlsubcat" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Select Brand</label>
                                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Product Name</label>
                                <asp:TextBox ID="txtProductName" runat="server" autocomplete="off" class="form-control" placeholder="Enter Product Name"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Active/De-Active</label>
                                <div class="custom-radiobox">
                                    <asp:RadioButtonList ID="RadioAD" runat="server" CssClass="form-control" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="0">Active &nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="1"> De-Active </asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnSubmit" ValidationGroup="ram" runat="server" OnClientClick="return validateProduct();" Text="Save changes" class="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnProductId" runat="server" />


    <script type="text/javascript">
        var productIds = {
            ddlsubcat: '<%= ddlsubcat.ClientID%>',
            ddlBrand: '<%= ddlBrand.ClientID%>',
            txtProductName: '<%= txtProductName.ClientID %>'
        };
    </script>
    <script src="../Contents/admin/js/fetchTextData.js"></script>
    

</asp:Content>
