<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="AddAuctionYard.aspx.cs" Inherits="SayyarahCars.CommonMasters.AddAuctionYard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Add Auction Yard</h5>
                    <a href="AuctionYardMaster.aspx" class="btn btn-secondary"><i class="ti ti-circle-plus-filled"></i>View Auction Yard</a>
                </div>
                <div class="card-body">
                    <div class="row">
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label" for="shipping">Select Auction Name</label>
                                <asp:DropDownList ID="ddlAuction" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="ddlAuctionError" ClientIDMode="Static"></asp:DropDownList>
                                <p id="ddlAuctionError" class="error-message">Please Select Auction Name</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Auction Yard</label>
                                <asp:TextBox ID="txtAuctionYard" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtAuctionYardError" placeholder="Enter Auction Yard" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtAuctionYardError" class="error-message">Please enter Name</p>
                            </div>
                        </div>

                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Lot No From</label>
                                <asp:TextBox ID="txtlotNoFrom" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtlotNoFromError" placeholder="Enter Lot No from" ClientIDMode="Static" TextMode="Number"></asp:TextBox>
                                <p id="txtlotNoFromError" class="error-message">Please enter Lot No From</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Lot No To</label>
                                <asp:TextBox ID="txtlotNoTo" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtlotNoToError" placeholder="Enter Lot No To" ClientIDMode="Static" TextMode="Number"></asp:TextBox>
                                <p id="txtlotNoToError" class="error-message">Please enter Lot No To</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Out Day</label>
                                <asp:TextBox ID="txtoutday" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtoutdayError" placeholder="Enter Out Day" ClientIDMode="Static" TextMode="Number"></asp:TextBox>
                                <p id="txtoutdayError" class="error-message">Please enter Out Day</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Out Time</label>
                                <asp:TextBox ID="txtouttime" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtouttimeError" placeholder="Enter Out Time" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtouttimeError" class="error-message">Please Enter Out Time</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Email ID</label>
                                <asp:TextBox ID="txtemail" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="email" data-error-id="txtemailError" placeholder="Enter Email ID" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtemailError" class="error-message">Please Enter Email ID</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Contact No</label>
                                <asp:TextBox ID="txtcontact" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtcontactError" placeholder="Enter Contact No" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtcontactError" class="error-message">Please Contact Error</p>
                            </div>
                        </div>
                        <div class="col-lg-3 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Fax No</label>
                                <asp:TextBox ID="txtfaxno" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtfaxnoError" placeholder="Enter Fax No" ClientIDMode="Static" TextMode="Number"></asp:TextBox>
                                <p id="txtfaxnoError" class="error-message">Please Fax No</p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-6 col-12">
                            <div class="form-group">
                                <label class="form-label">Address</label>
                                <asp:TextBox ID="txtaddress" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="txtaddressError" placeholder="Enter Address" ClientIDMode="Static"></asp:TextBox>
                                <p id="txtaddressError" class="error-message">Please Enter Address </p>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-12 col-12">
                            <div class="form-group">
                                <label class="form-label">Status</label>
                                <div class="custom-radiobox">
                                    <label class="radio-block">
                                        <asp:RadioButton ID="rdoactive" runat="server" GroupName="Status" Text="Active" />
                                    </label>
                                    <label class="radio-block">
                                        <asp:RadioButton ID="rdodeActive" runat="server" GroupName="Status" Text="De-Active" />
                                    </label>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <label class="form-label">&nbsp;</label>
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary float-end mt-2" Text="Submit" OnClientClick="return ValidateFormData();" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
