$(function () {

    $('.list-group-item').on('click', function () {
        $('.fas:not(.fa-check-circle, .fa-check-circle)', this)
            .toggleClass('fa-chevron-right')
            .toggleClass('fa-chevron-down');
    });

});