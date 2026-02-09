<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Update-Push-Price.aspx.cs" Inherits="SayyarahCars.Admin.Update_Push_Price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        function SelectAllCheckboxes(chk, selector) {
            $('#<%=GridView1.ClientID%>').find(selector + " input:checkbox").each(function () {
                $(this).prop("checked", $(chk).prop("checked"));
            });
        }
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Update Push Price</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-md-2">
                            <div class="form-group">
                                <label class="control-label">
                                    <b>Auction Group </b>
                                </label>
                                <asp:DropDownList ID="ddlAuctionGroup" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Auction Group</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">
                                    <b>Source Of Auction </b>
                                </label>
                                <asp:DropDownList ID="ddlAuctionSource" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static">
                                    <asp:ListItem Value="0">Source Of Auction</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label">
                                    <b>Auction House </b>
                                </label>
                                <asp:DropDownList ID="ddlAuctionHouse" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="form-group">
                                <label class="control-label"><b>Auction date</b></label>
                                <asp:TextBox ID="txtAdate" runat="server" autocomplete="off" TextMode="Date" class="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label"><b>Sort By</b></label>
                                <asp:DropDownList ID="ddlPageSize" runat="server" CssClass="chosen-select form-control">
                                    <asp:ListItem Value="1000">1000</asp:ListItem>
                                    <asp:ListItem Value="1500">1500</asp:ListItem>
                                    <asp:ListItem Value="2000">2000</asp:ListItem>
                                    <asp:ListItem Value="5000">5000</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="form-group">
                                <label class="control-label"><b>Chassis No.</b></label>
                                <asp:TextBox ID="txtChassisNo" runat="server" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="form-group">
                                <label class="control-label"><b>All Chassis No </b></label>
                                <asp:TextBox ID="txtAllChassisNo" runat="server" TextMode="MultiLine" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click" />
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <asp:Button ID="btnExport" runat="server" Text="Download Excel" CssClass="btn btn-primary fa-pull-right" OnClick="btnExport_Click" />
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="clearfix"></div>
                    </div>
                    <div id="Divserver" runat="server">
                        <div class="row">
                            <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                                <asp:GridView ID="GridView1" runat="server" CellPadding="3" CssClass="table table-striped align-middle"
                                    ForeColor="Black" AutoGenerateColumns="False" Width="100%" BackColor="White" BorderColor="#999999" BorderStyle="Solid" BorderWidth="1px"
                                    GridLines="Vertical" AllowCustomPaging="true" AllowPaging="True"
                                    OnPageIndexChanging="GridView1_PageIndexChanging" ShowFooter="True" OnRowDataBound="GridView1_RowDataBound" PageSize="1000">
                                    <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                                    <AlternatingRowStyle BackColor="WhiteSmoke" />
                                    <Columns>
                                        <asp:TemplateField Visible="false">
                                            <ItemTemplate>
                                                <asp:Label ID="lblpid" runat="server" Text='<%# Eval("ID") %>'></asp:Label>
                                                <asp:Label ID="lblaid" runat="server" Text='<%# Eval("AID") %>'></asp:Label>
                                                <asp:Label ID="PPType" runat="server" Text='<%# Eval("PPType") %>'></asp:Label>
                                                <asp:Label ID="ABFType" runat="server" Text='<%# Eval("ABFType") %>'></asp:Label>
                                                <asp:Label ID="OtherType" runat="server" Text='<%# Eval("OtherType") %>'></asp:Label>
                                                <asp:Label ID="OtherNType" runat="server" Text='<%# Eval("OtherNType") %>'></asp:Label>

                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" Select">
                                            <HeaderStyle Width="50px" />
                                            <HeaderTemplate>
                                                <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText=" S.No.">
                                            <HeaderStyle Width="50px" />
                                            <ItemTemplate>
                                                 <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                        <asp:TemplateField HeaderText="">
                                            <ItemTemplate>
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
                                                            <label class="control-label"><b>Chassis No.</b></label><br />
                                                            <%# Eval("ChassisNo") %><br />
                                                            <asp:DropDownList ID="ddlPPType" runat="server" CssClass="chosen-select form-control ddlPPType">
                                                                <asp:ListItem Value="10">Push P Taxable </asp:ListItem>
                                                                <asp:ListItem Value="0">Handicap/Tax Free Zone</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Push Price</b></label>
                                                            <asp:TextBox ID="txtPushPrice" runat="server" CssClass="form-control txtPushPrice" placeholder="Amount" Text='<%# Eval("PushPrice") %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtPushPriceTax" runat="server" CssClass="form-control txtPushPriceTax" placeholder="Tax" Text='<%# Eval("PushPriceTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>ABF Type</b></label><br />
                                                            <asp:DropDownList ID="ddlABFType" runat="server" CssClass="chosen-select form-control ddlABFType">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Auction BF </b></label>
                                                            <asp:TextBox ID="txtAuctionFeed" runat="server" CssClass="form-control txtAuctionFeed" placeholder="Amount" Text='<%# Eval("AuctionFeed") %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtAuctionFeedTax" runat="server" CssClass="form-control txtAuctionFeedTax" placeholder="Tax" Text='<%# Eval("AuctionFeedTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>No. plate </b></label>
                                                            <asp:TextBox ID="txtNoPlate" runat="server" CssClass="form-control txtNoPlate" placeholder="Amount" Text='<%# Eval("NoPlate") %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtNoPlateTax" runat="server" CssClass="form-control txtNoPlateTax" placeholder="Tax" Text='<%# Eval("NoPlateTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>No. plate </b></label>
                                                            <asp:TextBox ID="txtNoPlateNTax" runat="server" CssClass="form-control txtNoPlateNTax" placeholder="Amount" Text='<%# Eval("NoPlateNTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Security Deposit </b></label>
                                                            <asp:TextBox ID="txtSecurity" runat="server" CssClass="form-control txtSecurity" placeholder="Amount" Text='<%# Eval("Security") %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtSecurityTax" runat="server" CssClass="form-control txtSecurityTax" placeholder="Tax" Text='<%# Eval("SecurityTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Security Deposit </b></label>
                                                            <asp:TextBox ID="txtSecurityNTax" runat="server" CssClass="form-control txtSecurityNTax" placeholder="Amount" Text='<%# Eval("SecurityNTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Transport </b></label>
                                                            <asp:TextBox ID="txtTransport" runat="server" CssClass="form-control txtTransport" placeholder="Amount" Text='<%# Eval("Transport") %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtTransportTax" runat="server" CssClass="form-control txtTransportTax" placeholder="Tax" Text='<%# Eval("TransportTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Cancellation</b></label>
                                                            <asp:TextBox ID="txtCancellation" runat="server" CssClass="form-control txtCancellation" placeholder="Amount" Text='<%# Eval("Cancellation") %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtCancellationTax" runat="server" CssClass="form-control txtCancellationTax" placeholder="Tax" Text='<%# Eval("CancellationTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Can Penalty </b></label>
                                                            <asp:TextBox ID="txtCarPanalty" runat="server" CssClass="form-control txtCarPanalty" placeholder="Amount" Text='<%# Eval("CarPanalty") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Recycle Fee(Tax)</b></label>
                                                            <asp:TextBox ID="txtRecycleFee" runat="server" CssClass="form-control txtRecycleFee" placeholder="Amount" Text='<%# Eval("RecycleFee") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Other Type</b></label><br />
                                                            <asp:DropDownList ID="ddlOtherType" runat="server" CssClass="chosen-select form-control ddlOtherType">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Other Debit </b></label>
                                                            <asp:TextBox ID="txtOtherTypeAmt" runat="server" CssClass="form-control txtOtherTypeAmt" placeholder="Amount" Text='<%# Eval("OtherTypeAmt") %>'></asp:TextBox>
                                                            <asp:TextBox ID="txtOtherTypeTax" runat="server" CssClass="form-control txtOtherTypeTax" placeholder="Tax" Text='<%# Eval("OtherTypeTax") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Other Type NT</b></label><br />
                                                            <asp:DropDownList ID="ddlOtherNType" runat="server" CssClass="chosen-select form-control ddlOtherNType">
                                                            </asp:DropDownList>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-2">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Other Debit(N Tax)</b></label>
                                                            <asp:TextBox ID="txtOtherNTypeAmt" runat="server" CssClass="form-control txtOtherNTypeAmt" placeholder="Amount" Text='<%# Eval("OtherNTypeAmt") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-4">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Total</b></label>
                                                            <asp:TextBox ID="txtTotalAmount" runat="server" CssClass="form-control txtTotalAmount" placeholder="Total Amount" Text='<%# Eval("TotalAmount") %>'></asp:TextBox>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-12">
                                                        <div class="form-group">
                                                            <label class="control-label"><b>Remark</b></label>
                                                            <asp:TextBox ID="txtRemarks" runat="server" CssClass="form-control txtRemarks" Text='<%# Eval("Remarks") %>'></asp:TextBox>
                                                            <br />
                                                            <b>Auction Date: </b><%# Eval("DOE","{0:dd/MM/yyyy}") %>,<b> Auction : </b><%# Eval("AName") %>, <b>Lot No. : </b><%# Eval("LotNo") %>
                                                        </div>
                                                    </div>
                                                </div>
                                            </ItemTemplate>
                                            <FooterTemplate>
                                                <b>Grand Total </b>
                                                <asp:TextBox ID="txtgrandtotal" runat="server" CssClass="form-control"></asp:TextBox>
                                            </FooterTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                    <FooterStyle CssClass="grid-footer" />
                                    <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                                    <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                    <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                    <SortedAscendingHeaderStyle BackColor="#808080" />
                                    <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                    <SortedDescendingHeaderStyle BackColor="#383838" />
                                </asp:GridView>
                            </div>
                            <div class="clearfix"></div>
                        </div>
                        <div class="col-md-12">
                            <div class="row">
                                <div class="col-md-1">&nbsp;</div>
                                <div class="col-md-5">
                                    <asp:Button ID="btnUpdatePrice" runat="server" Text="Update Price" CssClass="btn btn-primary" OnClick="btnUpdatePrice_Click" />
                                </div>
                                <div class="col-md-3">
                                    <asp:TextBox ID="txtPushDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-3">
                                    <asp:Button ID="btnUpdateAdate" runat="server" Text="Update Push Date" CssClass="btn btn-primary" OnClick="btnUpdateAdate_Click" />
                                </div>
                            </div>
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
         
            function calculateRowTotal($row) {
                let total = 0;
                const selectors = [
                    '.txtPushPrice', '.txtPushPriceTax',
                    '.txtAuctionFeed', '.txtAuctionFeedTax',
                    '.txtNoPlate', '.txtNoPlateTax', '.txtNoPlateNTax',
                    '.txtSecurity', '.txtSecurityTax', '.txtSecurityNTax',
                    '.txtTransport', '.txtTransportTax',
                    '.txtCancellation', '.txtCancellationTax',
                    '.txtCarPanalty', '.txtRecycleFee',
                    '.txtOtherTypeAmt', '.txtOtherTypeTax',
                    '.txtOtherNTypeAmt'
                ];

                selectors.forEach(selector => {
                    total += parseFloatSafe($row.find(selector).val());
                });

                $row.find('.txtTotalAmount').val(total.toFixed(2));
            }
         
            function setupTaxHandler($row, amountCls, taxCls) {
                $row.find(amountCls).on('input', function () {
                    const amount = parseFloatSafe($(this).val());
                    const tax = Math.round(amount / 10);
                    $row.find(taxCls).val(tax);
                    calculateRowTotal($row);
                });
            }
         
            function setupToggleFields($row, mainCls, toggleClses) {
                $row.find(mainCls).on('input', function () {
                    const hasValue = $(this).val().trim() !== "";

                    toggleClses.forEach(cls => {
                        const $field = $row.find(cls);
                        if (hasValue) {
                            $field.prop('disabled', true).val(0);
                        } else {
                            $field.prop('disabled', false);
                        }
                    });

                    calculateRowTotal($row);
                });
            }

          
            $('#<%= GridView1.ClientID %> tr').each(function () {
               const $row = $(this);

              
               setupTaxHandler($row, '.txtAuctionFeed', '.txtAuctionFeedTax');
               setupTaxHandler($row, '.txtNoPlate', '.txtNoPlateTax');
               setupTaxHandler($row, '.txtSecurity', '.txtSecurityTax');
               setupTaxHandler($row, '.txtTransport', '.txtTransportTax');
               setupTaxHandler($row, '.txtCancellation', '.txtCancellationTax');
               setupTaxHandler($row, '.txtOtherTypeAmt', '.txtOtherTypeTax');

               setupToggleFields($row, '.txtNoPlate', ['.txtNoPlateNTax']);
               setupToggleFields($row, '.txtNoPlateNTax', ['.txtNoPlate', '.txtNoPlateTax']);
               setupToggleFields($row, '.txtSecurity', ['.txtSecurityNTax']);
               setupToggleFields($row, '.txtSecurityNTax', ['.txtSecurity', '.txtSecurityTax']);

             
               const simpleFields = [
                   '.txtCarPanalty', '.txtRecycleFee', '.txtOtherNTypeAmt',
                   '.txtNoPlateNTax', '.txtSecurityNTax'
               ];
               simpleFields.forEach(cls => {
                   $row.find(cls).on('input', function () {
                       calculateRowTotal($row);
                   });
               });

          
               $row.find('.ddlPPType, .txtPushPrice').on('change input', function () {
                   const amount = parseFloatSafe($row.find('.txtPushPrice').val());
                   const type = parseInt($row.find('.ddlPPType').val());

                   const tax = (type === 10) ? Math.round(amount / 10) : 0;
                   $row.find('.txtPushPriceTax').val(tax);

                   calculateRowTotal($row);
               });
           });
       });
    </script>
    <script type="text/javascript">
        $("#<%= GridView1.ClientID %> input[id*='Chkbox']").change(function () {
            var Dtotal = 0;
            var checkBox = null;
            $('#<%= GridView1.ClientID %> tr').each(function () {
                checkBox = $(this).find("input[id*='Chkbox']");
                if (checkBox.is(':checked')) {
                    var TID = ($("[id*=txtTotalAmount]", $(this).closest("tr")).val());                   
                    Dtotal += parseFloat(TID);
                }
            });
            $('[id*="txtgrandtotal"]').val(Dtotal);
        });
    </script>
    <script type="text/javascript">
        $("#<%= GridView1.ClientID %> input[id*='checkAll']").change(function () {
            var Dtotal = 0;
            var checkBox = null;
            $('#<%= GridView1.ClientID %> tr').each(function () {
                checkBox = $(this).find("input[id*='Chkbox']");
                if (checkBox.is(':checked')) {
                    var TID = ($("[id*=txtTotalAmount]", $(this).closest("tr")).val());
                    Dtotal += parseFloat(TID);
                }
            });
            $('[id*="txtgrandtotal"]').val(Dtotal);

        });
    </script>
    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtChassisNo.ClientID %>',
            AllChassisNo: '<%= txtAllChassisNo.ClientID %>'
        };
    </script>
    <script src="../Contents/admin/js/fetchChassisNo.js" type="text/javascript"></script>
</asp:Content>
