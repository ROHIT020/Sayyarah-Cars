<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Seller.Master" AutoEventWireup="true" CodeBehind="Add-Products.aspx.cs" Inherits="SayyarahCars.Seller.Add_Products" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        .file-item {
            display: flex;
            align-items: center;
            gap: 1rem;
            width: auto !important;
        }
    </style>
    <link href="../Contents/admin/css/lightbox.min.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card">
                <div class="card-header">
                    <h5>Add Product</h5>
                    <a href="MyProducts.aspx" class="btn btn-secondary"><i class="ti ti-eye"></i>View Products</a>
                </div>
                <div class="card-body">
                    <asp:HiddenField ID="hdnid" runat="server" Value="0" />
                    <cc1:TabContainer ID="TabContainer1" runat="server" ActiveTabIndex="0" CssClass="custom-tab-container" AutoPostBack="true" OnActiveTabChanged="TabContainer1_ActiveTabChanged">
                        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Product Details" ID="TabPanel1">
                            <ContentTemplate>
                                <div class="row">
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="product">Category</label>
                                            <asp:DropDownList ID="ddlcategory" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="errCategory" ClientIDMode="Static" OnSelectedIndexChanged="ddlcategory_SelectedIndexChanged" AutoPostBack="true"></asp:DropDownList>
                                            <div id="errCategory" class="error-message">Please select Category.</div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="product">Product</label>
                                            <asp:DropDownList ID="ddlproduct" runat="server" CssClass="validate chosen-select form-control" data-required="true" data-type="dropdown" data-error-id="errProduct" ClientIDMode="Static" OnSelectedIndexChanged="ddlproduct_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <div id="errProduct" class="error-message">Please select Product.</div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Chassis Number</label>
                                            <asp:TextBox ID="txtChassisNo" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="errChassisNo" placeholder="Enter Chassis No" ClientIDMode="Static"></asp:TextBox>
                                            <p id="errChassisNo" class="error-message">Please enter Chassis Number</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Manufacturing Date</label>
                                            <asp:TextBox ID="txtMDate" runat="server" TextMode="Date" autocomplete="off" CssClass="validate form-control" data-error-id="errMDate" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                            <p id="errMDate" class="error-message">Please enter Manufacturing Date</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-9 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="code">Model/Variant</label>
                                            <asp:DropDownList ID="ddlModel" runat="server" CssClass="validate chosen-select form-control" data-error-id="errModel" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <div id="errModel" class="error-message">Please select Model/Variant.</div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Registration Date</label>
                                            <asp:TextBox ID="txtRDate" runat="server" TextMode="Date" autocomplete="off" CssClass="validate form-control" data-error-id="errRDate" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                            <p id="errRDate" class="error-message">Please enter Registration Date</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Mileage/kilometre</label>
                                            <asp:TextBox ID="txtMileage" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="errMileage" placeholder="Enter Mileage" ClientIDMode="Static"></asp:TextBox>
                                            <p id="errMileage" class="error-message">Please enter Mileage/kilometre</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Color</label>
                                            <asp:DropDownList ID="ddlcolor" runat="server" CssClass="validate chosen-select form-control" data-error-id="errColor" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                                <asp:ListItem Value="0">Select Color</asp:ListItem>
                                                <asp:ListItem Value="BEIGE">BEIGE</asp:ListItem>
                                                <asp:ListItem Value="BLACK">BLACK</asp:ListItem>
                                                <asp:ListItem Value="BLUE">BLUE</asp:ListItem>
                                                <asp:ListItem Value="DARK BLUE">DARK BLUE</asp:ListItem>
                                                <asp:ListItem Value="GOLD">GOLD</asp:ListItem>
                                                <asp:ListItem Value="GRAY">GRAY</asp:ListItem>
                                                <asp:ListItem Value="GREEN">GREEN</asp:ListItem>
                                                <asp:ListItem Value="GUNMETAL">GUNMETAL</asp:ListItem>
                                                <asp:ListItem Value="LIGHT BLUE">LIGHT BLUE</asp:ListItem>
                                                <asp:ListItem Value="ORANGE">ORANGE</asp:ListItem>
                                                <asp:ListItem Value="PEARL">PEARL</asp:ListItem>
                                                <asp:ListItem Value="PINK">PINK</asp:ListItem>
                                                <asp:ListItem Value="PURPLE">PURPLE</asp:ListItem>
                                                <asp:ListItem Value="RED">RED</asp:ListItem>
                                                <asp:ListItem Value="SILVER">SILVER</asp:ListItem>
                                                <asp:ListItem Value="WHITE">WHITE</asp:ListItem>
                                                <asp:ListItem Value="WINE">WINE</asp:ListItem>
                                                <asp:ListItem Value="YELLOW">YELLOW</asp:ListItem>
                                            </asp:DropDownList>
                                            <p id="errColor" class="error-message">Please select Color</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label">Seller Type</label>
                                            <asp:DropDownList ID="ddlSellerType" runat="server" CssClass="validate chosen-select form-control" data-error-id="errSellerType" data-required="true" data-type="dropdown" ClientIDMode="Static" OnSelectedIndexChanged="ddlSellerType_SelectedIndexChanged" AutoPostBack="true">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                                <asp:ListItem Value="1">Individual</asp:ListItem>
                                                <asp:ListItem Value="2">Dealer</asp:ListItem>
                                                <asp:ListItem Value="3">Auction House</asp:ListItem>
                                                <asp:ListItem Value="-1">Other</asp:ListItem>
                                            </asp:DropDownList>
                                            <p id="errSellerType" class="error-message">Please select Seller Type</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" id="lblSeller" runat="server">Seller</label>
                                            <asp:Panel ID="pnlseller" runat="server">
                                                <asp:DropDownList ID="ddlSeller" runat="server" CssClass="validate chosen-select form-control" data-error-id="errSeller" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                                    <asp:ListItem Value="0">Select</asp:ListItem>
                                                </asp:DropDownList>
                                                <p id="errSeller" class="error-message">Please select Seller</p>
                                            </asp:Panel>
                                            <asp:Panel ID="pnlother" runat="server" Visible="false">
                                                <asp:TextBox ID="txtSeller" runat="server" autocomplete="off" CssClass="validate form-control" data-required="true" data-type="text" data-error-id="errOther" placeholder="Enter Seller" ClientIDMode="Static"></asp:TextBox>
                                                <p id="errOther" class="error-message">Please enter Seller</p>
                                            </asp:Panel>
                                        </div>
                                    </div>
                                    
                                    <div class="col-lg-3 col-md-6 col-12" id="divAuctionSource" runat="server" visible="false">
                                        <div class="form-group">
                                            <label class="form-label">Source Of Auction</label>
                                            <asp:DropDownList ID="ddlAuctionSource" runat="server" CssClass="validate chosen-select form-control" data-error-id="errASource" data-required="true" data-type="dropdown" ClientIDMode="Static">
                                                <asp:ListItem Value="0">Select</asp:ListItem>
                                            </asp:DropDownList>
                                            <p id="errASource" class="error-message">Please select Auction Source</p>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12" id="divAuctionDate" runat="server" visible="false">
                                        <div class="form-group">
                                            <label class="form-label">Auction Date</label>
                                            <asp:TextBox ID="txtAuctionDate" runat="server" TextMode="Date" autocomplete="off" CssClass="validate form-control" data-error-id="errADate" data-required="true" data-type="text" ClientIDMode="Static"></asp:TextBox>
                                            <p id="errADate" class="error-message">Please enter Auction Date</p>
                                        </div>
                                    </div>
                                    
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="product">Product Type I</label>
                                            <asp:DropDownList ID="ddlptype1" runat="server" CssClass="chosen-select form-control">
                                                <asp:ListItem Value="N">Normal</asp:ListItem>
                                                <asp:ListItem Value="P">Promotional</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label class="form-label" for="product">Product Type II</label>
                                            <asp:DropDownList ID="ddlptype2" runat="server" CssClass="chosen-select form-control">
                                                <asp:ListItem Value="R">Real</asp:ListItem>
                                                <asp:ListItem Value="D">Duplicate</asp:ListItem>
                                            </asp:DropDownList>
                                        </div>
                                    </div>
                                    <div class="col-lg-12 col-md-12 col-12">
                                        <label class="form-label">&nbsp;</label>
                                        <asp:Button ID="btnsubmit" runat="server" class="btn btn-primary float-end mt-2" Text="Submit" OnClientClick="return ValidateFormData();" OnClick="btnsubmit_Click"></asp:Button>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Upload Images/Photos" ID="TabPanel2">
                            <ContentTemplate>
                                <asp:HiddenField ID="hdnuploaded" runat="server" Value="0" />
                                <div class="upload-block">
                                    <div class="upload-box" id="uploadBox" runat="server" clientidmode="Static">
                                        <div class="upload-content">
                                            <div class="upload-icon">
                                                <svg width="64" height="64" viewBox="0 0 24 24" fill="none">
                                                    <path d="M21 15v4a2 2 0 01-2 2H5a2 2 0 01-2-2v-4M17 8l-5-5-5 5M12 3v12" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                                                </svg>
                                            </div>
                                            <p class="upload-subtitle">Strictly PNG, JPG and JPEG files only.</p>
                                            <button class="upload-button" type="button">Choose File</button>
                                            <asp:FileUpload ID="flpupload" runat="server" Style="display: none" ClientIDMode="Static" onchange="triggerUpload()" />
                                            <asp:Button ID="btnupload" runat="server" Text="Upload" Style="display: none" OnClick="btnupload_Click" />
                                        </div>

                                        <div class="upload-progress" id="uploadProgress">
                                            <div class="progress-circle">
                                                <svg class="progress-ring" width="60" height="60">
                                                    <circle cx="30" cy="30" r="25" stroke="#4a5568" stroke-width="4" fill="none" />
                                                    <circle class="progress-bar" cx="30" cy="30" r="25" stroke="#f093fb" stroke-width="4" fill="none" stroke-dasharray="157" stroke-dashoffset="157" />
                                                </svg>
                                                <span class="progress-text">0%</span>
                                            </div>
                                            <p class="progress-label">Uploading files...</p>
                                        </div>
                                    </div>
                                    <div id="filesPreview" runat="server" clientidmode="Static">
                                        <div class="preview-header">
                                            <h4 class="preview-title">Uploaded Files</h4>
                                            <asp:Button class="add-more-btn" ID="addMoreBtn" runat="server" Text="Add More Files" OnClick="addMoreBtn_Click"></asp:Button>
                                        </div>
                                        <div class="files-list" id="filesList">
                                            <asp:Repeater ID="rptFiles" runat="server" OnItemCommand="rptFiles_ItemCommand">
                                                <ItemTemplate>
                                                    <div class="file-item">
                                                        <a href='<%#Eval("sID") %>' data-lightbox="car-gallery" runat="server" id="alight">
                                                            <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("sID") %>' CssClass="file-preview" />
                                                        </a>
                                                        <div class="file-status">
                                                            <div class="status-icon status-success">✓</div>
                                                        </div>
                                                        <div class="file-actions">
                                                            <asp:LinkButton ID="btndelete" runat="server" class="file-action delete" CommandName="Delete" CommandArgument='<%# Eval("sID") %>'>
                                                            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                                                <path d="M3 6h18M19 6v14a2 2 0 01-2 2H7a2 2 0 01-2-2V6M8 6V4a2 2 0 012-2h4a2 2 0 012 2v2" />
                                                            </svg>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                    <div class="upload-complete" id="uploadComplete" style="display: none;">
                                        <div class="complete-header">
                                            <div class="success-icon">✓</div>
                                            <h3 class="complete-title">Upload Successful!</h3>
                                            <p class="complete-subtitle">
                                                <asp:Label ID="lblnooffilesuploaded" runat="server"></asp:Label>
                                                file(s) uploaded successfully
                                            </p>
                                        </div>
                                    </div>
                                    <asp:Panel ID="pnlerror" runat="server" Visible="false">
                                        <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                            <strong>Error:</strong>
                                            <asp:Label ID="lblmsg" runat="server"></asp:Label>
                                            <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                        </div>
                                    </asp:Panel>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Features" ID="TabPanel3">
                            <ContentTemplate>
                                <asp:Repeater ID="rptCategories" runat="server" OnItemDataBound="rptCategories_ItemDataBound">
                                    <ItemTemplate>
                                        <div class="features-block mb-4">
                                            <h4><%# Eval("FeatureName") %></h4>
                                            <ul class="features-list">
                                                <asp:Repeater ID="rptFeatures" runat="server">
                                                    <ItemTemplate>
                                                        <%# (Container.ItemIndex % 4 == 0) ? "<li>" : "" %>
                                                        <asp:CheckBox ID="chkFeature" class="check" runat="server" Text='<%# Eval("FeatureName") %>' data-id='<%# Eval("id") %>' />
                                                        <%# ((Container.ItemIndex + 1) % 4 == 0) ? "</li>" : "" %>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </ul>
                                        </div>
                                    </ItemTemplate>
                                </asp:Repeater>
                                <div class="col-lg-12 col-md-12 col-12">
                                    <label class="form-label">&nbsp;</label>
                                    <asp:Button ID="btnsavefeature" runat="server" class="btn btn-primary float-end mt-2" Text="Submit" OnClick="btnsavefeature_Click"></asp:Button>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Scratches and Defects" ID="TabPanel4">
                            <ContentTemplate>
                                <asp:Panel ID="pnlErrorDefects" runat="server" Visible="false">
                                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                        <strong>Error:</strong>
                                        <asp:Label ID="lblerrorDefects" runat="server"></asp:Label>
                                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                    </div>
                                </asp:Panel>
                                <cc1:TabContainer ID="TabContainer2" runat="server" ActiveTabIndex="0" CssClass="custom-tab-container2" AutoPostBack="true" OnActiveTabChanged="TabContainer2_ActiveTabChanged">
                                    <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Left Side" ID="TabLeft">
                                        <ContentTemplate>
                                            <div class="upload-block">
                                                <div class="upload-box" id="uploadBox_Left" runat="server" clientidmode="Static">
                                                    <div class="upload-content">
                                                        <div class="upload-icon">
                                                            <svg width="64" height="64" viewBox="0 0 24 24" fill="none">
                                                                <path d="M21 15v4a2 2 0 01-2 2H5a2 2 0 01-2-2v-4M17 8l-5-5-5 5M12 3v12" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                                                            </svg>
                                                        </div>
                                                        <p class="upload-subtitle">Strictly PNG, JPG and JPEG files only.</p>
                                                        <button class="upload-button" type="button">Choose File</button>
                                                        <asp:FileUpload ID="flpupload_Left" runat="server" Style="display: none" onchange="triggerUpload_Left()" />
                                                        <asp:Button ID="btnupload_Left" runat="server" Text="Upload" Style="display: none" OnClick="btnupload_Left_Click" />
                                                    </div>
                                                </div>
                                                <div id="filesPreview_Left" runat="server" clientidmode="Static">
                                                    <div class="preview-header">
                                                        <h4 class="preview-title">Left Side Scratches and Defects</h4>
                                                        <asp:Button class="add-more-btn" ID="btnadd_Left" runat="server" Text="Add More Files" OnClick="btnadd_Left_Click"></asp:Button>
                                                    </div>
                                                    <div class="files-list" id="Left-filesList">
                                                        <asp:Repeater ID="rptLeft" runat="server" OnItemCommand="rptLeft_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="file-item">
                                                                    <a href='<%#Eval("sID") %>' data-lightbox="car-gallery-Left" runat="server" id="alight">
                                                                        <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("sID") %>' CssClass="file-preview" />
                                                                    </a>
                                                                    <div class="file-status">
                                                                        <div class="status-icon status-success">✓</div>
                                                                    </div>
                                                                    <div class="file-actions">
                                                                        <asp:LinkButton ID="btndelete" runat="server" class="file-action delete" CommandName="Delete" CommandArgument='<%# Eval("sID") %>'>
                                                            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                                                <path d="M3 6h18M19 6v14a2 2 0 01-2 2H7a2 2 0 01-2-2V6M8 6V4a2 2 0 012-2h4a2 2 0 012 2v2" />
                                                            </svg>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </div>
                                            <script>
                                                this.uploadBox_Left.addEventListener('click', () => {
                                                    document.getElementById("<%=flpupload_Left.ClientID%>").click();
                                                });
                                                function triggerUpload_Left() {
                                                    document.getElementById("<%=btnupload_Left.ClientID%>").click();
                                                }
                                            </script>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Right Side" ID="TabPanel7">
                                        <ContentTemplate>
                                            <div class="upload-block">
                                                <div class="upload-box" id="uploadBox_Right" runat="server" clientidmode="Static">
                                                    <div class="upload-content">
                                                        <div class="upload-icon">
                                                            <svg width="64" height="64" viewBox="0 0 24 24" fill="none">
                                                                <path d="M21 15v4a2 2 0 01-2 2H5a2 2 0 01-2-2v-4M17 8l-5-5-5 5M12 3v12" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                                                            </svg>
                                                        </div>
                                                        <p class="upload-subtitle">Strictly PNG, JPG and JPEG files only.</p>
                                                        <button class="upload-button" type="button">Choose File</button>
                                                        <asp:FileUpload ID="flpupload_Right" runat="server" Style="display: none" onchange="triggerUpload_Right()" />
                                                        <asp:Button ID="btnupload_Right" runat="server" Text="Upload" Style="display: none" OnClick="btnupload_Right_Click" />
                                                    </div>
                                                </div>
                                                <div id="filesPreview_Right" runat="server" clientidmode="Static">
                                                    <div class="preview-header">
                                                        <h4 class="preview-title">Right Side Scratches and Defects</h4>
                                                        <asp:Button class="add-more-btn" ID="btnadd_Right" runat="server" Text="Add More Files" OnClick="btnadd_Right_Click"></asp:Button>
                                                    </div>
                                                    <div class="files-list" id="Right-filesList">
                                                        <asp:Repeater ID="rptRight" runat="server" OnItemCommand="rptRight_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="file-item">
                                                                    <a href='<%#Eval("sID") %>' data-lightbox="car-gallery-Right" runat="server" id="alight">
                                                                        <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("sID") %>' CssClass="file-preview" />
                                                                    </a>
                                                                    <div class="file-status">
                                                                        <div class="status-icon status-success">✓</div>
                                                                    </div>
                                                                    <div class="file-actions">
                                                                        <asp:LinkButton ID="btndelete" runat="server" class="file-action delete" CommandName="Delete" CommandArgument='<%# Eval("sID") %>'>
                                                            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                                                <path d="M3 6h18M19 6v14a2 2 0 01-2 2H7a2 2 0 01-2-2V6M8 6V4a2 2 0 012-2h4a2 2 0 012 2v2" />
                                                            </svg>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </div>
                                            <script>
                                                this.uploadBox_Right.addEventListener('click', () => {
                                                    document.getElementById("<%=flpupload_Right.ClientID%>").click();
                                                });
                                                function triggerUpload_Right() {
                                                    document.getElementById("<%=btnupload_Right.ClientID%>").click();
                                                }
                                            </script>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Front Side" ID="TabPanel8">
                                        <ContentTemplate>
                                            <div class="upload-block">
                                                <div class="upload-box" id="uploadBox_Front" runat="server" clientidmode="Static">
                                                    <div class="upload-content">
                                                        <div class="upload-icon">
                                                            <svg width="64" height="64" viewBox="0 0 24 24" fill="none">
                                                                <path d="M21 15v4a2 2 0 01-2 2H5a2 2 0 01-2-2v-4M17 8l-5-5-5 5M12 3v12" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                                                            </svg>
                                                        </div>
                                                        <p class="upload-subtitle">Strictly PNG, JPG and JPEG files only.</p>
                                                        <button class="upload-button" type="button">Choose File</button>
                                                        <asp:FileUpload ID="flpupload_Front" runat="server" Style="display: none" onchange="triggerUpload_Front()" />
                                                        <asp:Button ID="btnupload_Front" runat="server" Text="Upload" Style="display: none" OnClick="btnupload_Front_Click" />
                                                    </div>
                                                </div>
                                                <div id="filesPreview_Front" runat="server" clientidmode="Static">
                                                    <div class="preview-header">
                                                        <h4 class="preview-title">Front Side Scratches and Defects</h4>
                                                        <asp:Button class="add-more-btn" ID="btnadd_Front" runat="server" Text="Add More Files" OnClick="btnadd_Front_Click"></asp:Button>
                                                    </div>
                                                    <div class="files-list" id="Front-filesList">
                                                        <asp:Repeater ID="rptFront" runat="server" OnItemCommand="rptFront_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="file-item">
                                                                    <a href='<%#Eval("sID") %>' data-lightbox="car-gallery-Front" runat="server" id="alight">
                                                                        <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("sID") %>' CssClass="file-preview" />
                                                                    </a>
                                                                    <div class="file-status">
                                                                        <div class="status-icon status-success">✓</div>
                                                                    </div>
                                                                    <div class="file-actions">
                                                                        <asp:LinkButton ID="btndelete" runat="server" class="file-action delete" CommandName="Delete" CommandArgument='<%# Eval("sID") %>'>
                                                            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                                                <path d="M3 6h18M19 6v14a2 2 0 01-2 2H7a2 2 0 01-2-2V6M8 6V4a2 2 0 012-2h4a2 2 0 012 2v2" />
                                                            </svg>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </div>
                                            <script>
                                                this.uploadBox_Front.addEventListener('click', () => {
                                                    document.getElementById("<%=flpupload_Front.ClientID%>").click();
                                                });
                                                function triggerUpload_Front() {
                                                    document.getElementById("<%=btnupload_Front.ClientID%>").click();
                                                }
                                            </script>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                    <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Rear Side" ID="TabPanel9">
                                        <ContentTemplate>
                                            <div class="upload-block">
                                                <div class="upload-box" id="uploadBox_Rear" runat="server" clientidmode="Static">
                                                    <div class="upload-content">
                                                        <div class="upload-icon">
                                                            <svg width="64" height="64" viewBox="0 0 24 24" fill="none">
                                                                <path d="M21 15v4a2 2 0 01-2 2H5a2 2 0 01-2-2v-4M17 8l-5-5-5 5M12 3v12" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                                                            </svg>
                                                        </div>
                                                        <p class="upload-subtitle">Strictly PNG, JPG and JPEG files only.</p>
                                                        <button class="upload-button" type="button">Choose File</button>
                                                        <asp:FileUpload ID="flpupload_Rear" runat="server" Style="display: none" onchange="triggerUpload_Rear()" />
                                                        <asp:Button ID="btnupload_Rear" runat="server" Text="Upload" Style="display: none" OnClick="btnupload_Rear_Click" />
                                                    </div>
                                                </div>
                                                <div id="filesPreview_Rear" runat="server" clientidmode="Static">
                                                    <div class="preview-header">
                                                        <h4 class="preview-title">Rear Side Scratches and Defects</h4>
                                                        <asp:Button class="add-more-btn" ID="btnadd_Rear" runat="server" Text="Add More Files" OnClick="btnadd_Rear_Click"></asp:Button>
                                                    </div>
                                                    <div class="files-list" id="Rear-filesList">
                                                        <asp:Repeater ID="rptRear" runat="server" OnItemCommand="rptRear_ItemCommand">
                                                            <ItemTemplate>
                                                                <div class="file-item">
                                                                    <a href='<%#Eval("sID") %>' data-lightbox="car-gallery-Rear" runat="server" id="alight">
                                                                        <asp:Image ID="img" runat="server" ImageUrl='<%#Eval("sID") %>' CssClass="file-preview" />
                                                                    </a>
                                                                    <div class="file-status">
                                                                        <div class="status-icon status-success">✓</div>
                                                                    </div>
                                                                    <div class="file-actions">
                                                                        <asp:LinkButton ID="btndelete" runat="server" class="file-action delete" CommandName="Delete" CommandArgument='<%# Eval("sID") %>'>
                                                            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                                                <path d="M3 6h18M19 6v14a2 2 0 01-2 2H7a2 2 0 01-2-2V6M8 6V4a2 2 0 012-2h4a2 2 0 012 2v2" />
                                                            </svg>
                                                                        </asp:LinkButton>
                                                                    </div>
                                                                </div>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </div>
                                                </div>
                                            </div>
                                            <script>
                                                this.uploadBox_Rear.addEventListener('click', () => {
                                                    document.getElementById("<%=flpupload_Rear.ClientID%>").click();
                                                });
                                                function triggerUpload_Rear() {
                                                    document.getElementById("<%=btnupload_Rear.ClientID%>").click();
                                                }
                                            </script>
                                        </ContentTemplate>
                                    </cc1:TabPanel>
                                </cc1:TabContainer>
                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Upload Documents" ID="TabPanel5">
                            <ContentTemplate>
                                <asp:Panel ID="pnlErrorDocuments" runat="server" Visible="false">
                                    <div class="alert alert-danger alert-dismissible fade show" role="alert">
                                        <strong>Error:</strong>
                                        <asp:Label ID="lblerrorDocuments" runat="server"></asp:Label>
                                        <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                    </div>
                                </asp:Panel>
                                <div class="upload-block">
                                    <div class="upload-box" id="uploadBox_Documents" runat="server" clientidmode="Static">
                                        <div class="upload-content">
                                            <div class="upload-icon">
                                                <svg width="64" height="64" viewBox="0 0 24 24" fill="none">
                                                    <path d="M21 15v4a2 2 0 01-2 2H5a2 2 0 01-2-2v-4M17 8l-5-5-5 5M12 3v12" stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                                                </svg>
                                            </div>
                                            <p class="upload-subtitle">Strictly PDF, PNG, JPG and JPEG files only.</p>
                                            <button class="upload-button" type="button">Choose File</button>
                                            <asp:FileUpload ID="flpupload_Documents" runat="server" Style="display: none" onchange="triggerUpload_Documents()" />
                                            <asp:Button ID="btnupload_Documents" runat="server" Text="Upload" Style="display: none" OnClick="btnupload_Documents_Click" />
                                        </div>
                                    </div>
                                    <div id="filesPreview_Documents" runat="server" clientidmode="Static">
                                        <div class="preview-header">
                                            <h4 class="preview-title">Documents </h4>
                                            <asp:Button class="add-more-btn" ID="btnadd_Documents" runat="server" Text="Add More Files" OnClick="btnadd_Documents_Click"></asp:Button>
                                            
                                        </div>
                                        <div class="files-list" id="Documents-filesList">
                                            <asp:Repeater ID="rptDocuments" runat="server" OnItemCommand="rptDocuments_ItemCommand">
                                                <ItemTemplate>
                                                    <div class="file-item">
                                                        <asp:PlaceHolder ID="phImage" runat="server" Visible='<%# IsImageFile(Eval("sID")) %>'>
                                                            <a href='<%# Eval("sID") %>' data-lightbox="car-gallery-Rear">
                                                                <asp:Image ID="img" runat="server" ImageUrl='<%# Eval("sID") %>' CssClass="file-preview" />
                                                            </a>
                                                        </asp:PlaceHolder>

                                                        <asp:PlaceHolder ID="phNonImage" runat="server" Visible='<%# !IsImageFile(Eval("sID")) %>'>
                                                            <a href='<%# Eval("sID") %>' target="_blank">
                                                                <div class="download-icon">
                                                                    <svg width="64" height="64" viewBox="0 0 24 24" fill="none">
                                                                        <path d="M21 15v4a2 2 0 0 1-2 2H5a2 2 0 0 1-2-2v-4M7 11l5 5 5-5M12 16V4"
                                                                            stroke="currentColor" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
                                                                    </svg>
                                                                </div>
                                                            </a>
                                                        </asp:PlaceHolder>
                                                        <div class="file-status">
                                                            <div class="status-icon status-success">✓</div>
                                                        </div>
                                                        <div class="file-actions">
                                                            <asp:LinkButton ID="btndelete" runat="server" class="file-action delete" CommandName="Delete" CommandArgument='<%# Eval("sID") %>'>
                                                            <svg width="16" height="16" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="2">
                                                                <path d="M3 6h18M19 6v14a2 2 0 01-2 2H7a2 2 0 01-2-2V6M8 6V4a2 2 0 012-2h4a2 2 0 012 2v2" />
                                                            </svg>
                                                            </asp:LinkButton>
                                                        </div>
                                                    </div>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </div>
                                    </div>
                                </div>
                                <script>
                                    this.uploadBox_Documents.addEventListener('click', () => {
                                        document.getElementById("<%=flpupload_Documents.ClientID%>").click();
                                    });                                    
                                    function triggerUpload_Documents() {
                                        document.getElementById("<%=btnupload_Documents.ClientID%>").click();
                                    }
                                </script>

                            </ContentTemplate>
                        </cc1:TabPanel>
                        <cc1:TabPanel runat="server" CssClass="nav-link" HeaderText="Location" ID="TabPanel6" Visible="false">
                            <ContentTemplate>
                                <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d57734.782646818145!2d55.42751552981862!3d25.25632136731777!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13 1!3m3!1m2!1s0x3e5f43496ad9c645%3A0xbde66e5084295162!2sDubai%20-%20United%20Arab%20Emirates!5e0!3m2!1sen!2sin!4v1751542589839!5m2!1sen!2sin" width="100%" height="450" style="border: 0; border-radius: 12px;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                                <div class="row mt-3">
                                    <div class="col-lg-6 col-md-6 col-12">
                                        <div class="form-group">
                                            <label>Address</label>
                                            <input type="text" class="form-control" id="">
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label>City</label>
                                            <input type="text" class="form-control" id="">
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-12">
                                        <div class="form-group">
                                            <label>Pincode</label>
                                            <input type="text" class="form-control" id="">
                                        </div>
                                    </div>
                                </div>
                            </ContentTemplate>
                        </cc1:TabPanel>
                    </cc1:TabContainer>

                </div>
            </div>
        </div>
    </div>

    <script> 
        this.uploadBox.addEventListener('click', () => {
            document.getElementById("<%=flpupload.ClientID%>").click();
        });
        function triggerUpload() {
            document.getElementById("<%=btnupload.ClientID%>").click();
        }

    </script>
    <script src="../Contents/admin/js/lightbox.min.js"></script>
</asp:Content>
