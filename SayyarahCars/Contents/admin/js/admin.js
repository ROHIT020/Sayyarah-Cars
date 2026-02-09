(function ($) {
  "use strict";

  // toggle menu
  $(".menu-toggle").click(function(){
      $(".menu-toggle").toggleClass("active");
      $(".toc__nav").toggleClass("active");
      $(".body").toggleClass("active");
  });

  $("#sidebar-hide").click(function(){
      $(".toc").toggleClass("sidebar-hide");
      $(".content-area").toggleClass("content-area-full");
  });

  // Checkbox all Select
  function isString(arg) {
      if (typeof arg == 'string' || arg instanceof String) {
          return true;
      } else {
          return false;
      }
  }

  /**
   * Enable Check All Functionality
   * @param  {string} element - ID or class of table
   * @return {[none]}         none
   */
  function enableCheckAll(element) {
      var $table = $(element),
          $notCheckAllCheckbox = $table.find(':checkbox').not('.checkAll');

      // "check all" checkbox functionality
      $table.find('.checkAll').click(function() {
          $notCheckAllCheckbox.prop('checked', this.checked);
      });

      /* The "check all" checkbox is only checked if all rows are checked */
      $notCheckAllCheckbox.change(function() {
          var numOfChecked = $notCheckAllCheckbox.filter(':checked').length,
              numOfCheckboxes = $notCheckAllCheckbox.length,
              isAllChecked = numOfChecked === numOfCheckboxes;
          $table.find('.checkAll').prop('checked', isAllChecked);
      });
  }

  var table2 = $('#table2');
  enableCheckAll('#table'); // passing in a string
  enableCheckAll(table2); // passing in an object


  /// tooltip
  var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
  var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl)
  })

  // range slider
  const slider = document.getElementById('sliderPrice');
const rangeMin = parseInt(slider.dataset.min);
const rangeMax = parseInt(slider.dataset.max);
const step = parseInt(slider.dataset.step);
const filterInputs = document.querySelectorAll('input.filter__input');

noUiSlider.create(slider, {
    start: [rangeMin, rangeMax],
    connect: true,
    step: step,
    range: {
        'min': rangeMin,
        'max': rangeMax
    },
  
    // make numbers whole
    format: {
      to: value => value,
      from: value => value
    }
});

// bind inputs with noUiSlider 
slider.noUiSlider.on('update', (values, handle) => { 
  filterInputs[handle].value = values[handle]; 
});

filterInputs.forEach((input, indexInput) => { 
  input.addEventListener('change', () => {
    slider.noUiSlider.setHandle(indexInput, input.value);
  })
});

  // Brose File Uploader
  const ImageUploaderModule = (function () {
    const privateMethods = {
        resizeImage: function (file, shouldResize, maxWidth, maxHeight, convertToWebp) {
            if (!(file instanceof Blob)) {
                throw new TypeError("Invalid type for 'file'. Expected Blob (including File).");
            }
            if (!file.type.startsWith('image/')) {
                throw new TypeError("Invalid type for 'file'. Expected an image.");
            }
            if (typeof shouldResize !== 'boolean') {
                throw new TypeError("Invalid type for 'shouldResize'. Expected boolean.");
            }
            if (maxWidth !== null && typeof maxWidth !== 'number') {
                throw new TypeError("Invalid type for 'maxWidth'. Expected number or null.");
            }
            if (maxHeight !== null && typeof maxHeight !== 'number') {
                throw new TypeError("Invalid type for 'maxHeight'. Expected number or null.");
            }

            return new Promise((resolve, reject) => {
                const reader = new FileReader();
                reader.onload = (e) => {
                    const img = new Image();
                    img.src = e.target.result;

                    img.onload = () => {
                        const canvas = document.createElement('canvas');
                        const ctx = canvas.getContext('2d');

                        if (shouldResize) {
                            if (!maxWidth || !maxHeight) {
                                throw new Error("Both maxWidth and maxHeight are required for resizing.");
                            }
                            const ratio = Math.min(maxWidth / img.width, maxHeight / img.height);

                            canvas.width = img.width * ratio;
                            canvas.height = img.height * ratio;

                            ctx.drawImage(img, 0, 0, canvas.width, canvas.height);
                        } else {
                            canvas.width = img.width;
                            canvas.height = img.height;
                            ctx.drawImage(img, 0, 0);
                        }
                        const convertType = convertToWebp ? 'image/webp' : file.type;
                        const resizedDataUrl = canvas.toDataURL(convertType);
                        console.log(resizedDataUrl);

                        // Küçültülen resmin dosya boyutu
                        const fileSize = Math.round(resizedDataUrl.length / 1024); // Kilobyte cinsinden

                        // Küçültülen resmin boyutları
                        const imageWidth = canvas.width;
                        const imageHeight = canvas.height;

                        console.log('Küçültülen Resim Bilgileri:');
                        console.log('Dosya Boyutu:', fileSize, 'KB');
                        console.log('Boyut:', imageWidth, 'x', imageHeight);

                        resolve(resizedDataUrl);
                    };
                };
                reader.readAsDataURL(file);
            });
        }
    };

    return {
        init: function (inputElement, imageElement, imageDataUrl, shouldResize = false, maxWidth = null, maxHeight = null, convertToWebp = false) {
            const input = inputElement instanceof HTMLElement ? inputElement : document.getElementById(inputElement);
            const image = imageElement instanceof HTMLElement ? imageElement : document.getElementById(imageElement);
            const dataUrl = imageDataUrl instanceof HTMLElement ? imageDataUrl : document.getElementById(imageDataUrl);

            if (!input || !image || !dataUrl) {
                throw new Error("Invalid input, avatar or dataUrl element");
            }

            const uploadImage = async (event) => {
                try {
                    const file = event.target.files[0];

                    if (!file) {
                        throw new Error("No file selected");
                    }
                    const base64Data = await privateMethods.resizeImage(file, shouldResize, maxWidth, maxHeight, convertToWebp);
                    image.src = base64Data;
                    dataUrl.value = "";
                    dataUrl.value = base64Data;
                } catch (error) {
                    console.error("Error uploading image:", error.message);
                }
            };

            input.addEventListener("change", (e) => {
                dataUrl.value = "";
                uploadImage(e);
            });
        }
    };
})();

ImageUploaderModule.init("image","uploadedImage","imageDataUrl",true,200,150,true);

})(window.jQuery);