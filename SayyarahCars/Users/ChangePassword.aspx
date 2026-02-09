<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/User.Master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="SayyarahCars.Users.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Change Password</h5>
                </div>
                <div class="card-body">
                    <div class="auth-main">
                        <div class="auth-wrapper">
                            <div class="auth-form">
                                <div class="card">
                                    <div class="card-body">
                                        <div class="text-center">
                                            <a href="#">
                                                <img src="../Contents/admin/images/logo.png" alt="img" width="35%"></a>
                                        </div>
                                        <h4 class="text-center mb-5 mt-3">Enter Details Here</h4>
                                        <div class="form-group">
                                            <label class="form-label">Current Password</label>
                                            <asp:TextBox ID="txtcurrentpwd" runat="server" TextMode="Password" CssClass="form-control" placeholder="Current Password" AutoCompleteType="None"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ForeColor="Red" ErrorMessage="ERROR: Current Password Required??" Display="dynamic" ControlToValidate="txtcurrentpwd" ValidationGroup="a"></asp:RequiredFieldValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">New Password</label>
                                            <asp:TextBox ID="txtnewpassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="New Password" MaxLength="20" AutoCompleteType="None"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ErrorMessage="ERROR: New Password Required??" Display="dynamic" ControlToValidate="txtnewpassword" ValidationGroup="a"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ForeColor="Red" ErrorMessage="Your password must satisfy the following. Password should be 8 to 20 character long, at least one Upper case alphabet, at least one Lower case alphabet, at least one numeric value, at least one special characters(!@#$%^&*-) "
                                                ValidationExpression="^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$"
                                                ControlToValidate="txtnewpassword" ValidationGroup="a" Display="Dynamic">
                                            </asp:RegularExpressionValidator>
                                        </div>
                                        <div class="form-group">
                                            <label class="form-label">Confirm Password</label>
                                            <asp:TextBox ID="txtconfrimpwd" runat="server" CssClass="form-control" placeholder="New Password" TextMode="Password" MaxLength="20" AutoCompleteType="None"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ErrorMessage="ERROR: Confirm Password Required??" Display="dynamic" ControlToValidate="txtconfrimpwd" ValidationGroup="a"></asp:RequiredFieldValidator>
                                            <asp:CompareValidator runat="server" ForeColor="Red" ErrorMessage="ERROR: Your password and confirmation password do not match." Display="dynamic" ControlToCompare="txtnewpassword" ControlToValidate="txtconfrimpwd" ValidationGroup="a"></asp:CompareValidator>
                                        </div>
                                        <div class="form-group">
                                            <div class="row">
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <asp:Image ID="Image2" runat="server" Height="70px" ImageUrl="~/Captcha.aspx" Width="100%" Style="float: left; margin-bottom: 7px;" />
                                                    </div>
                                                </div>
                                                <div class="col-md-6">
                                                    <div class="form-group">
                                                        <asp:TextBox ID="txtCaptcha" runat="server" class="form-control" placeholder="Security Key" MaxLength="6"></asp:TextBox>
                                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ForeColor="Red" ErrorMessage="ERROR: Enter Security Key !!" Display="dynamic" ControlToValidate="txtCaptcha" ValidationGroup="a"></asp:RequiredFieldValidator>
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="d-grid mt-4">
                                                <asp:Button ID="btnchangePassword" class="btn btn-primary" runat="server" Text="Change Password" ValidationGroup="a" OnClick="btnchangePassword_Click" />
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
