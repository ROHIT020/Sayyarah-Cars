<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Add-Shipping-Price.aspx.cs" Inherits="SayyarahCars.Admin.Add_Shipping_Price" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Add Shipping Price</h5>
                    <a href="ManageShippingPrice.aspx" type="submit" class="btn btn-secondary">View Shipping Price</a>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="terminal">Shipping Company Name</label>
                                <asp:DropDownList ID="ddlShipingCompany" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="ProductType">Product Type</label>
                                <asp:DropDownList ID="ddlProductType" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Select Country Name</label>
                                <asp:DropDownList ID="ddlCountryName" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Select Port Name</label>
                                <asp:DropDownList ID="ddlPortName" runat="server" CssClass="chosen-select form-control" data-live-search="true" AppendDataBoundItems="True">
                                </asp:DropDownList>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Freight Price</label>
                                <asp:TextBox ID="txtFreightPrice" runat="server" TextMode="Number" step="any" autocomplete="off" class="form-control" placeholder="Enter Ship Freight"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-xl-1 col-lg-12 col-md-12 col-12">
                            <asp:Button ID="btnSubmit" runat="server" OnClientClick="return validationShipingPricing();" Text="Submit" class="btn btn-primary float-end mt-4" OnClick="btnSubmit_Click" />
                            <asp:Button ID="btnUpdate" runat="server" Text="Update" Visible="false" CssClass="btn btn-primary float-end mt-4" OnClick="btnUpdate_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <asp:HiddenField ID="hdnShipinpriceId" runat="server" />

    <script type="text/javascript">
        var shiPriceIds = {
            
            ddlShipingCompany: '<%=ddlShipingCompany.ClientID%>',
            ddlProductType: '<%=ddlProductType.ClientID%>',
            ddlCountryName: '<%=ddlCountryName.ClientID%>',
            ddlPortName: '<%=ddlPortName.ClientID %>',
            txtFreightPrice: '<%=txtFreightPrice.ClientID%>'
        };
    </script>
    

</asp:Content>
