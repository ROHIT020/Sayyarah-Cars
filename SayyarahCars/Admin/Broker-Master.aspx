<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Broker-Master.aspx.cs" Inherits="SayyarahCars.Admin.Broker_Master" %>

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
                            <a class="nav-link active " id="TabInput" runat="server" data-bs-toggle="pill" href="#ContentPlaceHolder1_inputBox" role="tab" aria-controls="inputBox" aria-selected="true">Add Broker master</a>
                        </li>

                        <li class="nav-item">
                            <a class="nav-link" id="TabShow" runat="server" data-bs-toggle="pill" href="#ContentPlaceHolder1_showBox" role="tab" aria-controls="showBox" aria-selected="false">View Broker master</a>
                        </li>
                    </ul>
                </div>
            </div>
        </div>
    </div>
    <br />
    <div class="tab-content" id="pills-tabContent">
        <div class="tab-pane fade show active" id="inputBox" runat="server"  role="tabpanel" aria-labelledby="pills-details-tab">
            <div class="row">
                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-header">
                            <h4>Broker master </h4>
                        </div>
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-4 col-md-6 col-12">
                                    <div class="form-group">
                                        <label><b>Broker Company Name</b></label>
                                        <asp:TextBox ID="txtBCname" runat="server" autocomplete="off" CssClass="validate form-control"
                                            data-required="true" data-type="text" data-error-id="txtBCnameError" ClientIDMode="Static"
                                            Placeholder="Enter Broker Company Name"></asp:TextBox>
                                        <p id="txtBCnameError" class="error-message">Please enter Broker Company Name</p>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-12">
                                    <div class="form-group">
                                        <label><b>Email ID</b></label>
                                        <asp:TextBox ID="txtemail" runat="server" autocomplete="off" CssClass="validate form-control"
                                            data-required="true" data-type="email" data-error-id="txtemailError" ClientIDMode="Static"
                                            Placeholder="Enter Email ID"></asp:TextBox>
                                        <p id="txtemailError" class="error-message">Please enter Email ID</p>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-6 col-12">
                                    <div class="form-group">
                                        <label><b>Password</b></label>
                                        <asp:TextBox ID="txtpassword" runat="server" autocomplete="off" CssClass="validate form-control"
                                            data-required="true" data-type="text" data-error-id="txtpasswordError" ClientIDMode="Static"
                                            Placeholder="Enter Password"></asp:TextBox>
                                        <p id="txtpasswordError" class="error-message">Please enter Password</p>
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

    <div class="tab-pane fade" id="showBox" runat="server"  role="tabpanel" aria-labelledby="pills-images-tab">
        <div class="row">
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
                                            <%# Eval("EmailID") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>

                                    <asp:TemplateField HeaderText="Password">
                                        <ItemTemplate>
                                            <%# Eval("Password") %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Date">
                                        <ItemTemplate>
                                            <%# Eval("DOE") %>
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
