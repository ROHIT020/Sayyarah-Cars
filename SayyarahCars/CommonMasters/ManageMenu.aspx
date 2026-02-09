<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="ManageMenu.aspx.cs" Inherits="SayyarahCars.CommonMasters.ManageMenu" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .checkbox-group {
            display: flex;
            align-items: center;
            margin-bottom: 15px;
        }

            .checkbox-group input[type="checkbox"] {
                transform: scale(1.2);
                margin-right: 10px;
                cursor: pointer;
            }

        .form-check-input {
            margin-left: 0px !important;
        }

        .checkbox-group label {
            margin-bottom: 0;
            font-weight: 500;
            font-size: 16px;
            margin-left: 25px !important;
        }
    </style>


</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <div class="row">
                        <h5>Manage Menu</h5>
                    </div>
                </div>
                <div class="card-body">
                   
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">User Type</label>
                                <asp:DropDownList ID="ddlusertype" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlusertype_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Administrator</asp:ListItem>
                                    <asp:ListItem Value="2">Client</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">Type</label>
                                <asp:DropDownList ID="ddltype" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddltype_SelectedIndexChanged">
                                    <asp:ListItem Value="1">Menu</asp:ListItem>
                                    <asp:ListItem Value="2">Sub Menu</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12" id="divPid" runat="server" visible="false">
                            <div class="form-group mb-0">
                                <label class="form-label">Menu
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="ddlpid" InitialValue="0" ErrorMessage="Required??" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationGroup="a" />
                                </label>
                                <asp:DropDownList ID="ddlpid" runat="server" CssClass="chosen-select form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlpid_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">
                                    <asp:Label ID="lbltitle" runat="server" Text="Menu Title"></asp:Label>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtmenutitle" ErrorMessage="Required??" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationGroup="a" />
                                </label>
                                <asp:TextBox ID="txtmenutitle" runat="server" AutoCompleteType="None" CssClass="form-control" placeholder="Menu Title"></asp:TextBox>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <label class="form-label">
                                  <asp:Label ID="lblurl" runat="server" Text="Menu URL"></asp:Label>  
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txturl" ErrorMessage="Required??" ForeColor="Red" Display="Dynamic" SetFocusOnError="true" ValidationGroup="a" />
                                </label>
                                <asp:TextBox ID="txturl" runat="server" AutoCompleteType="None" CssClass="form-control" placeholder="Menu URL"></asp:TextBox>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group mb-0">
                                <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                                <asp:Button ID="btnsubmit" runat="server" CssClass="btn btn-primary mt-4" ValidationGroup="a" Text="Submit" OnClick="btnsubmit_Click" />
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
                        <asp:GridView ID="GridView1" runat="server" CssClass="table table-hover table-striped align-middle"
                            AutoGenerateColumns="False" EmptyDataText="No Record Added." OnRowCommand="GridView1_RowCommand"
                            AllowCustomPaging="true" AllowPaging="True" PageSize="100" OnPageIndexChanging="GridView1_PageIndexChanging"
                            Width="100%" GridLines="Vertical">
                            <PagerStyle HorizontalAlign="Center" CssClass="GridPager" />
                            <Columns>
                                <asp:TemplateField HeaderText="S.No.">
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemTemplate>
                                         <%# (GridView1.PageIndex * GridView1.PageSize) + Container.DataItemIndex + 1 %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Menu">
                                    <ItemTemplate>
                                        <%# Eval("MenuTitle") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="URL">
                                    <ItemTemplate>
                                        <%# Eval("MenuURL") %>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField HeaderText="Action">
                                    <ItemTemplate>
                                        <div class="text-end">
                                            <asp:LinkButton ID="lnkEdit" runat="server" CommandName="EditRow" CausesValidation="false"
                                                CommandArgument='<%# Eval("ID") %>' CssClass="avtar edit" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Edit"><i class="ti ti-pencil"></i></asp:LinkButton>
                                            <asp:LinkButton ID="lnkDelete" runat="server" CommandName="DeleteRow" CausesValidation="false" OnClientClick="return confirmDelete(this);"
                                                CommandArgument='<%# Eval("ID") %>' CssClass="avtar delete" data-bs-toggle="tooltip" data-bs-placement="top" data-bs-original-title="Delete"><i class="ti ti-trash"></i></asp:LinkButton>
                                        </div>
                                    </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                            <FooterStyle BackColor="#CCCCCC" />
                            <PagerStyle BackColor="#999999" ForeColor="Black" HorizontalAlign="Center" />
                            <SelectedRowStyle BackColor="#000099" Font-Bold="True" ForeColor="White" />
                            <SortedAscendingCellStyle BackColor="#F1F1F1" />
                            <SortedAscendingHeaderStyle BackColor="#808080" />
                            <SortedDescendingCellStyle BackColor="#CAC9C9" />
                            <SortedDescendingHeaderStyle BackColor="#383838" />
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>



</asp:Content>
