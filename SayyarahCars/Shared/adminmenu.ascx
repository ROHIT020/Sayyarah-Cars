<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="adminmenu.ascx.cs" Inherits="SayyarahCars.Shared.adminmenu" %>
<script src="../Contents/outer/js/jquery.js"></script>
<script>
    $(window).bind("load", function () {
        var PID = "1";
        $.ajax({
            type: "POST",
            url: "/WebServices/jquerydata.asmx/bindadminMenu",
            data: "{'PID': '" + PID + "'}",
            contentType: "application/json; charset=ISO-8859-1",
            dataType: "json",
            success: function (data) {
                var tempData = JSON.parse(data.d);
                var tHtml = '';
                tHtml += '<ul class="toc__navul">';
                tHtml += '<li>';
                tHtml += '<a href="/Admin/Dashboard.aspx" class="active"><i class="ti ti-arrow-big-right"></i>Dashboard</a>';
                tHtml += '</li>';
                for (var i = 0; i < tempData.length; i++) {
                    var PRID = tempData[i].parentId;
                    tHtml += '<li><a href=""><i class="ti ti-arrow-big-right"></i>' + tempData[i].Cname + '</a>';
                    tHtml += '<ul class="subnav">' + forSub(tempData[i]) + '</ul>';
                }
                $('#main-navigation').html(tHtml);
            }
        });
        return false;
    });
    function forSub(sublist) {
        var forSubMenu = '';
        for (var j = 0; j < sublist.Smenu.length; j++) {
            forSubMenu += '<li><a href="' + sublist.Smenu[j].URL + '"><i class="ti ti-arrow-big-right"></i>' + sublist.Smenu[j].Sname + '</a></li>'
        }
        return forSubMenu;
    }

</script>

<div class="toc">
    <div class="toc__inner">
        <div class="toc__logo">
            <a href="/">
                <img src="/Contents/admin/images/logo1.png" class="logo" alt="Bizupon"></a>
        </div>
        <div class="toc__nav">
            <div class="sidebar">
                <nav id="main-navigation" class="main-navigation">
                </nav>
            </div>
        </div>
    </div>
</div>


