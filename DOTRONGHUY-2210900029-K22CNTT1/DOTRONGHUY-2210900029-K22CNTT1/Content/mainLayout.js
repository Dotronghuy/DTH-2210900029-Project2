window.onload = function () {
    createSidebar();

    const isAdmin = document.body.getAttribute('data-is-admin') === 'True';

    const adminLink = document.getElementById("user-link");

    if (!isAdmin && adminLink) {
        adminLink.style.display = "none";
    }
};

function createSidebar() {
    const sidebarHTML = `
        <div id="sidebar" class="sidebar">
            <div class="close-item">&times;</div>
            <a id="user-link" href="/DTHquan_tri/Index">Quản trị</a>
            <a id="products-link" href="/DTHkhach_hang/Index">Khách hàng</a>
            <a id="catalog-link" href="/DTHdanh_muc_xe_hoi/Index">Chi tiết danh mục xe</a>
            <a id="orders-link" href="/DTHdon_hang/Index">Đơn hàng</a>
            <a id="payment-link" href="/DTHthanh_toan/Index">Thanh toán</a>
        </div>
    `;

    const sidebarContainer = document.createElement("div");
    sidebarContainer.innerHTML = sidebarHTML;
    document.body.appendChild(sidebarContainer);

    const closeButton = document.querySelector(".close-item");
    const sidebar = document.getElementById("sidebar");
    const openButton = document.querySelector(".open-item");
    const admin = document.getElementById("admin");

    function openNav() {
        sidebar.style.width = "350px";
        admin.style.visibility = "hidden";
    }

    function closeNav() {
        sidebar.style.width = "0";
        admin.style.visibility = "visible";
    }

    openButton.addEventListener("click", openNav);
    closeButton.addEventListener("click", closeNav);
}
