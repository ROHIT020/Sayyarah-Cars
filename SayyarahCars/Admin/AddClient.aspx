<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddClient.aspx.cs" Inherits="SayyarahCars.Admin.Add_Client" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Admin Client Registration </h5>
                </div>
                <div class="card-body">
                    <div class="row ">
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">First Name</label>
                                <asp:TextBox ID="txtfname" runat="server" CssClass=" validate form-control" data-required="true" data-type="text" data-error-id="txtfnamerror" />
                                <p id="txtfnamerror" class="error-message">Please enter first name.</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Last Name</label>
                                <asp:TextBox ID="txtlname" runat="server" CssClass=" validate form-control" data-required="true" data-type="text" data-error-id="txtlnamerror" />
                                <p id="txtlnamerror" class="error-message">Please enter last name.</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Email ID</label>
                                <asp:TextBox ID="txtemailid" runat="server"  CssClass=" validate form-control" TextMode="Email" data-required="true" data-type="text" data-error-id="txtemailerror" />
                                <p id="txtemailerror" class="error-message">Please enter email.</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Contact Number</label>
                                <asp:TextBox ID="txtcontactno" runat="server" CssClass=" validate form-control" TextMode="number" data-required="true" data-type="text" data-error-id="txtcontacterror" />
                                <p id="txtcontacterror" class="error-message">Please enter contact.</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="country">Select Country</label>
                                <asp:DropDownList ID="ddlcountry" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlcountry_SelectedIndexChanged" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryError" ClientIDMode="Static">
                                    <asp:ListItem Text="--Select Country--" Value="0" />
                                </asp:DropDownList>
                                <p id="ddlCountryError" class="error-message">Please select country</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label" for="state">Select State</label>
                                <asp:DropDownList ID="ddlstate" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlStateError" ClientIDMode="Static">
                                    <asp:ListItem Text="--Select State--" Value="0" />
                                </asp:DropDownList>
                                <p id="ddlStateError" class="error-message">Please select state</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Password</label>
                                <asp:TextBox ID="txtpassword" runat="server"   CssClass=" validate form-control" TextMode="Password" data-required="true" data-type="text" data-error-id="txtPassworderror" />
                                <p id="txtPassworderror" class="error-message">Please enter contact.</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Ref Employee ID</label>
                                <asp:TextBox ID="txtrefempid" runat="server" CssClass="validate form-control" data-required="true" data-error-id="txtrefempError" />
                                <p id="txtrefempError" class="error-message">Please enter Ref EmpID</p>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="form-label">Your Address</label>
                                <asp:TextBox ID="txtaddress" runat="server" CssClass=" validate form-control" data-required="true" data-error-id="txtAddressError" TextMode="MultiLine" Rows="2" />
                                <p id="txtAddressError" class="error-message">Please enter address</p>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="profile-pic">
                                <label class="form-label">Profile Photo</label>                                
                                    <asp:FileUpload ID="fuProfile" CssClass="form-control mt-0" data-required="true" data-type="pimage" runat="server" onchange="loadFile(event)" />
                                    <asp:Image ID="imgPreview" runat="server" ImageUrl="~/Contents/admin/images/avataar.jpeg" Width="100" CssClass="img-thumbnail" />
                                </div>                          
                        </div>
                    </div>
                    <div class="col-md-12">
                        <asp:Button ID="btnSave" runat="server" Text="Save Changes" CssClass="btn btn-primary btn-sm mt-2 float-end" OnClick="btnSave_Click" OnClientClick="return ValidateFormData();" />
                        <asp:HiddenField ID="hdnId" runat="server" />
                    </div>
                </div>

            </div>
        </div>
    </div>
    <script type="text/javascript">
        var loadFile = function (event) {
            var imgPreview = document.getElementById("<%= imgPreview.ClientID %>");
            imgPreview.src = URL.createObjectURL(event.target.files[0]);
            imgPreview.onload = function () {
                URL.revokeObjectURL(imgPreview.src);
            }
        };
    </script>
</asp:Content>
