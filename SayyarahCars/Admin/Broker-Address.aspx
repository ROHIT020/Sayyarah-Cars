<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Broker-Address.aspx.cs" Inherits="SayyarahCars.Admin.Broker_Address" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <ul class="nav nav-pills " id="pills-tab" role="tablist">
                        <li class="nav-item ">
                            <a class="nav-link active " id="TabInput" runat="server" data-bs-toggle="pill" href="#ContentPlaceHolder1_inputBox" role="tab" aria-controls="inputBox" aria-selected="true">Add Broker Address</a>
                        </li>
                        <li class="nav-item">
                            <a class="nav-link" id="TabShow" runat="server" data-bs-toggle="pill" href="#ContentPlaceHolder1_showBox" role="tab" aria-controls="showBox" aria-selected="false">View Broker Address</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="tab-content" id="pills-tabContent">
        <div class="tab-pane fade show active" id="inputBox" runat="server" role="tabpanel" aria-labelledby="pills-details-tab">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Broker master </h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-6 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label" for="country">Select Broker Company</label>
                                        <asp:DropDownList ID="ddlbCompany" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlbCompanyError" ClientIDMode="Static"></asp:DropDownList>
                                        <p id="ddlbCompanyError" class="error-message">Please select Broker Company</p>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label"><b>Broker Name</b></label>
                                        <asp:TextBox ID="txtBname" runat="server" autocomplete="off" CssClass="validate form-control"
                                            data-required="true" data-type="text" data-error-id="txtBnameError" ClientIDMode="Static"
                                            Placeholder="Enter Broker Name"></asp:TextBox>
                                        <p id="txtBnameError" class="error-message">Please enter Broker Name</p>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label"><b>Contact No</b></label>
                                        <asp:TextBox ID="txtcontact" runat="server" autocomplete="off" CssClass="validate form-control"
                                            data-required="true" data-type="text" data-error-id="txtcontactError" ClientIDMode="Static"
                                            Placeholder="Enter Broker Name"></asp:TextBox>
                                        <p id="txtcontactError" class="error-message">Please enter Broker Name</p>
                                    </div>
                                </div>
                                <div class="col-lg-6 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label"><b>Email ID</b></label>
                                        <asp:TextBox ID="txtemail" runat="server" autocomplete="off" CssClass="validate form-control"
                                            data-required="true" data-type="email" data-error-id="txtemailError" ClientIDMode="Static"
                                            Placeholder="Enter Email ID"></asp:TextBox>
                                        <p id="txtemailError" class="error-message">Please enter Email ID</p>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-12">
                                    <div class="form-group">
                                        <label class="form-label"><b>Broker Address</b></label>
                                        <asp:TextBox ID="txtBAddress" runat="server" TextMode="MultiLine" Rows="2" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtBAddressError" ClientIDMode="Static"></asp:TextBox>
                                        <p id="txtBAddressError" class="error-message">Please enter Broker Address</p>
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
        </div>
    </div>
    <div class="tab-pane fade" id="showBox" runat="server" role="tabpanel" aria-labelledby="pills-images-tab">
        <div class="row">
            <div class="col-lg-12 col-md-12 col-12">
                <div class="card">
                    <div class="card-body">
                        <div class="row">
                            <div class="col-lg-4 col-md-6 col-12">
                                <div class="form-group">
                                    <label class="form-label" for="country"><b>Select Broker Company</b></label>
                                    <asp:DropDownList ID="ddlBCSearch" runat="server" CssClass="chosen-select form-control"></asp:DropDownList>
                                </div>
                            </div>
                            <div class="col-lg-4 col-md-6 col-12">
                                <div class="form-group">
                                    <label  class="form-label"><b>Select Date</b></label>
                                    <asp:TextBox ID="txtdatefrom" runat="server" autocomplete="off" CssClass="form-control" TextMode="Date"></asp:TextBox>
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
                                    <asp:TemplateField HeaderText="Broker Company Name">
                                        <ItemTemplate>
                                            <%# Eval("Bcname") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email ID">
                                        <ItemTemplate>
                                            <%# Eval("bEmail") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Broker Name">
                                        <ItemTemplate>
                                            <%# Eval("BName") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Contact No">
                                        <ItemTemplate>
                                            <%# Eval("ContactNo") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Email ID">
                                        <ItemTemplate>
                                            <%# Eval("EmailID") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Broker Address">
                                        <ItemTemplate>
                                            <%# Eval("BAddress") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Action">
                                        <ItemTemplate>
                                            <div class="text-end">
                                                <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CommandArgument='<%# Eval("ID") %>'
                                                    CssClass="avtar edit" UseSubmitBehavior="false">
                                                    <i class="ti ti-pencil"></i>
                                                </asp:LinkButton>
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
    </div>
</asp:Content>
