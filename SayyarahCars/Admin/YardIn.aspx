<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="YardIn.aspx.cs" Inherits="SayyarahCars.Admin.YardIn" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table {
            overflow: visible
        }
    </style>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Port Name</label>
                                <asp:DropDownList ID="ddlPortName" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Chassis No</label>
                                <asp:TextBox ID="txtchassis" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Yard Out</label>
                                <asp:DropDownList ID="ddlYardOut" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                    <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    <asp:ListItem Value="No">No</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Yard Out Date</label>
                                <uc:DateSelector ID="txtYardOutDate" runat="server" CssClass="form-control" DataRequired="true" DataType="calendar" />
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Ship Name</label>
                                <asp:DropDownList ID="ddlShipName" runat="server" CssClass="validate chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-12">
                            <div class="form-group">
                                <label class="form-label">Yard In</label>
                                <asp:TextBox ID="txtYardIn" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-12">
                            <div class="form-group">
                                <label class="form-label">Out</label>
                                <asp:TextBox ID="txtOut" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-2 col-md-2 col-12">
                            <div class="form-group">
                                <label class="form-label">Remain</label>
                                <asp:TextBox ID="txtRemain" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnDownload" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Download" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" AllowPaging="True" AllowCustomPaging="True" PageSize="10"
                            EmptyDataText="No Record Added." Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />

                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" S.No">
                                    <ItemTemplate>
                                        &nbsp;&nbsp;  <%#Container.DataItemIndex + 1%>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Product Name">
                                    <ItemTemplate>
                                        <%# Eval("Product Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Chassis No">
                                    <ItemTemplate>
                                        <%# Eval("Chassis No") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Port Name">
                                    <ItemTemplate>
                                        <%# Eval("Port Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Ship Name">
                                    <ItemTemplate>
                                        <%# Eval("Shipname") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Yard Out">
                                    <ItemTemplate>
                                        <%# Eval("Yard Out") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Yard Date">
                                    <ItemTemplate>
                                        <%# Eval("Yard Out Date") %>
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
    <script>
        var ChassisClientID =
        {
            ChassisNo: '<%= txtchassis.ClientID %>',
        };
    </script>
</asp:Content>
