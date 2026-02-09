
document.body.onscroll = myPopupRelocate;
window.onscroll = myPopupRelocate;

function openOnPagePopup(title, pwidth, pheight) {
    const modal = document.querySelector('.modal-dialog');
    const modalContent = document.querySelector('.modal-content');
    const overlay = document.getElementById("popupOverlay");

    const isMobile = window.innerWidth <= 768;

    // Set modal size
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
    const loader = document.getElementById("pnlloadingpage");
    loader.style.display = "block";
    setTimeout(() => loader.style.display = "none", 500); 
    // Show modal
    overlay.classList.remove("hidden");
    myPopupRelocate();
}

function closePopup() {
    document.body.classList.remove('no-scroll');
    document.getElementById("popupOverlay").classList.add("hidden");   
}

function myPopupRelocate() {
    const popupModal = document.getElementById("popupModal");
    if (!popupModal) return;

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
