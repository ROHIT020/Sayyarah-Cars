<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/User.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SayyarahCars.Users.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Profile</h5>
                </div>
                <div class="card-body">
                    <div class="profile-sec" id="profile">
                        <div class="row mt-4">
                            <div class="col-lg-2 col-md-12">
                                <div class="profile-pic">
                                    <label class="label" for="file">
                                        <span class="ti ti-camera"></span>
                                        <span>Change Profile Pic</span>
                                        </label>
                                    <asp:FileUpload ID="fuProfile" CssClass="form-control mt-1" runat="server" onchange="loadFile(event)" />
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fuProfile" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please upload profile photo." />
                                    <asp:Image ID="imgPreview" runat="server" ImageUrl="../Contents/admin/images/avatar.png" Width="120" CssClass="img-thumbnail" />
                                </div>
                            </div>
                            <div class="col-lg-10 col-md-12">
                                <div class="row">

                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">First Name</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtfname" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter first name." />
                                            <asp:TextBox ID="txtfname" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Last Name</label>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtlname" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter last name." />
                                            <asp:TextBox ID="txtlname" runat="server" CssClass="form-control" />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Email ID</label>
                                            <asp:TextBox ID="txtemailid" runat="server" CssClass="form-control" TextMode="Email" ReadOnly="true" Enabled="false" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" runat="server" ControlToValidate="txtemailid" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter email id." />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Contact Number</label>
                                            <asp:TextBox ID="txtcontactno" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" runat="server" ControlToValidate="txtcontactno" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter contact number." />
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="country">Select Country</label>
                                            <asp:DropDownList ID="ddlcountry" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Select Country--" Value="0" />
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="ddlcountry" InitialValue="0" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please select country." />
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="country">Select State</label>
                                            <asp:DropDownList ID="ddlState1" runat="server" CssClass="form-control">
                                                <asp:ListItem Text="--Select State--" Value="0" ></asp:ListItem>
                                            </asp:DropDownList>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator7" runat="server" ControlToValidate="ddlState1" InitialValue="0" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please select state." />
                                        </div>
                                    </div>
                                    <div class="col-lg-8 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Your Address</label>
                                            <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtaddress" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter address." />
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Ref Employee ID</label>
                                            <asp:TextBox ID="txtrefempid" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtrefempid" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter Ref EmpID." />
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary btn-sm mt-4 float-end" ValidationGroup="a" OnClick="btnSave_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var loadFile = function (event) {
            var image = document.getElementById("<%=imgPreview.ClientID%>");
            image.src = URL.createObjectURL(event.target.files[0]);
        };
    </script>

</asp:Content>
