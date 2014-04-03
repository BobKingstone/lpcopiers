$(function () {
    $("#visitDate").datepicker({
        minDate: +7, maxDate: +90,
        dateFormat: "dd/mm/yy"
    });
});