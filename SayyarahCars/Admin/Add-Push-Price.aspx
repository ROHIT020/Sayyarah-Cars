<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="Add-Push-Price.aspx.cs" Inherits="SayyarahCars.Admin.Add_Push_Price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <div class="col-lg-12 col-md-12 col-12">
                        <div class="row">
                            <div class="col-md-3">
                                <label class="control-label">
                                    <b>Chassis No.:
                        <asp:Label ID="lblcno" runat="server"></asp:Label>
                                    </b>
                                </label>
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">
                                    <b>Auction House:
                        <asp:Label ID="lblAuctionHouse" runat="server"></asp:Label>
                                    </b>
                                </label>
                            </div>
                            <div class="col-md-3">
                                <label class="control-label">
                                    <b>Auction Date:
                        <asp:Label ID="lblAuctionDate" runat="server"></asp:Label>
                                    </b>
                                </label>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="card-body">

                    <div class="row">
                        <div class="col-md-2" style="display: none">
                            <div class="form-group">
                                <label class="control-label"><b>Currency Type</b></label>
                                <asp:DropDownList ID="ddlctype" runat="server" CssClass="validate chosen-select form-control" data-error-id="errctype" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                </asp:DropDownList>
                                <p id="errctype" class="error-message">Please select Currency Type</p>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Type</b></label>
                                <asp:DropDownList ID="ddlPPType" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="10">Push P Taxable </asp:ListItem>
                                    <asp:ListItem Value="0">Handicap/Tax Free Zone</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Push Price</b></label>
                                <asp:TextBox ID="txtPushPrice" runat="server" CssClass="validate form-control" placeholder="Amount" data-error-id="errPP" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtPushPriceTax" runat="server" CssClass="form-control" placeholder="Tax" ClientIDMode="Static"></asp:TextBox>
                                <p id="errPP" class="error-message">Please enter Push Price</p>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>ABF Type</b></label><br />
                                <asp:DropDownList ID="ddlABFType" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Auction BF </b></label>
                                <asp:TextBox ID="txtAuctionFeed" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtAuctionFeedTax" runat="server" CssClass="form-control" placeholder="Tax" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>No. plate </b></label>
                                <asp:TextBox ID="txtNoPlate" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtNoPlateTax" runat="server" CssClass="form-control" placeholder="Tax" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>No. plate </b></label>
                                <asp:TextBox ID="txtNoPlateNTax" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Security Deposit </b></label>
                                <asp:TextBox ID="txtSecurity" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtSecurityTax" runat="server" CssClass="form-control" placeholder="Tax" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Security Deposit </b></label>
                                <asp:TextBox ID="txtSecurityNTax" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Transport </b></label>
                                <asp:TextBox ID="txtTransport" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtTransportTax" runat="server" CssClass="form-control" placeholder="Tax" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Cancellation</b></label>
                                <asp:TextBox ID="txtCancellation" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtCancellationTax" runat="server" CssClass="form-control" placeholder="Tax" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Car Penalty </b></label>
                                <asp:TextBox ID="txtCarPanalty" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Recycle Fee(Tax)</b></label>
                                <asp:TextBox ID="txtRecycleFee" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Other Type</b></label><br />
                                <asp:DropDownList ID="ddlOtherType" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Other Debit </b></label>
                                <asp:TextBox ID="txtOtherTypeAmt" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                                <asp:TextBox ID="txtOtherTypeTax" runat="server" CssClass="form-control" placeholder="Tax" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Other Type NT</b></label><br />
                                <asp:DropDownList ID="ddlOtherNType" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label"><b>Other Debit(N Tax)</b></label>
                                <asp:TextBox ID="txtOtherNTypeAmt" runat="server" CssClass="form-control" placeholder="Amount" ClientIDMode="Static"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label"><b>Total</b></label>
                                <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control" placeholder="Total Amount" ClientIDMode="Static"></asp:TextBox>

                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label"><b>Remark</b></label>
                                <asp:TextBox ID="txtRemarks" runat="server" CssClass="validate form-control" placeholder="Remarks" data-error-id="errRemarks" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                <p id="errRemarks" class="error-message">Please enter Remarks</p>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <label class="form-label">&nbsp;</label>
                            <%--<asp:Button ID="btnsubmit" runat="server" Cssclass="btn btn-primary float-end mt-2" Text="Submit" OnClientClick="return ValidateFormData();" OnClick="btnsubmit_Click"></asp:Button>--%>
                            <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary float-end mt-2" Text="Submit" OnClick="btnsubmit_Click"></asp:Button>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>


    <script src="../Contents/admin/js/jquery.min.js"></script>
    <script>
        $(document).ready(function () {


            function parseFloatSafe(value) {
                const num = parseFloat(value.replace(/,/g, '').trim());
                return isNaN(num) ? 0 : num;
            }


            function setupTaxHandler(amountId, taxId) {
                $(`[id=${amountId}]`).on('input', function () {
                    const amount = parseFloatSafe($(this).val());
                    const tax = Math.round(amount / 10);
                    $(`[id=${taxId}]`).val(tax);
                    calculateTotal();
                });
            }


            function setupToggleFields(mainId, toggleIds) {
                $(`[id=${mainId}]`).on('input', function () {
                    const hasValue = $(this).val().trim() !== "";

                    toggleIds.forEach(id => {
                        const $field = $(`[id=${id}]`);
                        if (hasValue) {
                            $field.prop('disabled', true).val(0);
                        } else {
                            $field.prop('disabled', false);
                        }
                    });

                    calculateTotal();
                });
            }


            function calculateTotal() {
                let total = 0;
                const ids = [
                    'txtPushPrice', 'txtPushPriceTax',
                    'txtAuctionFeed', 'txtAuctionFeedTax',
                    'txtNoPlate', 'txtNoPlateTax', 'txtNoPlateNTax',
                    'txtSecurity', 'txtSecurityTax', 'txtSecurityNTax',
                    'txtTransport', 'txtTransportTax',
                    'txtCancellation', 'txtCancellationTax',
                    'txtCarPanalty', 'txtRecycleFee',
                    'txtOtherTypeAmt', 'txtOtherTypeTax',
                    'txtOtherNTypeAmt'
                ];

                ids.forEach(id => {
                    total += parseFloatSafe($(`[id=${id}]`).val());
                });

                $("[id=txtTotalAmount]").val(total.toFixed(2));
            }

            //setupTaxHandler('txtPushPrice', 'txtPushPriceTax');
            setupTaxHandler('txtAuctionFeed', 'txtAuctionFeedTax');
            setupTaxHandler('txtNoPlate', 'txtNoPlateTax');
            setupTaxHandler('txtSecurity', 'txtSecurityTax');
            setupTaxHandler('txtTransport', 'txtTransportTax');
            setupTaxHandler('txtCancellation', 'txtCancellationTax');
            setupTaxHandler('txtOtherTypeAmt', 'txtOtherTypeTax');


            setupToggleFields('txtNoPlate', ['txtNoPlateNTax']);
            setupToggleFields('txtNoPlateNTax', ['txtNoPlate', 'txtNoPlateTax']);

            setupToggleFields('txtSecurity', ['txtSecurityNTax']);
            setupToggleFields('txtSecurityNTax', ['txtSecurity', 'txtSecurityTax']);


            const simpleIds = [
                'txtCarPanalty', 'txtRecycleFee', 'txtOtherNTypeAmt',
                'txtNoPlateNTax', 'txtSecurityNTax'
            ];
            simpleIds.forEach(id => {
                $(`[id=${id}]`).on('input', calculateTotal);
            });


            $("[id=ddlPPType], [id=txtPushPrice]").on('change input', function () {
                const amount = parseFloatSafe($("[id=txtPushPrice]").val());
                const type = parseInt($("[id=ddlPPType]").val());

                const tax = (type === 10) ? Math.round(amount / 10) : 0;
                $("[id=txtPushPriceTax]").val(tax);

                calculateTotal();
            });
        });
    </script>
    <%--<script type="text/javascript">
        var btnSubmitClientId = '<%= btnsubmit.ClientID %>';
    </script>--%>
</asp:Content>
