<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="View-Faq.aspx.cs" Inherits="SayyarahCars.Admin.View_Faq" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>View Faq</h5>
                </div>
                <asp:HiddenField ID="hdnBankDetailId" runat="server" />
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added."
                            AllowPaging="True" PageSize="50" OnRowCommand="GridView1_RowCommand"
                            Width="100%" GridLines="Vertical">
                            <pagerstyle horizontalalign="Center" cssclass="GridPager" />
                            <columns>
                                <asp:TemplateField HeaderText="   S.No">
                                    <itemtemplate>
                                        <%#Container.DataItemIndex + 1%>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Question">
                                    <itemtemplate>
                                        <%# Eval("Question") %>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Answer">
                                    <itemtemplate>
                                        <a href="Add-Faq.aspx?Id=<%# Eval("Id") %> " target="_blank">View Ans</a>
                                    </itemtemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <itemtemplate>
                                        <div class="text-end">
                                            <a href="Add-Faq.aspx?Id=<%# Eval("Id") %>" class="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="View and update Ans"><i class="ti ti-eye"></i></a>
                                            <asp:LinkButton ID="LinkButton1" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("Id") %>' UseSubmitBehavior="false" data-bs-original-title="Delete"
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
</asp:Content>
