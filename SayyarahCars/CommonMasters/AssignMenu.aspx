<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="AssignMenu.aspx.cs" Inherits="SayyarahCars.CommonMasters.AssignMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Assign Menu</h5>
                </div>
                <div class="card-body" id="divuser" runat="server">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12 float-md-start">
                            <div class="form-group mb-0">
                                <label class="form-label">
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="ddluser" InitialValue="0" ErrorMessage="Required??" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationGroup="a" />
                                </label>
                                <asp:DropDownList ID="ddluser" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="changeddl"></asp:DropDownList>

                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="table-responsive">
                        <asp:Panel ID="pnlcustomControl" runat="server">
                        </asp:Panel>
                    </div>
                </div>
                <div class="card-header justify-content-end">
                    <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary mt-4 align-content-center" ValidationGroup="a" Text="Assign Menu" OnClick="btnsubmit_Click" />
                </div>
            </div>
        </div>

    </div>
    <script language="javascript">
        function checkchk(CheckBox, val2) {
            var Inputs = val2.split("|")
            for (var iCount = 0; iCount < Inputs.length; iCount++) {
                var chk = document.getElementById(Inputs[iCount]);

                chk.checked = CheckBox.checked;
            }
        }
    </script>
</asp:Content>
