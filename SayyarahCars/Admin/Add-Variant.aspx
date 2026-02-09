<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="Add-Variant.aspx.cs" Inherits="SayyarahCars.Admin.Add_Variant" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Select Product</label>
                                <asp:DropDownList ID="ddlProduct" runat="server" CssClass="validate chosen-select form-control" data-error-id="errProduct" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="errProduct" class="error-message">Please select Product</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="countryName">Select Body Type</label>
                                <asp:DropDownList ID="ddlBodyType" runat="server" CssClass="validate chosen-select form-control" data-error-id="errBodyType" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="errBodyType" class="error-message">Please select Body Type</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Variant Name</label>
                                <asp:TextBox ID="txtVarientName" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errVarient" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errVarient" class="error-message">Please enter Variant Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Model Code</label>
                                <asp:TextBox ID="txtModelCode" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errModelCode" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errModelCode" class="error-message">Please enter Model Code</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Drive</label>
                                <asp:DropDownList ID="ddldrive" runat="server" CssClass="validate chosen-select form-control" data-error-id="errDrive" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                    <asp:ListItem Value="0">-Select Drive-</asp:ListItem>
                                    <asp:ListItem Value="FWD">Front-Wheel Drive (FWD)</asp:ListItem>
                                    <asp:ListItem Value="RWD">Rear-Wheel Drive (RWD)</asp:ListItem>
                                    <asp:ListItem Value="4WD">Four-Wheel Drive (4WD)</asp:ListItem>
                                    <asp:ListItem Value="AWD">All-Wheel Drive (AWD)</asp:ListItem>
                                </asp:DropDownList>
                                <p id="errDrive" class="error-message">Please select Model Code</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Transmission</label>
                                <asp:TextBox ID="txtTransmission" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errTransmission" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errTransmission" class="error-message">Please enter Transmission</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Fuel Type</label>
                                <asp:DropDownList ID="ddlfueltype" runat="server" CssClass="validate chosen-select form-control" data-error-id="errfueltype" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                    <asp:ListItem Value="0">-Select Fuel Type-</asp:ListItem>
                                    <asp:ListItem Value="Petrol">Petrol</asp:ListItem>
                                    <asp:ListItem Value="Diesel">Diesel</asp:ListItem>
                                    <asp:ListItem Value="Hybrid">Hybrid</asp:ListItem>
                                    <asp:ListItem Value="Electric">Electric</asp:ListItem>
                                    <asp:ListItem Value="Gasoline">Gasoline</asp:ListItem>
                                    <asp:ListItem Value="Hydrogen">Hydrogen</asp:ListItem>
                                    <asp:ListItem Value="CNG">CNG</asp:ListItem>
                                    <asp:ListItem Value="LPG">LPG</asp:ListItem>
                                </asp:DropDownList>
                                <p id="errfueltype" class="error-message">Please select Fuel Type</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Steering Side</label>
                                <asp:DropDownList ID="ddlSteeringside" runat="server" CssClass="validate chosen-select form-control" data-error-id="errSteeringside" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                    <asp:ListItem Value="0">-Select Steering Side-</asp:ListItem>
                                    <asp:ListItem Value="LHS">Left Hand Side</asp:ListItem>
                                    <asp:ListItem Value="RHS">Right Hand Side</asp:ListItem>
                                </asp:DropDownList>
                                <p id="errSteeringside" class="error-message">Please select Fuel Type</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Engine Capacity(CC)</label>
                                <asp:TextBox ID="txtCC" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errCC" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errCC" class="error-message">Please enter CC</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Cylinders</label>
                                <asp:TextBox ID="txtCylinders" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errCylinders" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errCylinders" class="error-message">Please enter Cylinders</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Doors</label>
                                <asp:TextBox ID="txtDoors" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errDoors" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errDoors" class="error-message">Please enter CC</p>
                            </div>
                        </div>
                         <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Seats</label>
                                <asp:TextBox ID="txtSeats" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errSeats" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errSeats" class="error-message">Please enter Seats</p>
                            </div>
                        </div>
                         <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Wheel Size</label>
                                <asp:TextBox ID="txtWheelSize" runat="server" autocomplete="off" CssClass="validate form-control" data-error-id="errWheelSize" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errWheelSize" class="error-message">Please enter Wheel Size</p>
                            </div>
                        </div>
                         <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Sunroof</label>
                                <div class="custom-radiobox">
                                    <asp:DropDownList ID="ddlsunroof" runat="server" CssClass="validate chosen-select form-control" data-error-id="errSunroof" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                        <asp:ListItem Value="No">No</asp:ListItem>
                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                    <p id="errSunroof" class="error-message">Please select Sunroof</p>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Weight</label>
                                <asp:TextBox ID="txtWeight" runat="server" TextMode="Number" MaxLength="8" autocomplete="off" CssClass="validate form-control" data-error-id="errWeight" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errWeight" class="error-message">Please enter Weight</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Length</label>
                                <asp:TextBox ID="txtLength" runat="server" TextMode="Number" MaxLength="8" autocomplete="off" CssClass="validate form-control" data-error-id="errLength" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errLength" class="error-message">Please enter Length</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Width</label>
                                <asp:TextBox ID="txtWidth" runat="server" TextMode="Number" MaxLength="8" autocomplete="off" CssClass="validate form-control" data-error-id="errWidth" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errWidth" class="error-message">Please enter Width</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Height</label>
                                <asp:TextBox ID="txtheight" runat="server" TextMode="Number" MaxLength="8" autocomplete="off" CssClass="validate form-control" data-error-id="errHeight" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errHeight" class="error-message">Please enter Height</p>
                            </div>
                        </div>
                       <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Product Type</label>
                                <div class="custom-radiobox">
                                    <asp:DropDownList ID="ddlPType" runat="server" CssClass="chosen-select form-control">
                                        <asp:ListItem Value="Normal">Normal</asp:ListItem>
                                        <asp:ListItem Value="Hybrid">Hybrid</asp:ListItem>
                                        <asp:ListItem Value="Electric">Electric</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Mild Hybrid</label>
                                <div class="custom-radiobox">
                                    <asp:DropDownList ID="ddlhybrid" runat="server" CssClass="chosen-select form-control">
                                        <asp:ListItem Value="No">No</asp:ListItem>
                                        <asp:ListItem Value="Yes">Yes</asp:ListItem>
                                    </asp:DropDownList>
                                </div>
                            </div>
                        </div>
                        <div class="col-xl-12 col-lg-12 col-md-12 col-12">
                            <asp:Button ID="Button1" runat="server" Text="Submit" OnClientClick="return ValidateFormData();" class="btn btn-primary float-end mt-4" OnClick="Button1_Click" />
                            <asp:Button ID="Button2" runat="server" Text="Update" OnClientClick="return ValidateFormData();" Visible="false" CssClass="btn btn-primary float-end mt-4" OnClick="Button2_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdnVariantId" runat="server" />

</asp:Content>
