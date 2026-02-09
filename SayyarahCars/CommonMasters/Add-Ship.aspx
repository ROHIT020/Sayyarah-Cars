<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="Add-Ship.aspx.cs" Inherits="SayyarahCars.CommonMasters.Add_Ship" %>

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
                                <label class="form-label" for="shipping">Ship Type</label>
                                <asp:DropDownList ID="ddlshiptype" runat="server" CssClass="chosen-select form-control">
                                    <asp:ListItem Value="1">Real Ship</asp:ListItem>
                                    <asp:ListItem Value="2">Tentative Ship</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Shipping Company</label>
                                <asp:DropDownList ID="ddlShipingCompany" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlShipingCompanyError" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddlShipingCompanyError" class="error-message">Please select Shipping Company</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="countryName">Port From</label>
                                <asp:DropDownList ID="ddlPortFrom" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlPortFromError" ClientIDMode="Static" OnSelectedIndexChanged="ddlPortFrom_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <p id="ddlPortFromError" class="error-message">Please select Port From</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Terminal Name</label>
                                <asp:DropDownList ID="ddlTerminalName" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlTerminalNameError" ClientIDMode="Static">
                                    <asp:ListItem Value="0">--Select Terminal--</asp:ListItem>
                                </asp:DropDownList>
                                <p id="ddlTerminalNameError" class="error-message">Please select Terminal Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Country Name</label>
                                <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCountryNameError" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="ddlCountryNameError" class="error-message">Please select Country Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Enter Ship Name</label>
                                <asp:TextBox ID="txtShipName" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtShipNameError" placeholder="Enter Ship Name" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtShipNameError" class="error-message">Please enter Ship Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Departure Date</label>
                                <asp:TextBox ID="txtDepartureDate" runat="server" TextMode="Date" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtDepartureDateError" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtDepartureDateError" class="error-message">Please enter Departure Date</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Arrival Date</label>
                                <asp:TextBox ID="txtArrivalDate" runat="server" TextMode="Date" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtArrivalDateError" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtArrivalDateError" class="error-message">Please enter Arrival Date</p>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Ship Freight</label>
                                <asp:TextBox ID="txtShipFreight" runat="server" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtShipFreightDateError" ClientIDMode="Static" placeholder="Enter Ship Freight"></asp:TextBox>
                                <p id="txtShipFreightDateError" class="error-message">Please enter Ship Freight</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Loading Capacity</label>
                                <asp:TextBox ID="txtLoadingCapacity" runat="server" TextMode="Number" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtLoadingCapacityError" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtLoadingCapacityError" class="error-message">Please enter Loading Capacity</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Ship Use</label>
                                <asp:DropDownList ID="ddlshipuse" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                    <asp:ListItem Value="1">Normal</asp:ListItem>
                                    <asp:ListItem Value="2">Next Time</asp:ListItem>
                                    <asp:ListItem Value="3">Final Time</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-xl-1 col-lg-12 col-md-12 col-12">
                            <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClientClick="return ValidateFormData();" class="btn btn-primary float-end mt-4" OnClick="Button1_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" OnClientClick="return ValidateFormData();" CssClass="btn btn-primary float-end mt-4" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnshipId" runat="server" />
      
</asp:Content>
