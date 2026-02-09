document.addEventListener("DOMContentLoaded", function () {
    var elements = document.querySelectorAll(".validate");

    elements.forEach(function (el) {
        var type = el.getAttribute("data-type");
        var errorId = el.getAttribute("data-error-id");
        var errorElement = document.getElementById(errorId);

        var clearError = function () {
            // remove invalid from input
            el.classList.remove("is-invalid");

            // remove invalid from Chosen container
            if (el.classList.contains("chosen-select")) {
                var chosenContainer = el.nextElementSibling;
                if (chosenContainer && chosenContainer.classList.contains("chosen-container")) {
                    chosenContainer.classList.remove("is-invalid");
                }
            }

            // remove invalid from Flatpickr wrapper
            if (el.classList.contains("flatpickr-input")) {
                var wrapper = el.closest(".input-group");
                if (wrapper) wrapper.classList.remove("is-invalid");
            }
           

            if (errorElement) errorElement.style.display = "none";
        };

        // Attach clearError events
        if (["checkbox", "radiolist", "checkboxlist", "radiogroup"].includes(type)) {
            el.addEventListener("change", clearError);
        } else if (type === "dropdown") {
            el.addEventListener("change", clearError);
            if (typeof $ !== "undefined" && $(el).hasClass("chosen-select")) {
                $(el).on("change", clearError);
            }
        } else if (type === "calendar") {
            el.addEventListener("change", clearError);
            el.addEventListener("blur", clearError);
        }
        else if (type === "fileupload") {
            el.addEventListener("change", clearError);
        }
        else {
            el.addEventListener("input", clearError);
            el.addEventListener("change", clearError);
        }
    });
    alert(btnSubmitClientId);
    //const btnSubmit = document.getElementById(btnSubmitClientId);
    //if (btnSubmit) {
    //    btnSubmit.addEventListener("click", function (e) {
    //        if (!ValidateFormData()) {
    //            e.preventDefault();
    //            return false;
    //        }
    //    });
    //}
});

function ValidateFormData() {
    var isValid = true;
    var elements = document.querySelectorAll(".validate");

    elements.forEach(function (el) {
        var isRequired = el.getAttribute("data-required") === "true";
        var type = el.getAttribute("data-type");
        var errorId = el.getAttribute("data-error-id");
        var errorElement = document.getElementById(errorId);
        var valid = true;

        var value = (el.value || "").trim();

        // Reset error states
        el.classList.remove("is-invalid");
        if (el.classList.contains("chosen-select")) {
            var chosenContainer = el.nextElementSibling;
            if (chosenContainer && chosenContainer.classList.contains("chosen-container")) {
                chosenContainer.classList.remove("is-invalid");
            }
        }
        if (el.classList.contains("flatpickr-input")) {
            var wrapper = el.closest(".input-group");
            if (wrapper) wrapper.classList.remove("is-invalid");
        }
        if (errorElement) errorElement.style.display = "none";

        // Validation rules
        if (isRequired) {
            switch (type) {
                case "text":
                case "textarea":
                    valid = value !== "";
                    break;

                case "email":
                    var emailPattern = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
                    valid = emailPattern.test(value);
                    break;

                case "dropdown":
                    valid = value !== "" && value !== "0" && value !== null;
                    break;

                case "checkbox":
                    valid = el.checked;
                    break;

                case "radiolist":
                case "checkboxlist":
                    var checked = document.querySelectorAll('input[name="' + el.name + '"]:checked');
                    valid = checked.length > 0;
                    break;

                case "radiogroup":
                    var radios = el.querySelectorAll('input[type="radio"]');
                    valid = Array.from(radios).some(r => r.checked);
                    break;

                case "fileupload":
                    valid = el.files && el.files.length > 0;
                    break;

                case "calendar":
                    valid = value !== "";
                    if (valid) {
                        var datePattern = /^(\d{2})\/(\d{2})\/(\d{4})(\s+\d{2}:\d{2})?$/;
                        if (!datePattern.test(value)) {
                            valid = false;
                        } else {
                            var parts = value.split(" ")[0].split("/");
                            var day = parseInt(parts[0], 10);
                            var month = parseInt(parts[1], 10) - 1;
                            var year = parseInt(parts[2], 10);
                            var testDate = new Date(year, month, day);
                            if (
                                testDate.getFullYear() !== year ||
                                testDate.getMonth() !== month ||
                                testDate.getDate() !== day
                            ) {
                                valid = false;
                            }
                        }
                    }
                    break;

                default:
                    valid = value !== "";
                    break;
            }
        }

        // Show error if invalid
        if (!valid) {
            el.classList.add("is-invalid");

            if (el.classList.contains("chosen-select")) {
                var chosenContainer = el.nextElementSibling;
                if (chosenContainer && chosenContainer.classList.contains("chosen-container")) {
                    chosenContainer.classList.add("is-invalid");
                }
            }
            if (el.classList.contains("flatpickr-input")) {
                var wrapper = el.closest(".input-group");
                if (wrapper) wrapper.classList.add("is-invalid");
            }
            if (errorElement) errorElement.style.display = "block";
            isValid = false;
        }
    });

    // CKEditor Validation
    ["txtAnswer", "txtAnnouncement"].forEach(function (editorId) {
        if (typeof CKEDITOR !== "undefined" && CKEDITOR.instances[editorId]) {
            var content = CKEDITOR.instances[editorId].getData().trim();
            var errorSpan = document.getElementById(editorId + "Error");
            if (content === "") {
                if (errorSpan) errorSpan.style.display = "block";
                isValid = false;
            } else {
                if (errorSpan) errorSpan.style.display = "none";
            }
        }
    });

    return isValid;
}
