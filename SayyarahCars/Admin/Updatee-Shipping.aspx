<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Shared/Main.Master" CodeBehind="Updatee-Shipping.aspx.cs" Inherits="SayyarahCars.Admin.Updatee_Shipping" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
    <script type="text/javascript">
        function displayallcheckboxes(chk, Selector) {
            $('#<%=gvshipig.ClientID%>').find(Selector + "input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Shipping Details</h5>
                </div>
            </div>
            <div class="card-body">
                <div class="row">
                    <div class="col-lg-4 col-md-6 col-12">
                        <div class="form-group">
                            <label class="control-label">Category</label>
                            <asp:DropDownList ID="ddcategory" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static" OnSelectedIndexChanged="ddcategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-12">
                        <div class="form-group">
                            <label class="control-label">Select Product</label>
                            <asp:DropDownList ID="ddlproduct" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-12">
                        <div class="form-group">
                            <label class="control-label">Auction House</label>
                            <asp:DropDownList ID="ddlAuction" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-12">
                        <div class="form-group">
                            <label class="control-label">Auction date</label>
                            <uc:DateSelector ID="txtdate" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-12">
                        <div class="form-group">
                            <label class="control-label">SortBy</label>
                            <asp:DropDownList ID="ddlsortby" runat="server" CssClass="validate chosen-select form-control">
                                <asp:ListItem Value="10"></asp:ListItem>
                                <asp:ListItem Value="50"></asp:ListItem>
                                <asp:ListItem Value="100"></asp:ListItem>
                                <asp:ListItem Value="150"></asp:ListItem>
                                <asp:ListItem Value="200"></asp:ListItem>
                                <asp:ListItem Value="250"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>

                    <div class="col-lg-4 col-md-6 col-12">
                        <div class="form-group">
                            <label class="control-label">Chassis No.</label>
                            <asp:TextBox ID="txtChassisNo" runat="server" CssClass="form-control"></asp:TextBox>
                            <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                        </div>
                    </div>
                    <div class="col-md-12">
                        <div class="form-group">
                            <label class="control-label">All Chassis No </label>
                            <asp:TextBox ID="txtAllChassisNo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                        </div>
                    </div>
                </div>

                <div class="col-md-12">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="form-group">
                                <asp:Button ID="btnserach" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnserach_Click" />
                            </div>
                        </div>
                    </div>
                </div>


                <div id="Divserver" runat="server">
                    <div class="row">
                        <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                            <asp:GridView ID="gvshipig" runat="server" CssClass="table table-hover table-striped align-middle"
                                AutoGenerateColumns="False" OnPageIndexChanging="gvshipig_PageIndexChanging" AllowCustomPaging="true" AllowPaging="true" PageSize="10" Width="100%"
                                GridLines="Vertical">
                                <Columns>
                                     <asp:TemplateField Visible="false">
                                     <ItemTemplate>
                                         <asp:Label ID="lblpid" runat="server" Text='<%#Eval("Id") %>'></asp:Label>
                                         <asp:Label ID="LabTID" runat="server" Text='<%#Eval("TransportId") %>'></asp:Label>
                                         <asp:Label ID="LabSId" runat="server" Text='<%#Eval("ShippingId") %>'></asp:Label>
                                         <asp:Label ID="Labpt" runat="server" Text='<%#Eval("PortToId") %>'></asp:Label>
                                         <asp:Label ID="Labpf" runat="server" Text='<%#Eval("PortFromId") %>'></asp:Label>
                                         <asp:Label ID="Labelscid" runat="server" Text='<%#Eval("CountryId") %>'></asp:Label>
                                         <asp:DropDownList ID="ddlTransport" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static"></asp:DropDownList>
                                     </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText=" Select">
                                        <HeaderTemplate>
                                            <asp:CheckBox ID="chkall" runat="server" onclick="displayallcheckboxes()" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chckbox" runat="server" CssClass="employee" />
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText=" S.No.">
                                        <ItemTemplate>
                                            <%# (gvshipig.PageIndex * gvshipig.PageSize) + Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Chassis No">
                                        <ItemTemplate>
                                            <%# Eval("chassisNo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="ProductName">
                                        <ItemTemplate>
                                            <%# Eval("ProductName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Transport">
                                        <ItemTemplate>
                                            <%#Eval("TransportName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="S_Company">
                                        <ItemTemplate>
                                            <%#Eval("ShippingName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PortForm">
                                        <ItemTemplate>
                                            <%#Eval("PortTo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="PortTo">
                                        <ItemTemplate>
                                            <%#Eval("PortForm") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="In Auction">
                                        <ItemTemplate>
                                            <%--<%# Eval("fDkescription") %>--%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="grid-footer" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" CssClass="custom-pager" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </div>
                    </div>
                        <div class="row">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label"><b>Shipping Company</b></label>
                                <asp:DropDownList ID="ddlshipping" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                         <div class="col-md-3" style="margin-top: 25px">
                            <asp:Button ID="button1" runat="server" Text="Update Shipping" CssClass="btn btn-primary" OnClick="button1_Click" />
                        </div>
                        <div class="col-md-3">
                                        <div class="form-group">
                                            <label class="control-label"><b>Port From</b></label>
                                            <asp:DropDownList ID="ddlportfrom" runat="server"  CssClass="validate chosen-select form-control" data-type="dropdown" ClientIDMode="Static">                                               
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                         <div class="col-md-3" style="margin-top: 25px">
                            <asp:Button ID="button2" runat="server" Text="Update Port From" CssClass="btn btn-primary" OnClick="button2_Click"  />
                        </div>
                        
                     </div>
                </div>



            </div>
        </div>


        

    </div>
    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtChassisNo.ClientID %>',
            AllChassisNo: '<%= txtAllChassisNo.ClientID %>'
        };
    </script>
    <script src="../Contents/admin/js/fetchChassisNo.js" type="text/javascript"></script>
</asp:Content>
