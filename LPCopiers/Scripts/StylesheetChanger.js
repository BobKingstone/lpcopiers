$(document).ready(function () {

    var sheet = getCookie();

    //checks for cookie if it exists sets sheet to match value
    if (sheet != "") {
        swapStyleSheet(sheet);
    }
})

function swapStyleSheet(sheet) {
    $("#styles").attr("href", sheet);
    setCookie(sheet);
}

function setCookie(sheet) {
    //delete cookie first to ensure duplicates are not stored
    $.removeCookie('style');
    $.cookie('style', sheet, { expires: 7, path:'/' });
}

function getCookie() {
    var cookieValue = $.cookie('style');

    return cookieValue;
}