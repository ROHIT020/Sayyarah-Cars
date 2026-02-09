<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Popup.Master" AutoEventWireup="true" CodeBehind="Blog-Preview.aspx.cs" Inherits="SayyarahCars.Admin.Blog_Preview" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <meta name="description" content="car" />
    <meta name="keywords" content="car" />
    <meta name="author" content="" />
    <title>Sayyarah</title>
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon" />
    <!-- Stylesheets -->
    <link href="../Contents/outer/css/bootstrap.min.css" rel="stylesheet" />
    <link href="../Contents/outer/css/slick-theme.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/outer/css/slick.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/outer/css/animate.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/outer/css/owl.css" rel="stylesheet" type="text/css" />
    <link href="../Contents/outer/css/tabler-icons.min.css" rel="stylesheet" />
    <link href="../Contents/outer/css/nice-select.css" rel="stylesheet" />
    <link href="../Contents/outer/css/style.css" rel="stylesheet" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <section class="new-used-car-filter">
        <div class="container">
            <div class="row">
                <div class="col-lg-8 col-md-7 col-12">
                    <asp:DataList ID="DataList1" runat="server" RepeatDirection="Horizontal" RepeatColumns="1" RepeatLayout="Flow" Width="100%">
                        <ItemTemplate>
                            <div class="gallery-block">
                                <div class="inner-column gallery-slider slick-initialized slick-slider">
                                    <asp:Image ID="Image1" CssClass="primary-img" ImageUrl='<%# Eval("BlogImage") %>' runat="server" />
                                     <span class="fa-pull-left"><%# Eval("AuthorName") %></span><span class="fa-pull-right"><%# Eval("BlogDate") %></span>
                                </div>                               
                            </div>
                            <div class="overview-section">
                                <h4 class="title"><%# Eval("BlogTitle") %></h4>
                                <div class="row">
                                    <div class="content-column col-lg-12 col-md-12 col-sm-12">
                                        <div class="inner-column">
                                            <%# Eval("pagecontent") %>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </ItemTemplate>
                    </asp:DataList>
                </div>
                <div class="col-lg-4 col-md-5 col-12">
                    <div class="overview-section" style="margin-top: 0px;">
                        <h4 class="title">Blog Topics</h4>
                        <div class="row">
                            <div class="content-column col-lg-12 col-md-12 col-sm-12">
                                <div class="inner-column">
                                    <asp:DataList ID="DataList2" runat="server" RepeatLayout="Flow" Width="100%">
                                        <ItemTemplate>
                                            <li><a class="bloglink">
                                                <%# Eval("Topic") %></a>
                                            </li>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="overview-section">
                        <h4 class="title">Popular Tags</h4>
                        <div class="row">
                            <div class="content-column col-lg-12 col-md-12 col-sm-12">
                                <div class="inner-column">
                                    <asp:DataList ID="DataList3" runat="server" RepeatLayout="Flow" Width="100%">
                                        <ItemTemplate>
                                            <li><a class="bloglink">
                                                <%# Eval("Topic") %></a>
                                            </li>
                                        </ItemTemplate>
                                    </asp:DataList>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </section>

    <script src="../Contents/admin/js/jquery.min.js"></script>
    <script src="../Contents/admin/js/bootstrap.min.js"></script>
    <script src="../Contents/admin/js/admin.js"></script>
</asp:Content>
