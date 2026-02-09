function IsEmail(email) {
    var regex = /^([a-zA-Z0-9_\.\-\+])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,4})+$/;
    if (!regex.test(email)) {
        return false;
    } else {
        return true;
    }
}

$("#btnAlogin").click(function (e) {
    e.preventDefault();
    var txtemail = $('[id*="txtAusername"]').val();
    var txtpwd = $('[id*="txtApassword"]').val();
    if (txtemail == '') {
        alert('Enter your user id or email id.');
        return false;
    }
    else if (txtpwd == '') {
        alert('Enter your password');
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "/WebServices/jquerydata.asmx/checkAdminLogin",
            data: "{'UID': '" + txtemail + "','Password': '" + txtpwd + "'}",
            contentType: "application/json",
            dataType: "json",
            success: function (r) {
                var res = r.d;
                if (res == '0') {
                    alert('Invalid user id or password');
                }
                else {
                    window.location.replace("Admin/Dashboard");
                }
            }
        });
        return false;
    }
});


$("#btnlogin").click(function (e) {
    e.preventDefault();
    var txtemail = $('[id*="txtusername"]').val();
    var txtpwd = $('[id*="txtpassword"]').val();
    if (txtemail == '') {
        alert('Enter your user id or email id.');
        return false;
    }
    else if (txtpwd == '') {
        alert('Enter your password');
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "/WebServices/jquerydata.asmx/checkUserLogin",
            data: "{'UID': '" + txtemail + "','Password': '" + txtpwd + "'}",
            contentType: "application/json",
            dataType: "json",
            success: function (r) {
                var res = r.d;
                if (res == '0') {
                    alert('Invalid user id or password');
                }
                else {
                    window.location.replace("Users/Dashboard");
                }
            }
        });
        return false;
    }
});


$("#btnSlogin").click(function (e) {
    e.preventDefault();
    var txtSellerEmailId = $('[id*="txtSellerEmailId"]').val();
    var txtSellerPassword = $('[id*="txtSellerPassword"]').val();
    if (txtSellerEmailId == '') {
        alert('Enter your user id or email id.');
        return false;
    }
    else if (txtSellerPassword == '') {
        alert('Enter your password');
        return false;
    }
    else {
        $.ajax({
            type: "POST",
            url: "/WebServices/jquerydata.asmx/checkSellerLogin",
            data: "{'UID': '" + txtSellerEmailId + "','Password': '" + txtSellerPassword + "'}",
            contentType: "application/json",
            dataType: "json",
            success: function (r) {
                var res = r.d;
                if (res == '0') {
                    alert('Invalid user id or password');
                }
                else {
                    window.location.replace("Seller/Dashboard");
                }
            }
        });
        return false;
    }
});