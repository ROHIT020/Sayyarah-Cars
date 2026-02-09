<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Inspection-Update.aspx.cs" Inherits="SayyarahCars.Admin.Inspection_Update" %>

<%@ Register Src="~/Contents/DateSelector/DateSelector.ascx" TagPrefix="uc" TagName="DateSelector" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="../Contents/admin/css/Pagging.css" rel="stylesheet" />
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
                    <h5>Update Inspection</h5>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Chassis No.</label>
                                <asp:TextBox ID="txtChassisNo" runat="server" CssClass="form-control"></asp:TextBox>
                                <ul id="suggest" class="list-group mt-1 shadow-sm" style="display: none;"></ul>
                            </div>
                        </div>
                        <div class="col-md-4 mt-4">
                            <div class="form-group">
                                <asp:Button ID="btnsearch" runat="server" Text="Search" CssClass="btn btn-primary" OnClick="btnsearch_Click" />
                            </div>
                        </div>
                    </div>
                </div>


                <div id="Divserver" runat="server">
                    <div class="row">
                        <div class="col-md-12" style="overflow-x: auto; white-space: nowrap;">
                            <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                                AutoGenerateColumns="False" EmptyDataText="No Record Added."
                                AllowCustomPaging="true" AllowPaging="true" PageSize="10"
                                Width="100%" GridLines="Vertical">
                                <Columns>
                                    <asp:TemplateField Visible="false">
                                        <ItemTemplate>
                                            <asp:Label ID="lblpid" runat="server" Text='<%# Eval("Id") %>'></asp:Label>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" Select">

                                        <HeaderTemplate>
                                            <asp:CheckBox ID="checkAll" runat="server" onclick="SelectAllCheckboxes(this, '.employee')" />
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chkbox" runat="server" CssClass="employee" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText=" S.No.">
                                        <ItemTemplate>
                                            <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <table style="width: 100%">
                                                <tr>
                                                    <td><b>Product Name</b></td>
                                                    <td><%# Eval("ProductName") %></td>
                                                    <td><b>Chassis No.</b></td>
                                                    <td><%# Eval("ChassisNo") %></td>
                                                    <td><b>Country </b></td>
                                                    <td><%# Eval("CountryName") %></td>
                                                </tr>
                                                <tr>
                                                    <td><b>I R R Date</b></td>
                                                    <td><%# Eval("InsRRDate") %></td>
                                                    <td><b>Date of P </b></td>
                                                    <td><%# Eval("PayFInsDate") %></td>
                                                    <td><b>Date of I</b></td>
                                                    <td><%# Eval("InsDate") %></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"><%# Eval("InsRRRemark") %></td>
                                                    <td colspan="2"><%# Eval("PayFInsRemark") %></td>
                                                    <td colspan="2"><%# Eval("InsDRemark") %></td>
                                                </tr>
                                                <tr>
                                                    <td><b>I Status</b></td>
                                                    <td><%# Eval("InsStatus") %></td>
                                                    <td><b>I D Sent</b></td>
                                                    <td><%# Eval("InsDocSend") %></td>
                                                    <td><b>I D Back </b></td>
                                                    <td><%# Eval("InsDocBack") %></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2"><%# Eval("InsSRemark") %> </td>
                                                    <td colspan="2"><%# Eval("InsDocSRemark") %> </td>
                                                    <td colspan="2"><%# Eval("InsDocBRemark") %> </td>
                                                </tr>
                                            </table>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle CssClass="grid-footer" />
                                <HeaderStyle BackColor="#333333" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" CssClass="custom-pager" />
                                <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                                <SortedAscendingCellStyle BackColor="#F1F1F1" />
                                <SortedAscendingHeaderStyle BackColor="#808080" />
                                <SortedDescendingCellStyle BackColor="#CAC9C9" />
                                <SortedDescendingHeaderStyle BackColor="#383838" />
                            </asp:GridView>
                        </div>
                        <div class="col-md-4 ">
                            <div class="form-group">
                                <asp:Button ID="btnDelete" runat="server" Text="Delete" CssClass="btn btn-primary" OnClick="btnDelete_Click" />
                            </div>
                        </div>
                    </div>

                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection R R Date</label>
                                <uc:DateSelector ID="txtIRRDate" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection R R Remark</label>
                                <asp:TextBox ID="txtIRRRemark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Date of Payment For I</label>
                                <uc:DateSelector ID="txtDofPForI" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Date of P For Remark</label>
                                <asp:TextBox ID="txtDPFReamark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Date of Inspection</label>
                                <uc:DateSelector ID="txtdateofInspection" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Date of Inspection Remark</label>
                                <asp:TextBox ID="txtDofInsRemark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection Status</label>
                                <asp:TextBox ID="txtInsStatus" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection Status Remark</label>
                                <asp:TextBox ID="txtInsStatusRemark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection Document Sent</label>
                                <uc:DateSelector ID="txtInsDocSent" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection Doc Sent Remark</label>
                                <asp:TextBox ID="txtInsDocSRemark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection Document Back</label>
                                <uc:DateSelector ID="txtInsDocBack" runat="server" CssClass="validate form-control" DataErrorId="errRDate" DataType="calendar" />
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="control-label">Inspection Doc Back Remark</label>
                                <asp:TextBox ID="txtInsDocBRemark" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Certificate</label>
                                <div class="browse-file">
                                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="form-control" />
                                    <asp:Image ID="imgPreview" runat="server" Width="90px" Height="60px" Visible="false" />
                                    <asp:HiddenField ID="HiddenFieldOldImage" runat="server" />
                                </div>
                            </div>
                        </div>
                        <div class="col-md-4 mt-4 ">
                            <div class="form-group">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="btn btn-primary" OnClick="btnSubmit_Click" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <script>
        var ChassisClientID = {
            ChassisNo: '<%= txtChassisNo.ClientID %>'
        };
    </script>
</asp:Content>
