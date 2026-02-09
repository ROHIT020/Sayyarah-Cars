<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="userheader.ascx.cs" Inherits="SayyarahCars.Shared.userheader" %>
<header class="header">
    <div class="header-wrapper">
        <a href="#" class="menubar-link" id="sidebar-hide">
            <svg width="24px" height="24px" viewBox="0 0 24 24" fill="none" xmlns="http://www.w3.org/2000/svg">
                <path d="M3 12H21M3 6H21M3 18H21" stroke="#6f756e" stroke-width="2" stroke-linecap="round" stroke-linejoin="round" />
            </svg>
        </a>
        <div class="toc__menu-toggle">
            <div class="menu-toggle">
                <span class="one"></span>
                <span class="two"></span>
                <span class="three"></span>
            </div>
        </div>
        <ul class="user-menu">
            <li class="dropdown topbar-item">
                <a href="#" class="dropdown-toggle" data-bs-toggle="dropdown" data-bs-toggle="tooltip" data-bs-placement="bottom" role="button" title="Notification" aria-haspopup="false" aria-expanded="false">
                    <svg class="w-6 h-6 text-gray-800 dark:text-white" aria-hidden="true" xmlns="http://www.w3.org/2000/svg" width="28" height="28" fill="#6f756e" viewBox="0 0 24 24">
                        <path d="M17.133 12.632v-1.8a5.406 5.406 0 0 0-4.154-5.262.955.955 0 0 0 .021-.106V3.1a1 1 0 0 0-2 0v2.364a.955.955 0 0 0 .021.106 5.406 5.406 0 0 0-4.154 5.262v1.8C6.867 15.018 5 15.614 5 16.807 5 17.4 5 18 5.538 18h12.924C19 18 19 17.4 19 16.807c0-1.193-1.867-1.789-1.867-4.175ZM8.823 19a3.453 3.453 0 0 0 6.354 0H8.823Z" />
                    </svg>
                    <span class="badge">10</span>
                </a>
                <div class="dropdown-menu stop dropdown-menu-end dropdown-lg py-0">
                    <h5 class="dropdown-item-text">Notifications</h5>
                    <div class="tab-pane fade show active" id="All" role="tabpanel" aria-labelledby="all-tab" tabindex="0">
                        <a href="#" class="dropdown-item">
                            <small class="float-end text-muted ps-2">2 min ago</small>
                            <div class="d-flex align-items-center">
                                <div class="flex-shrink-0 bg-primary-subtle text-primary thumb-md rounded-circle">
                                    <i class="iconoir-wolf fs-4"></i>
                                </div>
                                <div class="flex-grow-1 ms-2 text-truncate">
                                    <h6 class="my-0 fw-normal text-dark fs-13">Your order is placed</h6>
                                    <small class="text-muted mb-0">Dummy text of the printing and industry.</small>
                                </div>
                            </div>
                        </a>
                        <a href="#" class="dropdown-item">
                            <small class="float-end text-muted ps-2">2 min ago</small>
                            <div class="d-flex align-items-center">
                                <div class="flex-shrink-0 bg-primary-subtle text-primary thumb-md rounded-circle">
                                    <i class="iconoir-wolf fs-4"></i>
                                </div>
                                <div class="flex-grow-1 ms-2 text-truncate">
                                    <h6 class="my-0 fw-normal text-dark fs-13">Your order is placed</h6>
                                    <small class="text-muted mb-0">Dummy text of the printing and industry.</small>
                                </div>
                            </div>
                        </a>
                        <a href="#" class="dropdown-item">
                            <small class="float-end text-muted ps-2">2 min ago</small>
                            <div class="d-flex align-items-center">
                                <div class="flex-shrink-0 bg-primary-subtle text-primary thumb-md rounded-circle">
                                    <i class="iconoir-wolf fs-4"></i>
                                </div>
                                <div class="flex-grow-1 ms-2 text-truncate">
                                    <h6 class="my-0 fw-normal text-dark fs-13">Your order is placed</h6>
                                    <small class="text-muted mb-0">Dummy text of the printing and industry.</small>
                                </div>
                            </div>
                        </a>
                    </div>
                </div>
            </li>            
            <li class="dropdown topbar-item">
                <a class="nav-link dropdown-toggle arrow-none nav-icon" data-bs-toggle="dropdown" href="#" role="button" aria-haspopup="false" aria-expanded="false">
                    <img src="../Contents/admin/images/avatar.jpg" alt="" class="img-fluid">
                </a>
                <div class="dropdown-menu dropdown-menu-end py-0" style="">
                    <div class="d-flex align-items-center dropdown-item py-2 bg-secondary-subtle">
                        <div class="flex-grow-1 ms-2 text-truncate align-self-center">
                            <h6 class="my-0 fw-medium text-dark fs-13"><span id="user" runat="server"></span></h6>                           
                        </div>
                    </div>
                    <div class="dropdown-divider mt-0"></div>
                    <a class="dropdown-item" href="../Users/MyProfile.aspx"><i class="las la-user fs-18 me-1 align-text-bottom"></i>Profile</a>
                    <a class="dropdown-item" href="../Users/ChangePassword.aspx"><i class="las la-wallet fs-18 me-1 align-text-bottom"></i>Change Password</a>
                    <div class="dropdown-divider mb-0"></div>
                    <a class="dropdown-item text-danger" href="../logout.aspx"><i class="las la-power-off fs-18 me-1 align-text-bottom"></i>Logout</a>
                </div>
            </li>
        </ul>
    </div>
</header>
