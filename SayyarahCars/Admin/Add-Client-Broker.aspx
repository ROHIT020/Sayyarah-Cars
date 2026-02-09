<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Add-Client-Broker.aspx.cs" Inherits="SayyarahCars.Admin.Add_Client_Broker" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="custom-tab-container" AutoPostBack="true" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Add Client Broker" ID="TabPanel1">
            <ContentTemplate>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-12">
                        <div class="card">
                            <div class="card-header">
                                <h4>Add Client Broker </h4>
                            </div>
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="country">Select Broker Company</label>
                                            <asp:DropDownList ID="ddlbCompany" runat="server" CssClass="validate chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlbCompany_SelectedIndexChanged" data-required="true" data-type="dropdown" data-error-id="ddlbCompanyError" ClientIDMode="Static"></asp:DropDownList>
                                            <p id="ddlbCompanyError" class="error-message">Please select Broker Company</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="country">Select Broker Name</label>
                                            <asp:DropDownList ID="ddlBname" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlBnameError" ClientIDMode="Static"></asp:DropDownList>
                                            <p id="ddlBnameError" class="error-message">Please select Broker Name</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="country">Select Client Name</label>
                                            <asp:DropDownList ID="ddlClient" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlClientError" ClientIDMode="Static"></asp:DropDownList>
                                            <p id="ddlClientError" class="error-message">Please select Client Name</p>
                                        </div>
                                    </div>
                                    <div class="card-header justify-content-end">
                                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ValidateFormData();" CssClass="btn btn-primary btn-sm mt-4" OnClick="btnSubmit_Click" />
                                        <asp:HiddenField ID="hdnId" runat="server" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </ContentTemplate>
        </cc1:TabPanel>
        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="View Client Broker" ID="TabPanel2">
            <ContentTemplate>
                <div class="row">
                    <div class="col-lg-12 col-md-12 col-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="row">
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="country"><b>Select Broker Company</b></label>
                                            <asp:DropDownList ID="ddlBCSearch" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlBCSearch_SelectedIndexChanged"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                         <div class="form-group">
                                            <label class="form-label" for="country"><b>Select Broker Name</b></label>
                                            <asp:DropDownList ID="ddlBnameSearch" runat="server" CssClass="chosen-select form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                         <div class="form-group">
                                            <label class="form-label" for="country"><b>Select Client Name</b></label>
                                            <asp:DropDownList ID="ddlClientSearch" runat="server" CssClass="chosen-select form-control"></asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <asp:Button ID="btnFilter" runat="server" Text="search" CssClass="btn btn-primary btn-sm mt-4 float-end" OnClick="btnFilter_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="col-lg-12 col-md-12 col-12">
                        <div class="card">
                            <div class="card-body">
                                <div class="table-responsive">
                                    <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                                        AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                                        AllowCustomPaging="true" AllowPaging="True" PageSize="10" OnPageIndexChanging="GridView1_PageIndexChanging"
                                        Width="100%" GridLines="Vertical">
                                        <Columns>
                                            <asp:TemplateField HeaderText="<input type='checkbox' id='checkAll' class='checkAll' />">
                                                <ItemTemplate>
                                                    <input type="checkbox" name="checkRow" class="rowCheckbox" />
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Client Name">
                                                <ItemTemplate>
                                                    <%# Eval("ClientName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Broker Company Name">
                                                <ItemTemplate>
                                                    <%# Eval("Bcname") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>

                                            <asp:TemplateField HeaderText="Broker Name">
                                                <ItemTemplate>
                                                    <%# Eval("BName") %>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:TemplateField HeaderText="Action">
                                                <ItemTemplate>
                                                    <div class="text-end">
                                                    
                                                    <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CommandArgument='<%# Eval("ID") %>' UseSubmitBehavior="false"
                                                        ClientIDMode="Static" CssClass="avtar delete" OnClientClick="return confirmDelete(this);"><i class="ti ti-trash"></i></asp:LinkButton>
                                                    </div>
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
            </ContentTemplate>
        </cc1:TabPanel>
    </cc1:TabContainer>
</asp:Content>
