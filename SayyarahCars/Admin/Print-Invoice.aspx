<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Print-Invoice.aspx.cs" Inherits="SayyarahCars.Admin.Print_Invoice" %>
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
                                    <td colspan="5" style="height: 100px">
                                        <img src="../Contents/admin/images/logo1.png" style="width: 160px; height: 58px" /></td>
                                </tr>
                                <tr style="padding-top: 10px">
                                    <td colspan="4"><b>Bizupon Co. Ltd.</b></td>
                                    <td rowspan="4" style="text-align: right; background-color: #279f19;">
                                        <div style="background-color: #279f19; display: block">
                                            <div style="color: #fff; padding-top: 10px; padding-right: 20px; text-align: right; font-size: 22px">INVOICE </div>
                                            <div style="color: #fff; padding-bottom: 10px; padding-right: 20px; font-size: 22px">
                                                <asp:Label ID="lblinvno" runat="server" Text=""></asp:Label>
                                            </div>
                                        </div>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">8-36-A202, Chigasaki Chuo , Tsuzuki-ku
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">Yokohama-city, Kanagawa-ken, 224-0032, JAPAN </td>
                                </tr>
                                <tr>
                                    <td colspan="3">TEL 045-507-8363  Fax  045-507-8364 </td>
                                </tr>
                                <tr>
                                    <td colspan="5">&nbsp; &nbsp;</td>
                                </tr>
                                <tr>
                                    <td><b>Billed To</b></td>
                                    <td colspan="4">:
                                        <asp:Label ID="lblcutomername" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td><b>Address</b></td>
                                    <td colspan="4">:
                                        <asp:Label ID="Lbladdress" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5">&nbsp; &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 100px"><b>Customer Code</b> </td>
                                    <td colspan="4">:
                                        <asp:Label ID="lblccode" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width:190px !important"><b>Invoice Date</b> </td>
                                    <td style="width:300px !important"><b>Due Date  </b></td>
                                    <td style="width:300px !important"><b>Delivery till </b></td>
                                    <td colspan="2" style="padding-left: 50px"><b>Invoice Amount</b> </td>

                                </tr>
                                <tr>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblinvnodate" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lblduedate" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="text-align: left">
                                        <asp:Label ID="lbldays" runat="server" Text=""></asp:Label>
                                    </td>
                                    <td style="padding-left: 50px"><b>
                                        <asp:Label ID="lblinvamout" runat="server" Text="0"></asp:Label>
                                    </b></td>
                                </tr>
                                <tr>
                                    <td colspan="5">&nbsp; &nbsp;</td>
                                </tr>

                                <tr>
                                    <td colspan="5">&nbsp; &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5">&nbsp; &nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="border-bottom: solid 1px #808080">
                                        <table style="width: 100%; border-collapse: collapse;">
                                            <thead style="padding: 10px; border: 0; background: #279f19; height: 30px; color: #fff;">
                                                <tr>
                                                    <th colspan="3" style="text-align: left; padding: 10px; border: 0; background: #279f19; height: 30px; color: #fff;">Description </th>
                                                    <th style="text-align: left; padding: 10px; border: 0; background: #279f19; height: 30px; color: #fff;">FOB/C&F </th>
                                                    <th style="text-align: Right; padding: 10px; border: 0; background: #279f19; height: 30px; color: #fff;">Amount </th>
                                                </tr>
                                            </thead>
                                            <tbody>
                                                <tr style="height: 50px">
                                                    <td colspan="3" style="padding: 5px">

                                                        <span id="pname" runat="server"></span>
                                                        <br />
                                                        <asp:Label ID="lblchno" runat="server" Text=""></asp:Label>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblfob" runat="server" Text="C&F"></asp:Label>
                                                    </td>
                                                    <td style="text-align: Right; padding-right: 10px">
                                                        <asp:Label ID="lblcarprice" runat="server" Text="0"></asp:Label>
                                                    </td>
                                                </tr>
                                                <tr id="FRRD" runat="server" style="display: none">
                                                    <td colspan="3" style="padding: 5px">Freight</td>
                                                    <td></td>
                                                    <td style="text-align: Right; padding-right: 10px">
                                                        <asp:Label ID="lblfreight" runat="server" Text="0"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr id="Tr1" runat="server" style="height: 30px">
                                                    <td colspan="3" style="padding: 5px">Other Charges</td>
                                                    <td></td>
                                                    <td style="text-align: Right; padding-right: 10px">
                                                        <asp:Label ID="lblOtherCharges" runat="server" Text="0"></asp:Label>
                                                    </td>
                                                </tr>

                                                <tr style="background-color: #EBEBEB; height: 30px">
                                                    <td colspan="3" style="padding: 5px">Thanks for your business</td>
                                                    <td><b>Total</b></td>
                                                    <td style="text-align: Right; padding-right: 10px"><b>
                                                        <asp:Label ID="lbltotalamtbeforetax" runat="server" Text="0"></asp:Label></b></td>
                                                </tr>
                                            </tbody>
                                        </table>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="border-bottom: solid 1px #808080; padding-bottom: 10px; padding-top: 10px">
                                        <p><b>Payment Terms:</b></p>
                                        <p style="padding-left: 80px">
                                            <asp:BulletedList ID="BulletedList1" runat="server" BulletStyle="Disc" Font-Bold="True">
                                            </asp:BulletedList>
                                        </p>

                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="padding-top: 10px">
                                        <p><b>Inclusions</b> </p>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="5"><b>FOB  </b>: <span>Vehicle cost, Auction house fee, Local transportation cost, Japan Port Charges, Radiation charges, SAYYARAH service charges</span></td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="padding-bottom: 10px"><b>C&F  </b>: <span>Vehicle cost, Auction house fee, Local transportation cost, Japan Port Charges, Radiation charges, SAYYARAH service,
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
                                                <td colspan="2"><b>Bank Details</b></td>
                                            </tr>
                                            <tr>
                                                <td>Bank Name</td>
                                                <td>
                                                    <asp:Label ID="lblbankname" runat="server"></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td>Branch Name</td>
                                                <td>
                                                    <asp:Label ID="lblbranch" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Swift Code</td>
                                                <td>
                                                    <asp:Label ID="lblswift" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Account No.</td>
                                                <td>
                                                    <asp:Label ID="lblaccount" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Account Name</td>
                                                <td>
                                                    <asp:Label ID="lblaccountname" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Address</td>
                                                <td>
                                                    <asp:Label ID="lblbaddress" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>

                                    </td>
                                    <td colspan="2" style="text-align: right; padding-right: 20px">
                                        <asp:Image ID="Image2" runat="server" Width="160px" ImageUrl="https://www.bizupon.com/images/signature.png" /></td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="border-top: solid 1px #808080">&nbsp;&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="text-align: right; padding-right: 20px; width: 100%">
                                        <img src="../Contents/admin/images/logo1.png" style="width: 150px; height: 53px" /></td>
                                </tr>
                                <tr>
                                    <td colspan="5" style="width: 100%; line-height: 50px"></td>
                                </tr>

                            </table>
                        </div>
                        <div class="col-md-12 col-sm-12 col-xs-12">

                            <asp:Button ID="Button1" runat="server" Text="Download" CssClass="btn btn-primary" OnClick="Button1_Click" />
                            <asp:HiddenField ID="HEmail" runat="server" />
                            <input type="button" id="btnPrint" value="Print Invoice" class="btn btn-primary" onclick="PrintGridData()" />

                        </div>
                    </div>

                </div>
            </div>









</asp:Content>
