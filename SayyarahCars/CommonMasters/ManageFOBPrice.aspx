<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManageFOBPrice.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManageFOBPrice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
     <link href="../Contents/Popup/popup.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <div class="row">


        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">Country Name</label>
                                <asp:DropDownList ID="ddlCountryNameS" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlCountryNameS_SelectedIndexChanged" CssClass="chosen-select form-control" data-live-search="true">
                                    <asp:ListItem Value="0">Select Country</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">Region/City</label>
                                <asp:DropDownList ID="ddlCityNameS" runat="server" CssClass="chosen-select form-control" data-live-search="true">
                                    <asp:ListItem Value="0">Select City Name</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">FOB Type</label>
                                <asp:DropDownList ID="ddlFobtypeS" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                    <asp:ListItem Value="">Select FOB Type</asp:ListItem>
                                    <asp:ListItem Value="A">A</asp:ListItem>
                                    <asp:ListItem Value="B">B</asp:ListItem>
                                    <asp:ListItem Value="C">C</asp:ListItem>
                                    <asp:ListItem Value="D">D</asp:ListItem>
                                    <asp:ListItem Value="E">E</asp:ListItem>
                                    <asp:ListItem Value="F">F</asp:ListItem>
                                    <asp:ListItem Value="G">G</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-3 col-12">
                            <asp:Button ID="btnsearch" ValidationGroup="ram" runat="server" Text="Search" class="btn btn-primary float-end mt-4" OnClick="btnsearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>FOB Price Master</h5>                    
                     <a class="btn btn-secondary" href="javascript:void(0);" title="my title" onclick="openCSSPopup('Add-FOB.aspx','Add Fob Price','30vw','70vh')"><i class="ti ti-circle-plus-filled"></i>Add Fob Price</a>
                </div>              
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." AllowPaging="true"
                            AllowCustomPaging="true" OnRowCommand="GridView1_RowCommand"
                            Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No">
                                    <HeaderStyle Width="80px" />
                                    <ItemTemplate>
                                         <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country Name ">
                                    <ItemTemplate>
                                        <%# Eval("CountryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Region/City Name">
                                    <ItemTemplate>
                                        <%# Eval("StateName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Port Name">
                                    <ItemTemplate>
                                        <%# Eval("PortName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="FOB Type">
                                    <ItemTemplate>
                                        <%# Eval("FobType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <%# Eval("FobPrice") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                       <div class="text-end">
                                            <a class="avtar edit" href="javascript:void(0);" title="Edit" onclick="openCSSPopup('Add-FOB.aspx?id=<%#cmf.Encrypt(Eval("Id").ToString()) %>','Edit FOB Price','30vw','70vh')"><i class="ti ti-pencil"></i></a>
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

    
    <div style="display: none">
        <asp:Button ID="btnreload" runat="server" OnClick="btnreload_Click" />
    </div>
    <script src="../Contents/Popup/defaultpopup.js"></script>
    <script type="text/javascript">
        function closePopup() {
            document.getElementById("popupOverlay").classList.add("hidden");
            document.getElementById("popupIframe").src = "";
            document.getElementById("<%=btnreload.ClientID%>").click();
        }
    </script>
 
   

</asp:Content>
