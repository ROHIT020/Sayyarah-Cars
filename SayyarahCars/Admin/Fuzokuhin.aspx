<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Fuzokuhin.aspx.cs" Inherits="SayyarahCars.Admin.Fuzokuhin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Fuzokuhin Master</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Fuzokuhin</a>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                            AllowCustomPaging="true" AllowPaging="true" PageSize="10" PagerSettings-Position="TopAndBottom"
                            Width="100%" GridLines="Vertical">
                            <pagerstyle horizontalalign="Center" cssclass="GridPager" />
                            <columns>
                                <asp:TemplateField Visible="false">
                                    <itemtemplate>
                                        <asp:Label ID="Label1" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText=" S.No">
                                    <headerstyle width="80px" />
                                    <itemtemplate>
                                        <%# Container.DataItemIndex + 1 %>                                      
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Fuzokuhin">
                                    <itemtemplate>
                                        <%# Eval("FuzokuhinName") %>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Price">
                                    <itemtemplate>
                                        <%# Eval("Price") %>
                                    </itemtemplate>
                                </asp:TemplateField>                                
                                <asp:TemplateField HeaderText="Status">
                                    <itemtemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' CssClass='<%# Eval("Status").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <itemtemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit" CommandArgument='<%# Eval("ID") %>'><i class="ti ti-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Delete"
                                                ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);">
                                                <i class="ti ti-trash"></i>
                                            </asp:LinkButton>
                                        </div>
                                    </itemtemplate>
                                </asp:TemplateField>
                            </columns>
                            <footerstyle backcolor="#CCCCCC" />
                            <pagerstyle backcolor="#999999" forecolor="Black" horizontalalign="Center" />
                            <selectedrowstyle backcolor="#000099" font-bold="True" forecolor="White" />
                            <sortedascendingcellstyle backcolor="#F1F1F1" />
                            <sortedascendingheaderstyle backcolor="#808080" />
                            <sorteddescendingcellstyle backcolor="#CAC9C9" />
                            <sorteddescendingheaderstyle backcolor="#383838" />
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
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Add Fuzokuhin</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ti ti-x"></i>
                    </button>
                </div>
                <asp:HiddenField ID="hdnFuzokuhinId" runat="server" />
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Fuzokuhin Name</label>
                                <asp:TextBox ID="txtFuzokuhinName" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="txtFuzokuhinNameError" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                             <p id="txtFuzokuhinNameError" class="error-message">Please enter fuzokuhin name</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Price</label>
                                <asp:TextBox ID="txtPrice" runat="server" autocomplete="off" CssClass="validate form-control" TextMode="Number" step="any" data-error-id="txtPriceError" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <div id="txtPriceError" class="error-message">Please enter fuzokuhin name.</div>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Active/De-Active</label>
                                <div class="custom-radiobox">
                                    <asp:RadioButtonList ID="RadioAD" runat="server" CssClass="form-control" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="1">Active &nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="0">De-Active </asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnSubmit" ValidationGroup="ram" runat="server" Text="Save changes" OnClientClick="return ValidateFormData();" class="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>
