<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Update-Fuzokuhin.aspx.cs" Inherits="SayyarahCars.Admin.Update_Fuzokuhin" %>


<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <script type="text/javascript">
         function SelectAllCheckboxes(chk, selector) {
             $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                 $(this).prop("checked", $(chk).prop("checked"));
             });
         }
     </script>

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
                                <label class="form-label">Chassis No</label>
                                <asp:TextBox ID="txtchassis" runat="server" autocomplete="off" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group">
                                <label class="form-label">Browse Image</label>
                                <div class="browse-file">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                </div>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-1 col-12">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>

                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-6 col-md-6 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" AllowCustomPaging="true" AllowPaging="True" PageSize="50" EmptyDataText="No Record Added."
                            Width="100%" GridLines="Vertical">
                            <Columns>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblId" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
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
                                <asp:TemplateField HeaderText="Fuzokuhin">
                                    <ItemTemplate>
                                        <asp:Label ID="lblFname" runat="server" Text='<%# Eval("FuzokuhinName") %>'></asp:Label>
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
        var ChassisClientID = {
            ChassisNo: '<%= txtchassis.ClientID %>',
        };
    </script>
</asp:Content>
