<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="Add-FOB.aspx.cs" Inherits="SayyarahCars.CommonMasters.Add_FOB" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Country Name</label>
                <asp:DropDownList ID="ddlCountryName" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountryName_SelectedIndexChanged1" CssClass="chosen-select form-control" data-live-search="true">
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Region</label>
                <asp:DropDownList ID="ddlRegion" runat="server" CssClass="chosen-select form-control" data-live-search="true">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Port Name</label>
                <asp:DropDownList ID="ddlPortname" runat="server" CssClass="chosen-select form-control" data-live-search="true">
                    <asp:ListItem Value="0">--Select--</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-6 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="fob">FOB Type</label>
                <asp:DropDownList ID="ddlFobtype" runat="server" CssClass="chosen-select form-control" data-live-search="true">
                    <asp:ListItem Value="0">FOB Type</asp:ListItem>
                    <asp:ListItem Value="A">A</asp:ListItem>
                    <asp:ListItem Value="B">B</asp:ListItem>
                    <asp:ListItem Value="C">C</asp:ListItem>
                    <asp:ListItem Value="D">D</asp:ListItem>
                    <asp:ListItem Value="E">E</asp:ListItem>
                    <asp:ListItem Value="F">F</asp:ListItem>
                    <asp:ListItem Value="G">G</asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <div class="col-lg-6 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">Price</label>
                <asp:TextBox ID="txtprice" runat="server" step="any" TextMode="Number" autocomplete="off" class="form-control"></asp:TextBox>

            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label">&nbsp;</label>
                <asp:Button ID="btnSubmit" ValidationGroup="ram" runat="server" OnClientClick="return validateFobType();" Text="Save changes" class="btn btn-primary btn-sm" OnClick="btnSubmit_Click" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        var fobTypeIds = {
            ddlCountryName: '<%=ddlCountryName.ClientID %>',
            ddlCityName: '<%=ddlRegion.ClientID %>',
            ddlPortname: '<%=ddlPortname.ClientID %>',
            ddlFobtype: '<%=ddlFobtype.ClientID %>',
            txtprice: '<%=txtprice.ClientID %>'
        };
    </script>
</asp:Content>
