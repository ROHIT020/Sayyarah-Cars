<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="AddBill.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddBill" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="form-group">
                <label class="form-label" for="shipping">Select Document</label>
                <asp:DropDownList ID="ddlDocument" runat="server" CssClass="chosen-select form-control" ClientIDMode="Static"></asp:DropDownList>
                <span id="errorDoc" style="color: red; display: none;">Please select a document.</span>
            </div>
        </div>
    </div>
    <div class="col-lg-12 col-md-12 col-12">
        <div class="form-group">
            <label class="form-label">Bill Date</label>
            <asp:TextBox ID="txtBillDate" runat="server" CssClass="form-control" ClientIDMode="Static" TextMode="Date" placeholder="Select Bill Date"></asp:TextBox>
            <span id="errorDate" style="color: red; display: none;">Please select a bill date.</span>
        </div>
    </div>
    <div class="col-lg-12 col-md-12 col-12">
        <div class="form-group">
            <label class="form-label">Upload Document</label>
            <div class="browse-file">
                <asp:FileUpload ID="fuImage" runat="server" CssClass="form-control form-control-lg" ClientIDMode="Static" accept="image/*" />
                <span id="errorFile" style="color: red; display: none;">Please upload a document.</span>
                <asp:HiddenField ID="hidden" runat="server" />
                <asp:Image ID="imgDoc" runat="server" CssClass="img" Style="max-height: 200px;" />
            </div>
        </div>
        <div class="card-header justify-content-end">
            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-sm mt-4 align-content-center" Text="Save" OnClick="btnSubmit_Click1" OnClientClick="return validateForm();" />
            <asp:HiddenField ID="hdnId" runat="server" Value="0" />
        </div>
    </div>
    <script type="text/javascript">
        function validateForm() {
            var ddlDocument = document.getElementById("ddlDocument");
            var billDate = document.getElementById("txtBillDate").value.trim();
            var fileUpload = document.getElementById("fuImage").value;

            // Reset error messages
            document.getElementById("errorDoc").style.display = "none";
            document.getElementById("errorDate").style.display = "none";
            document.getElementById("errorFile").style.display = "none";

            ddlDocument.classList.remove("is-invalid");
            document.getElementById("txtBillDate").classList.remove("is-invalid");
            document.getElementById("fuImage").classList.remove("is-invalid");

            let isValid = true;

            // Validate Document dropdown
            if (ddlDocument.selectedIndex === 0 || ddlDocument.value === "") {
                document.getElementById("errorDoc").style.display = "inline";
                ddlDocument.classList.add("is-invalid");
                isValid = false;
            }

            // Validate Bill Date
            if (billDate === "") {
                document.getElementById("errorDate").style.display = "inline";
                document.getElementById("txtBillDate").classList.add("is-invalid");
                isValid = false;
            }

            // Validate FileUpload
            if (fileUpload === "") {
                document.getElementById("errorFile").style.display = "inline";
                document.getElementById("fuImage").classList.add("is-invalid");
                isValid = false;
            }
            return isValid; 
        }
    </script>

</asp:Content>
