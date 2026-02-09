<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="AddBankDetails.aspx.cs" Inherits="SayyarahCars.Admin.AddBankDetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Bank Details</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Bank Details</a>
                </div>
                <asp:HiddenField ID="hdnBankDetailId" runat="server" />
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added."
                            AllowPaging="True" PageSize="10" OnRowCommand="GridView1_RowCommand" OnPageIndexChanging="GridView1_PageIndexChanging"
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
                                <asp:TemplateField HeaderText="Company">
                                    <ItemTemplate>
                                        <%# Eval("CompanyName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Bank Name">
                                    <ItemTemplate>
                                        <%# Eval("BankName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Branch Name">
                                    <ItemTemplate>
                                        <%# Eval("BranchName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Swift Name">
                                    <ItemTemplate>
                                        <%# Eval("SwiftName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Account Name">
                                    <ItemTemplate>
                                        <%# Eval("AccountName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Account Number">
                                    <ItemTemplate>
                                        <%# Eval("AccountNo") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit" CssClass="avtar edit" CommandArgument='<%# Eval("Id") %>'><i class="ti ti-pencil"></i></asp:LinkButton>
                                        <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Delete"
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
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Add Bank Details</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ti ti-x"></i>
                    </button>
                </div>
                <asp:HiddenField ID="HiddenFieldSID" runat="server" />
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Select Company</label>
                                <asp:DropDownList ID="ddlCompany" runat="server" CssClass="validate chosen-select form-control" data-error-id="errProduct" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="errProduct" class="error-message">Please select Company</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Bank Name</label>
                                <asp:TextBox ID="txtBankName" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="txtBankNameError" data-required="true" data-type="text" ClientIDMode="Static" placeholder="Enter Bank Name"></asp:TextBox>
                                <p class="error-message" id="txtBankNameError">Please enter bank name.</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Branch Name</label>
                                <asp:TextBox ID="txtBranchName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtBranchNameError" placeholder="Enter Branch Name"></asp:TextBox>
                                <p class="error-message" id="txtBranchNameError">Please enter branch name.</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Account Name</label>
                                <asp:TextBox ID="txtAccountName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAccountNameError" placeholder="Enter Account Name"></asp:TextBox>
                                <p class="error-message" id="txtAccountNameError">Please enter account name.</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Swift Name</label>
                                <asp:TextBox ID="txtSwiftName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtSwiftNameError" placeholder="Enter Swift Name"></asp:TextBox>
                                <p class="error-message" id="txtSwiftNameError">Please enter swift name.</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Account No.</label>
                                <asp:TextBox ID="txtAccountNo" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAccountNoError" placeholder="Enter Account No"></asp:TextBox>
                                <p class="error-message" id="txtAccountNoError">Please enter account no.</p>
                            </div>
                        </div>

                         <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Address.</label>
                                <asp:TextBox ID="txtAddress" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAddressError" placeholder="Enter Address"></asp:TextBox>
                                <p class="error-message" id="txtAddressError">Please enter address.</p>
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
    <script src="../Contents/admin/js/ValidateControls.js" type="text/javascript"></script>
</asp:Content>
