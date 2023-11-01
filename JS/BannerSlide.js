$(document).ready(function () {
    // Configure the slider settings
    var slideIndex = 0;
    var slides = $(".banner-slide");
    var slideCount = slides.length;

    function nextSlide() {
        slides.eq(slideIndex).fadeOut(500);
        slideIndex = (slideIndex + 1) % slideCount;
        slides.eq(slideIndex).fadeIn(500);
    }

    // Auto-slide every 3 seconds
    setInterval(nextSlide, 6000);
});