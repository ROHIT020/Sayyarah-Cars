//<a class="btn btn-primary btn-sm" href="javascript:void(0);" title="my title" onclick="openCSSPopup('mypopup.aspx','My Page title')">View</a>



document.body.onscroll = myPopupRelocate;
window.onscroll = myPopupRelocate;

var IE = document.all;

cHTML = '<div id="popupOverlay" class="popup-overlay hidden">\
<div class="modal fade show" id="popupModal" tabindex="-1" role="dialog" style="display: block;" aria-labelledby="myExtraLargeModalLabel" aria-modal="true">\
<div class="modal-dialog fullscreenmodal" role="document">\
<div class="modal-content">\
<div class="modal-header">\
<h5 class="modal-title m-0" id="popupTitle">Title</h5>\
<a onclick="closePopup()" class="close">\
<i class="ti ti-x"></i>\
</a>\
</div>\
<div class="modal-body" style="position: relative;">\
<div id="pnlloadingpage" class="loader">\
<center>\
<div class="spinner-border text-primary" role="status"></div><br />\
loading.....\
</center>\
</div>\
<iframe id="popupIframe" class="popup-iframe"></iframe>\
</div>\
</div>\
</div>\
</div>\
</div>'

document.write(cHTML)

function openCSSPopup(url, title, pwidth, pheight) {
    const modal = document.querySelector('.modal-dialog');
    const modalContent = document.querySelector('.modal-content');

    const isMobile = window.innerWidth <= 768;
    // Optional custom size (if not full-screen)
    if (isMobile || !(pwidth && pheight)) {
        modal.style.width = '100vw';
        modal.style.height = '100vh';
        modal.classList.add("is-fullscreen");
        document.body.classList.add('no-scroll');
    } else {
        modal.style.width = pwidth;
        modal.style.height = pheight;
        modal.classList.remove("is-fullscreen");
        document.body.classList.remove('no-scroll');
    }
  

    document.getElementById("popupTitle").innerText = title;

    const iframe = document.getElementById("popupIframe");
    document.getElementById("pnlloadingpage").style.display = "block";

    iframe.onload = function () {
        document.getElementById("pnlloadingpage").style.display = "none";
    };
    iframe.src = url;

    document.getElementById("popupOverlay").classList.remove("hidden");
    myPopupRelocate();
}

function closePopup() {
    document.body.classList.remove('no-scroll');
    document.getElementById("popupOverlay").classList.add("hidden");
    const iframe = document.getElementById("popupIframe");
    iframe.src = ""; // Clear iframe

}

function myPopupRelocate() {
    const popupModal = document.getElementById("popupModal");
    if (!popupModal) return;

    // Skip manual positioning for full-screen behavior
    const isFullscreen = document.querySelector(".modal-dialog").classList.contains("is-fullscreen");
    if (window.innerWidth <= 768 || isFullscreen) {
        popupModal.style.position = "static";
        popupModal.style.left = "0";
        popupModal.style.top = "0";
        return;
    }

    let scrolledX = window.scrollX || document.documentElement.scrollLeft || document.body.scrollLeft || 0;
    let scrolledY = window.scrollY || document.documentElement.scrollTop || document.body.scrollTop || 0;
    let centerX = window.innerWidth || document.documentElement.clientWidth || document.body.clientWidth;
    let centerY = window.innerHeight || document.documentElement.clientHeight || document.body.clientHeight;

    const Divwidth = popupModal.offsetWidth;
    const Divheight = popupModal.offsetHeight;

    const leftOffset = scrolledX + (centerX - Divwidth) / 2;
    const topOffset = scrolledY + (centerY - Divheight) / 2;

    popupModal.style.position = "absolute";
    popupModal.style.left = `${leftOffset}px`;
    popupModal.style.top = `${topOffset}px`;
}