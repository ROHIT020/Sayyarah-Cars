<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="GenerateInvoice.aspx.cs" Inherits="SayyarahCars.Admin.GenerateInvoice" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script type="text/javascript">
        function PrintGridData() {
            var prtGrid = document.getElementById('<%=Grid.ClientID %>');
            prtGrid.border = 0;
            var prtwin = window.open('', 'PrintGridViewData', 'left=100,top=100,width=1000,height=1000,tollbar=0,scrollbars=1,status=0,resizable=1');
            prtwin.document.write(prtGrid.outerHTML);
            prtwin.document.writeln('<body MS_POSITIONING="GridLayout" bottomMargin="0"');
            prtwin.document.writeln(' leftMargin="0" topMargin="0" rightMargin="0">');
            prtwin.document.close();
            prtwin.focus();
            prtwin.print();
            prtwin.close();
        }
    </script>
    <style>
        table {
            font-size: 14px;
        }
    </style>
    <div class="container">
        <div class="row">
            <div class="col">
                <h4>Print Invoice </h4>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="padding-bottom: 20px">
                <div id="Grid12" runat="server">
                    <table id="Grid" runat="server" style="width: 1000px; margin-left: 0px; margin-right: 0px;">
                        <tr>
                            <td colspan="5">
                                <div>
                                    <asp:Image ID="lblCompLogo" runat="server" Width="160px" ImageUrl="~/Contents/admin/images/logo1.png"></asp:Image>
                                </div>
                            </td>
                        </tr>
                        <tr style="padding-top: 10px">
                            <td colspan="4"><b runat="server" id="lblCompName" font-size="13px">Sayyrah Cars</b></td>
                            <td rowspan="3" style="text-align: right; background-color: #0d6efd;">
                                <div style="background-color: #0d6efd; display: block" runat="server" id="divHeadInv">
                                    <div style="color: #fff; padding-right: 20px; text-align: right; font-size: 18px">INVOICE </div>
                                    <div style="color: #fff; padding-right: 20px; font-size: 16px">
                                        <asp:Label ID="lblInvoiceNo" runat="server" Text=""></asp:Label>
                                    </div>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" font-size="12px">8-36-A202, Chigasaki Chuo , Tsuzuki-ku, Yokohama-city, Kanagawa-ken, 224-0032, JAPAN
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3" font-size="12px">TEL 045-507-8363  Fax  045-507-8364</td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="font-size: 13px !important"><b>Billed To</b></td>
                            <td colspan="4">:
                                <asp:Label ID="lblcutomername" runat="server" Text="" Font-Size="12px" Visible="false"></asp:Label>
                                <asp:Label ID="lblcutomername1" runat="server" Text="" Font-Size="12px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 150px !important; font-size: 13px !important"><b>Customer Code</b> </td>
                            <td colspan="4">:
                                        <asp:Label ID="lblCustomerCode" runat="server" Text="" Font-Size="12px"></asp:Label>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 160px !important; font-size: 13px !important"><b>Invoice Date</b> </td>
                            <td style="width: 160px !important; font-size: 13px !important"><b>Due Date  </b></td>
                            <td style="font-size: 13px !important"><b>Delivery Till </b></td>
                            <td colspan="2" style="padding-left: 50px; font-size: 13px !important"><b>Invoice Amount</b> </td>
                        </tr>
                        <tr>
                            <td style="text-align: left">
                                <asp:Label ID="lblInvoiceDate" runat="server" Text="" Font-Size="12px"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblduedate" runat="server" Text="" Font-Size="12px"></asp:Label>
                            </td>
                            <td style="text-align: left">
                                <asp:Label ID="lblDeliverTill" runat="server" Text="" Font-Size="12px"></asp:Label>
                            </td>
                            <td colspan="2" style="padding-left: 50px"><b>
                                <asp:Label ID="lblinvamout" runat="server" Text="0" Font-Size="12px"></asp:Label>
                            </b></td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td style="width: 160px !important; font-size: 13px !important"><b>Port of Loading</b> </td>
                            <td>:
                                        <asp:Label ID="lblLodingPort" runat="server" Text="" Font-Size="12px"></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td style="width: 160px !important; font-size: 13px !important"><b>Port of Arrival</b> </td>
                            <td>:
                                        <asp:Label ID="lblArrivalPort" runat="server" Text="" Font-Size="12px"></asp:Label></td>
                            <td></td>
                            <td></td>
                            <td></td>
                        </tr>
                        <tr>
                            <td colspan="5">&nbsp; &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="5" style="border-bottom: solid 1px #808080">
                                <table style="width: 100%; border-collapse: collapse;">
                                    <thead style="padding: 10px; border: 0; background: #279f19; height: 30px; color: #fff;">
                                        <tr>
                                            <th colspan="3" style="text-align: left; padding: 5px 10px; border: 0; background: #0d6efd; height: 24px; color: #fff; font-size: 13px !important"> Description </th>
                                            <th style="text-align:left; padding:5px 0px; border:0; background: #0d6efd; height: 24px; color: #fff; font-size: 13px !important"> FOB/C&F </th>
                                            <th style="text-align:Right; padding:5px 10px; border:0; background: #0d6efd; height: 24px; color: #fff; font-size: 13px !important"> Amount </th>
                                        </tr>
                                    </thead>
                                    <tbody>
                                        <tr style="height: 50px">
                                            <td colspan="3" style="padding: 5px">
                                                <span id="pname" runat="server" style="font-size: 12px !important"></span>
                                                <br />
                                                <asp:Label ID="lblChasisNo" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </td>
                                            <td>
                                                <asp:Label ID="lblfob" runat="server" Text="" Font-Size="12px"></asp:Label>
                                            </td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lblcarprice" runat="server" Text="0" Font-Size="12px"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr style="background-color: #EBEBEB; height: 30px" id="TRPushPrice" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Push Price  </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">

                                                <asp:Label ID="lblPushPrice" runat="server" Text="0" Font-Size="12px"></asp:Label>
                                            </td>
                                        </tr>

                                        <tr style="background-color: #EBEBEB; height: 30px" id="TRfreight" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Freight  </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">

                                                <asp:Label ID="lblfreight" runat="server" Text="0" Font-Size="12px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="height: 30px" id="TRrecycleCharges" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Recycle Charges </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lblrecycleCharge" runat="server" Text="0" Font-Size="12px"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr style="background-color: #EBEBEB; height: 30px" id="TRotherServices" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Other Services  </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lblOtherServices" runat="server" Text="0" Font-Size="12px"></asp:Label></td>
                                        </tr>
                                        <tr style="height: 30px;" id="TRdinsuranceCharges" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Insurance Charges  </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lblInsuranceCharges" runat="server" Text="0" Font-Size="12px"></asp:Label></td>
                                        </tr>
                                        <tr style="height: 30px;" id="TRcustomClearance" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Custom Clearance  </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lblcustomeClearance" runat="server" Text="0" Font-Size="12px"></asp:Label></td>
                                        </tr>

                                        <%--<tr style="height: 30px;" id="TRservice" runat="server">
                                            <td colspan="3" style="padding: 5px">Service Charges </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lblServiceCharges" runat="server" Text="0"></asp:Label></td>
                                        </tr>--%>

                                        <tr style="height: 30px;" id="TRtransport" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Additional transport & Yard Handling Charges  </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lbltransport" runat="server" Text="0" Font-Size="12px"></asp:Label></td>
                                        </tr>
                                        <tr style="height: 30px;" id="TRpositivediscount" runat="server">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Positive Discount  </td>
                                            <td>--</td>
                                            <td style="text-align: Right; padding-right: 10px">
                                                <asp:Label ID="lblPositiveDiscount" runat="server" Text="0" Font-Size="12px"></asp:Label></td>
                                        </tr>
                                        <tr style="background-color: #EBEBEB; height: 30px">
                                            <td colspan="3" style="padding: 5px; font-size: 13px !important">Thanks for your business</td>
                                            <td><b style="font-size: 13px !important">Total</b></td>
                                            <td style="text-align: Right; padding-right: 10px"><b>
                                                <asp:Label ID="lbltotalamtbeforetax" runat="server" Text="0" Font-Size="12px"></asp:Label></b></td>
                                        </tr>
                                    </tbody>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="border-bottom: solid 1px #808080; padding-bottom: 10px; padding-top: 10px">
                                <p><b style="font-size: 13px !important">Payment Terms:</b></p>
                                <p style="padding-left: 80px">
                                    <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Disc" Font-Bold="True" Font-Size="12px">
                                    </asp:BulletedList>
                                </p>

                            </td>
                        </tr>
                        <tr>
                            <td colspan="5" style="padding-top: 10px">
                                <p><b style="font-size: 13px">Inclusions</b></p>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="5"><b style="font-size: 13px">FOB  </b>: <span style="font-size: 13px">Vehicle cost, Auction house fee, Local transportation cost, Japan Port Charges, Radiation charges, Sayyrah Cars service charges</span></td>
                        </tr>
                        <tr>
                            <td colspan="5" style="padding-bottom: 10px; font-size: 13px !important"><b style="font-size: 13px">C&F  </b>: <span style="font-size: 13px">Vehicle cost, Auction house fee, Local transportation cost, Japan Port Charges, Radiation charges, Sayyrah Cars service,
                                   Shipment charges, country specific Inspection charges (if required).</span>
                            </td>

                        </tr>
                        <tr>
                            <td colspan="5" style="border-top: solid 1px #808080">&nbsp;&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <table style="width: 100%">
                                    <tr>
                                        <td colspan="2" style="font-size: 13px"><b>Bank Details</b></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 190px; font-size: 13px">Bank Name</td>
                                        <td>:
                                           <asp:Label ID="lblbankname" runat="server" Font-Size="12px"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td style="width: 190px !important; font-size: 13px">Branch Name</td>
                                        <td>:
                                           <asp:Label ID="lblbranch" runat="server" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 13px">Swift Code</td>
                                        <td>:
                                           <asp:Label ID="lblswift" runat="server" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 190px !important; font-size: 13px">Account No.</td>
                                        <td>:
                                            <asp:Label ID="lblaccount" runat="server" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="width: 190px !important; font-size: 13px">Account Name</td>
                                        <td>:
                                            <asp:Label ID="lblaccountname" runat="server" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td style="font-size: 13px !important">Address</td>
                                        <td>:
                                             <asp:Label ID="lblbaddress" runat="server" Font-Size="12px"></asp:Label>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td colspan="2" style="text-align: right; padding-right: 20px">
                                <asp:Image ID="Image2" runat="server" Width="160px" ImageUrl="https://www.Bizupon.com/images/signature.png" /></td>
                        </tr>
                        <tr>
                            <td colspan="5" style="border-top: solid 1px #808080">&nbsp;&nbsp;</td>
                        </tr>
                        <%--<tr>
                            <td colspan="5" style="text-align: right; padding-right: 20px; width: 100%">
                                <img src="../Contents/admin/images/logo1.png" runat="server" id="imgCompLogo" /></td>
                        </tr>--%>
                        <%--<tr>
                            <td colspan="5" style="width: 100%; line-height: 50px"></td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width: 100%; line-height: 50px"></td>
                        </tr>
                        <tr>
                            <td colspan="5" style="width: 100%; line-height: 50px"></td>
                        </tr>--%>
                    </table>
                </div>
                <div class="col-md-12 col-sm-12 col-xs-12">
                    <asp:Button ID="btnExport" runat="server" Text="Send Mail" CssClass="btn btn-primary" OnClick="btnExport_Click" />
                    <asp:Button ID="Button1" runat="server" Text="Download" CssClass="btn btn-primary" OnClick="Button1_Click" />
                    <asp:HiddenField ID="HEmail" runat="server" />
                    <input type="button" id="btnPrint" value="Print Invoice" class="btn btn-primary" onclick="PrintGridData()" />
                </div>
            </div>

        </div>
    </div>

    <style>
        @media print {
            html, body {
                width: 794px;
                height: 1123px;
                margin: 0;
                padding: 0;
                overflow: hidden;
            }

            #pdfContainer {
                width: 100%;
                height: 100%;
                overflow: hidden;
                page-break-inside: avoid;
            }

            img {
                max-width: 200px;
                height: auto;
            }

            table {
                width: 100%;
                font-size: 12px;
            }
        }
    </style>


</asp:Content>
