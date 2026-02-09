<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" ValidateRequest="false" AutoEventWireup="true" CodeBehind="Add-Video.aspx.cs" Inherits="SayyarahCars.Admin.Add_Video" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>View Video</h5>
                    <a class="btn btn-secondary" data-bs-toggle="modal" data-bs-target="#add_region"><i class="ti ti-circle-plus-filled"></i>Add Video</a>
                </div>
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnPageIndexChanging="GridView1_PageIndexChanging"
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

                                <asp:TemplateField HeaderText="Video language">
                                    <ItemTemplate>
                                        <%# Eval("VideoLanguage") %>
                                    </ItemTemplate>

                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Video Title">
                                    <ItemTemplate>
                                        <%# Eval("VideoTitle") %>
                                    </ItemTemplate>
                                </asp:TemplateField>

                                <asp:TemplateField HeaderText="Video URL">
                                    <ItemTemplate>
                                      <%# Eval("VideoUrl") %>
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
                    <h5 class="modal-title m-0" id="myExtraLargeModalLabel">Add Video</h5>
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <i class="ti ti-x"></i>
                    </button>
                </div>
                
                <div class="modal-body">
                    <div class="row">
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Select Video Language</label>
                                <asp:DropDownList ID="ddlVideolanguage" runat="server" CssClass="validate chosen-select form-control" data-error-id="errProduct" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                    <asp:ListItem Value="1">English</asp:ListItem>
                                    <asp:ListItem Value="2">Other</asp:ListItem>
                                </asp:DropDownList>
                                <p id="errProduct" class="error-message">Please select Company</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Video Title</label>
                                <asp:TextBox ID="txtVideoTitle" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtVideoTitleError" placeholder="Enter Video Title"></asp:TextBox>
                                <p class="error-message" id="txtVideoTitleError">Please enter video title.</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Video HTML</label>
                                <asp:TextBox ID="txtVideoHtml" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtVideoHtmlError" placeholder="Enter Video URL"></asp:TextBox>
                                <p class="error-message" id="txtVideoHtmlError">Please enter video URL.</p>
                            </div>
                        </div>

                    </div>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-secondary btn-sm" data-bs-dismiss="modal">Close</button>
                    <asp:Button ID="btnSubmit" ValidationGroup="ram" OnClientClick="return ValidateFormData();" runat="server" Text="Save changes" class="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdnVideoId" runat="server" />
    <script src="../Contents/admin/js/ValidateControls.js"></script>
</asp:Content>
