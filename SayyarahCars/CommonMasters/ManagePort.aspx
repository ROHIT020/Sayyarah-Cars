<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManagePort.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManagePort" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="row">

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">Select Country Name</label>
                                <asp:DropDownList ID="ddlCountryName1" runat="server" class="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">Shipping Company</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-3 col-12">
                            <asp:Button ID="btnsearch" runat="server" Text="Search" class="btn btn-primary float-end mt-4" OnClick="btnsearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Port Master</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Port</a>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                            AllowCustomPaging="true"
                            Width="100%" GridLines="Vertical">
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
                                <asp:TemplateField HeaderText="Country Name">
                                    <ItemTemplate>
                                        <%# Eval("CountryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Port Name">
                                    <ItemTemplate>
                                        <%# Eval("PortName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Active") %>' CssClass='<%# Eval("Active").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
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
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Add Port</h5>
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
                                    <asp:ListItem Value="">Select Country</asp:ListItem>
                                </asp:DropDownList>
                                <p id="errCountry" class="error-message">Please select Country Name</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Port Name</label>
                                <asp:TextBox ID="txtrname" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errPortName" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errPortName" class="error-message">Please enter Port Name</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtaddress" runat="server" autocomplete="off" CssClass="form-control" data-error-id="errAddress" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errAddress" class="error-message">Please enter Address</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Email ID</label>
                                <asp:TextBox ID="txtemail" runat="server" autocomplete="off" CssClass="form-control" data-error-id="errEmail" data-required="true" data-type="email" ClientIDMode="Static"></asp:TextBox>
                                <p id="errEmail" class="error-message">Please enter Email ID</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Contact No</label>
                                <asp:TextBox ID="txtcontact" runat="server" autocomplete="off" CssClass="form-control" data-error-id="errContactNo" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errContactNo" class="error-message">Please enter Contact No</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Fax No</label>
                                <asp:TextBox ID="txtfax" runat="server" autocomplete="off" CssClass="form-control" ></asp:TextBox>                                
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
                    <asp:Button ID="btnSubmit" ValidationGroup="ram" runat="server" Text="Save changes" class="btn btn-primary btn-sm" OnClientClick="return ValidateFormData();" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="HiddenFieldID" runat="server" />

    <%--<script type="text/javascript">
        var btnSubmitClientId = '<%= btnSubmit.ClientID %>';
    </script>--%>
</asp:Content>
