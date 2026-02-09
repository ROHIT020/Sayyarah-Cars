<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Single-Page-Details.aspx.cs" Inherits="SayyarahCars.Single_Page_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0">
    <meta name="description" content="car">
    <meta name="keywords" content="car">
    <meta name="author" content="Bizupon">
    <title>Sayyarah : </title>
    <link rel="shortcut icon" href="images/favicon.png" type="image/x-icon">
    <!-- Stylesheets -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <link href="css/slick-theme.css" rel="stylesheet" type="text/css">
    <link href="css/slick.css" rel="stylesheet" type="text/css">
    <link href="css/menu.css" rel="stylesheet">
    <link href="css/animate.css" rel="stylesheet" type="text/css">
    <link href="css/owl.css" rel="stylesheet" type="text/css">
    <link href="css/nice-select.css" rel="stylesheet" type="text/css">
    <link href="css/jquery.fancybox.min.css" rel="stylesheet" type="text/css">
    <link href="css/tabler-icons.min.css" rel="stylesheet">
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
                                <button type="button" class="user-dropdown phone" data-bs-toggle="modal" data-bs-target="#popup_login"><i class="ti ti-user"></i>Login/Register</button>
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
                                <li><a href="index.html">Home</a></li>
                                <li><a href="list-page.html">New and Used Cars in UAE</a></li>
                                <li><span>Single Page Details</span></li>
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
                        <div class="col-lg-8 col-md-7 col-12">
                            <div class="gallery-block">
                                <div class="inner-column gallery-slider">
                                    <div class="image-box">
                                        <figure class="image"><a href="images/banner1.jpg" data-fancybox="gallery">
                                            <img src="images/banner1.jpg" alt=""></a></figure>
                                    </div>
                                    <div class="image-box">
                                        <figure class="image"><a href="images/banner2.jpg" data-fancybox="gallery">
                                            <img src="images/banner2.jpg" alt=""></a></figure>
                                    </div>
                                    <div class="image-box">
                                        <figure class="image"><a href="images/banner3.jpg" data-fancybox="gallery">
                                            <img src="images/banner3.jpg" alt=""></a></figure>
                                    </div>
                                    <div class="image-box">
                                        <figure class="image"><a href="images/banner4.jpg" data-fancybox="gallery">
                                            <img src="images/banner4.jpg" alt=""></a></figure>
                                    </div>
                                </div>
                                <div class="content-box">
                                    <ul class="video-list">
                                        <li><a href="images/banner1.jpg" data-fancybox="gallery"><i class="ti ti-view-360-number"></i>360 View</a></li>
                                        <li><a href="images/banner1.jpg" data-fancybox="gallery"><i class="ti ti-library-photo"></i>All Photos</a></li>
                                    </ul>
                                </div>
                            </div>
                            <div class="overview-section">
                                <h4 class="title">Car Overview</h4>
                                <div class="row">
                                    <div class="content-column col-lg-6 col-md-12 col-sm-12">
                                        <div class="inner-column">
                                            <ul class="list">
                                                <li><span>
                                                    <img src="images/insep1-1.svg">Make</span> Tata</li>
                                                <li><span>
                                                    <img src="images/insep1-1.svg">Model</span> Nexon XM+ S</li>
                                                <li><span>
                                                    <img src="images/insep1-3.svg">Fuel Type</span> Petrol</li>
                                                <li><span>
                                                    <img src="images/insep1-2.svg">Km driven</span> 11,500</li>
                                                <li><span>
                                                    <img src="images/insep1-5.svg">Transmission</span> Manual (Regular)</li>
                                                <li><span>
                                                    <img src="images/insep1-4.svg">Model Year</span> Aug 2022</li>
                                            </ul>
                                        </div>
                                    </div>
                                    <div class="content-column col-lg-6 col-md-12 col-sm-12">
                                        <div class="inner-column">
                                            <ul class="list">
                                                <li><span>
                                                    <img src="images/insep1-7.svg">Wheel Size</span> 16</li>
                                                <li><span>
                                                    <img src="images/insep1-8.svg">Engine Capacity</span> 1.5 L</li>
                                                <li><span>
                                                    <img src="images/insep1-11.svg">Color</span> White</li>
                                                <li><span>
                                                    <img src="images/insep1-6.svg">Steering Side</span> Right Hand</li>
                                                <li><span>
                                                    <img src="images/insep1-10.svg">Cylinders </span>4 Cylinders</li>
                                                <li><span>
                                                    <img src="images/insep1-1.svg">Car Location</span>Faridabad, Haryana</li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="features-section">
                                <h4 class="title">Features</h4>
                                <div class="row">
                                    <!-- list-column -->
                                    <div class="list-column col-lg-4 col-md-6 col-sm-12">
                                        <div class="inner-column">
                                            <h5>Interior</h5>
                                            <ul class="feature-list">
                                                <li><i class="ti ti-check"></i>Air Conditioner</li>
                                                <li><i class="ti ti-check"></i>Digital Odometer</li>
                                                <li><i class="ti ti-check"></i>Leather Seats</li>
                                                <li><i class="ti ti-check"></i>Heater</li>
                                                <li><i class="ti ti-check"></i>Tachometer</li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- list-column -->
                                    <div class="list-column col-lg-4 col-md-6 col-sm-12">
                                        <div class="inner-column">
                                            <h5>Exterior</h5>
                                            <ul class="feature-list">
                                                <li><i class="ti ti-check"></i>Fog Lights Front</li>
                                                <li><i class="ti ti-check"></i>Rain Sensing Wipe</li>
                                                <li><i class="ti ti-check"></i>Rear Spoiler</li>
                                                <li><i class="ti ti-check"></i>Sun Roof</li>
                                            </ul>
                                        </div>
                                    </div>
                                    <!-- list-column -->
                                    <div class="list-column col-lg-4 col-md-6 col-sm-12">
                                        <div class="inner-column">
                                            <h5>Safety</h5>
                                            <ul class="feature-list">
                                                <li><i class="ti ti-check"></i>Brake Assist</li>
                                                <li><i class="ti ti-check"></i>Child Safety Locks</li>
                                                <li><i class="ti ti-check"></i>Traction Control</li>
                                                <li><i class="ti ti-check"></i>Power Door Locks</li>
                                                <li><i class="ti ti-check"></i>Driver Air Bag</li>
                                            </ul>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="overview-section">
                                <h4 class="title">Scratches and Defects</h4>
                                <div class="scrach-block">
                                    <div class="scrach-item">
                                        <div class="scrach-title">
                                            <h6>Tires & Rims</h6>
                                            <p>Scratched/Dented</p>
                                        </div>
                                        <div class="scrach-thumb">
                                            <a class="lightbox" href="#thumb1">
                                                <img src="images/scrach-img1.jpg" alt="">
                                            </a>
                                            <div class="lightbox-target" id="thumb1">
                                                <img src="images/scrach-img1.jpg" alt="" />
                                                <a class="lightbox-close" href="#"></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="scrach-item">
                                        <div class="scrach-title">
                                            <h6>Sides</h6>
                                            <p>Scratched/Dented</p>
                                        </div>
                                        <div class="scrach-thumb">
                                            <a class="lightbox" href="#thumb2">
                                                <img src="images/scrach-img2.jpg" alt="">
                                            </a>
                                            <div class="lightbox-target" id="thumb2">
                                                <img src="images/scrach-img2.jpg" alt="" />
                                                <a class="lightbox-close" href="#"></a>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="scrach-item">
                                        <div class="scrach-title">
                                            <h6>Front & Rear</h6>
                                            <p>Scratched/Dented</p>
                                        </div>
                                        <div class="scrach-thumb">
                                            <a class="lightbox" href="#thumb3">
                                                <img src="images/scrach-img3.jpg" alt="">
                                            </a>
                                            <div class="lightbox-target" id="thumb3">
                                                <img src="images/scrach-img3.jpg" alt="" />
                                                <a class="lightbox-close" href="#"></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div class="col-lg-4 col-md-5 col-12">
                            <div class="side-page-details">
                                <div class="detail-page-title">
                                    <h5>Mercedes-Benz Maybach S-Class</h5>
                                    <p class="text">2.0 D5 PowerPulse Momentum 5dr AWD Geartronic Estate</p>

                                    <ul class="feature-list">
                                        <li><span><i class="ti ti-calendar"></i>2023</span></li>
                                        <li><span><i class="ti ti-gauge"></i>35,000 KM</span></li>
                                        <li><span class="text-success"><i class="ti ti-user-check"></i>First Owner</span></li>
                                    </ul>
                                    <div class="page-title-price">
                                        <h4>AED 75,000</h4>
                                    </div>
                                    <div class="d-grid gap-3">
                                        <a href="javascript:void(0);" class="theme-btn"><i class="ti ti-tag"></i>Make An Offer Price</a>
                                        <a href="javascript:void(0);" class="theme-btn"><i class="ti ti-steering-wheel"></i>Schedule Test Drive</a>
                                    </div>
                                    <div class="content-box">
                                        <div class="btn-box">
                                            <div class="share-btn">
                                                <a href="javascript:void(0);" class="share">Share <i class="ti ti-share"></i></a>
                                            </div>
                                            <div class="share-btn">
                                                <a href="javascript:void(0);" class="share">Save<i class="ti ti-heart"></i></a>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="dealer-block">
                                    <div class="icon-box">
                                        <img src="images/dealer.webp" alt="" class="img-fluid">
                                        <div class="box-title">
                                            <h6 class="title">Volvo Cars Marin</h6>
                                            <div class="verified"><i class="ti ti-shield-check"></i>Verified Dealer</div>
                                        </div>
                                    </div>
                                    <div class="address-box">
                                        <h6><i class="ti ti-map"></i>2972 Westheimer Rd. Santa Ana, Illinois 85486</h6>
                                        <div class="map">
                                            <iframe src="https://www.google.com/maps/embed?pb=!1m21!1m12!1m3!1d14442.624371840478!2d55.26086853887278!3d25.181087640482758!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!4m6!3e6!4m0!4m3!3m2!1d25.183595999999998!2d55.272845999999994!5e0!3m2!1sen!2sin!4v1750238548075!5m2!1sen!2sin" width="100%" height="250" style="border: 0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
                                        </div>
                                    </div>
                                    <div class="btn-box">
                                        <a href="javascript:void(0);" class="side-btn call"><i class="ti ti-phone"></i>Call</a>
                                        <a href="javascript:void(0);" class="side-btn whatsapp"><i class="ti ti-brand-whatsapp"></i>Whatsapp</a>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </section>
            <!-- new used car filter section end -->

            <div class="related-listings">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-12 col-12">
                            <div class="section-title wow fadeInUp animated">
                                <h4 class="m-0">Related Listings</h4>
                            </div>
                        </div>
                        <div class="col-lg-12 col-md-12 col-12">
                            <div class="row popular-car-slider" data-preview="4">
                                <!-- car-block-three -->
                                <div class="car-block col-lg-3 col-md-6 col-sm-12">
                                    <div class="inner-box">
                                        <div class="image-box">
                                            <figure class="image"><a href="#">
                                                <img src="images/car-img4.jpg" alt=""></a></figure>
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
                                            <figure class="image"><a href="#">
                                                <img src="images/car-img2.jpg" alt=""></a></figure>
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
                                            <figure class="image"><a href="#">
                                                <img src="images/car-img3.jpg" alt=""></a></figure>
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
                                            <figure class="image"><a href="#">
                                                <img src="images/car-img1.jpg" alt=""></a></figure>
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
                                            <figure class="image"><a href="#">
                                                <img src="images/car-img4.jpg" alt=""></a></figure>
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
                </div>
            </div>

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
                                                    <li><a href="javascript:void(0);">About Us</a></li>
                                                    <li><a href="javascript:void(0);">Blogs</a></li>
                                                    <li><a href="javascript:void(0);">FAQs</a></li>
                                                    <li><a href="javascript:void(0);">Terms</a></li>
                                                    <li><a href="javascript:void(0);">Contact Us</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 col-12">
                                        <div class="footer-widget links-widget wow fadeInUp animated" data-wow-delay="100ms">
                                            <h4 class="widget-title">Popular Brands</h4>
                                            <div class="widget-content">
                                                <ul class="user-links style-two">
                                                    <li><a href="javascript:void(0);">Toyota</a></li>
                                                    <li><a href="javascript:void(0);">Nissan</a></li>
                                                    <li><a href="javascript:void(0);">Audi</a></li>
                                                    <li><a href="javascript:void(0);">Ford</a></li>
                                                    <li><a href="javascript:void(0);">BMW</a></li>
                                                    <li><a href="javascript:void(0);">Porsche</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-lg-3 col-md-6 col-sm-12 col-12">
                                        <div class="footer-widget links-widget wow fadeInUp animated" data-wow-delay="200ms">
                                            <h4 class="widget-title">Popular Body Type</h4>
                                            <div class="widget-content">
                                                <ul class="user-links style-two">
                                                    <li><a href="javascript:void(0);">SUV</a></li>
                                                    <li><a href="javascript:void(0);">Sedan</a></li>
                                                    <li><a href="javascript:void(0);">Hatchback</a></li>
                                                    <li><a href="javascript:void(0);">Hybrid</a></li>
                                                    <li><a href="javascript:void(0);">Electric</a></li>
                                                    <li><a href="javascript:void(0);">Coupe</a></li>
                                                    <li><a href="javascript:void(0);">Convertible</a></li>
                                                </ul>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="footer-column col-lg-3 col-md-6 col-sm-12 col-12">
                                        <div class="footer-widget social-widget wow fadeInUp animated" data-wow-delay="400ms">
                                            <h4 class="widget-title">Our Mobile App</h4>
                                            <div class="widget-content">
                                                <a href="javascript:void(0);" class="store">
                                                    <i class="ti ti-brand-apple"></i>
                                                    <span>Download on the</span>
                                                    <h6 class="title">Apple Store</h6>
                                                </a>
                                                <a href="javascript:void(0);" class="store two">
                                                    <i class="ti ti-brand-google-play"></i>
                                                    <span>Get in on</span>
                                                    <h6 class="title">Google Play</h6>
                                                </a>
                                                <div class="social-icons">
                                                    <h6 class="title">Connect With Us</h6>
                                                    <ul>
                                                        <li><a href="javascript:void(0);"><i class="ti ti-brand-facebook-filled"></i></a></li>
                                                        <li><a href="javascript:void(0);"><i class="ti ti-brand-x-filled"></i></a></li>
                                                        <li><a href="javascript:void(0);"><i class="ti ti-brand-instagram-filled"></i></a></li>
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
                                <div class="copyright-text wow fadeInUp animated">© <a href="javascript:void(0);">2025 sayyarah.com. All rights reserved.</a></div>
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
    <script src="js/slick.min.js"></script>
    <script src="js/slick-animation.min.js"></script>
    <script src="js/jquery.fancybox.js"></script>
    <script src="js/jquery.nice-select.min.js"></script>
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
