<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Seller.Master" AutoEventWireup="true" CodeBehind="MyProfile.aspx.cs" Inherits="SayyarahCars.Seller.MyProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <style>
        .img#ContentPlaceHolder1_imgPreview {
    max-width: 100%;
    height: 192px;
    width: 100% !important;
}
    </style>
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
                                    <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="fuProfile" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please upload profile photo." />--%>
                                    <asp:Image ID="imgPreview" runat="server" ImageUrl="../Contents/admin/images/avatar.png" Width="120" CssClass="img-thumbnail" />
                                    <asp:HiddenField ID="hdnProfilePic" runat="server" />
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
                                            <label class="form-label">Email Id</label>
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
                                            <label class="form-label" for="country">Password</label>
                                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" Enabled="false"></asp:TextBox>
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Nationality</label>
                                            <asp:TextBox ID="txtnationality" runat="server" CssClass="form-control" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator9" runat="server" ControlToValidate="txtnationality" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter nationality." />
                                        </div>
                                    </div>
                                    <div class="col-lg-4 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Date Of Birth</label>
                                            <asp:TextBox ID="txtdateofBirth" TextMode="Date" runat="server" CssClass="form-control"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" runat="server" ControlToValidate="txtdateofBirth" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter date of birth." />
                                        </div>
                                    </div>
                                    <div class="col-lg-8 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Address</label>
                                            <asp:TextBox ID="txtaddress" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="3" />
                                            <asp:RequiredFieldValidator ID="RequiredFieldValidator8" runat="server" ControlToValidate="txtaddress" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter address." />
                                        </div>
                                    </div>

                                    <div class="col-lg-4 col-md-6 col-12">
                                        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary btn-sm mt-4 float-end" ValidationGroup="a" OnClick="btnSave_Click" />
                                    </div>
                                    <asp:HiddenField ID="hdnProfileId" runat="server" />
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
