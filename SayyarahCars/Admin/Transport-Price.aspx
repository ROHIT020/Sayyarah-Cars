<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Transport-Price.aspx.cs" Inherits="SayyarahCars.Admin.Transport_Price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label" for="shipping">Transport Name</label>
                                        <asp:DropDownList ID="ddlTransportName" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlTransportNameError" ClientIDMode="Static"></asp:DropDownList>
                                        <p id="ddlTransportNameError" class="error-message">Please select transport name</p>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Select Auction Name</label>
                                        <asp:DropDownList ID="ddlAuctionName" runat="server" CssClass="validate chosen-select form-control" OnSelectedIndexChanged="ddlAuctionName_SelectedIndexChanged" AutoPostBack="true" data-required="true" data-type="dropdown" data-error-id="ddlAuctionNameError" ClientIDMode="Static"></asp:DropDownList>
                                        <p id="ddlAuctionNameError" class="error-message">Please select auction name</p>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Select Yard Name</label>
                                        <asp:DropDownList ID="ddlYardName" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlYardNameError" ClientIDMode="Static"></asp:DropDownList>
                                        <p id="ddlYardNameError" class="error-message">Please select yard name</p>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-2 col-12">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" OnClientClick="return ValidateFormData();" Text="Submit" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-header">
                    <h5></h5>
                    <asp:Button ID="btnAddPrice" ValidationGroup="ram" Visible="false" runat="server" Text="Add Transport Price" class="btn btn-primary float-end mt-4" OnClick="btnAddPrice_Click" />
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" PageSize="10" EmptyDataText="No Record Added."
                            AllowPaging="True" OnPageIndexChanging="GridView1_PageIndexChanging"
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
                                <asp:TemplateField HeaderText="	Port Name">
                                    <ItemTemplate>
                                        <%# Eval("PortName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txtprice" runat="server" class="table-input-control" Text="0" TextMode="Number"></asp:TextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Tax">
                                    <ItemTemplate>
                                        <asp:TextBox ID="txttax" runat="server" class="table-input-control" Text="0"></asp:TextBox>
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

    <script type="text/javascript">
        $("#<%= GridView1.ClientID %> input[id*='txtprice']").change(function () {
            var pptax = 0;
            var TID = ($("[id*=txtprice]", $(this).closest("tr")).val());
            pptax = (parseFloat(TID) / 10);
            $("[id*=txttax]", $(this).closest("tr")).val(pptax)

        });
    </script>

    <script>
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }

        $(document).ready(function () {
            $('#<%=GridView1.ClientID%>').on('change', '.employee input:checkbox', function () {
                var allCheckboxes = $('#<%=GridView1.ClientID%>').find('.employee input:checkbox');
                var allChecked = allCheckboxes.length === allCheckboxes.filter(':checked').length;
                $('#<%=GridView1.ClientID%>').find('#checkAll').prop('checked', allChecked);
            });
        });
    </script>

</asp:Content>
