<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Update-Doc-Receive-Date.aspx.cs" Inherits="SayyarahCars.Admin.Update_Doctument_Receive_Date" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
    <script type="text/javascript">
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
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
                    <div class="row">
                        <h5>Update Document Receive Date</h5>
                    </div>
                </div>
                <div class="card-body">

                    <div class="row">
                        <div class="col-lg-4 col-md-4 col-12">
                            <div class="form-group">
                                <label class="form-label">Auction Date</label>
                                <uc:DateSelector ID="txtADate" runat="server" CssClass="validate form-control" DataErrorId="errADate" DataRequired="true" DataType="calendar" />
                                <%-- <p id="errADate" class="error-message">Please enter Auction Date</p>--%>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-4 col-12">
                            <div class="form-group">
                                <label class="form-label"><b>Urgent </b></label>
                                <asp:DropDownList ID="ddlurgent" runat="server" CssClass="chosen-select form-control ">
                                    <asp:ListItem Value="0">Urgent</asp:ListItem>
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                       
                        <div class="col-lg-4 col-md-4 col-12">  
                            <div class="form-group">
                                <label class="control-label">Chassis No.</label>
                                <asp:TextBox ID="txtChassisNo" runat="server" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-4 col-12">
                            <div class="form-group">
                                <label class="control-label"><b>Sort By</b></label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="chosen-select form-control">
                                    <asp:ListItem Value="500">500</asp:ListItem>
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="5000">5000</asp:ListItem>
                                    <asp:ListItem Value="10000">10000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label">All Chassis No </label>
                                <asp:TextBox ID="txtAllChassisNo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <asp:Button ID="btnSubmit" runat="server" Text="Search" CssClass="btn btn-primary mt-4" OnClick="btnSubmit_Click" />
                            </div>
                        </div>



                        <div class="row" runat="server" id="Divb" visible="false">
                            <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                                <asp:GridView ID="GridView1" runat="server" CellPadding="3" CssClass="table table-striped align-middle" 
                                    ForeColor="Black" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                    GridLines="Vertical" AllowCustomPaging="true" AllowPaging="True" PageSize="500" OnPageIndexChanging="GridView1_PageIndexChanging">
                                    <Columns>

                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Select">
                                            <HeaderStyle Width="50px" />
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" S.No.">
                                            <HeaderStyle Width="50px" />
                                            <ItemTemplate>
                                                <%# Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                      
                                        <asp:TemplateField HeaderText="Product">
                                            <ItemTemplate>
                                                <%# Eval("ProductName") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Chassis">
                                            <ItemTemplate>
                                                <%# Eval("ChassisNo") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Sold">
                                            <ItemTemplate>
                                                <%# Eval("CountryName") %> /<%#Eval("ProductType") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Port Form">
                                            <ItemTemplate>
                                                <%#Eval("PortForm") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Urgent">
                                            <ItemTemplate>
                                                <%# Eval("Urgent") %>
                                            </ItemTemplate>
                                        </asp:TemplateField>                                       
                                        <asp:TemplateField HeaderText="Document-R-Date">
                                            <ItemTemplate>
                                                <uc:DateSelector ID="TxtDRDate" runat="server" CssClass="validate form-control" Text='<%#Eval("DrDate") %>'  DataType="calendar" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="Document-S-Date" Visible="false">
                                            <ItemTemplate>
                                                <asp:TextBox ID="TxtDSDate" runat="server" CssClass="form-control" Text='<%#Eval("DSDate") %>'></asp:TextBox>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                       


                                    </Columns>
                                    <FooterStyle BackColor="#CCCCCC" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" CssClass="custom-pager" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />

                                </asp:GridView>

                                <asp:HiddenField ID="HiddenField1" runat="server" Value="1" />

                            </div>
                            <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <asp:Button ID="BtnUpdateStatus" runat="server" Text="Update Document Status" CssClass="btn btn-primary mt-4" OnClick="BtnUpdateStatus_Click" />
                            </div>
                        </div>
                            
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
    
</asp:Content>
