<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Make-Invoice.aspx.cs" Inherits="SayyarahCars.Admin.Make_Invoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Make Invoice</h5>
                    <%--<a href="Manage-Invoices.aspx" class="btn btn-secondary"><i class="ti ti-eye"></i>View Invoices</a>--%>
                </div>

                <div class="col-lg-12 col-md-12 col-12">
                    <div class="card">
                        <div class="card-body">
                            <div class="row">
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label" for="shipping">Product Type</label>
                                        <asp:DropDownList ID="ddlProductType" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                            <asp:ListItem Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2">Constructor</asp:ListItem>
                                            <asp:ListItem Value="3">Container</asp:ListItem>
                                            <asp:ListItem Value="4">Cut</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Select Customer</label>
                                        <asp:DropDownList ID="ddlCustomer" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlCustomerError" ClientIDMode="Static"></asp:DropDownList>
                                        <span id="ddlCustomerError" class="error-message">Please Select customer name</span>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Product Name</label>
                                        <asp:TextBox ID="txtProductName" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Chassis No</label>
                                        <asp:TextBox ID="txtChassisNo" runat="server" autocomplete="off" CssClass="validate form-control" data-type="text"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Auction Name</label>
                                        <asp:DropDownList ID="ddlAuctionName" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown"></asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Shipping Company</label>
                                        <asp:DropDownList ID="ddlShippingCompany" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlShippingCompanyError" ClientIDMode="Static"></asp:DropDownList>
                                        <span id="ddlShippingCompanyError" class="error-message">Please Select shipping company name</span>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Invoice Type</label>
                                        <asp:DropDownList ID="ddlInvoiceType" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                            <asp:ListItem Value="1">FOB</asp:ListItem>
                                            <asp:ListItem Value="2">C &amp; F</asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Port Name</label>
                                        <asp:DropDownList ID="ddlPortName" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlPortNameError" ClientIDMode="Static"></asp:DropDownList>
                                        <span id="ddlPortNameError" class="error-message">Please Select port name</span>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Currency Type</label>
                                        <asp:DropDownList ID="ddlCurrencyType" runat="server" CssClass="validate chosen-select form-control" data-type="dropdown">
                                        </asp:DropDownList>
                                    </div>
                                </div>
                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Push Price</label>
                                        <asp:TextBox ID="txtPushPrice" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control" onkeyup="sum();"></asp:TextBox>

                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">FOB Price</label>
                                        <asp:TextBox ID="txtFOBPrice" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control" onkeyup="sum();"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Freight Charge</label>
                                        <asp:TextBox ID="txtFreightCharge" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Recycle Amount</label>
                                        <asp:TextBox ID="txtRecycleAmount" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Other Services</label>
                                        <asp:TextBox ID="txtOtherServices" runat="server" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Insurance</label>
                                        <br />
                                        <asp:RadioButtonList ID="myCheck" runat="server" onclick="myFunction()" RepeatDirection="Horizontal" RepeatLayout="Flow">
                                            <asp:ListItem Value="Y">&nbsp;&nbsp;Yes &nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="N" Selected="True">&nbsp;&nbsp; No </asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Insurance</label>
                                        <asp:TextBox ID="txtInsurance" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Radiation Price</label>
                                        <asp:TextBox ID="txtRadiationPrice" runat="server" TextMode="Number" step="any" Text="0" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Inspection Price</label>
                                        <asp:TextBox ID="txtInspectionPrice" runat="server" TextMode="Number" step="any" Text="0" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Port Price</label>
                                        <asp:TextBox ID="txtPortPrice" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Custom Clearance</label>
                                        <asp:TextBox ID="txtCustomClearance" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Car Selection</label>
                                        <asp:TextBox ID="txtCarSelection" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Transport</label>
                                        <asp:TextBox ID="txtTransport" runat="server" Text="0" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Final Sold Price</label>
                                        <asp:TextBox ID="txtFinalSoldPrice" runat="server" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" ClientIDMode="Static" data-error-id="txtFinalSoldPriceError" placeholder="Enter Amount"></asp:TextBox>
                                        <span id="txtFinalSoldPriceError" class="error-message">Please enter price</span>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Order Type</label><br />
                                        <asp:RadioButtonList ID="radiortype" runat="server" RepeatDirection="Horizontal" RepeatLayout="Flow" data-required="true">
                                            <asp:ListItem Value="O" Selected="True">&nbsp;Ordered &nbsp;&nbsp;</asp:ListItem>
                                            <asp:ListItem Value="N">&nbsp;&nbsp;Not Ordered</asp:ListItem>
                                        </asp:RadioButtonList>
                                        <br />
                                        <asp:RequiredFieldValidator ID="rfvOrderType" runat="server" ControlToValidate="radiortype" InitialValue="" ErrorMessage="Please select Order Type" CssClass="error-message" Display="Dynamic" ForeColor="Red" />
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Discount</label>
                                        <asp:TextBox ID="txtDiscount" runat="server" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Rate</label>
                                        <asp:TextBox ID="txtRate" runat="server" TextMode="Number" step="any" autocomplete="off" CssClass="validate form-control"></asp:TextBox>
                                    </div>
                                </div>

                                <div class="col-lg-3 col-md-3 col-12">
                                    <div class="form-group">
                                        <label class="form-label">Invoice Used</label>
                                        <asp:DropDownList ID="ddlInvoiceUsed" CssClass="validate chosen-select form-control" data-live-search="true" runat="server">
                                            <asp:ListItem Value="1">Normal</asp:ListItem>
                                            <asp:ListItem Value="2"> Ruble </asp:ListItem>
                                        </asp:DropDownList>
                                    </div>
                                </div>

                                <div class="col-lg-1 col-md-1 col-12">
                                    <asp:Button ID="btnSubmit" runat="server" OnClientClick="return ValidateFormData();" CssClass="btn btn-primary float-end mt-4" Text="Submit" OnClick="btnSubmit_Click" /> 
                                </div>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <asp:HiddenField ID="hdnInvoiceId" runat="server" />
    <asp:HiddenField ID="Hiddenfob" runat="server" Value="0" />
    <asp:HiddenField ID="Hdollaryenprice" runat="server" />
    <asp:HiddenField ID="Hnetpprice" runat="server" Value="0" />
    <asp:HiddenField ID="Hnetprice" runat="server" Value="0" />
    <asp:HiddenField ID="CountryId" runat="server" Value="0" />
    <asp:HiddenField ID="AuctionDate" runat="server" Value="0" />
    <asp:HiddenField ID="Hiddeninsurance" runat="server" Value="0" />

    <script>
        function fobchange() {
            var txtnetprice = document.getElementById('txtnetprice').value;
            var txtfob = document.getElementById('txtfob').value;
            var discount = "0";
            var fob = document.getElementById('Hiddenfob').value;
            if (discount == "")
                discount = "0";
            if (txtnetprice == "")
                txtnetprice = 0;
            if (txtfob == "")
                txtfob = 0;
            var countfob = parseInt(fob) - (parseInt(fob) * parseInt(discount)) / 100;
            document.getElementById('txtfob').value = countfob;
            txtfob = countfob;
            var result = parseFloat(txtnetprice) + parseFloat(txtfob);

            if (!isNaN(result)) {
                document.getElementById('txtprice').value = result;
            }
            myFunction();
        }
        function sum() {

            // Get input elements and their values
            var txtrprice = document.getElementById('ContentPlaceHolder1_txtRadiationPrice').value;
            var txtinprice = document.getElementById('ContentPlaceHolder1_txtInspectionPrice').value;
            var txtCustomClearance = "0"; // Replace with actual input if needed
            var txtCarSelection = "0";    // Replace with actual input if needed
            var txtpprice = document.getElementById('ContentPlaceHolder1_txtPortPrice').value;
            var txtInsurance = document.getElementById('ContentPlaceHolder1_txtInsurance').value;
            var txtnetprice = document.getElementById('ContentPlaceHolder1_txtPushPrice').value;
            var txtfob = document.getElementById('ContentPlaceHolder1_txtFOBPrice').value;

            // Optional: get hidden FOB value
            var fob = document.getElementById('ContentPlaceHolder1_Hiddenfob').value;

            // Convert all values to float
            var netPrice = parseFloat(txtnetprice) || 0;
            var fobPrice = parseFloat(txtfob) || 0;
            var radiationPrice = parseFloat(txtrprice) || 0;
            var inspectionPrice = parseFloat(txtinprice) || 0;
            var clearancePrice = parseFloat(txtCustomClearance) || 0;
            var carSelectionPrice = parseFloat(txtCarSelection) || 0;
            var portPrice = parseFloat(txtpprice) || 0;
            var insurance = parseFloat(txtInsurance) || 0;

            // Calculate total
            var result = netPrice + fobPrice + radiationPrice + inspectionPrice +
                clearancePrice + carSelectionPrice + portPrice + insurance;

            // Set final price in the output field
            if (!isNaN(result)) {
                document.getElementById('txtFinalSoldPrice').value = result;
            }
        }

        function myFunction() {
            var selectedvalue = $('#<%= myCheck.ClientID %> input:checked').val()
            var Insurancet = document.getElementById('txtInsurance').value;
            var Price = document.getElementById('txtFinalSoldPrice').value;
            var InsuINT = document.getElementById('Hiddeninsurance').value;
            var Doc = parseFloat(Price) * parseFloat(InsuINT);
            var finalINT = parseInt(Doc);
            document.getElementById('txtInsurance').value = finalINT;
        }

        function domesticsum() {
            var txtnnetprice = document.getElementById('txtnnetprice').value;
            var txtffob = document.getElementById('txtffob').value;

            if (txtnnetprice == "")
                txtnnetprice = 0;

            if (txtffob == "")
                txtffob = 0;

            var resultdomestic = parseFloat(txtnnetprice) + parseFloat(txtffob) + parseFloat(txtffob) / 10;
            if (!isNaN(resultdomestic)) {
                document.getElementById('txtFinalSoldPrice').value = resultdomestic;
            }
        }
    </script>

</asp:Content>
