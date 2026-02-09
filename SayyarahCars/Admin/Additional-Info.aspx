<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Additional-Info.aspx.cs" Inherits="SayyarahCars.Admin.Additional_Info" %>

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
                                <label class="form-label" for="shipping">Select Category Name</label>
                                <asp:DropDownList ID="ddlCategoryName1" runat="server" class="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                   <asp:ListItem Value="0">Select Category Name</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-4 col-md-3 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label" for="shipping">Info Type</label>
                                <asp:DropDownList ID="ddlInfoType1" runat="server" class="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                    <asp:ListItem Value="1">Feature</asp:ListItem>
                                    <asp:ListItem Value="2">Problem</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-3 col-12">
                            <asp:Button ID="btnsearch" ValidationGroup="ram" runat="server" Text="Search" class="btn btn-primary float-end mt-4" OnClick="btnsearch_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Additional Info</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Additional Info</a>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added."
                            AllowCustomPaging="true" PageSize="50" OnRowCommand="GridView1_RowCommand"
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

                                <asp:TemplateField HeaderText="Category Name">
                                    <ItemTemplate>
                                        <%# Eval("CategoryName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Additional Name">
                                    <ItemTemplate>
                                        <%# Eval("AdditinalInfoName") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Info Type">
                                    <ItemTemplate>
                                        <%# Eval("InfoType") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Status">
                                    <ItemTemplate>
                                        <asp:Label ID="lblStatus" runat="server" Text='<%# Eval("Status") %>' CssClass='<%# Eval("Status").ToString().Trim() == "Active" ? "status active" : "status deactive" %>'></asp:Label>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit" CommandArgument='<%# Eval("Id") %>'><i class="ti ti-pencil"></i></asp:LinkButton>
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
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Additional Info</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ti ti-x"></i>
                    </button>
                </div>
                <asp:HiddenField ID="HiddenFieldSID" runat="server" />
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Select Category Name</label>
                                <asp:DropDownList ID="ddlCategoryName" runat="server" CssClass="chosen-select form-control selectpicker " data-live-search="true" AppendDataBoundItems="True">
                                    <asp:ListItem Value="0">Select Category Name</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Additinal Info</label>
                                <asp:TextBox ID="txtAdditinalInfo" runat="server" autocomplete="off" class="form-control" placeholder="Enter Additinal Info"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Info Type</label>
                                <asp:DropDownList ID="ddlInfoType" runat="server" CssClass="chosen-select form-control selectpicker " data-live-search="true" AppendDataBoundItems="True">
                                    <asp:ListItem Value="1">Feature</asp:ListItem>
                                    <asp:ListItem Value="2">Problem</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Status</label>
                                <div class="custom-radiobox">
                                    <asp:RadioButtonList ID="RadioAD" runat="server" CssClass="form-control" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                        <asp:ListItem Selected="True" Value="1">Active &nbsp;&nbsp;&nbsp;&nbsp;</asp:ListItem>
                                        <asp:ListItem Value="0"> De-Active </asp:ListItem>
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnSubmit" ValidationGroup="ram" runat="server" Text="Save changes" class="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdnAdditionalInfo" runat="server" />
</asp:Content>
