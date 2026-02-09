<%@ Page Title="" Language="C#" MasterPageFile="~/Shared/Main.Master" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="SayyarahCars.Admin.Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="row">
        <div class="col-lg-12 col-md-12 col-12">
            <div class="card welcome-banner">
                <div class="card-body">
                    <div class="row">
                        <div class="col-sm-6">
                            <div class="p-4">
                                <h2 class="text-white">Your trusted partner for quality cars</h2>
                                <p class="text-white">The Brand new User Interface with power of Bootstrap Components. Explore the Endless possibilities with Sayyarah cars.</p>
                            </div>
                        </div>
                        <div class="col-sm-6 text-center">
                            <div class="img-welcome-banner">
                                <img src="../Contents/admin/images/range-rover.png" alt="img" class="img-fluid">
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-lg-4 col-md-6 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block">
                        <div class="card-thumb">
                            <img src="../Contents/admin/images/car.png" class="w-75">
                        </div>
                        <div class="content">
                            <p class="text-dark mb-0 fw-semibold fs-14">Total Cars Listed</p>
                            <h3 class="mt-1 mb-0 fw-bold">54</h3>
                        </div>
                        <select class="form-select" aria-label="Default select example">
                            <option selected="">This Year</option>
                            <option value="2">This Month</option>
                            <option value="3">This Week</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block">
                        <div class="card-thumb">
                            <img src="../Contents/admin/images/car.png" class="w-75">
                        </div>
                        <div class="content">
                            <p class="text-dark mb-0 fw-semibold fs-14">New Cars Listed</p>
                            <h3 class="mt-1 mb-0 fw-bold">32</h3>
                        </div>
                        <select class="form-select" aria-label="Default select example">
                            <option selected="">This Year</option>
                            <option value="2">This Month</option>
                            <option value="3">This Week</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block">
                        <div class="card-thumb">
                            <img src="../Contents/admin/images/car.png" class="w-75">
                        </div>
                        <div class="content">
                            <p class="text-dark mb-0 fw-semibold fs-14">Old Cars Listed</p>
                            <h3 class="mt-1 mb-0 fw-bold">28</h3>
                        </div>
                        <select class="form-select" aria-label="Default select example">
                            <option selected="">This Year</option>
                            <option value="2">This Month</option>
                            <option value="3">This Week</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block">
                        <div class="card-thumb">
                            <img src="../Contents/admin/images/pending.png" class="w-50">
                        </div>
                        <div class="content">
                            <p class="text-dark mb-0 fw-semibold fs-14">Pending Approvals</p>
                            <h3 class="mt-1 mb-0 fw-bold">10</h3>
                        </div>
                        <select class="form-select" aria-label="Default select example">
                            <option selected="">New Car</option>
                            <option value="2">Old Car</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block">
                        <div class="card-thumb">
                            <img src="../Contents/admin/images/car.png" class="w-75">
                        </div>
                        <div class="content">
                            <p class="text-dark mb-0 fw-semibold fs-14">Total Car Sold</p>
                            <h3 class="mt-1 mb-0 fw-bold">10</h3>
                        </div>
                        <select class="form-select" aria-label="Default select example">
                            <option selected="">New Car</option>
                            <option value="2">Old Car</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-lg-4 col-md-6 col-12">
            <div class="card">
                <div class="card-body">
                    <div class="card-block">
                        <div class="card-thumb">
                            <img src="../Contents/admin/images/seller.png" class="w-50">
                        </div>
                        <div class="content">
                            <p class="text-dark mb-0 fw-semibold fs-14">Active Sellers</p>
                            <h3 class="mt-1 mb-0 fw-bold">10</h3>
                        </div>
                        <select class="form-select" aria-label="Default select example">
                            <option selected="">New Car</option>
                            <option value="2">Old Car</option>
                        </select>
                    </div>
                </div>
            </div>
        </div>
        <div class="col-md-12 col-lg-12">
            <div class="card mb-0">
                <div class="card-header">
                    <div class="col">
                        <h4 class="card-title">Total Revenue</h4>
                    </div>
                    <select class="form-select" aria-label="Default select example">
                        <option selected="">This Year</option>
                        <option value="2">This Month</option>
                    </select>
                </div>
                <div class="card-body pt-0">
                    <div id="chart"></div>
                </div>
            </div>
        </div>
    </div>


    <script src="../Contents/admin/js/apexcharts.min.js"></script>
    <script src="../Contents/admin/js/stock-prices.js"></script>
    <script src="../Contents/admin/js/stock-prices.js"></script>
    <script src="../Contents/admin/js/admin.js"></script>
    <script>
        // total revenue
        var series = [
            {
                name: "New Car",
                data: [12, 42, 31, 56, 25, 61, 38, 29, 45, 32]
            },
            {
                name: "Old Car",
                data: [28, 35, 55, 20, 48, 30, 60, 22, 49, 31]
            }
        ];
        var options = {
            chart: {
                type: "line",
                height: 400,
                stacked: true
            },
            series,
            xaxis: {
                categories: [
                    "Jan",
                    "Feb",
                    "Mar",
                    "Apr",
                    "May",
                    "Jun",
                    "Jul",
                    "Aug",
                    "Sep",
                    "Oct",
                    "Nov",
                    "Dec"
                ]
            },
            title: {
                align: "center"
            }
        };

        var chart = new ApexCharts(document.querySelector("#chart"), options);
        chart.render();

        var currIndex = 0;
        window.setInterval(() => {
            if (currIndex > 4) {
                currIndex = 0;
            }
            chart.highlightSeries(series[currIndex].name);
            currIndex++;
        }, 1500);
    </script>
</asp:Content>
