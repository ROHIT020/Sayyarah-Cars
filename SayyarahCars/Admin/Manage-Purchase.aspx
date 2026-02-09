<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Manage-Purchase.aspx.cs" Inherits="SayyarahCars.Admin.Manage_Purchase" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Filter Purchase</h5>
                    <a class="btn btn-secondary" href="Add-Purchase.aspx" title="Add Purchase"><i class="ti ti-circle-plus-filled"></i>Add Purchase</a>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="product">Category</label>
                                <asp:DropDownList ID="ddlcategory" runat="server" CssClass="chosen-select form-control" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Brand</label>
                                <asp:DropDownList ID="ddlBrand" runat="server" CssClass="chosen-select form-control" OnSelectedIndexChanged="ddlBrand_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="product">Product</label>
                                <asp:DropDownList ID="ddlproduct" runat="server" CssClass="chosen-select form-control" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged" AutoPostBack="true">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="countryName">Body Type</label>
                                <asp:DropDownList ID="ddlBodyType" runat="server" CssClass="chosen-select form-control" OnSelectedIndexChanged="ddlBodyType_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="code">Model/Variant</label>
                                <asp:DropDownList ID="ddlModel" runat="server" CssClass="chosen-select form-control">
                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Chassis Number</label>
                                <asp:TextBox ID="txtChassisNo" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Kms From</label>
                                <asp:TextBox ID="txtKmsF" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Kms To</label>
                                <asp:TextBox ID="txtKmsT" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Price From</label>
                                <asp:TextBox ID="txtPriceF" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Price To</label>
                                <asp:TextBox ID="txtPriceT" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">CC</label>
                                <asp:TextBox ID="txtCC" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Color</label>
                                <asp:DropDownList ID="ddlcolor" runat="server" CssClass="chosen-select form-control">
                                    <asp:ListItem Value="">Select Color </asp:ListItem>
                                    <asp:ListItem Value="BEIGE">BEIGE</asp:ListItem>
                                    <asp:ListItem Value="BLACK">BLACK</asp:ListItem>
                                    <asp:ListItem Value="BLUE">BLUE</asp:ListItem>
                                    <asp:ListItem Value="DARK BLUE">DARK BLUE</asp:ListItem>
                                    <asp:ListItem Value="GOLD">GOLD</asp:ListItem>
                                    <asp:ListItem Value="GRAY">GRAY</asp:ListItem>
                                    <asp:ListItem Value="GREEN">GREEN</asp:ListItem>
                                    <asp:ListItem Value="GUNMETAL">GUNMETAL</asp:ListItem>
                                    <asp:ListItem Value="LIGHT BLUE">LIGHT BLUE</asp:ListItem>
                                    <asp:ListItem Value="ORANGE">ORANGE</asp:ListItem>
                                    <asp:ListItem Value="PEARL">PEARL</asp:ListItem>
                                    <asp:ListItem Value="PINK">PINK</asp:ListItem>
                                    <asp:ListItem Value="PURPLE">PURPLE</asp:ListItem>
                                    <asp:ListItem Value="RED">RED</asp:ListItem>
                                    <asp:ListItem Value="SILVER">SILVER</asp:ListItem>
                                    <asp:ListItem Value="WHITE">WHITE</asp:ListItem>
                                    <asp:ListItem Value="WINE">WINE</asp:ListItem>
                                    <asp:ListItem Value="YELLOW">YELLOW</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Year From</label>
                                <uc:DateSelector ID="txtYearF" runat="server" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Year To</label>                               
                                <uc:DateSelector ID="txtYearT" runat="server" />
                            </div>
                        </div>
                        
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">No of Records</label>
                                <asp:DropDownList ID="ddlpageSize" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlpageSize_SelectedIndexChanged">
                                    <asp:ListItem Value="100">100</asp:ListItem>
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="5000">5000</asp:ListItem>
                                    <asp:ListItem Value="10000">10000</asp:ListItem>
                                    <asp:ListItem Value="-1">Custom</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping"></label>
                                <asp:TextBox ID="txtpagesize" runat="server" Text="20000" TextMode="Number" CssClass="form-control" Visible="false" placeholder="No of Records"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <asp:Button ID="btnsearch" ValidationGroup="ram" runat="server" Text="Search" class="btn btn-primary float-end mt-4" OnClick="btnsearch_Click" />
                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="col-lg-12 col-md-12 col-12">
        <div class="card">
            <div class="card-header">
                <h5>Manage Purchase</h5>
            </div>
            <div class="card-body">
                <div class="table-responsive">
                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                        AutoGenerateColumns="False" EmptyDataText="No Record Found." OnRowCommand="GridView1_RowCommand"
                        AllowCustomPaging="true" AllowPaging="true" PageSize="10" PagerSettings-Position="Bottom"
                        Width="100%" GridLines="Vertical" OnPageIndexChanging="GridView1_PageIndexChanging">
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
                            <asp:TemplateField HeaderText="Body Type">
                                <ItemTemplate>
                                    <%# Eval("BodyTypeName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Variant Name">
                                <ItemTemplate>
                                    <%# Eval("VariantName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Model Code">
                                <ItemTemplate>
                                    <%# Eval("ModelCode") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Chassis No.">
                                <ItemTemplate>
                                    <%# Eval("ChassisNo") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="M Date">
                                <ItemTemplate>
                                    <%# Eval("Mdate","{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="R Date">
                                <ItemTemplate>
                                    <%# Eval("Rdate","{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Seller Type">
                                <ItemTemplate>
                                    <%# Eval("SellerType") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Seller">
                                <ItemTemplate>
                                    <%# Eval("Seller") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="User">
                                <ItemTemplate>
                                    <%# Eval("UserName") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="DOE">
                                <ItemTemplate>
                                    <%# Eval("DOE","{0:dd/MM/yyyy}") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Push Price">
                                <ItemTemplate>
                                    <div class="text-end">
                                        <%# PushPrice(Eval("Stype").ToString(), Eval("ID").ToString()) %>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField HeaderText="Action">
                                <ItemTemplate>
                                    <div class="text-end">
                                        <a class="avtar edit" href="Make-Invoice.aspx?PId=<%#cmf.Encrypt(Eval("Id").ToString()) %>" style="font-size: 20px; color: green" title="Sale Product" target="_blank"><i class="ti ti-currency-dollar"></i></a>
                                        <a class="avtar edit" href="Add-Purchase.aspx?id=<%#cmf.Encrypt(Eval("Id").ToString()) %>" title="Edit"><i class="ti ti-pencil"></i></a>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false"
                                            ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);"><i class="ti ti-trash"></i></asp:LinkButton>
                                    </div>
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                        <FooterStyle BackColor="#CCCCCC" />
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
    <script src="../Contents/Popup/defaultpopup.js"></script>

    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtChassisNo.ClientID %>'
        };
    </script>
    <script src="../Contents/admin/js/fetchChassisNo.js" type="text/javascript"></script>
</asp:Content>
