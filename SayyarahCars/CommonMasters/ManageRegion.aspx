<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManageRegion.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManageRegion" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="https://cdn.jsdelivr.net/npm/sweetalert2@11"></script>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Region Master</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Region</a>
                </div>
                <div class="card-body">
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlcountry" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" >
                                        <asp:ListItem Value="">Select Country</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-primary" OnClick="btnsearch_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added."
                            AllowCustomPaging="true" OnRowCommand="GridView1_RowCommand"
                            Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText=" Select">
                                    <HeaderStyle Width="50px" />
                                    <HeaderTemplate>
                                        <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField Visible="false">
                                    <ItemTemplate>
                                        <asp:Label ID="lblid" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="S.No">
                                    <HeaderStyle Width="80px" />
                                    <ItemTemplate>
                                         <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Country">
                                    <ItemTemplate>
                                        <%# Eval("CountryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Region">
                                    <ItemTemplate>
                                        <%# Eval("Name") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Archive") %>' CssClass='<%# Eval("Archive").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Port">
                                    <ItemTemplate>
                                        <%# Eval("PortName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit" CssClass="avtar edit" CommandArgument='<%# Eval("Id") %>'><i class="ti ti-pencil"></i></asp:LinkButton>
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
                    <div class="col-md-12">
                        <div class="row">
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:DropDownList ID="ddlport" runat="server" CssClass="chosen-select form-control">
                                        <asp:ListItem Value="">Select Port Name</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-md-2">
                                <div class="form-group">
                                    <asp:Button ID="btnupdateport" runat="server" Text="Update Port" class="btn btn-primary" OnClick="btnupdateport_Click" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade bd-example-modal-md" id="add_region" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Add Region</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ti ti-x"></i>
                    </button>
                </div>
                <asp:HiddenField ID="HiddenFieldSID" runat="server" />
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Select Country Name</label>
                                <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="validate chosen-select form-control" data-error-id="errCountry" data-required="true" data-type="dropdown" ClientIDMode="Static" >                                   
                                </asp:DropDownList>
                                <p id="errCountry" class="error-message">Please select Country Name</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Region Name</label>
                                <asp:TextBox ID="txtRegioName" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errRegion" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                              <p id="errRegion" class="error-message">Please enter Region Name</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Status</label>
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

                    <asp:Button ID="btnSubmit" ValidationGroup="ram" runat="server" OnClientClick="return ValidateFormData();" Text="Save changes" class="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
    <%--<script type="text/javascript">
        var btnSubmitClientId = '<%= btnSubmit.ClientID %>';
    </script>--%>
</asp:Content>
