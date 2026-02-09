

// Start Validaton Shi Master

function validateShipForm() {
    var isValid = true;
    var message = "";

    function isEmpty(value) {
        return value === null || value.trim() === "";
    }

    // Reset all input borders
    document.querySelectorAll('.form-control, select').forEach(el => removeHighlight(el));

    // Dropdowns
    var ddlshipping = document.getElementById(shipFormClientIDs.ddlshipping);
    var ddlportname = document.getElementById(shipFormClientIDs.ddlportname);
    var ddlterminal = document.getElementById(shipFormClientIDs.ddlterminal);
    var ddlcountry = document.getElementById(shipFormClientIDs.ddlcountry);

    if (ddlshipping.selectedIndex <= 0) {
        message += "Select Shipping\n";
        highlightError(ddlshipping);
        ddlshipping.addEventListener("change", () => removeHighlight(ddlshipping), { once: true });
        return false;
    }

    if (ddlportname.selectedIndex <= 0) {
        message += "Select Port From\n";
        highlightError(ddlportname);
        ddlportname.addEventListener("change", () => removeHighlight(ddlportname), { once: true });
        return false;
    }

    if (ddlterminal.selectedIndex <= 0) {
        message += "Select Terminal Name\n";
        highlightError(ddlterminal);
        ddlterminal.addEventListener("change", () => removeHighlight(ddlterminal), { once: true });
        return false;
    }

    if (ddlcountry.selectedIndex <= 0) {
        message += "Select Country Name\n";
        highlightError(ddlcountry);
        ddlcountry.addEventListener("change", () => removeHighlight(ddlcountry), { once: true });
        return false;
    }

    // Textboxes
    var txtsname = document.getElementById(shipFormClientIDs.txtsname);
    var txtddate = document.getElementById(shipFormClientIDs.txtddate);
    var txtadate = document.getElementById(shipFormClientIDs.txtadate);
    var txtshipfreight = document.getElementById(shipFormClientIDs.txtshipfreight);
    var txtLoadingCapacity = document.getElementById(shipFormClientIDs.txtLoadingCapacity);

    if (isEmpty(txtsname.value)) {
        message += "Enter Ship Name\n";
        highlightError(txtsname);
        txtsname.addEventListener("input", () => removeHighlight(txtsname), { once: true });
        return false;
    }

    if (isEmpty(txtddate.value)) {
        message += "Select Departure Date\n";
        highlightError(txtddate);
        txtddate.addEventListener("input", () => removeHighlight(txtddate), { once: true });
        return false;
    }

    if (isEmpty(txtadate.value)) {
        message += "Select Arrival Date\n";
        highlightError(txtadate);
        txtadate.addEventListener("input", () => removeHighlight(txtadate), { once: true });
        return false;
    }

    if (isEmpty(txtshipfreight.value) || isNaN(txtshipfreight.value)) {
        message += "Enter valid Ship Freight\n";
        highlightError(txtshipfreight);
        txtshipfreight.addEventListener("input", () => removeHighlight(txtshipfreight), { once: true });
        return false;
    }

    if (isEmpty(txtLoadingCapacity.value) || isNaN(txtLoadingCapacity.value)) {
        message += "Enter valid Loading Capacity\n";
        highlightError(txtLoadingCapacity);
        txtLoadingCapacity.addEventListener("input", () => removeHighlight(txtLoadingCapacity), { once: true });
        return false;
    }

    if (!isValid) {
        alert("Please correct the following:\n\n" + message);
    }
    showSpinner();
    return isValid;
    
}



// End Validaton Shi Master

//--------------------------------------------------------------------------------------------------------------
//Start Validation category master
function validateCategoryForm() {
    let isValid = true;
    let errorMessages = [];

    // Get element references
    const cnameEl = document.getElementById(cnameClientId);
    const titleEl = document.getElementById(titleClientId);
    const keywordEl = document.getElementById(keywordClientId);
    const descriptionEl = document.getElementById(descriptionClientId);
    const fileUploadEl = document.getElementById(fileUploadClientId);
    const oldImageValue = document.getElementById(oldImageClientId).value.trim();

    const cname = cnameEl.value.trim();
    const title = titleEl.value.trim();
    const keyword = keywordEl.value.trim();
    const description = descriptionEl.value.trim();
    const fileUpload = fileUploadEl.value.trim();

    // Reset all borders
    [cnameEl, titleEl, keywordEl, descriptionEl, fileUploadEl].forEach(el => removeHighlight(el));

    // Validate Category Name
    if (!cname) {
        alert("Please enter Category Name.");
        highlightError(cnameEl);
        cnameEl.addEventListener("input", () => removeHighlight(cnameEl), { once: true });
        return false;
    }

    // Validate Category Icon if no old image is present
    if (!fileUpload && !oldImageValue) {
        alert("Please upload a Category Icon.");
        highlightError(fileUploadEl);
        fileUploadEl.addEventListener("change", () => removeHighlight(fileUploadEl), { once: true });
        return false;
    }

    // Validate file type if file is uploaded
    if (fileUpload) {
        const allowedExtensions = ['pdf', 'jpg', 'jpeg', 'png'];
        const fileName = fileUploadEl.value.toLowerCase();
        const extension = fileName.substring(fileName.lastIndexOf('.') + 1);

        if (!allowedExtensions.includes(extension)) {
            alert("Only PDF, JPG, JPEG, and PNG files are allowed.");
            highlightError(fileUploadEl);
            fileUploadEl.addEventListener("change", () => removeHighlight(fileUploadEl), { once: true });
            return false;
        }
    }

    // Validate Title Tag
    if (!title) {
        alert("Please enter Title Tag.");
        highlightError(titleEl);
        titleEl.addEventListener("input", () => removeHighlight(titleEl), { once: true });
        return false;
    }

    // Validate Keyword Tag
    if (!keyword) {
        alert("Please enter Keyword Tag.");
        highlightError(keywordEl);
        keywordEl.addEventListener("input", () => removeHighlight(keywordEl), { once: true });
        return false;
    }

    // Validate Description
    if (!description) {
        alert("Please enter Description.");
        highlightError(descriptionEl);
        descriptionEl.addEventListener("input", () => removeHighlight(descriptionEl), { once: true });
        return false;
    }

    return true;
}


//END Validation category master

function highlightError(controlId) {
    const ctrl = document.getElementById(controlId);
    if (ctrl) {
        ctrl.style.border = "1px solid red";
    }
}

document.addEventListener("DOMContentLoaded", function () {
    const submitBtn = document.getElementById(submitBtnClientId);
    if (submitBtn) {
        submitBtn.onclick = function (e) {
            if (!validateCategoryForm()) {
                e.preventDefault();
                return false;
            }
        };
    }
});

//Start Validation Subcategory

function validationSubcategory() {
    // Get elements
    var ddlCategoryElem = document.getElementById(SubCategoryIds.ddlCategory);
    var txtSubCategoryNameElem = document.getElementById(SubCategoryIds.txtSubCategoryName);
    var txttitleElem = document.getElementById(SubCategoryIds.txttitle);
    var txtkeywordElem = document.getElementById(SubCategoryIds.txtkeyword);
    var txtdescriptionElem = document.getElementById(SubCategoryIds.txtdescription);

    // Trimmed values
    var ddlCategory = ddlCategoryElem.value.trim();
    var txtSubCategoryName = txtSubCategoryNameElem.value.trim();
    var txttitle = txttitleElem.value.trim();
    var txtkeyword = txtkeywordElem.value.trim();
    var txtdescription = txtdescriptionElem.value.trim();

    // Reset all borders
    [ddlCategoryElem, txtSubCategoryNameElem, txttitleElem, txtkeywordElem, txtdescriptionElem].forEach(el => removeHighlight(el));

    // Validation
    if (ddlCategoryElem.selectedIndex === 0 || ddlCategory === "") {
        alert("Please select a category.");
        highlightError(ddlCategoryElem);
        ddlCategoryElem.addEventListener("change", () => removeHighlight(ddlCategoryElem), { once: true });
        return false;
    }

    if (txtSubCategoryName === '') {
        alert("Please enter sub category name.");
        highlightError(txtSubCategoryNameElem);
        txtSubCategoryNameElem.addEventListener("input", () => removeHighlight(txtSubCategoryNameElem), { once: true });
        return false;
    }

    if (txttitle === '') {
        alert("Please enter title tag.");
        highlightError(txttitleElem);
        txttitleElem.addEventListener("input", () => removeHighlight(txttitleElem), { once: true });
        return false;
    }

    if (txtkeyword === '') {
        alert("Please enter keyword tag.");
        highlightError(txtkeywordElem);
        txtkeywordElem.addEventListener("input", () => removeHighlight(txtkeywordElem), { once: true });
        return false;
    }

    if (txtdescription === '') {
        alert("Please enter description.");
        highlightError(txtdescriptionElem);
        txtdescriptionElem.addEventListener("input", () => removeHighlight(txtdescriptionElem), { once: true });
        return false;
    }

    return true;
}
//End Validation Subcategory


function validateProduct() {

    // Get elements
    var ddlsubcatElem = document.getElementById(productIds.ddlsubcat);
    var ddlBrandElem = document.getElementById(productIds.ddlBrand);
    var txtProductNameElem = document.getElementById(productIds.txtProductName);
   

    // Trimmed values
    var ddlsubcat = ddlsubcatElem.value.trim();
    var ddlBrand = ddlBrandElem.value.trim();
    var txtProductName = txtProductNameElem.value.trim();
  

    // Reset borders
    [ddlsubcatElem, ddlBrandElem, txtProductNameElem].forEach(el => removeHighlight(el));

    // Validation
    if (ddlsubcatElem.selectedIndex === 0 || ddlsubcat === "") {
        alert("Please select a sub category.");
        highlightError(ddlsubcatElem);
        ddlsubcatElem.addEventListener("change", () => removeHighlight(ddlsubcatElem), { once: true });
        return false;
    }

    if (ddlBrandElem.selectedIndex === 0 || ddlBrand === "") {
        alert("Please select a brand.");
        highlightError(ddlBrandElem);
        ddlBrandElem.addEventListener("change", () => removeHighlight(ddlBrandElem), { once: true });
        return false;
    }

    if (txtProductName === "") {
        alert("Please enter product name.");
        highlightError(txtProductNameElem);
        txtProductNameElem.addEventListener("input", () => removeHighlight(txtProductNameElem), { once: true });
        return false;
    }

    

    return true;
}






//Start Fob type Validation
function validateFobType() {
    // Get elements
    var ddlCountryNameElem = document.getElementById(fobTypeIds.ddlCountryName);
    var ddlCityNameElem = document.getElementById(fobTypeIds.ddlCityName);
    var ddlPortnameElem = document.getElementById(fobTypeIds.ddlPortname);
    var ddlFobtypeElem = document.getElementById(fobTypeIds.ddlFobtype);
    var txtpriceElem = document.getElementById(fobTypeIds.txtprice);

    // Trimmed values
    var ddlCountryName = ddlCountryNameElem.value.trim();
    var ddlCityName = ddlCityNameElem.value.trim();
    var ddlPortname = ddlPortnameElem.value.trim();
    var ddlFobtype = ddlFobtypeElem.value.trim();
    var txtprice = txtpriceElem.value.trim();

    // Reset borders
    [ddlCountryNameElem, ddlCityNameElem, ddlPortnameElem, ddlFobtypeElem, txtpriceElem].forEach(el => removeHighlight(el));

    if (ddlCountryNameElem.selectedIndex === 0 || ddlCountryName === "") {
        alert("Please select a country.");
        highlightError(ddlCountryNameElem);
        ddlCountryNameElem.addEventListener("change", () => removeHighlight(ddlCountryNameElem), { once: true });
        return false;
    }
    if (ddlFobtypeElem.selectedIndex === 0 || ddlFobtype === "") {
        alert("Please select a fob type.");
        highlightError(ddlFobtypeElem);
        ddlFobtypeElem.addEventListener("change", () => removeHighlight(ddlFobtypeElem), { once: true });
        return false;
    }
    if (txtprice === "") {
        alert("Please enter price.");
        highlightError(txtpriceElem);
        txtpriceElem.addEventListener("input", () => removeHighlight(txtpriceElem), { once: true });
        return false;
    }
    return true;
}
//End Fob type Validation

//Start validation add-ship

function validateAddShip() {
    // Get elements
    var ddlShipingCompanyElem = document.getElementById(addShipIds.ddlShipingCompany);
    var ddlPortFromElem = document.getElementById(addShipIds.ddlPortFrom);
    var ddlTerminalNameElem = document.getElementById(addShipIds.ddlTerminalName);
    var ddlCountryNameElem = document.getElementById(addShipIds.ddlCountryName);
    var txtShipNameElem = document.getElementById(addShipIds.txtShipName);
    var txtDepartureDateElem = document.getElementById(addShipIds.txtDepartureDate);
    var txtArrivalDateElem = document.getElementById(addShipIds.txtArrivalDate);
    var txtShipFreightElem = document.getElementById(addShipIds.txtShipFreight);

    // Trimmed values
    var ddlShipingCompany = ddlShipingCompanyElem.value.trim();
    var ddlPortFrom = ddlPortFromElem.value.trim();
    var ddlTerminalName = ddlTerminalNameElem.value.trim();
    var ddlCountryName = ddlCountryNameElem.value.trim();
    var txtShipName = txtShipNameElem.value.trim();
    var txtDepartureDate = txtDepartureDateElem.value.trim();
    var txtArrivalDate = txtArrivalDateElem.value.trim();
    var txtShipFreight = txtShipFreightElem.value.trim();

    // Reset borders
    [ddlShipingCompanyElem, ddlPortFromElem, ddlTerminalNameElem, ddlCountryNameElem, txtShipNameElem, txtDepartureDateElem, txtArrivalDateElem, txtShipFreightElem].forEach(el => removeHighlight(el));

    if (ddlShipingCompanyElem.selectedIndex === 0 || ddlShipingCompany === "") {
        alert("Please select a shiping company.");
        highlightError(ddlShipingCompanyElem);
        ddlShipingCompanyElem.addEventListener("change", () => removeHighlight(ddlShipingCompanyElem), { once: true });
        return false;
    }

    if (ddlPortFromElem.selectedIndex === 0 || ddlPortFrom==="") {
        alert("Please select a port from.");
        highlightError(ddlPortFromElem);
        ddlPortFromElem.addEventListener("input", () => removeHighlight(ddlPortFromElem), { once: true });
        return false;
    }
    if (ddlTerminalNameElem.selectedIndex === 0 || ddlTerminalName === "") {
        alert("Please select a terminal.");
        highlightError(ddlTerminalNameElem);
        ddlTerminalNameElem.addEventListener("input", () => removeHighlight(ddlTerminalNameElem), { once: true });
        return false;
    }
    if (ddlCountryNameElem.selectedIndex === 0 || ddlCountryName === "") {
        alert("Please select a country name.");
        highlightError(ddlCountryNameElem);
        ddlCountryNameElem.addEventListener("input", () => removeHighlight(ddlCountryNameElem), { once: true });
        return false;
    }
    if (txtShipNameElem.selectedIndex === 0 || txtShipName === "") {
        alert("Please enter ship name.");
        highlightError(txtShipNameElem);
        txtShipNameElem.addEventListener("input", () => removeHighlight(txtShipNameElem), { once: true });
        return false;
    }
    if (txtDepartureDate ==="") {
        alert("Please enter departure date.");
        highlightError(txtDepartureDateElem);
        txtDepartureDateElem.addEventListener("input", () => removeHighlight(txtDepartureDateElem), { once: true });
        return false;
    }
    if (txtArrivalDate === "") {
        alert("Please enter arrival date.");
        highlightError(txtArrivalDateElem);
        txtArrivalDateElem.addEventListener("input", () => removeHighlight(txtArrivalDateElem), { once: true });
        return false;
    }
    if (txtShipFreight === "") {
        alert("Please enter ship freight.");
        highlightError(txtShipFreightElem);
        txtShipFreightElem.addEventListener("input", () => removeHighlight(txtShipFreightElem), { once: true });
        return false;
    }

    return true;
}
//End validation add-ship

function highlightError(ctrl) {
    if (ctrl) {
        ctrl.style.border = "1px solid red";
        ctrl.focus();

        // If using Chosen.js, also highlight its container
        var chosenDiv = document.getElementById(ctrl.id + "_chosen");
        if (chosenDiv) {
            var single = chosenDiv.querySelector('.chosen-single');
            if (single) single.style.border = "1px solid red";
        }
    }
}

function removeHighlight(ctrl) {
    if (ctrl) {
        ctrl.style.border = "";

        var chosenDiv = document.getElementById(ctrl.id + "_chosen");
        if (chosenDiv) {
            var single = chosenDiv.querySelector('.chosen-single');
            if (single) single.style.border = "";
        }
    }
}



