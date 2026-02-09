<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="List-Page.aspx.cs" Inherits="SayyarahCars.List_Page" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="description" content="car">
    <meta name="keywords" content="car">
    <meta name="author" content="">
    <title>Sayyarah : </title>
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon">
    <!-- Stylesheets -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/menu.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet" type="text/css">
    <link href="css/owl.css" rel="stylesheet" type="text/css">
    <link href="css/tabler-icons.min.css" rel="stylesheet">
    <link href="css/nice-select.css" rel="stylesheet">
    <link href="css/style.css" rel="stylesheet">
</head>
<body>
    <form id="form1" runat="server">

        <div class="wrapper">

            <!-- Main Header start -->
            <header class="header inner-header">
                <div class="header-inner">
                    <div class="container">
                        <!-- Main box -->
                        <div class="c-box">
                            <div class="logo-inner">
                                <div class="logo"><a href="index.html">
                                    <img src="images/logo.png" alt="" title=""></a></div>
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
                                <!-- <a href="#" class="search phone" data-bs-toggle="modal" data-bs-target="#popup_login"><i class="ti ti-user"></i> Login/Register</a> -->
                                <button type="button" class="user-dropdown dropdown-toggle" data-bs-toggle="dropdown" aria-expanded="false"><i class="ti ti-user"></i>Mercedes-Benz, C Class <i class="ti ti-chevron-down"></i></button>
                                <div class="dropdown-menu">
                                    <a class="dropdown-item" href="#">Admin</a>
                                    <a class="dropdown-item" href="#">Profile</a>
                                    <div class="dropdown-divider"></div>
                                    <a class="dropdown-item" href="#">Logout</a>
                                </div>
                                <div class="btn d-none d-md-block p-0">
                                    <a href="#" class="header-btn-two">Sell My Car</a>
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

            <!-- breadcrumb section start -->
            <div class="breadcrumb-section">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12">
                            <ul class="breadcrumb">
                                <li><a href="#">Home</a></li>
                                <li><span>New and Used Cars in UAE</span></li>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
            <!-- breadcrumb section start -->

            <!-- new used car filter section start -->
            <section class="new-used-car-filter">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-3 col-md-5 col-12">
                            <div class="sidebar-filter">
                                <div class="sidebar-handle">
                                    <svg width="24" height="24" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                                        <path fill-rule="evenodd" clip-rule="evenodd" d="M15.75 4.50903C13.9446 4.50903 12.4263 5.80309 12.0762 7.50903H2.25C1.83579 7.50903 1.5 7.84482 1.5 8.25903C1.5 8.67324 1.83579 9.00903 2.25 9.00903H12.0762C12.4263 10.715 13.9446 12.009 15.75 12.009C17.5554 12.009 19.0737 10.715 19.4238 9.00903H21.75C22.1642 9.00903 22.5 8.67324 22.5 8.25903C22.5 7.84482 22.1642 7.50903 21.75 7.50903H19.4238C19.0737 5.80309 17.5554 4.50903 15.75 4.50903ZM15.75 6.00903C17.0015 6.00903 18 7.00753 18 8.25903C18 9.51054 17.0015 10.509 15.75 10.509C14.4985 10.509 13.5 9.51054 13.5 8.25903C13.5 7.00753 14.4985 6.00903 15.75 6.00903Z" fill="#050B20"></path>
                                        <path fill-rule="evenodd" clip-rule="evenodd" d="M8.25 12.009C6.44461 12.009 4.92634 13.3031 4.57617 15.009H2.25C1.83579 15.009 1.5 15.3448 1.5 15.759C1.5 16.1732 1.83579 16.509 2.25 16.509H4.57617C4.92634 18.215 6.44461 19.509 8.25 19.509C10.0554 19.509 11.5737 18.215 11.9238 16.509H21.75C22.1642 16.509 22.5 16.1732 22.5 15.759C22.5 15.3448 22.1642 15.009 21.75 15.009H11.9238C11.5737 13.3031 10.0554 12.009 8.25 12.009ZM8.25 13.509C9.5015 13.509 10.5 14.5075 10.5 15.759C10.5 17.0105 9.5015 18.009 8.25 18.009C6.9985 18.009 6 17.0105 6 15.759C6 14.5075 6.9985 13.509 8.25 13.509Z" fill="#050B20"></path>
                                    </svg>
                                    Show Filter 
                                </div>
                                <div class="sidebar-widget">
                                    <div class="filters">
                                        <h4>Filters</h4>
                                        <a class="text-right"><i class="ti ti-x"></i>Clear Filters</a>
                                    </div>
                                    <div class="card-filter">
                                        <h6 class="filter-title">Make & Model</h6>
                                        <div class="categories-box">
                                            <div class="accordion" id="accordionPanelsStayOpenExample">
                                                <div class="accordion-item">
                                                    <h2 class="accordion-header" id="panelsStayOpen-headingOne">
                                                        <label class="check">
                                                            <input type="checkbox">
                                                        </label>
                                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseOne" aria-expanded="true" aria-controls="panelsStayOpen-collapseOne">
                                                            <h6>Suzuki</h6>
                                                        </button>
                                                    </h2>
                                                    <div id="panelsStayOpen-collapseOne" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingOne">
                                                        <div class="accordion-body">
                                                            <div class="d-grid gap-2">
                                                                <label class="check">
                                                                    <input type="checkbox">
                                                                    Vitara Breeza
                                                                </label>
                                                                <label class="check">
                                                                    <input type="checkbox">
                                                                    Vitara Breeza
                                                                </label>
                                                                <label class="check">
                                                                    <input type="checkbox">
                                                                    Vitara Breeza
                                                                </label>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="accordion-item">
                                                    <h2 class="accordion-header" id="panelsStayOpen-headingTwo">
                                                        <label class="check">
                                                            <input type="checkbox">
                                                        </label>
                                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseTwo" aria-expanded="false" aria-controls="panelsStayOpen-collapseTwo">
                                                            <h6>Tata</h6>
                                                        </button>
                                                    </h2>
                                                    <div id="panelsStayOpen-collapseTwo" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingTwo">
                                                        <div class="accordion-body">
                                                            <strong>This is the second item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="accordion-item">
                                                    <h2 class="accordion-header" id="panelsStayOpen-headingThree">
                                                        <label class="check">
                                                            <input type="checkbox">
                                                        </label>
                                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseThree" aria-expanded="false" aria-controls="panelsStayOpen-collapseThree">
                                                            <h6>Nissan</h6>
                                                        </button>
                                                    </h2>
                                                    <div id="panelsStayOpen-collapseThree" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingThree">
                                                        <div class="accordion-body">
                                                            <strong>This is the third item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="accordion-item">
                                                    <h2 class="accordion-header" id="panelsStayOpen-headingFour">
                                                        <label class="check">
                                                            <input type="checkbox">
                                                        </label>
                                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseFour" aria-expanded="false" aria-controls="panelsStayOpen-collapseFour">
                                                            <h6>Toyota</h6>
                                                        </button>
                                                    </h2>
                                                    <div id="panelsStayOpen-collapseFour" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingFour">
                                                        <div class="accordion-body">
                                                            <strong>This is the third item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="accordion-item">
                                                    <h2 class="accordion-header" id="panelsStayOpen-headingFive">
                                                        <label class="check">
                                                            <input type="checkbox">
                                                        </label>
                                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseFive" aria-expanded="false" aria-controls="panelsStayOpen-collapseFive">
                                                            <h6>Audi</h6>
                                                        </button>
                                                    </h2>
                                                    <div id="panelsStayOpen-collapseFive" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingFive">
                                                        <div class="accordion-body">
                                                            <strong>This is the third item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="accordion-item">
                                                    <h2 class="accordion-header" id="panelsStayOpen-headingSix">
                                                        <label class="check">
                                                            <input type="checkbox">
                                                        </label>
                                                        <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#panelsStayOpen-collapseSix" aria-expanded="false" aria-controls="panelsStayOpen-collapseSix">
                                                            <h6>BMW</h6>
                                                        </button>
                                                    </h2>
                                                    <div id="panelsStayOpen-collapseSix" class="accordion-collapse collapse" aria-labelledby="panelsStayOpen-headingSix">
                                                        <div class="accordion-body">
                                                            <strong>This is the third item's accordion body.</strong> It is hidden by default, until the collapse plugin adds the appropriate classes that we use to style each element. These classes control the overall appearance, as well as the showing and hiding via CSS transitions. You can modify any of this with custom CSS or overriding our default variables. It's also worth noting that just about any HTML can go within the <code>.accordion-body</code>, though the transition does limit overflow.
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-filter">
                                        <h6 class="filter-title">Body Type</h6>
                                        <div class="categories-box">
                                            <div class="cheak-box">
                                                <label class="contain">
                                                    SUV  (1,456)
                                            <input type="checkbox" checked="checked">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Sedan  (1,456)
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Hatchback  (1,456)
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Coupe  (1,456)
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Convertible  (1,456)
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-filter">
                                        <h6 class="filter-title">Price</h6>
                                        <div class="price-box">
                                            <form class="row g-0">
                                                <div class="form-column col-lg-6">
                                                    <div class="form_boxes">
                                                        <div class="drop-menu">
                                                            <span id="slider-range-value1">$5000</span>
                                                        </div>
                                                    </div>
                                                </div>
                                                <div class="form-column v2 col-lg-6">
                                                    <div class="form_boxes">
                                                        <div class="drop-menu">
                                                            <span id="slider-range-value2">$45000</span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </form>
                                            <div class="widget-price">
                                                <div id="slider-val" class="noUi-target noUi-ltr noUi-horizontal noUi-background"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-filter">
                                        <h6 class="filter-title">Fuel Type</h6>
                                        <div class="categories-box">
                                            <div class="check-box">
                                                <label class="contain">
                                                    Petrol
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Diesel
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Hybrid
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Electric
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-filter">
                                        <h6 class="filter-title">Transmission</h6>
                                        <div class="categories-box">
                                            <div class="check-box">
                                                <label class="contain">
                                                    Automatic
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Manual
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="card-filter">
                                        <h6 class="filter-title">Steering Side</h6>
                                        <div class="categories-box">
                                            <div class="check-box">
                                                <label class="contain">
                                                    Left Hand
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                                <label class="contain">
                                                    Right Hand
                                            <input type="checkbox">
                                                    <span class="checkmark"></span>
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-9 col-md-7 col-12">
                            <div class="text-box">
                                <div class="text">Showing 1 to 18 of 155 vehicles</div>
                                <form>
                                    <div class="category-filter">
                                        <div class="listing-grid">
                                            <a href="#" class="btn-view grid active">
                                                <svg width="25" height="25" viewBox="0 0 25 25" fill="none"
                                                    xmlns="http://www.w3.org/2000/svg">
                                                    <path
                                                        d="M5.04883 6.40508C5.04883 5.6222 5.67272 5 6.41981 5C7.16686 5 7.7908 5.62221 7.7908 6.40508C7.7908 7.18801 7.16722 7.8101 6.41981 7.8101C5.67241 7.8101 5.04883 7.18801 5.04883 6.40508Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M11.1045 6.40508C11.1045 5.62221 11.7284 5 12.4755 5C13.2229 5 13.8466 5.6222 13.8466 6.40508C13.8466 7.18789 13.2227 7.8101 12.4755 7.8101C11.7284 7.8101 11.1045 7.18794 11.1045 6.40508Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M19.9998 6.40514C19.9998 7.18797 19.3757 7.81016 18.6288 7.81016C17.8818 7.81016 17.2578 7.18794 17.2578 6.40508C17.2578 5.62211 17.8813 5 18.6288 5C19.3763 5 19.9998 5.62215 19.9998 6.40514Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M7.74249 12.5097C7.74249 13.2926 7.11849 13.9147 6.37133 13.9147C5.62411 13.9147 5 13.2926 5 12.5097C5 11.7267 5.62419 11.1044 6.37133 11.1044C7.11842 11.1044 7.74249 11.7266 7.74249 12.5097Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M13.7976 12.5097C13.7976 13.2927 13.1736 13.9147 12.4266 13.9147C11.6795 13.9147 11.0557 13.2927 11.0557 12.5097C11.0557 11.7265 11.6793 11.1044 12.4266 11.1044C13.1741 11.1044 13.7976 11.7265 13.7976 12.5097Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M19.9516 12.5097C19.9516 13.2927 19.328 13.9147 18.5807 13.9147C17.8329 13.9147 17.209 13.2925 17.209 12.5097C17.209 11.7268 17.8332 11.1044 18.5807 11.1044C19.3279 11.1044 19.9516 11.7265 19.9516 12.5097Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M5.04297 18.5947C5.04297 17.8118 5.66709 17.1896 6.4143 17.1896C7.16137 17.1896 7.78523 17.8116 7.78523 18.5947C7.78523 19.3778 7.16139 19.9997 6.4143 19.9997C5.66714 19.9997 5.04297 19.3773 5.04297 18.5947Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M11.0986 18.5947C11.0986 17.8118 11.7227 17.1896 12.47 17.1896C13.2169 17.1896 13.8409 17.8117 13.8409 18.5947C13.8409 19.3778 13.2169 19.9997 12.47 19.9997C11.7225 19.9997 11.0986 19.3774 11.0986 18.5947Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M17.252 18.5947C17.252 17.8117 17.876 17.1896 18.6229 17.1896C19.3699 17.1896 19.9939 17.8117 19.9939 18.5947C19.9939 19.3778 19.3702 19.9997 18.6229 19.9997C17.876 19.9997 17.252 19.3774 17.252 18.5947Z"
                                                        stroke="CurrentColor">
                                                    </path>
                                                </svg>
                                            </a>
                                            <a href="#" class="btn-view list">
                                                <svg width="25" height="25" viewBox="0 0 25 25" fill="none"
                                                    xmlns="http://www.w3.org/2000/svg">
                                                    <path
                                                        d="M19.7016 18.3317H9.00246C8.5615 18.3317 8.2041 17.9743 8.2041 17.5333C8.2041 17.0923 8.5615 16.7349 9.00246 16.7349H19.7013C20.1423 16.7349 20.4997 17.0923 20.4997 17.5333C20.4997 17.9743 20.1426 18.3317 19.7016 18.3317Z"
                                                        fill="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M19.7016 13.3203H9.00246C8.5615 13.3203 8.2041 12.9629 8.2041 12.5219C8.2041 12.081 8.5615 11.7236 9.00246 11.7236H19.7013C20.1423 11.7236 20.4997 12.081 20.4997 12.5219C20.5 12.9629 20.1426 13.3203 19.7016 13.3203Z"
                                                        fill="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M19.7016 8.30919H9.00246C8.5615 8.30919 8.2041 7.95179 8.2041 7.51083C8.2041 7.06986 8.5615 6.71246 9.00246 6.71246H19.7013C20.1423 6.71246 20.4997 7.06986 20.4997 7.51083C20.4997 7.95179 20.1426 8.30919 19.7016 8.30919Z"
                                                        fill="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M5.5722 8.64465C6.16436 8.64465 6.6444 8.16461 6.6444 7.57245C6.6444 6.98029 6.16436 6.50024 5.5722 6.50024C4.98004 6.50024 4.5 6.98029 4.5 7.57245C4.5 8.16461 4.98004 8.64465 5.5722 8.64465Z"
                                                        fill="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M5.5722 13.5942C6.16436 13.5942 6.6444 13.1141 6.6444 12.522C6.6444 11.9298 6.16436 11.4498 5.5722 11.4498C4.98004 11.4498 4.5 11.9298 4.5 12.522C4.5 13.1141 4.98004 13.5942 5.5722 13.5942Z"
                                                        fill="CurrentColor">
                                                    </path>
                                                    <path
                                                        d="M5.5722 18.5438C6.16436 18.5438 6.6444 18.0637 6.6444 17.4716C6.6444 16.8794 6.16436 16.3994 5.5722 16.3994C4.98004 16.3994 4.5 16.8794 4.5 17.4716C4.5 18.0637 4.98004 18.5438 5.5722 18.5438Z"
                                                        fill="CurrentColor">
                                                    </path>
                                                </svg>
                                            </a>
                                        </div>
                                        <div class="group-select">
                                            <div class="nice-select" tabindex="0">
                                                <span class="current">Default Order</span>
                                                <ul class="list style">
                                                    <li data-value="" class="option selected">Default Order
                                                    </li>
                                                    <li data-value="by-latest" class="option">All </li>
                                                    <li data-value="low-to-high" class="option">Low to high
                                                    </li>
                                                    <li data-value="high-to-low" class="option">High to low
                                                    </li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                </form>
                            </div>
                            <div class="listing-car-wrap">
                                <div class="list-car-grid">
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img1.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img2.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img3.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img1.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img3.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img1.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img2.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img3.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img3.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img3.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img3.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="car-block">
                                        <div class="inner-box">
                                            <div class="image-box">
                                                <figure class="image"><a href="single-page-details.html">
                                                    <img src="images/car-img3.jpg" alt=""></a></figure>
                                                <span class="bg-success">Great Price</span>
                                                <a href="#" class="icon-box" tabindex="0">
                                                    <i class="ti ti-heart"></i>
                                                </a>
                                            </div>
                                            <div class="content-box">
                                                <h6 class="title"><a href="single-page-details.html">Mercedes-Benz, C Class</a></h6>
                                                <div class="text">2023 C300e AMG Line Night Ed Premiu...</div>
                                                <ul>
                                                    <li><i class="ti ti-gauge"></i>72,925 km</li>
                                                    <li><i class="ti ti-gas-station"></i>Petrol</li>
                                                    <li><i class="ti ti-manual-gearbox"></i>Automatic</li>
                                                </ul>
                                                <div class="btn-box">
                                                    <small>$39,900</small>
                                                    <a href="single-page-details.html" class="details">View Details <i class="ti ti-arrow-up-right"></i></a>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- new used car filter section end -->

            <!-- footer section start -->
            <section class="footer">
                <div class="footer-top">
                    <div class="container">
                        <div class="right-box">
                            <div class="top-left wow fadeInUp animated">
                                <h6 class="title">
                                    <img src="images/logo.png" alt="">
                                </h6>
                                <div class="text">Excepteur sint occaecat cupidatat non proident, sunt in culpa
                                    <br>
                                    qui officia deserunt mollit anim id es</div>
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
        <div class="modal fade popup login-form" id="popup_login" tabindex="-1" aria-hidden="true">
            <div class="modal-dialog modal-dialog-centered" role="document">
                <div class="modal-content">
                    <button type="button" class="close" data-bs-dismiss="modal" aria-label="Close">
                        <span aria-hidden="true" class="ti ti-x"></span>
                    </button>
                    <div class="modal-body pd-40">
                        <div class="wrap-modal d-flex">
                            <div class="images flex-none">
                                <img src="images/login-img.jpg" alt="images">
                            </div>
                            <div class="login-content">
                                <h1 class="title-login">Login</h1>
                                <form method="post" class="comment-form form-submit" action="#" accept-charset="utf-8">
                                    <fieldset class="">
                                        <label>Enter Email ID</label>
                                        <input type="text" id="text" name="text" placeholder="info@doamin.com">
                                    </fieldset>
                                    <fieldset class="">
                                        <label>Enter Password</label>
                                        <input type="password" id="text" name="text" placeholder="123456">
                                    </fieldset>
                                    <button class="continuebtn mt-2" name="submit" type="button">Login</button>
                                </form>
                                <div class="text-box">
                                    Don’t you have an account? 
                            <a class="color-popup" data-bs-toggle="modal" data-bs-target="#popup_register">Register</a>
                                </div>
                                <!-- <p class="text-line">or login with</p>
                        <div class="button-box">
                            <a href="#">
                                <svg width="20" height="21" viewBox="0 0 20 21" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M4.43242 12.5863L3.73625 15.1852L1.19176 15.239C0.431328 13.8286 0 12.2149 0 10.5C0 8.84179 0.403281 7.27804 1.11812 5.90112H1.11867L3.38398 6.31644L4.37633 8.56815C4.16863 9.17366 4.05543 9.82366 4.05543 10.5C4.05551 11.2341 4.18848 11.9374 4.43242 12.5863Z" fill="#FBBB00" />
                                    <path d="M19.8242 8.6319C19.939 9.23682 19.9989 9.86155 19.9989 10.5C19.9989 11.216 19.9236 11.9143 19.7802 12.588C19.2934 14.8803 18.0214 16.8819 16.2594 18.2984L16.2588 18.2978L13.4055 18.1522L13.0017 15.6314C14.1709 14.9456 15.0847 13.8726 15.566 12.588H10.2188V8.6319H19.8242Z" fill="#518EF8" />
                                    <path d="M16.2595 18.2978L16.2601 18.2984C14.5464 19.6758 12.3694 20.5 9.99965 20.5C6.19141 20.5 2.88043 18.3715 1.19141 15.239L4.43207 12.5863C5.27656 14.8401 7.45074 16.4445 9.99965 16.4445C11.0952 16.4445 12.1216 16.1484 13.0024 15.6313L16.2595 18.2978Z" fill="#28B446" />
                                    <path d="M16.382 2.80219L13.1425 5.45437C12.2309 4.88461 11.1534 4.55547 9.99906 4.55547C7.39246 4.55547 5.17762 6.23348 4.37543 8.56812L1.11773 5.90109H1.11719C2.78148 2.6923 6.13422 0.5 9.99906 0.5C12.4254 0.5 14.6502 1.3643 16.382 2.80219Z" fill="#F14336" />
                                </svg>
                                <span>Google</span>
                            </a>
                            <a href="#">
                                <svg width="21" height="21" viewBox="0 0 21 21" fill="none" xmlns="http://www.w3.org/2000/svg">
                                    <path d="M20.5 10.5C20.5 15.4914 16.843 19.6285 12.0625 20.3785V13.3906H14.3926L14.8359 10.5H12.0625V8.62422C12.0625 7.8332 12.45 7.0625 13.6922 7.0625H14.9531V4.60156C14.9531 4.60156 13.8086 4.40625 12.7145 4.40625C10.4305 4.40625 8.9375 5.79063 8.9375 8.29688V10.5H6.39844V13.3906H8.9375V20.3785C4.15703 19.6285 0.5 15.4914 0.5 10.5C0.5 4.97734 4.97734 0.5 10.5 0.5C16.0227 0.5 20.5 4.97734 20.5 10.5Z" fill="#1877F2" />
                                    <path d="M14.3926 13.3906L14.8359 10.5H12.0625V8.62418C12.0625 7.83336 12.4499 7.0625 13.6921 7.0625H14.9531V4.60156C14.9531 4.60156 13.8088 4.40625 12.7146 4.40625C10.4304 4.40625 8.9375 5.79063 8.9375 8.29688V10.5H6.39844V13.3906H8.9375V20.3785C9.44664 20.4584 9.96844 20.5 10.5 20.5C11.0316 20.5 11.5534 20.4584 12.0625 20.3785V13.3906H14.3926Z" fill="white" />
                                </svg>
                                <span>Facebook</span>
                            </a>
                        </div> -->
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
                                <img src="images/login-img.jpg" alt="images">
                            </div>
                            <div class="login-content">
                                <h1 class="title-login">Register</h1>
                                <form method="post" class="comment-form form-submit" action="#" accept-charset="utf-8">
                                    <fieldset class="">
                                        <label>Enter Your Full Name</label>
                                        <input type="text" id="text" name="text" placeholder="example: sanjesh sharma">
                                    </fieldset>
                                    <fieldset class="">
                                        <label>Enter Your Email</label>
                                        <input type="text" id="text" name="text" placeholder="info@youname.com">
                                    </fieldset>
                                    <!-- <fieldset class="">
                                <label>Register As</label>
                                <select class="form-select" id="userType" name="userType" required>
                                    <option value="" disabled selected>Select User Type</option>
                                    <option value="individual">Individual</option>
                                    <option value="buyer">Buyer</option>
                                    <option value="seller">Seller</option>
                                    <option value="dealer">Dealer</option>
                                </select>
                            </fieldset> -->
                                    <fieldset class="">
                                        <label>Enter Mobile Number</label>
                                        <input type="text" id="text" name="text" placeholder="+91 12345 67890">
                                    </fieldset>
                                    <button class="continuebtn2 mt-2" name="submit" type="button">Continue</button>
                                </form>
                            </div>
                            <div class="otp-verification">
                                <h1 class="title-login">OTP Verification</h1>
                                <form method="post" class="verification" action="#">
                                    <fieldset class="">
                                        <label>Enter OTP sent to <span>9871966898</span> & <span>sanjesh.bizupon@gmail.com</span></label>
                                        <input type="text" id="text" name="text" placeholder="Enter OTP">
                                        <p class="resend-otp">Resend OTP</p>
                                    </fieldset>
                                    <button class="submit-button" name="submit" type="submit">Submit</button>
                                </form>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        <!-- Scroll To Top -->
        <div class="scroll-to-top scroll-to-target" data-target="html" title="Go To Top">
            <img src="images/car-up.png" class="car-scroll-img"></div>


    </form>
    <script src="js/jquery.js"></script>
    <script src="js/popper.min.js"></script>
    <script src="js/bootstrap.min.js"></script>
    <script src="js/jquery.nice-select.min.js"></script>
    <script src="js/price-ranger.js"></script>
    <script src="js/wow.js"></script>
    <script src="js/menu.js"></script>
    <script src="js/main.js"></script>

    <script>
        $(document).ready(function () {
            $(".continuebtn2").click(function () {
                $(".login-form").addClass("hide");
                $(".login-content").addClass("hide");
                $(".otp-verification").addClass("show");
            });
        });
    </script>
</body>
</html>
