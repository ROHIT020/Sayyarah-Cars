<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Add-User.aspx.cs" Inherits="SayyarahCars.Admin.Add_User" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Add User</h5>
                    <a href="Manage-User.aspx" class="btn btn-secondary"><i class="ti ti-circle-plus-filled"></i>View User</a>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">First Name</label>
                                <asp:TextBox ID="txtfname" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtfnameError" placeholder="Enter First Name" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtfnameError" class="error-message">Please enter First Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Last Name</label>
                                <asp:TextBox ID="txtlname" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtlnameError" placeholder="Enter Last name" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtlnameError" class="error-message">Please enter Last Name</p>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Contact Number</label>
                                <asp:TextBox ID="txtcontactno" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtcontactnoError" placeholder="Enter Contact No" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtcontactnoError" class="error-message">Please enter Contact No</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Email ID</label>
                                <asp:TextBox ID="txtemailid" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtemailidError" placeholder="Enter Email ID" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtemailidError" class="error-message">Please enter Email ID</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="country">Country Name</label>
                                <asp:DropDownList ID="ddlcountry" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddlCountryError" class="error-message">Please select Country Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">ID Type</label>
                                <asp:TextBox ID="txtIDtype" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtIDtypeError" placeholder="Enter ID Type" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtIDtypeError" class="error-message">Please enter ID Type</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">ID Number</label>
                                <asp:TextBox ID="txtIDNumber" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtIDNumberError" placeholder="Enter ID Number" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtIDNumberError" class="error-message">Please enter ID Number</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Date of Birth</label>
                                <asp:TextBox ID="txtDOB" runat="server" TextMode="Date" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtDOBError" placeholder="Enter Date of Birth" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtDOBError" class="error-message">Please enter Date Of Birth</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Date of Joining</label>
                                <asp:TextBox ID="txtDOJ" runat="server" TextMode="Date" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtDOJError" placeholder="Enter Date Of Joining" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtDOJError" class="error-message">Please enter Date Of Joining</p>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Designation</label>
                                <asp:DropDownList ID="ddldesignation" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddldesignationError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddldesignationError" class="error-message">Please select Designation</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="user">User Type</label>
                                <asp:DropDownList ID="ddlusertype" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlusertypeError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddlusertypeError" class="error-message">Please select User type</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="department">Employee Department</label>
                                <asp:DropDownList ID="ddldepartment" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddldepartmentError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddldepartmentError" class="error-message">Please select Employee Department</p>
                            </div>
                        </div>

                        <div class="col-lg-9 col-md-12">
                            <div class="row">
                                <div class="col-lg-12 col-md-12 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Permanent Address</label>
                                        <asp:TextBox ID="txtPAddress" runat="server" TextMode="MultiLine" Rows="3" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtPAddressError" ClientIDMode="Static"></asp:TextBox>
                                        <p id="txtPAddressError" class="error-message">Please enter Permanent Addresss</p>
                                    </div>
                                </div>
                                <div class="col-lg-12 col-md-12 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Residence Address</label>
                                        <asp:TextBox ID="txtRAddress" runat="server" TextMode="MultiLine" Rows="3" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtRAddressError" ClientIDMode="Static"></asp:TextBox>
                                        <p id="txtRAddressError" class="error-message">Please enter residence Address</p>
                                    </div>
                                </div>

                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="form-group">
                                <asp:CheckBox ID="chkShowpanel" runat="server" Text="Click To Change UserName" AutoPostBack="true" OnCheckedChanged="chkShowLoginFields_CheckedChanged" />
                            </div>
                        </div>
                        <asp:Panel ID="pnlUserDetails" runat="server" Visible="True">
                            <div class="row">
                                <div class="col-lg-3 col-md-6 col-12">
                                    <div class="form-group">
                                        <label class="form-label">User Name</label>
                                        <asp:TextBox ID="txtusername" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtusernameError" ClientIDMode="Static"></asp:TextBox>
                                        <%-- <asp:RequiredFieldValidator ID="rfvUsername" runat="server" ControlToValidate="txtusername"
                                            Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter username."></asp:RequiredFieldValidator>--%>
                                        <p id="txtusernameError" class="error-message">Please enter User Name</p>

                                    </div>
                            </div>
                            <div class="col-lg-3 col-md-6 col-12">
                                <div class="form-group">
                                    <label class="form-label">Password</label>
                                    <asp:TextBox ID="txtpassword" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtpasswordError" ClientIDMode="Static" TextMode="Password"></asp:TextBox>
                                    <%--<asp:RequiredFieldValidator ID="rfvPassword" runat="server" ControlToValidate="txtpassword"
                                            Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter password."></asp:RequiredFieldValidator>
                                    </div>--%>
                                    <p id="txtpasswordError" class="error-message">Please enter Password</p>
                                </div>
                            </div>
                    </div>
                    </asp:Panel>

                        <div class="col-lg-12 col-md-12 col-12">
                            <label class="form-label">&nbsp;</label>
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-2" Text="Submit" OnClientClick="return ValidateFormData();" OnClick="btnsubmit_Click" />
                        </div>
                </div>
            </div>
        </div>
    </div>
    </div>

</asp:Content>
