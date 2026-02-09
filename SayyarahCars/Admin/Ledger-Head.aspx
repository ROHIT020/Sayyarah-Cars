<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Ledger-Head.aspx.cs" Inherits="SayyarahCars.Admin.Ledger_Head" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">





         <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Select Group Name</label>
                                <asp:DropDownList ID="ddlGroupNameS" runat="server" AutoPostBack="true" CssClass="chosen-select form-control" OnSelectedIndexChanged="ddlGroupNameS_SelectedIndexChanged" data-type="dropdown">
                                </asp:DropDownList>  
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Ledger Head Name</label>
                                <asp:TextBox ID="txtLedgerHeadNameS" runat="server" CssClass="validate form-control" autocomplete="off" data-type="text" placeholder="Enter Ledger Head Name"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Short Code</label>
                                <asp:TextBox ID="txtShortCodeS" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text" placeholder="Enter Ledger Short Code"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-1 col-md-3 col-12"> 
                            <asp:Button ID="btnsearch" ValidationGroup="ram" runat="server" Text="Search" class="btn btn-primary float-end mt-4" OnClick="btnsearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>











        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Ledger Head</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Ledger Head</a>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnPageIndexChanging="GridView1_PageIndexChanging"
                            AllowPaging="true" PageSize="15" OnRowCommand="GridView1_RowCommand"
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

                                <asp:TemplateField HeaderText="Group Name">
                                    <ItemTemplate>
                                        <%# Eval("GroupName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Ledger Head Name">
                                    <ItemTemplate>
                                        <%# Eval("LedgerHeadName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Short Code">
                                    <ItemTemplate>
                                        <%# Eval("ShortCode") %>
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
                </div>
            </div>
        </div>
    </div>

    <div class="modal fade bd-example-modal-md" id="add_region" tabindex="-1" role="dialog" aria-labelledby="myExtraLargeModalLabel" aria-hidden="true">
        <div class="modal-dialog modal-md" role="document">
            <div class="modal-content">
                <div class="modal-header">
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Add Ledger Head</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ti ti-x"></i>
                    </button>
                </div>
                <asp:HiddenField ID="HiddenFieldSID" runat="server" />
                <div class="modal-body">
                    <div class="row">

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Select Group Name</label>
                                <asp:DropDownList ID="ddlGroupName" runat="server" CssClass="validate chosen-select form-control" data-error-id="ddlGroupNameError" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                </asp:DropDownList>
                                <div id="ddlGroupNameError" class="error-message">Please select Group Name.</div>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Ledger Head Name</label>
                                <asp:TextBox ID="txtLedgerHeadName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtLedgerHeadNameError" placeholder="Enter Ledger Head Name" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtLedgerHeadNameError" class="error-message">Please enter ledger head name</p>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Short Code</label>
                                <asp:TextBox ID="txtShortCode" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtShortCodeError" placeholder="Enter Ledger Head Name" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtShortCodeError" class="error-message">Please enter Short Code</p>
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
    <asp:HiddenField ID="hdnledgerheadId" runat="server" />
    <script src="../Contents/admin/js/lightbox.min.js"></script>
</asp:Content>
