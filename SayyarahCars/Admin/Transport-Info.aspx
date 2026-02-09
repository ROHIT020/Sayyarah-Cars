<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Transport-Info.aspx.cs" Inherits="SayyarahCars.Admin.Transport_Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .table{
            overflow:visible
        }
    </style>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label" for="shipping">Select Country Name</label>
                                        <asp:DropDownList ID="ddlCountry" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryError" ClientIDMode="Static"></asp:DropDownList>
                                        <p id="ddlCountryError" class="error-message">Please select country name</p>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Select Region Name</label>
                                        <asp:DropDownList ID="ddlStateName" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlStateNameError" ClientIDMode="Static"></asp:DropDownList>
                                        <p id="ddlStateNameError" class="error-message">Please select region name</p>
                                    </div>
                                </div>
                                <div class="col-lg-2 col-md-2 col-12">
                                    <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-4" OnClientClick="return ValidateFormData();" Text="Submit" OnClick="btnSubmit_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5></h5>
                    <asp:Button ID="btnAddTransport" ValidationGroup="ram" Visible="false" runat="server" Text="Add Transport and Shipping" class="btn btn-primary float-end mt-4" OnClick="btnAddTransport_Click" />
                </div>
                <div class="card-body">
                   
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" PageSize="10" EmptyDataText="No Record Added."
                            AllowPaging="True" 
                            Width="100%" GridLines="Vertical">
                            <Columns>
                                 <asp:TemplateField Visible="false">
                                <ItemTemplate>
                                    <asp:Label ID="Label1" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
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
                            
                              <asp:TemplateField HeaderText="Auction Name ">
                                <ItemTemplate>
                                     <%# Eval("Name") %>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="TRAILER">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddltrailer" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="S_NORMAL">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlnormal" runat="server" CssClass="validate chosen-select form-control" data-live-search="true"></asp:DropDownList>
                                    <br />
                                    <asp:DropDownList ID="ddlportn" runat="server" CssClass="validate chosen-select form-control" data-live-search="true" data-type="dropdown"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="S_CONSTRUCTOR">
                                <ItemTemplate>
                                     <asp:DropDownList ID="ddlconst" runat="server" CssClass="validate chosen-select form-control" data-live-search="true"></asp:DropDownList>
                                    <br />
                                    <asp:DropDownList ID="ddlportt" runat="server" CssClass="validate chosen-select form-control" data-live-search="true" data-type="dropdown"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="S_Cut">
                                <ItemTemplate>
                                     <asp:DropDownList ID="ddlscut" runat="server" CssClass="validate chosen-select form-control" data-live-search="true"></asp:DropDownList>
                                    <br />
                                    <asp:DropDownList ID="ddlportcut" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown"></asp:DropDownList>
                                </ItemTemplate>
                            </asp:TemplateField>
                              <asp:TemplateField HeaderText="S_CONTAINER">
                                <ItemTemplate>
                                    <asp:DropDownList ID="ddlcontainer" runat="server" CssClass="validate chosen-select form-control" data-live-search="true"></asp:DropDownList>
                                    <br />
                                    <asp:DropDownList ID="ddlportner" runat="server" CssClass="validate chosen-select form-control" data-live-search="true" data-type="dropdown"></asp:DropDownList>
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
