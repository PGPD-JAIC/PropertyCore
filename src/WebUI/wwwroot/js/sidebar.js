jQuery(function ($) {
    $(document).ready(function () {
        if ($(window).width() < 945) {
            $(".page-wrapper").removeClass("toggled");
        }
    })
    $(window).resize(function () {
        if ($(window).width() < 945) {
            $(".page-wrapper").removeClass("toggled");
        }
        else {
            $(".page-wrapper").addClass("toggled");
        }
    });
    $(".sidebar-dropdown > a").click(function () {
        $(".sidebar-submenu").slideUp(200);
        if ($(this).parent().hasClass("active")) {
            $(".sidebar-dropdown").removeClass("active");
            $(this).parent().removeClass("active");
        } else {
            $(".sidebar-dropdown").removeClass("active");
            $(this).next(".sidebar-submenu").slideDown(200);
            $(this).parent().addClass("active");
        }
    });
    $("#close-sidebar").click(function () {
        $(".page-wrapper").removeClass("toggled");
    });
    $("#show-sidebar").click(function () {
        $(".page-wrapper").addClass("toggled");
    });
});