(function ($) {
  "use strict";

  //Update Header Style and Scroll to Top
  function headerStyle() {
    if ($(".header").length) {
      var windowpos = $(window).scrollTop();
      var siteHeader = $(".header-style");
      var scrollLink = $(".scroll-to-top");
      var sticky_header = $(".header .sticky-header");
      if (windowpos > 100) {
        sticky_header.addClass("fixed-header animated slideInDown");
        scrollLink.fadeIn(300);
      } else {
        sticky_header.removeClass("fixed-header animated slideInDown");
        scrollLink.fadeOut(300);
      }
      if (windowpos > 1) {
        siteHeader.addClass("fixed-header");
      } else {
        siteHeader.removeClass("fixed-header");
      }
    }
  }
  headerStyle();


  //grid-list view tab
  document.addEventListener("DOMContentLoaded", function () {
    var gridBtn = document.querySelector(".btn-view.grid");
    var listBtn = document.querySelector(".btn-view.list");
    var cardContainer = document.querySelector(".list-car-grid");

    // Set default as grid view
    // cardContainer.classList.add("grid-view");

    gridBtn.addEventListener("click", function (e) {
      e.preventDefault();
      gridBtn.classList.add("active");
      listBtn.classList.remove("active");

      // cardContainer.classList.add("grid-view");
      cardContainer.classList.remove("list-car-list");
    });

    listBtn.addEventListener("click", function (e) {
      e.preventDefault();
      listBtn.classList.add("active");
      gridBtn.classList.remove("active");

      cardContainer.classList.add("list-car-list");
      cardContainer.classList.remove("grid-view");
    });
  });

  // Elements Animation
  if ($(".wow").length) {
    var wow = new WOW({
      boxClass: "wow", // animated element css class (default is wow)
      animateClass: "animated", // animation css class (default is animated)
      offset: 0, // distance to the element when triggering the animation (default is 0)
      mobile: false, // trigger animations on mobile devices (default is true)
      live: true, // act on asynchronously loaded content (default is true)
    });
    wow.init();
  }


  var sidebarToggle = function () {
    $(".sidebar-handle").click(function () {
      var args = { duration: 300 };
      $(this)
        .parent(".wrap-sidebar-dk")
        .find(".inventory-sidebar")
        .slideToggle(args);
    });
  };

  $(window).on("scroll", function () {
    headerStyle();
  });

  var tooltipTriggerList = [].slice.call(
    document.querySelectorAll('[data-bs-toggle="tooltip"]')
  );
  var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
    return new bootstrap.Tooltip(tooltipTriggerEl);
  });


  //=========NICE SELECT=========
  $('.select_js').niceSelect();
  
    // go to top
  $('.scroll-to-top').click(function (e) {
    e.preventDefault();

    const $img = $(this).find('img');
    $img.addClass('animate');

    setTimeout(() => {
      $('html, body').animate({ scrollTop: 0 }, 800);
      setTimeout(() => $img.removeClass('animate'), 5000);
    }, 5000);
  });

  // select2 dropdown
    $("#maker").chosen({no_results_text: "Oops, nothing found!"}); 
    $("#model").chosen({no_results_text: "Oops, nothing found!"}); 
    $("#Btype").chosen({no_results_text: "Oops, nothing found!"});
    $("#year").chosen({no_results_text: "Oops, nothing found!"}); 
    $("#kilometer").chosen({no_results_text: "Oops, nothing found!"}); 
    $("#price").chosen({no_results_text: "Oops, nothing found!"});
    $("#status").chosen({no_results_text: "Oops, nothing found!"});

  var goTop = function () {
    if ($(".scroll-to-target").length) {
      $(".scroll-to-target").on("click", function () {
        var target = $(this).attr("data-target");
        // animate
        $("html, body").animate(
          {
            scrollTop: $(target).offset().top,
          },
          1500
        );
      });
    }
  };

  /* ==========================================================================
   When document is loading, do
   ========================================================================== */

  $(window).on("load", function () {
    sidebarToggle();
    goTop();
  });
})(window.jQuery);