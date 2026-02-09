<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="SayyarahCars.Index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
    <meta name="description" content="car" />
    <meta name="keywords" content="car" />
    <meta name="author" content="" />
    <title>Sayyarah</title>
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon" />
    <!-- Stylesheets -->
    <link href="Contents/outer/css/bootstrap.min.css" rel="stylesheet" />
    <link href="Contents/outer/css/slick-theme.css" rel="stylesheet" type="text/css" />
    <link href="Contents/outer/css/slick.css" rel="stylesheet" type="text/css" />
    <link href="Contents/outer/css/menu.css" rel="stylesheet" />
    <link href="Contents/outer/css/animate.css" rel="stylesheet" type="text/css" />
    <link href="Contents/outer/css/owl.css" rel="stylesheet" type="text/css" />
    <link href="Contents/outer/css/tabler-icons.min.css" rel="stylesheet" />
    <link href="Contents/outer/css/nice-select.css" rel="stylesheet" />
    <link href="Contents/outer/css/chosen.min.css" rel="stylesheet" />
    <link href="Contents/outer/css/style.css" rel="stylesheet" />
    <link rel="stylesheet" href="https://cdnjs.cloudflare.com/ajax/libs/font-awesome/6.2.0/css/all.min.css" />
    <!-- Noty CSS -->
    <link rel="stylesheet" href="../Contents/admin/css/noty.min.css" />
    <script src="../Contents/admin/js/noty.min.js"></script>


    <%-- <script language="javascript" type="text/javascript">       
        function DisableControlKey(e) {
            var message = "Copy/ Paste is not allowed";
            if (e.which == 17 || e.button == 2) {
                window.event.returnValue = false;
            }
        }
    </script>

    <script>
        document.addEventListener("contextmenu", (event) => {
            event.preventDefault();
        });
    </script>--%>
</head>
<body>
    <form id="form1" runat="server">

        <div class="wrapper">

            <!-- Main Header start -->
            <header class="header header-style style-1">
                <div class="header-inner">
                    <div class="container">
                        <!-- Main box -->
                        <div class="c-box">
                            <div class="logo-inner">
                                <div class="logo">
                                    <a href="index.html">
                                        <img src="Contents/outer/images/logo1.png" alt="" title=""></a>
                                </div>
                            </div>

                            <!--Nav Box-->
                            <div class="nav-out-bar">
                                <nav class="nav main-menu">
                                    <ul class="navigation" id="navbar">
                                        <li class="current-dropdown current"><a href="">New Cars</a></li>
                                        <li class="current-dropdown"><a href="">Used Cars</a></li>
                                        <li><a href="">Car Value</a></li>
                                        <li><a href="">Car News</a></li>
                                        <li><a href="">Contact Us</a></li>
                                    </ul>
                                </nav>
                                <!-- Main Menu End-->
                            </div>

                            <div class="right-box">
                                <button type="button" class="user-dropdown phone" data-bs-toggle="modal" data-bs-target="#popup_Adminlogin"><i class="ti ti-user"></i>Admin</button>
                                <button type="button" class="user-dropdown phone" data-bs-toggle="modal" data-bs-target="#popup_login"><i class="ti ti-user"></i>Login/Register</button>
                                <div class="btn d-none d-md-block">
                                    <a href="#" class="header-btn-two" data-bs-toggle="modal" data-bs-target="#popup_seller">Sell My Car</a>
                                </div>
                                <div class="mobile-navigation">
                                    <a href="#nav-mobile" title="">
                                        <svg width="22" height="11" viewBox="0 0 22 11" fill="#405ff2" xmlns="http://www.w3.org/2000/svg">
                                            <rect width="22" height="2" fill="#405ff2" />
                                            <rect y="9" width="22" height="2" fill="#405ff2" />
                                        </svg>
                                    </a>
                                </div>
                            </div>
                        </div>
                        <!-- Mobile Menu  -->
                    </div>
                </div>

                <div id="nav-mobile"></div>
            </header>
            <!-- header-section end -->

            <!-- banner-section start -->
            <div class="banner-section">
                <div class="banner-slider">
                    <div class="banner-slide">
                        <img src="Contents/outer/images/banner1.jpg" alt="">
                        <div class="right-box">
                            <div class="container position-relative">
                                <div class="content-area">
                                    <div class="content-box">
                                        <h1 data-animation-in="fadeInUp" data-delay-in="0.2">Volvo XC60 B5</h1>
                                        <span class="sub-title" data-animation-in="fadeInDown">Ultimate BSVI</span>
                                    </div>
                                </div>
                                <div class="list-box" data-animation-in="fadeInUp" data-delay-in="0.3">
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gas-station">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M14 11h1a2 2 0 0 1 2 2v3a1.5 1.5 0 0 0 3 0v-7l-3 -3" />
                                            <path d="M4 20v-14a2 2 0 0 1 2 -2h6a2 2 0 0 1 2 2v14" />
                                            <path d="M3 20l12 0" />
                                            <path d="M18 7v1a1 1 0 0 0 1 1h1" />
                                            <path d="M4 11l10 0" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Fuel Type</span>
                                            <h6 class="title">Petrol</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gauge">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M12 12m-9 0a9 9 0 1 0 18 0a9 9 0 1 0 -18 0" />
                                            <path d="M12 12m-1 0a1 1 0 1 0 2 0a1 1 0 1 0 -2 0" />
                                            <path d="M13.41 10.59l2.59 -2.59" />
                                            <path d="M7 12a5 5 0 0 1 5 -5" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Kilometers</span>
                                            <h6 class="title">20,925 Km</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-manual-gearbox">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M5 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M19 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 8l0 8" />
                                            <path d="M12 8l0 8" />
                                            <path d="M19 8v2a2 2 0 0 1 -2 2h-12" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Transmisson</span>
                                            <h6 class="title">Automatic</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-calendar-week">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M4 7a2 2 0 0 1 2 -2h12a2 2 0 0 1 2 2v12a2 2 0 0 1 -2 2h-12a2 2 0 0 1 -2 -2v-12z" />
                                            <path d="M16 3v4" />
                                            <path d="M8 3v4" />
                                            <path d="M4 11h16" />
                                            <path d="M7 14h.013" />
                                            <path d="M10.01 14h.005" />
                                            <path d="M13.01 14h.005" />
                                            <path d="M16.015 14h.005" />
                                            <path d="M13.015 17h.005" />
                                            <path d="M7.01 17h.005" />
                                            <path d="M10.01 17h.005" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Model Year</span>
                                            <h6 class="title">2024</h6>
                                        </div>
                                    </div>
                                    <div class="btn-box d-block">
                                        <a href="single-page-details.html" class="btn-white">More Info <i class="ti ti-arrow-up-right"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="banner-slide">
                        <img src="Contents/outer/images/banner2.jpg" alt="">
                        <div class="right-box">
                            <div class="container position-relative">
                                <div class="content-area">
                                    <div class="content-box">
                                        <h1 data-animation-in="fadeInUp" data-delay-in="0.2">Audi Q5</h1>
                                        <span class="sub-title" data-animation-in="fadeInDown">2.0 TDI quattro Premium Plus</span>
                                    </div>
                                </div>
                                <div class="list-box" data-animation-in="fadeInUp" data-delay-in="0.3">
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gas-station">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M14 11h1a2 2 0 0 1 2 2v3a1.5 1.5 0 0 0 3 0v-7l-3 -3" />
                                            <path d="M4 20v-14a2 2 0 0 1 2 -2h6a2 2 0 0 1 2 2v14" />
                                            <path d="M3 20l12 0" />
                                            <path d="M18 7v1a1 1 0 0 0 1 1h1" />
                                            <path d="M4 11l10 0" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Fuel Type</span>
                                            <h6 class="title">Petrol</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gauge">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M12 12m-9 0a9 9 0 1 0 18 0a9 9 0 1 0 -18 0" />
                                            <path d="M12 12m-1 0a1 1 0 1 0 2 0a1 1 0 1 0 -2 0" />
                                            <path d="M13.41 10.59l2.59 -2.59" />
                                            <path d="M7 12a5 5 0 0 1 5 -5" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Kilometers</span>
                                            <h6 class="title">20,925 Km</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-manual-gearbox">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M5 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M19 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 8l0 8" />
                                            <path d="M12 8l0 8" />
                                            <path d="M19 8v2a2 2 0 0 1 -2 2h-12" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Transmisson</span>
                                            <h6 class="title">Automatic</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-calendar-week">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M4 7a2 2 0 0 1 2 -2h12a2 2 0 0 1 2 2v12a2 2 0 0 1 -2 2h-12a2 2 0 0 1 -2 -2v-12z" />
                                            <path d="M16 3v4" />
                                            <path d="M8 3v4" />
                                            <path d="M4 11h16" />
                                            <path d="M7 14h.013" />
                                            <path d="M10.01 14h.005" />
                                            <path d="M13.01 14h.005" />
                                            <path d="M16.015 14h.005" />
                                            <path d="M13.015 17h.005" />
                                            <path d="M7.01 17h.005" />
                                            <path d="M10.01 17h.005" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Model Year</span>
                                            <h6 class="title">2024</h6>
                                        </div>
                                    </div>
                                    <div class="btn-box d-block">
                                        <a href="single-page-details.html" class="btn-white">More Info <i class="ti ti-arrow-up-right"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="banner-slide">
                        <img src="Contents/outer/images/banner3.jpg" alt="">
                        <div class="right-box">
                            <div class="container position-relative">
                                <div class="content-area">
                                    <div class="content-box">
                                        <h1 data-animation-in="fadeInUp" data-delay-in="0.2">Audi Q8</h1>
                                        <span class="sub-title" data-animation-in="fadeInDown">Celebration Edition BSVI</span>
                                    </div>
                                </div>
                                <div class="list-box" data-animation-in="fadeInUp" data-delay-in="0.3">
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gas-station">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M14 11h1a2 2 0 0 1 2 2v3a1.5 1.5 0 0 0 3 0v-7l-3 -3" />
                                            <path d="M4 20v-14a2 2 0 0 1 2 -2h6a2 2 0 0 1 2 2v14" />
                                            <path d="M3 20l12 0" />
                                            <path d="M18 7v1a1 1 0 0 0 1 1h1" />
                                            <path d="M4 11l10 0" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Fuel Type</span>
                                            <h6 class="title">Petrol</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gauge">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M12 12m-9 0a9 9 0 1 0 18 0a9 9 0 1 0 -18 0" />
                                            <path d="M12 12m-1 0a1 1 0 1 0 2 0a1 1 0 1 0 -2 0" />
                                            <path d="M13.41 10.59l2.59 -2.59" />
                                            <path d="M7 12a5 5 0 0 1 5 -5" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Kilometers</span>
                                            <h6 class="title">20,925 Km</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-manual-gearbox">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M5 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M19 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 8l0 8" />
                                            <path d="M12 8l0 8" />
                                            <path d="M19 8v2a2 2 0 0 1 -2 2h-12" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Transmisson</span>
                                            <h6 class="title">Automatic</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-calendar-week">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M4 7a2 2 0 0 1 2 -2h12a2 2 0 0 1 2 2v12a2 2 0 0 1 -2 2h-12a2 2 0 0 1 -2 -2v-12z" />
                                            <path d="M16 3v4" />
                                            <path d="M8 3v4" />
                                            <path d="M4 11h16" />
                                            <path d="M7 14h.013" />
                                            <path d="M10.01 14h.005" />
                                            <path d="M13.01 14h.005" />
                                            <path d="M16.015 14h.005" />
                                            <path d="M13.015 17h.005" />
                                            <path d="M7.01 17h.005" />
                                            <path d="M10.01 17h.005" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Model Year</span>
                                            <h6 class="title">2024</h6>
                                        </div>
                                    </div>
                                    <div class="btn-box d-block">
                                        <a href="single-page-details.html" class="btn-white">More Info <i class="ti ti-arrow-up-right"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <div class="banner-slide">
                        <img src="Contents/outer/images/banner4.jpg" alt="">
                        <div class="right-box">
                            <div class="container position-relative">
                                <div class="content-area">
                                    <div class="content-box">
                                        <h1 data-animation-in="fadeInUp" data-delay-in="0.2">Mercedes-AMG</h1>
                                        <span class="sub-title" data-animation-in="fadeInDown">CGI, Sports Car</span>
                                    </div>
                                </div>
                                <div class="list-box" data-animation-in="fadeInUp" data-delay-in="0.3">
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gas-station">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M14 11h1a2 2 0 0 1 2 2v3a1.5 1.5 0 0 0 3 0v-7l-3 -3" />
                                            <path d="M4 20v-14a2 2 0 0 1 2 -2h6a2 2 0 0 1 2 2v14" />
                                            <path d="M3 20l12 0" />
                                            <path d="M18 7v1a1 1 0 0 0 1 1h1" />
                                            <path d="M4 11l10 0" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Fuel Type</span>
                                            <h6 class="title">Petrol</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-gauge">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M12 12m-9 0a9 9 0 1 0 18 0a9 9 0 1 0 -18 0" />
                                            <path d="M12 12m-1 0a1 1 0 1 0 2 0a1 1 0 1 0 -2 0" />
                                            <path d="M13.41 10.59l2.59 -2.59" />
                                            <path d="M7 12a5 5 0 0 1 5 -5" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Kilometers</span>
                                            <h6 class="title">20,925 Km</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-manual-gearbox">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M5 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M19 6m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M12 18m-2 0a2 2 0 1 0 4 0a2 2 0 1 0 -4 0" />
                                            <path d="M5 8l0 8" />
                                            <path d="M12 8l0 8" />
                                            <path d="M19 8v2a2 2 0 0 1 -2 2h-12" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Transmisson</span>
                                            <h6 class="title">Automatic</h6>
                                        </div>
                                    </div>
                                    <div class="items">
                                        <svg xmlns="http://www.w3.org/2000/svg" width="52" height="52" viewBox="0 0 24 24" fill="none" stroke="#fff" stroke-width="1.2" stroke-linecap="round" stroke-linejoin="round" class="icon icon-tabler icons-tabler-outline icon-tabler-calendar-week">
                                            <path stroke="none" d="M0 0h24v24H0z" fill="none" />
                                            <path d="M4 7a2 2 0 0 1 2 -2h12a2 2 0 0 1 2 2v12a2 2 0 0 1 -2 2h-12a2 2 0 0 1 -2 -2v-12z" />
                                            <path d="M16 3v4" />
                                            <path d="M8 3v4" />
                                            <path d="M4 11h16" />
                                            <path d="M7 14h.013" />
                                            <path d="M10.01 14h.005" />
                                            <path d="M13.01 14h.005" />
                                            <path d="M16.015 14h.005" />
                                            <path d="M13.015 17h.005" />
                                            <path d="M7.01 17h.005" />
                                            <path d="M10.01 17h.005" />
                                        </svg>
                                        <div class="item-content">
                                            <span>Model Year</span>
                                            <h6 class="title">2024</h6>
                                        </div>
                                    </div>
                                    <div class="btn-box d-block">
                                        <a href="single-page-details.html" class="btn-white">More Info <i class="ti ti-arrow-up-right"></i></a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="banner-filter-area">
                    <div class="container">
                        <div class="myform">
                            <div class="inner-group">
                                <div class="form-group">
                                    <select name="maker" id="maker" class="form-control">
                                        <option value="">Maker</option>
                                        <option value="toyota">Toyota</option>
                                        <option value="sukuki">Suzuki</option>
                                        <option value="bmw">BMW</option>
                                        <option value="nissan">Nissan</option>
                                        <option value="honda">Honda</option>
                                        <option value="subaru">Subaru</option>
                                        <option value="mazda">Mazda</option>
                                    </select>
                                </div>

                                <div class="form-group">
                                    <select name="model" id="model" class="form-control">
                                        <option value="">Model</option>
                                        <option value="a4">A4</option>
                                        <option value="almera">Almera</option>
                                        <option value="bellet">Bellet</option>
                                        <option value="class">C-Class</option>
                                        <option value="camry">Camry</option>
                                        <option value="carnival">Carnival</option>
                                        <option value="wagan">Wagonr</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <select name="year" id="year" class="form-control">
                                        <option value="">Model Year</option>
                                        <option value="2024">2024 & above</option>
                                        <option value="2022">2022 & above</option>
                                        <option value="2020">2020 & above</option>
                                        <option value="2018">2018 & above</option>
                                        <option value="2016">2016 & above</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <select name="kilometer" id="kilometer" class="form-control">
                                        <option value="">Kilometers</option>
                                        <option value="5">5,000 or less</option>
                                        <option value="10">10,000 or less</option>
                                        <option value="20">20,000 or less</option>
                                        <option value="30">30,000 or less</option>
                                        <option value="40">40,000 or less</option>
                                        <option value="50">50,000 or less</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <select name="price" id="price" class="form-control">
                                        <option value="">Price</option>
                                        <option value="58">5 - 8 lakh</option>
                                        <option value="81">8 - 12 lakh</option>
                                        <option value="12">12 - 15 lakh</option>
                                        <option value="15">15 - 20 lakh</option>
                                        <option value="20">20 - 25 lakh</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <select name="Btype" id="Btype" class="form-control">
                                        <option value="">Body Type</option>
                                        <option value="suv">SUV</option>
                                        <option value="seden">Seden</option>
                                        <option value="ven">Mini Ven</option>
                                        <option value="convertible">Convertible</option>
                                        <option value="hatchback">Hatchback</option>
                                    </select>
                                </div>
                                <!-- <div class="form-group">
                            <div class="group-select">
                                <div class="nice-select" tabindex="0">
                                    <span class="current">Kilometers</span>
                                    <ul class="list">
                                        <li data-value="0"><input type="text" placeholder="Search Kilometers"></li>
                                        <li data-value="Convertible" class="option">10,000 kms or less</li>
                                        <li data-value="Coupe" class="option">20,000 kms or less</li>
                                        <li data-value="Crossover" class="option ">30,000 kms or less</li>
                                        <li data-value="Hatchback" class="option">40,000 kms or less</li>
                                        <li data-value="Crossover" class="option ">50,000 kms or less</li>
                                    </ul>
                                </div>
                            </div>
                        </div> -->
                                <div class="form-submit">
                                    <a href="list-page.html" type="button" class="theme-btn"><i class="ti ti-search"></i>Find Cars</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- banner-section end -->

            <!-- buy sell section start --->
            <section class="buy-sell-section">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="buy-sell-banner buy-banner wow fadeInUp animated">
                                <h3 class="title">Are You Looking For a
                                    <br>
                                    Used Car?</h3>
                                <div class="text">We are committed to providing our customers with exceptional service.</div>
                                <a href="" class="theme-btn">Get Started <i class="ti ti-arrow-up-right"></i></a>
                                <div class="hover-img">
                                    <img src="Contents/outer/images/buy-car.png">
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="buy-sell-banner sell-banner wow fadeInUp animated">
                                <h3 class="title">Do You Want to Sell a
                                    <br>
                                    Car?</h3>
                                <div class="text">We are committed to providing our customers with exceptional service.</div>
                                <a href="" class="theme-btn">Get Started <i class="ti ti-arrow-up-right"></i></a>
                                <div class="hover-img">
                                    <img src="Contents/outer/images/sell-car.png">
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- buy sell section end --->

            <!-- why choose us start -->
            <section class="why-choose-us">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="image-section">
                                <ul class="icon-list">
                                    <li class="icon-block ani1">
                                        <i class="ti ti-circle-check-filled"></i>
                                        <span>Proven Expertise</span>
                                    </li>
                                    <li class="icon-block ani2">
                                        <i class="ti ti-circle-check-filled"></i>
                                        <span>1 million visits per day</span>
                                    </li>
                                    <li class="icon-block ani1">
                                        <i class="ti ti-circle-check-filled"></i>
                                        <span>7,800 car sellers</span>
                                    </li>
                                </ul>
                                <div class="image-inner">
                                    <img class="lazyloaded" data-src="Contents/outer/images/why-us.jpg" src="Contents/outer/images/why-us.jpg" alt="images">
                                </div>
                                <div class="image-inner2">
                                    <img class="lazyloaded" data-src="Contents/outer/images/why-choose-car.png" src="Contents/outer/images/why-choose-car.png" alt="images">
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="content-area">
                                <div class="heading-section">
                                    <h2 class="wow fadeInUpSmall" data-wow-delay="0.2s" data-wow-duration="1000ms">Why Choose Sayyarah</h2>
                                    <p class="wow fadeInUpSmall" data-wow-delay="0.2s" data-wow-duration="1000ms">
                                        Our experienced team excels in car sales with many years of successfully
                                navigating the market, delivering informed decisions and optimal results.
                                    </p>
                                </div>
                                <div class="icon-box-list">
                                    <div class="icon-box wow fadeInUpSmall" data-wow-delay="0.2s" data-wow-duration="1000ms">
                                        <div class="icon">
                                            <svg width="56" height="56" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                <g clip-path="url(#clip0_2181_18199)">
                                                    <path d="M50 28.2812C50 27.5 49.5312 26.875 48.9062 26.5625C47.8125 26.0938 46.7969 25.4688 45.8594 24.7656C42.7344 22.3438 38.9844 20.7031 35.1562 19.9219C35.625 18.9844 35.8594 17.8906 35.8594 16.7969C35.8594 12.7344 32.5 9.375 28.4375 9.375C24.375 9.375 21.0156 12.7344 21.0156 16.7969C21.0156 18.125 21.3281 19.2969 21.9531 20.3906C20.2344 21.0156 18.9844 21.875 17.6562 22.6562C16.4062 23.4375 15.0781 24.2969 13.4375 24.9219C6.17188 25.3125 2.1875 26.7969 0.46875 29.6094C0.15625 30 0 30.625 0 31.1719V33.5156C0 34.8438 0.9375 35.9375 2.26562 36.1719L5.54688 36.6406C5.85938 38.9063 7.8125 40.7031 10.1562 40.7031C12.5 40.7031 14.375 38.9844 14.7656 36.7969L36.6406 36.7188C37.0312 38.9062 38.9062 40.625 41.25 40.625C43.5938 40.625 45.4688 38.9062 45.8594 36.7188H47.3438C48.5938 36.7188 50 35.7031 50 33.5156V28.2812ZM40.8594 23.4375C39.9219 24.0625 38.125 26.6406 34.375 26.6406H29.1406V24.1406C31.25 23.9062 33.125 22.8125 34.375 21.1719C34.6875 21.4844 37.0312 21.5625 40.8594 23.4375ZM28.3594 10.8594C31.6406 10.8594 34.2188 13.5156 34.2188 16.7187C34.2188 20 31.5625 22.5781 28.3594 22.5781C25.0781 22.5781 22.5 19.9219 22.5 16.7187C22.5 13.5156 25.1562 10.8594 28.3594 10.8594ZM18.4375 23.9062C22.0312 21.6406 22.3438 21.9531 22.7344 21.5625C23.9062 22.9688 25.625 23.9062 27.5781 24.1406V26.6406H18.0469C16.9531 26.6406 15.8594 26.4062 14.8438 25.9375C16.25 25.3125 17.3438 24.6094 18.4375 23.9062ZM10.2344 39.1406C8.51562 39.1406 7.10938 37.7344 7.10938 36.0156C7.10938 34.2969 8.51562 32.8906 10.2344 32.8906C11.9531 32.8906 13.3594 34.2969 13.3594 36.0156C13.3594 37.7344 11.9531 39.1406 10.2344 39.1406ZM41.25 39.0625C39.5312 39.0625 38.125 37.6562 38.125 35.9375C38.125 34.2188 39.5312 32.8125 41.25 32.8125C42.9688 32.8125 44.375 34.2188 44.375 35.9375C44.375 37.6562 42.9688 39.0625 41.25 39.0625ZM47.3438 35.1562H45.8594C45.4688 32.9688 43.5938 31.3281 41.25 31.3281C38.9062 31.3281 37.0312 33.0469 36.6406 35.2344L14.7656 35.3125C14.375 33.125 12.5 31.4844 10.1562 31.4844C7.89062 31.4844 6.01562 33.125 5.625 35.2344L2.5 34.7656C1.95312 34.6094 1.5625 34.0625 1.5625 33.5156V31.1719C1.5625 30.8594 1.64062 30.5469 1.79688 30.2344C2.65625 28.8281 4.6875 26.9531 12.7344 26.3281C14.2969 27.4219 16.0938 28.0469 17.9688 28.0469H34.375C38.9062 28.0469 41.0156 24.9219 42.1875 24.1406C42.1875 24.1406 42.1875 24.0625 42.2656 24.0625C43.2031 24.6094 44.0625 25.1562 44.8438 25.7812C45.8594 26.5625 47.0312 27.2656 48.2031 27.8125C48.3594 27.8906 48.4375 28.0469 48.4375 28.125V33.2812C48.4375 34.5312 48.0469 35.1562 47.3438 35.1562Z" fill="#405ff2"></path>
                                                    <path d="M26.3281 29.8438H23.3594C22.9688 29.8438 22.5781 30.1563 22.5781 30.625C22.5781 31.0938 22.8906 31.4062 23.3594 31.4062H26.3281C26.7188 31.4062 27.1094 31.0938 27.1094 30.625C27.1094 30.1563 26.7188 29.8438 26.3281 29.8438ZM26.7188 20.2344C27.0313 20.5469 27.5 20.5469 27.8125 20.2344L31.875 16.1719C32.1875 15.8594 32.1875 15.3906 31.875 15.0781C31.5625 14.7656 31.0938 14.7656 30.7813 15.0781L27.2656 18.5938L25.9375 17.2656C25.625 16.9531 25.1562 16.9531 24.8437 17.2656C24.5312 17.5781 24.5312 18.0469 24.8437 18.3594L26.7188 20.2344Z" fill="#405ff2"></path>
                                                </g>
                                                <defs>
                                                    <clipPath id="clip0_2181_18199">
                                                        <rect width="50" height="50" fill="#405ff2"></rect>
                                                    </clipPath>
                                                </defs>
                                            </svg>
                                        </div>
                                        <div class="content">
                                            <h5><a href="#">New range rover, defender, discovery</a></h5>
                                            <p>Experience the joy of owning a brand new Range Rover, Defender or Discovery today!</p>
                                        </div>
                                    </div>
                                    <div class="icon-box wow fadeInUpSmall" data-wow-delay="0.3s" data-wow-duration="1000ms">
                                        <div class="icon">
                                            <svg width="56" height="56" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                <g clip-path="url(#clip0_2180_18173)">
                                                    <path d="M8.51562 9.45312L9.14062 9.53125C8.82812 9.92188 8.67188 10.4688 8.75 11.0156L9.21875 18.5938C9.29688 19.2969 9.6875 19.9219 10.2344 20.2344V21.4844C10.2344 22.5781 11.0938 23.4375 12.1875 23.4375H15.4688C16.5625 23.4375 17.4219 22.5781 17.4219 21.4844V20.5469H30.5469V21.4844C30.5469 22.5781 31.4062 23.4375 32.5 23.4375H35.7812C36.875 23.4375 37.7344 22.5781 37.7344 21.4844V20.0781C38.2031 19.6875 38.5156 19.2188 38.5156 18.5938L38.9844 11.0156C39.0625 10.4688 38.8281 10 38.5938 9.53125L39.2969 9.45312C40.5469 9.29688 41.5625 8.20312 41.4844 6.79688C41.3281 5.625 40.3125 4.76562 39.1406 4.6875H37.1875C36.5625 4.6875 35.9375 4.92188 35.4688 5.39062C34.9219 4.14062 34.2188 2.96875 33.5938 1.95312C32.8906 0.78125 31.5625 0 30.2344 0H17.6562C16.25 0 15 0.703125 14.2188 1.95312C13.4375 3.20312 12.8906 4.21875 12.3438 5.39062C11.9531 4.92188 11.3281 4.6875 10.7031 4.6875L8.75 4.76562C7.42188 4.76562 6.40625 5.85938 6.40625 7.10938C6.40625 8.28125 7.34375 9.375 8.51562 9.45312ZM12.2656 8.75H35.5469C35.7812 9.0625 36.0156 9.29688 36.25 9.53125C33.2812 10.0781 31.4062 11.5625 30.3125 12.9688C29.7656 13.6719 28.9844 13.9844 28.2031 13.9844H19.5312C18.75 13.9844 17.9688 13.5938 17.4219 12.9688C16.3281 11.6406 14.4531 10.0781 11.4844 9.53125C11.7969 9.29688 12.0312 8.98438 12.2656 8.75ZM36.4844 19.0625H11.3281C11.0156 19.0625 10.7031 18.8281 10.7031 18.5156L10.4688 14.6094C10.7031 14.6094 13.8281 16.4844 16.0938 13.75C16.9531 14.7656 17.9687 15.5469 19.5312 15.5469H28.2812C29.7656 15.5469 30.7812 14.8438 31.7187 13.75C32.8125 15.0781 34.6875 15.625 36.3281 15L37.2656 14.6094L37.0312 18.5156C37.1094 18.8281 36.7969 19.0625 36.4844 19.0625ZM15 12.6563C13.4375 14.7656 10.9375 13.0469 10.3906 12.9688L10.3125 10.9375C12.4219 11.0156 13.9063 11.7969 15 12.6563ZM37.5 10.9375L37.4219 12.9688C36.875 13.0469 34.375 14.7656 32.8125 12.6563C33.9062 11.7969 35.3906 11.0156 37.5 10.9375ZM15.9375 21.5625C15.9375 21.7969 15.7031 22.0312 15.4688 22.0312H12.1875C11.9531 22.0312 11.7188 21.7969 11.7188 21.5625V20.625H15.8594V21.5625H15.9375ZM35.8594 21.9531H32.5781C32.3438 21.9531 32.1094 21.7188 32.1094 21.4844V20.5469H36.25V21.4844C36.25 21.7969 36.0938 21.9531 35.8594 21.9531ZM37.1875 6.25H39.1406C39.6094 6.25 40 6.5625 40 6.95312C40 7.03125 40.0781 7.8125 39.2188 7.89063L37.1875 8.125C36.25 7.1875 36.4844 7.03125 36.4844 6.95312C36.3281 6.5625 36.7187 6.25 37.1875 6.25ZM15.5469 2.73438C15.9375 2.03125 16.7969 1.5625 17.6562 1.5625H30.2344C31.0938 1.5625 31.875 2.03125 32.3438 2.73438C34.0625 5.625 33.9844 5.70312 34.6875 7.26562H13.2031C13.9062 5.625 13.75 5.625 15.5469 2.73438ZM8.75 6.25H10.7031C11.6406 6.17188 11.4062 7.1875 11.4844 7.26562C11.25 7.65625 11.0156 7.96875 10.7031 8.20312L8.67188 7.96875C8.20313 7.89062 7.8125 7.57813 7.8125 7.10938C7.96875 7.03125 7.96875 6.32812 8.75 6.25Z" fill="#405ff2"></path>
                                                    <path d="M48.9062 22.0311C47.4219 19.9218 44.375 19.9999 42.9688 21.8749L32.5 32.9686C31.7969 31.4843 30.3125 30.4686 28.6719 30.4686H19.375C18.5156 30.4686 17.7344 30.3124 16.9531 29.9218C13.0469 28.0468 8.35938 28.5936 5 31.4061L0.703125 34.9999C0.390625 35.2343 0.3125 35.7811 0.625 36.0936C0.859375 36.4061 1.40625 36.4843 1.71875 36.1718L6.01562 32.578C8.90625 30.1561 12.9688 29.6874 16.3281 31.328C17.2656 31.7968 18.3594 32.0311 19.4531 32.0311H28.75C30.1562 32.0311 31.4844 33.1249 31.4844 34.7655C31.4844 36.2499 30.3906 37.4218 28.9062 37.4218H18.8281C18.4375 37.4218 18.0469 37.7343 18.0469 38.203C18.0469 38.6718 18.3594 38.9843 18.8281 38.9843H28.75C30.9375 38.9843 32.8125 37.2655 32.8125 34.8436L44.1406 22.8905C45 21.7186 46.7969 21.7186 47.6562 22.9686C48.2031 23.7499 48.2031 24.8436 47.5781 25.6249L38.6719 37.3436C32.6562 45.3124 22.3438 47.6561 13.5156 44.9218C11.0937 44.1405 7.26562 44.6874 5 46.0155L0.78125 48.5936C0.390625 48.828 0.3125 49.2968 0.546875 49.6093C0.703125 49.9999 1.17188 50.078 1.5625 49.8436L5.9375 47.2655C7.8125 46.0936 11.1719 45.703 13.2031 46.328C22.5781 49.2186 33.5156 46.7186 40 38.203L48.9062 26.4843C49.8438 25.1562 49.8438 23.3593 48.9062 22.0311Z" fill="#405ff2"></path>
                                                </g>
                                                <defs>
                                                    <clipPath id="clip0_2180_18173">
                                                        <rect width="50" height="50" fill="#405ff2"></rect>
                                                    </clipPath>
                                                </defs>
                                            </svg>
                                        </div>
                                        <div class="content">
                                            <h5><a href="#">Pre-Owned vehicles</a></h5>
                                            <p>Sayyarah has a great selection of pre-owned vehicles.</p>
                                        </div>
                                    </div>
                                    <div class="icon-box wow fadeInUpSmall" data-wow-delay="0.4s" data-wow-duration="1000ms">
                                        <div class="icon">
                                            <svg width="56" height="56" viewBox="0 0 50 50" fill="none" xmlns="http://www.w3.org/2000/svg">
                                                <path d="M12.4219 23.75L8.4375 22.8906C7.34375 22.6562 6.32812 23.5156 6.32812 24.6094V26.25C6.32812 27.5781 7.34375 27.8906 8.59375 27.8906H12.9688C13.8281 27.8906 14.6875 27.7344 14.6875 26.7969V26.5625C14.6875 25.1562 13.75 23.9844 12.4219 23.75ZM7.8125 26.25V24.5312C7.8125 24.375 7.96875 24.2187 8.125 24.2969L12.1094 25.1562C12.6562 25.3125 13.0469 25.7812 13.125 26.3281C10.3906 26.3281 8.04687 26.3281 7.8125 26.25Z" fill="#405ff2"></path>
                                                <path d="M47.8906 15.3906L42.2656 12.7344C40.3906 11.875 38.3594 11.5625 36.4062 11.9531L35.5469 10.2344C34.9219 8.67188 33.4375 7.57812 31.7187 7.57812H13.4375C11.7188 7.57812 10.2344 8.59375 9.60938 10.1563L6.5625 16.4844C5.85937 15.4688 4.6875 14.8438 3.4375 14.8438H2.10938C0.9375 14.8438 0 15.7813 0 16.9531V17.8125C0 18.9844 0.9375 19.9219 2.10938 19.9219H4.14062C3.28125 21.0156 2.89062 22.4219 2.89062 23.8281V28.5156C2.89062 30.3125 3.51562 32.0312 4.76562 33.5156V37.0312C4.76562 38.5938 6.01562 39.8438 7.57812 39.8438H10.4688C12.0312 39.8438 13.2812 38.5938 13.2812 37.0312V35.625H28.9062C32.3438 40.3125 37.7344 42.3438 37.8125 42.3438C37.9688 42.4219 38.125 42.4219 38.3594 42.3438C38.4375 42.2656 50 38.0469 50 27.5V18.75C50 17.3438 49.1406 16.0156 47.8906 15.3906ZM11.0156 10.7813C11.4062 9.76563 12.3438 9.14062 13.4375 9.14062H31.7187C32.8125 9.14062 33.75 9.76562 34.2188 10.8594L34.9219 12.3438C34.6094 12.4219 34.2969 12.5781 33.9844 12.7344L28.3594 15.3906C27.1094 16.0156 26.25 17.2656 26.25 18.6719H7.10938C7.42188 18.2031 7.10938 18.9844 11.0156 10.7813ZM1.5625 17.8125V16.9531C1.5625 16.6406 1.79688 16.4062 2.10938 16.4062H3.4375C5 16.4062 5.54688 17.8125 5.70312 18.0469C5.625 18.2031 5.54688 18.2812 5.39062 18.4375H2.10938C1.79688 18.3594 1.5625 18.125 1.5625 17.8125ZM11.7188 36.9531C11.7188 37.6562 11.1719 38.2031 10.4688 38.2031H7.5C6.79688 38.2812 6.25 37.6562 6.25 36.9531V34.6875C7.1875 35.2344 8.28125 35.5469 9.375 35.5469H11.7188V36.9531ZM9.29688 34.0625C6.48438 34.0625 4.29688 31.3281 4.29688 28.4375V23.75C4.29688 22.4219 4.84375 21.1719 5.78125 20.1562H26.25V27.0312H17.6562C17.2656 27.0312 16.875 27.3437 16.875 27.8125C16.875 28.2812 17.1875 28.5937 17.6562 28.5937H26.3281C26.4062 29.1406 26.4062 29.6094 26.5625 30.0781H17.6562C17.2656 30.0781 16.875 30.3906 16.875 30.8594C16.875 31.3281 17.1875 31.6406 17.6562 31.6406H26.875C27.1875 32.5 27.5 33.3594 27.9688 34.0625H9.29688ZM48.4375 27.5C48.4375 36.1719 39.6875 40.1562 38.125 40.7812C32.5 38.5156 27.8125 33.6719 27.8125 27.5V18.75C27.8125 17.8906 28.2812 17.1875 29.0625 16.7969L34.6875 14.1406C36.9531 13.0469 39.4531 13.0469 41.7188 14.1406L47.3438 16.7969C48.0469 17.1875 48.5938 17.8906 48.5938 18.75V27.5H48.4375Z" fill="#405ff2"></path>
                                                <path d="M45.7812 18.5937L40.625 16.1719C39.0625 15.3906 37.1094 15.3906 35.5469 16.1719L30.4687 18.5937C30.2344 18.75 30 18.9844 30 19.2969V27.5C30 33.6719 35.3906 37.0312 37.7344 38.2031C37.9687 38.2812 38.2031 38.2812 38.4375 38.2031C40.7812 37.0312 46.1719 33.6719 46.1719 27.5V19.2969C46.1719 18.9844 46.0156 18.75 45.7812 18.5937ZM44.6875 27.5C44.6875 32.5 40.3125 35.4688 38.125 36.6406C35.5469 35.2344 31.5625 32.4219 31.5625 27.5V19.7656L36.25 17.5C37.4219 16.9531 38.8281 16.9531 40 17.5L44.6875 19.7656V27.5Z" fill="#405ff2"></path>
                                                <path d="M35.0785 27.2657C34.766 27.0313 34.2973 27.1094 33.9848 27.4219C33.6723 27.7344 33.8285 28.2032 34.141 28.5157L37.1098 30.7813C37.4223 31.0157 37.891 30.9375 38.2035 30.625L42.5785 24.9219C42.8129 24.6094 42.7348 24.1407 42.4223 23.8282C42.1098 23.5938 41.641 23.6719 41.3285 23.9844L37.4223 29.0625L35.0785 27.2657Z" fill="#405ff2"></path>
                                            </svg>
                                        </div>
                                        <div class="content">
                                            <h5><a href="#">Certified pre-owned vehicles</a></h5>
                                            <p>Sayyarah Demo has a great selection of certified pre-owned vehicles.</p>
                                        </div>
                                    </div>
                                    <div class="icon-box wow fadeInUpSmall" data-wow-delay="0.5s" data-wow-duration="1000ms">
                                        <div class="icon">
                                            <svg width="56" height="56" viewBox="0 0 50 50" fill="#405ff2" xmlns="http://www.w3.org/2000/svg">
                                                <g clip-path="url(#clip0_2180_18160)">
                                                    <path d="M14.1406 32.9687L9.92188 32.0312C8.75 31.7969 7.73438 32.6562 7.73438 33.8281V35.625C7.73438 37.0312 8.82813 37.2656 10.1563 37.3437H15C15.8594 37.3437 16.5625 37.0312 16.5625 36.1719V35.9375C16.4844 34.4531 15.5469 33.2812 14.1406 32.9687ZM9.21875 35.7031V33.75C9.21875 33.5156 9.375 33.3594 9.60938 33.4375L13.9062 34.375C14.5312 34.5312 15 35.0781 15.0781 35.7031C14.9219 35.7812 9.29688 35.7812 9.21875 35.7031ZM40.0781 32.0312L35.7813 32.9687C34.375 33.2812 33.4375 34.4531 33.4375 35.8594C33.4375 35.9375 33.2812 36.9531 34.375 37.1875C34.9219 37.3437 38.4375 37.2656 39.9219 37.2656C41.25 37.2656 42.2656 36.9531 42.2656 35.5469V33.75C42.3438 32.6562 41.25 31.7969 40.0781 32.0312ZM40.7813 35.7031C40.5469 35.7812 35.0781 35.7812 35 35.7812C35.0781 35.1562 35.4688 34.6094 36.0938 34.4531L40.3906 33.5156C40.625 33.4375 40.7813 33.5937 40.7813 33.8281V35.7031ZM30.2344 36.5625H19.7656C19.375 36.5625 18.9844 36.875 18.9844 37.3437C18.9844 37.8125 19.2969 38.125 19.7656 38.125H30.2344C30.625 38.125 31.0156 37.8125 31.0156 37.3437C31.0156 36.875 30.7031 36.5625 30.2344 36.5625ZM30.2344 39.7656H19.7656C19.375 39.7656 18.9844 40.0781 18.9844 40.5469C18.9844 41.0156 19.2969 41.3281 19.7656 41.3281H30.2344C30.625 41.3281 31.0156 41.0156 31.0156 40.5469C31.0156 40.0781 30.7031 39.7656 30.2344 39.7656Z" fill="#405ff2"></path>
                                                    <path d="M46.875 23.5938H45.4688C44.1406 23.5938 42.8906 24.2188 42.1875 25.3906L40.7812 22.5781C44.8438 20.7031 47.6562 16.6406 47.6562 11.875C47.5781 5.3125 42.2656 0 35.7812 0C29.2969 0 23.9844 5.3125 23.9844 11.7969C23.9844 13.2031 24.2188 14.5313 24.6875 15.7813H15.2344C13.4375 15.7813 11.7969 16.875 11.1719 18.5156L7.89063 25.3125C7.1875 24.2188 5.9375 23.5156 4.60937 23.5156H3.125C1.95312 23.5156 0.9375 24.5313 0.9375 25.7031V26.6406C0.9375 27.8125 1.875 28.8281 3.125 28.8281H5.39062C4.45312 30 3.98438 31.4844 3.98438 33.0469V38.0469C3.98438 39.9219 4.6875 41.7969 6.01562 43.3594V47.1094C6.01562 48.75 7.34375 50 8.90625 50H12.0312C13.6719 50 14.9219 48.6719 14.9219 47.1094V45.625H35V47.1094C35 48.75 36.3281 50 37.8906 50H41.0156C42.6562 50 43.9062 48.6719 43.9062 47.1094V43.3594C45.2344 41.875 45.9375 40.0781 45.9375 38.125V33.125C45.9375 32.1875 45.7031 31.1719 45.3125 30.3125C45.0781 29.8438 44.8438 29.375 44.4531 28.9062H46.875C48.0469 28.9062 49.0625 27.9688 49.0625 26.7188V25.7812C48.9844 24.5312 48.0469 23.5938 46.875 23.5938ZM35.7812 1.5625C41.4844 1.5625 46.0938 6.17188 46.0938 11.7969C46.0938 17.4219 41.4844 22.0312 35.8594 22.0312C30.2344 22.0312 25.625 17.4219 25.625 11.7969C25.625 6.17188 30.1562 1.5625 35.7812 1.5625ZM12.5781 19.1406C12.9688 18.0469 14.0625 17.3438 15.2344 17.3438H25.3906C27.3438 21.0938 31.25 23.5938 35.7812 23.5938C37.0312 23.5938 38.2031 23.4375 39.2969 23.0469C39.375 23.125 41.25 27.1094 41.5625 27.6563H8.35938C8.67188 27.1875 8.20313 28.2812 12.5781 19.1406ZM2.5 26.6406V25.7031C2.5 25.3125 2.8125 25 3.125 25H4.53125C6.25 25 6.875 26.5625 7.03125 26.7969C6.95312 26.9531 6.79688 27.1094 6.71875 27.2656H3.125C2.8125 27.2656 2.5 27.0312 2.5 26.6406ZM13.4375 47.0312C13.4375 47.8125 12.8125 48.4375 12.0312 48.4375H8.90625C8.125 48.4375 7.5 47.8125 7.5 47.0312V44.5312C8.51563 45.1562 9.6875 45.4688 10.8594 45.4688H13.4375V47.0312ZM41.0938 48.4375H37.9688C37.1875 48.4375 36.5625 47.8125 36.5625 47.0312V45.5469H39.1406C40.3125 45.5469 41.4844 45.2344 42.5 44.6094V47.1094C42.5 47.8125 41.875 48.4375 41.0938 48.4375ZM44.5312 37.9688C44.5312 41.0938 42.2656 43.9844 39.1406 43.9844H10.8594C7.73438 43.9844 5.46875 41.0156 5.46875 37.9688V32.9688C5.46875 31.5625 6.01563 30.1562 7.10938 29.1406H42.9688C43.4375 29.6094 43.8281 30.1563 44.1406 30.7813C44.4531 31.4844 44.6094 32.2656 44.6094 32.9688V37.9688H44.5312ZM47.5 26.6406C47.5 27.0312 47.1875 27.2656 46.875 27.2656H43.2812C43.125 27.1094 43.0469 26.9531 42.9688 26.7969C43.2031 26.5625 43.75 25 45.4688 25H46.875C47.2656 25 47.5 25.3125 47.5 25.625V26.6406Z" fill="#405ff2"></path>
                                                    <path d="M33.4375 14.9219C33.4375 14.5312 33.125 14.1406 32.6562 14.1406C32.1875 14.1406 31.875 14.4531 31.875 14.9219C31.875 16.7969 33.2031 18.3594 35 18.6719V19.6875C35 20.0781 35.3125 20.4688 35.7812 20.4688C36.25 20.4688 36.5625 20.1562 36.5625 19.6875V18.6719C38.3594 18.2812 39.6875 16.7969 39.6875 14.9219C39.6875 13.0469 38.3594 11.4844 36.5625 11.1719V6.48438C37.5 6.79688 38.125 7.65625 38.125 8.67188C38.125 9.0625 38.4375 9.45313 38.9062 9.45313C39.375 9.45313 39.6875 9.14063 39.6875 8.67188C39.6875 6.79688 38.3594 5.23438 36.5625 4.92188V3.90625C36.5625 3.51562 36.25 3.125 35.7812 3.125C35.3125 3.125 35 3.4375 35 3.90625V4.92188C33.2031 5.3125 31.875 6.79688 31.875 8.67188C31.875 10.5469 33.2031 12.1094 35 12.4219V17.0312C34.1406 16.7969 33.4375 15.9375 33.4375 14.9219ZM38.125 14.9219C38.125 15.9375 37.4219 16.7969 36.5625 17.1094V12.7344C37.5 12.9687 38.125 13.9062 38.125 14.9219ZM33.4375 8.67188C33.4375 7.65625 34.1406 6.79688 35 6.48438V10.9375C34.1406 10.5469 33.4375 9.6875 33.4375 8.67188Z" fill="#405ff2"></path>
                                                </g>
                                                <defs>
                                                    <clipPath id="clip0_2180_18160">
                                                        <rect width="50" height="50" fill="#405ff2"></rect>
                                                    </clipPath>
                                                </defs>
                                            </svg>
                                        </div>
                                        <div class="content">
                                            <h5><a href="#">Financing</a></h5>
                                            <p>Get approved today and drive off in a new or used vehicle.</p>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- why choose us end -->

            <!-- popular car section start -->
            <section class="popular-car-section section-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12 col-12">
                            <div class="section-title justify-content-center wow fadeInUp animated">
                                <h2 class="text-center">Popular Car in UAE</h2>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <nav class="wow fadeInUp" data-wow-delay="100ms">
                                <div class="nav nav-tabs" id="nav-tab" role="tablist">
                                    <button class="nav-link active" id="nav-new-tab" data-bs-toggle="tab" data-bs-target="#nav-new" type="button" role="tab" aria-controls="nav-new" aria-selected="true">New Cars</button>
                                    <button class="nav-link" id="nav-used-tab" data-bs-toggle="tab" data-bs-target="#nav-used" type="button" role="tab" aria-controls="nav-used" aria-selected="false">Used Cars</button>
                                </div>
                            </nav>
                            <div class="tab-content" id="nav-tabContent">
                                <div class="tab-pane fade show active" id="nav-new" role="tabpanel" aria-labelledby="nav-new-tab">
                                    <div class="row popular-car-slider" data-preview="4">
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img4.jpg" alt=""></a>
                                                    </figure>
                                                    <span>EMI Available</span>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img2.jpg" alt=""></a>
                                                    </figure>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box two">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img3.jpg" alt=""></a>
                                                    </figure>
                                                    <span>Great Price</span>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img1.jpg" alt=""></a>
                                                    </figure>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img4.jpg" alt=""></a>
                                                    </figure>
                                                    <span>Low Mileage</span>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <span>$789</span>
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-used" role="tabpanel" aria-labelledby="nav-used-tab">
                                    <div class="row popular-car-slider" data-preview="4">
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img1.jpg" alt=""></a>
                                                    </figure>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img2.jpg" alt=""></a>
                                                    </figure>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img4.jpg" alt=""></a>
                                                    </figure>
                                                    <span>EMI Available</span>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box two">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img3.jpg" alt=""></a>
                                                    </figure>
                                                    <span>Great Price</span>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i>
                                                        </a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <!-- car-block-three -->
                                        <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                            <div class="inner-box">
                                                <div class="image-box">
                                                    <figure class="image">
                                                        <a href="#">
                                                            <img src="Contents/outer/images/car-img4.jpg" alt=""></a>
                                                    </figure>
                                                    <span>Low Mileage</span>
                                                    <a href="#" class="icon-box">
                                                        <i class="ti ti-heart"></i>
                                                    </a>
                                                </div>
                                                <div class="content-box">
                                                    <h6 class="title mb-0"><a href="#">Mercedes-Benz, C Class</a></h6>
                                                    <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                    <ul>
                                                        <li><i class="ti ti-gauge"></i>72,925</li>
                                                        <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                        <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                    </ul>
                                                    <div class="btn-box">
                                                        <span>$789</span>
                                                        <small>$399</small>
                                                        <a href="#" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="section-title wow fadeInUp animated">
                                <a href="#" class="btn-title">View All <i class="ti ti-arrow-up-right"></i></a>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- popular car section end -->

            <!-- premium brand section start -->
            <div class="brand-section">
                <div class="container">
                    <div class="section-title wow fadeInUp animated">
                        <h2>Explore Our Premium Brands</h2>
                        <a href="#" class="btn-title d-none d-md-block">View All Brands <i class="ti ti-arrow-up-right"></i></a>
                    </div>
                    <div class="row">
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated">
                                <div class="image-box">
                                    <img src="Contents/outer/images/audi-logo.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Audi</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="100ms" style="visibility: visible; animation-delay: 100ms; animation-name: fadeInUp;">
                                <div class="image-box">
                                    <img src="Contents/outer/images/mercedes-logo.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Mercedes</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="200ms" style="visibility: visible; animation-delay: 200ms; animation-name: fadeInUp;">
                                <div class="image-box">
                                    <img src="Contents/outer/images/nissan-logo.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Nissan</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="300ms" style="visibility: visible; animation-delay: 300ms; animation-name: fadeInUp;">
                                <div class="image-box">
                                    <img src="Contents/outer/images/toyota-logo.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Toyota</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="400ms" style="visibility: visible; animation-delay: 400ms; animation-name: fadeInUp;">
                                <div class="image-box">
                                    <img src="Contents/outer/images/porsche-logo.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Porsche</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block style-svg col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="500ms" style="visibility: visible; animation-delay: 500ms; animation-name: fadeInUp;">
                                <div class="image-box">
                                    <img src="Contents/outer/images/volkswagen-logo.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Volkswagen</a></h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- premium brand section end -->

            <!-- body type section start -->
            <section class="body-type-section">
                <div class="container">
                    <div class="section-title wow fadeInUp animated">
                        <h2>Explore by Body Type</h2>
                        <a href="#" class="btn-title d-none d-md-block">View All Types <i class="ti ti-arrow-up-right"></i></a>
                    </div>
                    <div class="row">
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated">
                                <div class="image-box">
                                    <img src="Contents/outer/images/suv.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">SUV</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="100ms">
                                <div class="image-box">
                                    <img src="Contents/outer/images/sedan.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Sedan</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="200ms">
                                <div class="image-box">
                                    <img src="Contents/outer/images/hatchback.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Hatchback</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="300ms">
                                <div class="image-box">
                                    <img src="Contents/outer/images/coupe.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Coupe</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="400ms">
                                <div class="image-box">
                                    <img src="Contents/outer/images/hybrid.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Hybrid</a></h6>
                                </div>
                            </div>
                        </div>
                        <!-- cars-block -->
                        <div class="cars-block col-lg-2 col-md-4 col-sm-6 col-6">
                            <div class="inner-box wow fadeInUp animated" data-wow-delay="500ms">
                                <div class="image-box">
                                    <img src="Contents/outer/images/convertible.png" alt="">
                                </div>
                                <div class="content-box">
                                    <h6 class="title"><a href="#">Convertible</a></h6>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- body type section end -->

            <!-- compare section start -->
            <section class="compare-car-section section-bg">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="section-title wow fadeInUp animated">
                                <h2>Compare to Buy the Right Car</h2>
                                <a href="#" class="btn-title d-none d-md-block">View All <i class="ti ti-arrow-up-right"></i></a>
                            </div>
                        </div>
                        <div class="col-lg-12">
                            <div class="row">
                                <div class="col-lg-4 col-md-12 col-12">
                                    <div class="compare-item">
                                        <div class="image-compare relative flex">
                                            <div class="image ">
                                                <img class="lazyload" data-src="Contents/outer/images/compare1.jpg" src="Contents/outer/images/compare1.jpg" alt="images">
                                            </div>
                                            <div class="image">
                                                <img class="lazyload" data-src="Contents/outer/images/compare2.jpg" src="Contents/outer/images/compare2.jpg" alt="images">
                                            </div>
                                            <div class="vs">VS</div>
                                        </div>
                                        <div class="content-compare">
                                            <div class="compare-list-inner">
                                                <div class="compare-list">
                                                    <h6>Kia</h6>
                                                    <h6>Hyundai</h6>
                                                </div>
                                                <div class="compare-list">
                                                    <p>Seltos</p>
                                                    <p>Creta</p>
                                                </div>
                                                <div class="compare-list my-3">
                                                    <p>$73,000 - $120,000</p>
                                                    <p>$73,000 - $120,000</p>
                                                </div>
                                            </div>
                                            <div class="btn-wrap">
                                                <a href="" class="theme-border-btn w-100">
                                                    <span>Hyundai Creta vs Kia Seltos</span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-12">
                                    <div class="compare-item">
                                        <div class="image-compare relative flex">
                                            <div class="image ">
                                                <img class="lazyload" data-src="Contents/outer/images/compare1.jpg" src="Contents/outer/images/compare3.jpg" alt="images">
                                            </div>
                                            <div class="image">
                                                <img class="lazyload" data-src="Contents/outer/images/compare2.jpg" src="Contents/outer/images/compare4.jpg" alt="images">
                                            </div>
                                            <div class="vs">VS</div>
                                        </div>
                                        <div class="content-compare">
                                            <div class="compare-list-inner">
                                                <div class="compare-list">
                                                    <h6>Kia</h6>
                                                    <h6>Hyundai</h6>
                                                </div>
                                                <div class="compare-list">
                                                    <p>Seltos</p>
                                                    <p>Creta</p>
                                                </div>
                                                <div class="compare-list my-3">
                                                    <p>$73,000 - $120,000</p>
                                                    <p>$73,000 - $120,000</p>
                                                </div>
                                            </div>
                                            <div class="btn-wrap">
                                                <a href="" class="theme-border-btn w-100">
                                                    <span>Hyundai Creta vs Kia Seltos</span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-lg-4 col-md-12 col-12">
                                    <div class="compare-item">
                                        <div class="image-compare relative flex">
                                            <div class="image ">
                                                <img class="lazyload" data-src="Contents/outer/images/compare1.jpg" src="Contents/outer/images/compare5.jpg" alt="images">
                                            </div>
                                            <div class="image">
                                                <img class="lazyload" data-src="Contents/outer/images/compare2.jpg" src="Contents/outer/images/compare6.jpg" alt="images">
                                            </div>
                                            <div class="vs">VS</div>
                                        </div>
                                        <div class="content-compare">
                                            <div class="compare-list-inner">
                                                <div class="compare-list">
                                                    <h6>Kia</h6>
                                                    <h6>Hyundai</h6>
                                                </div>
                                                <div class="compare-list">
                                                    <p>Seltos</p>
                                                    <p>Creta</p>
                                                </div>
                                                <div class="compare-list my-3">
                                                    <p>$73,000 - $120,000</p>
                                                    <p>$73,000 - $120,000</p>
                                                </div>
                                            </div>
                                            <div class="btn-wrap">
                                                <a href="" class="theme-border-btn w-100">
                                                    <span>Hyundai Creta vs Kia Seltos</span>
                                                </a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- compare section end -->

            <!-- news section start -->
            <div class="news-section">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <div class="section-title wow fadeInUp animated">
                                <h2>News to Help Choose Your Car</h2>
                            </div>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="blog-article-item">
                                <div class="article-images">
                                    <img class="lazyload" data-src="Contents/outer/images/blog-1.jpg" src="Contents/outer/images/blog-1.jpg" alt="images">
                                    <div class="date">January 28, 2024</div>
                                </div>
                                <div class="content">
                                    <div class="sub-box">
                                        <a href="#" class="admin">Sanjesh Sharma</a>
                                        <a href="#" class="category">First Owner</a>
                                    </div>
                                    <h3><a href="">Get Ready For A Diesel Mild-Hybrid Toyota Fortuner In...</a></h3>
                                    <p>The sub-4 metre SUV segment has been quite active over the last six months or so, with the launch of various facelifted...</p>
                                    <a href="" class="read-more">Read more</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="blog-article-item">
                                <div class="article-images">
                                    <img class="lazyload" data-src="Contents/outer/images/blog-1.jpg" src="Contents/outer/images/blog-2.jpg" alt="images">
                                    <div class="date">January 28, 2024</div>
                                </div>
                                <div class="content">
                                    <div class="sub-box">
                                        <a href="#" class="admin">Sanjesh Sharma</a>
                                        <a href="#" class="category">First Owner</a>
                                    </div>
                                    <h3><a href="">Get Ready For A Diesel Mild-Hybrid Toyota Fortuner In...</a></h3>
                                    <p>The sub-4 metre SUV segment has been quite active over the last six months or so, with the launch of various facelifted...</p>
                                    <a href="" class="read-more">Read more</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="blog-article-item">
                                <div class="article-images">
                                    <img class="lazyload" data-src="Contents/outer/images/blog-1.jpg" src="Contents/outer/images/blog-3.jpg" alt="images">
                                    <div class="date">January 28, 2024</div>
                                </div>
                                <div class="content">
                                    <div class="sub-box">
                                        <a href="#" class="admin">Sanjesh Sharma</a>
                                        <a href="#" class="category">First Owner</a>
                                    </div>
                                    <h3><a href="">Get Ready For A Diesel Mild-Hybrid Toyota Fortuner In...</a></h3>
                                    <p>The sub-4 metre SUV segment has been quite active over the last six months or so, with the launch of various facelifted...</p>
                                    <a href="" class="read-more">Read more</a>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-6 col-md-12 col-12">
                            <div class="blog-article-item">
                                <div class="article-images">
                                    <img class="lazyload" data-src="Contents/outer/images/blog-1.jpg" src="Contents/outer/images/blog-4.jpg" alt="images">
                                    <div class="date">January 28, 2024</div>
                                </div>
                                <div class="content">
                                    <div class="sub-box">
                                        <a href="#" class="admin">Sanjesh Sharma</a>
                                        <a href="#" class="category">First Owner</a>
                                    </div>
                                    <h3><a href="">Get Ready For A Diesel Mild-Hybrid Toyota Fortuner In...</a></h3>
                                    <p>The sub-4 metre SUV segment has been quite active over the last six months or so, with the launch of various facelifted...</p>
                                    <a href="" class="read-more">Read more</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <!-- news section end -->

            <!-- footer section start -->
            <section class="footer">
                <div class="footer-top">
                    <div class="container">
                        <div class="right-box">
                            <div class="top-left wow fadeInUp animated">
                                <h6 class="title">
                                    <img src="Contents/outer/images/logo.png" alt="">
                                </h6>
                                <div class="text">
                                    Excepteur sint occaecat cupidatat non proident, sunt in culpa
                                    <br>
                                    qui officia deserunt mollit anim id es
                                </div>
                                <div class="contact-details">
                                    <div class="contact"><i class="ti ti-phone"></i>+91 12345 67890</div>
                                    <div class="contact"><i class="ti ti-mail"></i>info@sayyarahcars.com</div>
                                </div>
                            </div>
                            <div class="service-area wow fadeInUp animated" data-wow-delay="100ms">
                                <a class="theme-btn btn-style-one"><i class="ti ti-car"></i>Buy Used Car</a>
                                <a class="theme-btn btn-style-one"><i class="ti ti-car"></i>Buy New Car</a>
                                <a class="theme-btn btn-style-one"><i class="ti ti-car"></i>Sell Your Car</a>
                            </div>
                        </div>
                    </div>
                </div>
                <div class="widgets-section">
                    <div class="container">
                        <div class="row">
                            <!-- Footer COlumn -->
                            <div class="footer-column">
                                <div class="row">
                                    <div class="col-lg-3 col-md-6 col-sm-12 col-12">
                                        <div class="footer-widget links-widget wow fadeInUp animated">
                                            <h4 class="widget-title">Useful Links</h4>
                                            <div class="widget-content">
                                                <ul class="user-links">
                                                    <li><a href="">New Cars</a></li>
                                                    <li><a href="">Used Cars</a></li>
                                                    <li><a href="#">About Us</a></li>
                                                    <li><a href="#">Blogs</a></li>
                                                    <li><a href="#">FAQs</a></li>
                                                    <li><a href="#">Terms</a></li>
                                                    <li><a href="#">Contact Us</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 col-12">
                                        <div class="footer-widget links-widget wow fadeInUp animated" data-wow-delay="100ms">
                                            <h4 class="widget-title">Popular Brands</h4>
                                            <div class="widget-content">
                                                <ul class="user-links style-two">
                                                    <li><a href="#">Toyota</a></li>
                                                    <li><a href="#">Nissan</a></li>
                                                    <li><a href="#">Audi</a></li>
                                                    <li><a href="#">Ford</a></li>
                                                    <li><a href="#">BMW</a></li>
                                                    <li><a href="#">Porsche</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 col-12">
                                        <div class="footer-widget links-widget wow fadeInUp animated" data-wow-delay="200ms">
                                            <h4 class="widget-title">Popular Body Type</h4>
                                            <div class="widget-content">
                                                <ul class="user-links style-two">
                                                    <li><a href="#">SUV</a></li>
                                                    <li><a href="#">Sedan</a></li>
                                                    <li><a href="#">Hatchback</a></li>
                                                    <li><a href="#">Hybrid</a></li>
                                                    <li><a href="#">Electric</a></li>
                                                    <li><a href="#">Coupe</a></li>
                                                    <li><a href="#">Convertible</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="footer-column col-lg-3 col-md-6 col-sm-12 col-12">
                                        <div class="footer-widget social-widget wow fadeInUp animated" data-wow-delay="400ms">
                                            <h4 class="widget-title">Our Mobile App</h4>
                                            <div class="widget-content">
                                                <a href="#" class="store">
                                                    <i class="ti ti-brand-apple"></i>
                                                    <span>Download on the</span>
                                                    <h6 class="title">Apple Store</h6>
                                                </a>
                                                <a href="#" class="store two">
                                                    <i class="ti ti-brand-google-play"></i>
                                                    <span>Get in on</span>
                                                    <h6 class="title">Google Play</h6>
                                                </a>
                                                <div class="social-icons">
                                                    <h6 class="title">Connect With Us</h6>
                                                    <ul>
                                                        <li><a href="#"><i class="ti ti-brand-facebook-filled"></i></a></li>
                                                        <li><a href="#"><i class="ti ti-brand-x-filled"></i></a></li>
                                                        <li><a href="#"><i class="ti ti-brand-instagram-filled"></i></a></li>
                                                    </ul>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <!-- footer column -->
                        </div>
                    </div>
                </div>
                <!--  Footer Bottom -->
                <div class="footer-bottom">
                    <div class="container">
                        <div class="row">
                            <div class="col-lg-6 col-md-12 col-12">
                                <div class="copyright-text wow fadeInUp animated">© <a href="#">2025 sayyarah.com. All rights reserved.</a></div>
                            </div>
                            <div class="col-lg-6 col-md-12 col-12">
                                <ul class="footer-nav wow fadeInUp animated" data-wow-delay="200ms">
                                    <li><a href="#">Terms & Conditions</a></li>
                                    <li><a href="#">Privacy Policy</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- footer section start -->
        </div>
        <!-- End Page Wrapper -->

        <!-- login popup -->

        <div class="modal fade popup login-form" id="popup_Adminlogin" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="ti ti-x"></span>
                    </button>
                    <div class="modal-body pd-40">
                        <div class="wrap-modal d-flex">
                            <div class="images flex-none">
                                <img src="Contents/outer/images/login-bg.png" alt="images">
                            </div>
                            <div class="login-content">
                                <h1 class="title-login">Admin Login</h1>
                                <div class="comment-form form-submit myform">
                                    <fieldset class="">
                                        <label>Enter Username</label>
                                        <asp:TextBox ID="txtAusername" placeholder="Email ID" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rfAusername" runat="server" Display="Dynamic"
                                            ErrorMessage="Enter valid Email ID" ControlToValidate="txtAusername" Font-Size="12px" ValidationGroup="a"
                                            ForeColor="red" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">
                                        </asp:RegularExpressionValidator>
                                    </fieldset>
                                    <fieldset class="">
                                        <label>Enter Password</label>
                                        <asp:TextBox ID="txtApassword" placeholder="Password" TextMode="Password" AutoCompleteType="None" runat="server"></asp:TextBox>
                                    </fieldset>
                                    <asp:Button ID="btnAlogin" runat="server" CssClass="continuebtn mt-2" ValidationGroup="a" Text="Login" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <div class="modal fade popup login-form" id="popup_login" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="ti ti-x"></span>
                    </button>
                    <div class="modal-body pd-40">
                        <div class="wrap-modal d-flex">
                            <div class="images flex-none">
                                <img src="Contents/outer/images/login-bg.png" alt="images">
                            </div>
                            <div class="login-content">
                                <h1 class="title-login">Login</h1>
                                <div class="comment-form form-submit myform">
                                    <fieldset class="">
                                        <label>Enter Email ID</label>
                                        <asp:TextBox ID="txtusername" placeholder="Email ID" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="rfusername" runat="server" Display="Dynamic"
                                            ErrorMessage="Enter valid Email ID" ControlToValidate="txtusername" Font-Size="12px" ValidationGroup="a"
                                            ForeColor="red" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">
                                        </asp:RegularExpressionValidator>
                                    </fieldset>
                                    <fieldset class="">
                                        <label>Enter Password</label>
                                        <asp:TextBox ID="txtpassword" placeholder="Password" TextMode="Password" AutoCompleteType="None" runat="server"></asp:TextBox>
                                    </fieldset>
                                    <asp:Button ID="btnlogin" runat="server" CssClass="continuebtn mt-2" ValidationGroup="a" Text="Login" />
                                </div>
                                <div class="text-box">
                                    Don’t you have an account? 
                            <a class="color-popup" data-bs-toggle="modal" data-bs-target="#popup_register">Register</a>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <!-- register popup -->
        <div class="modal fade popup register-form" id="popup_register" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="ti ti-x"></span>
                    </button>
                    <div class="modal-body pd-40">
                        <div class="wrap-modal d-flex">
                            <div class="images flex-none">
                                <img src="Contents/outer/images/login-bg.png" alt="images">
                            </div>
                            <div class="login-content">
                                <h1 class="title-login">Register</h1>
                                <asp:Panel ID="pnlRegisterForm" runat="server" CssClass="comment-form form-submit myform">

                                    <fieldset>
                                        <label class="form-label">Enter Full Name</label>
                                        <asp:TextBox ID="txtfullname" runat="server" CssClass="form-control" Placeholder="Enter Full Name" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtfullname" ForeColor="red" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter your name." />
                                    </fieldset>
                                    <fieldset>
                                        <label class="form-label">Email ID</label>
                                        <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Enter Email ID" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="txtEmail" ForeColor="red" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Enter valid Email ID" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" />
                                    </fieldset>

                                    <fieldset>
                                        <label class="form-label">Contact Number</label>
                                        <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" TextMode="Phone" Placeholder="Enter Contact" />
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ControlToValidate="txtContact" ForeColor="red" Display="Dynamic" CssClass="error-message" ValidationGroup="a" ErrorMessage="Please enter contact number." />
                                    </fieldset>

                                    <asp:Button ID="btnContinue" runat="server" Text="Submit" CssClass="continuebtn2 mt-2" ValidationGroup="a" OnClick="btnContinue_Click" />
                                </asp:Panel>
                            </div>
                            <div class="otp-verification" id="pnlOTPVerification" runat="server">
                                <h1 class="title-login">OTP Verification</h1>
                                <div class="verification myform">
                                    <fieldset class="">
                                        <label>Enter OTP sent to <span>9871966898</span> & <span>sanjesh.bizupon@gmail.com</span></label>
                                        <asp:TextBox type="text" ID="txtOTP" name="text" placeholder="Enter OTP" runat="server"></asp:TextBox>
                                        <p class="resend-otp">Resend OTP</p>
                                    </fieldset>
                                    <button class="continuebtn3 mt-2" name="submit" type="button">Continue</button>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        

        <div class="modal fade popup register-form" id="popup_seller" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="ti ti-x"></span>
                    </button>
                    <div class="modal-body pd-40">
                        <div class="wrap-modal d-flex">
                            <div class="images flex-none">
                                <img src="Contents/outer/images/login-bg.png" alt="images" />
                            </div>
                            <div class="login-content">
                                <h1 class="title-login">Seller</h1>
                                <asp:Panel ID="pnlSellerRegisterForm" runat="server" CssClass="comment-form form-submit myform">
                                    <fieldset>
                                        <label class="form-label">Enter Full Name</label>
                                        <asp:TextBox ID="txtSellerName" runat="server" CssClass="form-control" Placeholder="Enter Full Name" />
                                        <asp:RequiredFieldValidator ID="RFValidator1" runat="server" ControlToValidate="txtSellerName" ForeColor="red" Display="Dynamic" CssClass="error-message" ValidationGroup="s" ErrorMessage="Please enter your name." />
                                    </fieldset>
                                    <fieldset>
                                        <label class="form-label">Email Id</label>
                                        <asp:TextBox ID="txtSellerEmail" runat="server" CssClass="form-control" TextMode="Email" Placeholder="Enter Email ID" />
                                        <asp:RequiredFieldValidator ID="RFValidator2" runat="server" ControlToValidate="txtSellerEmail" ForeColor="red" Display="Dynamic" CssClass="error-message" ValidationGroup="s" ErrorMessage="Enter valid Email ID" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$" />
                                    </fieldset>
                                    <fieldset>
                                        <label class="form-label">Contact Number</label>
                                        <asp:TextBox ID="txtSellerContact" runat="server" CssClass="form-control" TextMode="Phone" Placeholder="Enter Contact" />
                                        <asp:RequiredFieldValidator ID="RFValidator3" runat="server" ControlToValidate="txtSellerContact" ForeColor="red" Display="Dynamic" CssClass="error-message" ValidationGroup="s" ErrorMessage="Please enter contact number." />
                                    </fieldset>
                                    <asp:Button ID="btnSeller" runat="server" Text="Submit" CssClass="continuebtn2 mt-2" ValidationGroup="s" OnClick="btnSeller_Click" />
                                </asp:Panel>
                                <asp:Panel ID="pnlOTPSeller" runat="server" CssClass="comment-form form-submit myform" Visible="false">
                                    <fieldset class="">
                                        <label>Enter OTP sent to</label>
                                        :
                                        <label id="lblEmailId" runat="server"></label>
                                        <asp:TextBox type="text" ID="txtsellereOTP" name="text" placeholder="Enter OTP" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="RFValidator4" runat="server" ControlToValidate="txtsellereOTP" ForeColor="red" Display="Dynamic" CssClass="error-message" ValidationGroup="so" ErrorMessage="Please enter OTP." />
                                        <%--<p class="resend-otp">Resend OTP</p>--%>
                                    </fieldset>
                                    <asp:Button ID="btnVerifySellerOTP" runat="server" Text="Verify" CssClass="continuebtn2 mt-2" ValidationGroup="so" OnClick="btnVerifySellerOTP_Click" />
                                    <asp:HiddenField ID="hdnEmailId" runat="server" />
                                    <asp:HiddenField ID="hdnFullName" runat="server" />
                                </asp:Panel>
                            </div>

                            

                            <%--<div class="otp-verification" id="pnlOTPSeller1" runat="server">
                                <h1 class="title-login">OTP Verification</h1>
                                <div class="verification myform">

                                    
                                </div>
                            </div>--%>
                        </div>
                        <div class="text-box" style="margin-left:35% !important">
                                Do you have an account? 
                            <a class="color-popup" data-bs-toggle="modal" data-bs-target="#popup_SellerLogin">Login</a>
                            </div>
                    </div>
                </div>
            </div>
        </div>

        <%--//Seller Login--%>
        <div class="modal fade popup register-form" id="popup_SellerLogin" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="ti ti-x"></span>
                    </button>
                    <div class="modal-body pd-40">
                        <div class="wrap-modal d-flex">
                            <div class="images flex-none">
                                <img src="Contents/outer/images/login-bg.png" alt="images" />
                            </div>
                            <div class="login-content">
                                <h1 class="title-login">Seller Login</h1>


                                <div class="comment-form form-submit myform">
                                    <fieldset class="">
                                        <label>Enter Email ID</label>
                                        <asp:TextBox ID="txtSellerEmailId" placeholder="Email ID" runat="server"></asp:TextBox>
                                        <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" Display="Dynamic"
                                            ErrorMessage="Enter valid Email ID" ControlToValidate="txtusername" Font-Size="12px" ValidationGroup="a"
                                            ForeColor="red" ValidationExpression="^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$">
                                        </asp:RegularExpressionValidator>
                                    </fieldset>
                                    <fieldset class="">
                                        <label>Enter Password</label>
                                        <asp:TextBox ID="txtSellerPassword" placeholder="Password" TextMode="Password" AutoCompleteType="None" runat="server"></asp:TextBox>
                                    </fieldset>
                                    <asp:Button ID="btnSlogin" runat="server" CssClass="continuebtn mt-2" ValidationGroup="a" Text="Login" />
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
        <%--END Seller Login--%>


        <!-- Scroll To Top -->
        <div class="scroll-to-top scroll-to-target" data-target="html" title="Go To Top">
            <img src="Contents/outer/images/car-up.png" class="car-scroll-img" />
        </div>
    </form>
    <script src="Contents/outer/js/jquery.js"></script>
    <script src="Contents/outer/js/popper.min.js"></script>
    <script src="Contents/outer/js/bootstrap.min.js"></script>
    <script src="Contents/outer/js/appear.js"></script>
    <script src="Contents/outer/js/slick.min.js"></script>
    <script src="Contents/outer/js/slick-animation.min.js"></script>
    <script src="Contents/outer/js/jquery.nice-select.min.js"></script>
    <script src="Contents/outer/js/chosen.jquery.min.js"></script>
    <script src="Contents/outer/js/wow.js"></script>
    <script src="Contents/outer/js/menu.js"></script>
    <script src="Contents/outer/js/main.js"></script>
    <script src="Contents/admin/js/login.js"></script>
    <script type="text/javascript">
        // Rebind Chosen after postbacks (e.g., UpdatePanel)
        function initChosen() {
            $(".chosen-select").chosen({
                width: "100%"
            }, { no_results_text: "Oops, nothing found!" });
        }

        $(document).ready(function () {
            initChosen();
        });

        // Optional: if using UpdatePanels or partial postbacks, reinitialize
        Sys.WebForms.PageRequestManager.getInstance().add_endRequest(function () {
            initChosen();
        });
    </script>
    <script>
        $(document).ready(function () {
            $('a[data-bs-target="#popup_SellerLogin"]').on('click', function (e) {
                $('#popup_seller').modal('hide');
            });
        });
    </script>
</body>
</html>
