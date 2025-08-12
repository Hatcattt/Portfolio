window.initScrollTopButton = () => {
    const btn = document.getElementById("scrollTopBtn");

    window.addEventListener("scroll", () => {
        if (document.documentElement.scrollTop > 100) {
            btn.style.display = "block";
        } else {
            btn.style.display = "none";
        }
    });
};

window.scrollToTop = () => {
    window.scrollTo({ top: 0, behavior: 'smooth' });
};
