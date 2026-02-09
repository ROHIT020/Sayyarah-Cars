// Stop propagation on dropdown-menu with class 'stop'
try {
  var dropdownMenus = document.querySelectorAll(".dropdown-menu.stop");
  dropdownMenus.forEach(function (menu) {
    menu.addEventListener("click", function (e) {
      e.stopPropagation();
    });
  });
} catch (e) {}

// Initialize lucide icons
try {
  lucide.createIcons();
} catch (e) {}

// Mobile sidebar toggle and responsive behavior
try {
  var collapsedToggle = document.querySelector(".mobile-menu-btn");
  const overlay = document.querySelector(".startbar-overlay");

  const changeSidebarSize = () => {
    if (window.innerWidth >= 310 && window.innerWidth <= 1440) {
      document.body.setAttribute("data-sidebar-size", "collapsed");
    } else {
      document.body.setAttribute("data-sidebar-size", "default");
    }
  };

  if (collapsedToggle) {
    collapsedToggle.addEventListener("click", () => {
      const size = document.body.getAttribute("data-sidebar-size");
      document.body.setAttribute("data-sidebar-size", size === "collapsed" ? "default" : "collapsed");
    });
  }

  if (overlay) {
    overlay.addEventListener("click", () => {
      document.body.setAttribute("data-sidebar-size", "collapsed");
    });
  }

  window.addEventListener("resize", changeSidebarSize);
  changeSidebarSize();
} catch (e) {}

// Bootstrap tooltip and popover initialization
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
})


// Sticky topbar on scroll
function windowScroll() {
  const topbar = document.getElementById("topbar-custom");
  if (topbar) {
    if (document.body.scrollTop >= 50 || document.documentElement.scrollTop >= 50) {
      topbar.classList.add("nav-sticky");
    } else {
      topbar.classList.remove("nav-sticky");
    }
  }
}
window.addEventListener("scroll", (e) => {
  e.preventDefault();
  windowScroll();
});

// Initialize vertical sidebar menu
const initVerticalMenu = () => {
  const collapses = document.querySelectorAll(".navbar-nav li .active");

  document.querySelectorAll(".navbar-nav li active").forEach(item => {
    item.addEventListener("click", function (e) {
      e.preventDefault();
    });
  });

  collapses.forEach(collapse => {
    collapse.addEventListener("show.bs.active", function (e) {
      const current = e.target.closest(".active.show");
      document.querySelectorAll(".navbar-nav .active.show").forEach(other => {
        if (other !== e.target && other !== current) {
          new bootstrap.Collapse(other).hide();
        }
      });
    });
  });

  const navLinks = document.querySelectorAll(".navbar-nav a");
  navLinks.forEach(link => {
    const currentURL = window.location.href.split(/[?#]/)[0];
    if (link.href === currentURL) {
      link.classList.add("active");
      link.parentNode.classList.add("active");

      let parentCollapse = link.closest(".collapse");
      while (parentCollapse) {
        parentCollapse.classList.add("show");
        const trigger = parentCollapse.parentElement.children[0];
        trigger.classList.add("active");
        trigger.setAttribute("aria-expanded", "true");
        parentCollapse = parentCollapse.parentElement.closest(".collapse");
      }
    }
  });

    // Nice Select
  $('.select_js').niceSelect();

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


  // Scroll to active menu item
  setTimeout(() => {
    const activeLink = document.querySelector(".nav-item li a.active");
    if (activeLink) {
      const container = document.querySelector(".main-nav .simplebar-content-wrapper");
      if (container) {
        const targetScroll = activeLink.offsetTop - 300;
        if (targetScroll > 100) {
          const duration = 600;
          let start = container.scrollTop;
          let change = targetScroll - start;
          let currentTime = 0;
          const increment = 20;

          const animateScroll = () => {
            currentTime += increment;
            let val = easeInOutQuad(currentTime, start, change, duration);
            container.scrollTop = val;
            if (currentTime < duration) {
              setTimeout(animateScroll, increment);
            }
          };

          const easeInOutQuad = (t, b, c, d) => {
            t /= d / 2;
            if (t < 1) return c / 2 * t * t + b;
            t--;
            return -c / 2 * (t * (t - 2) - 1) + b;
          };

          animateScroll();
        }
      }
    }
  }, 200);
};

initVerticalMenu();
