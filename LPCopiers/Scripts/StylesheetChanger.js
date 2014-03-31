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
    $.cookie('style', sheet, { expires: 7 });
}


function getCookie() {
    var cookieValue = $.cookie('style');

    return cookieValue;
}
//var d = new Date();
//d.setTime(d.getTime() + (exdays * 7));
//var expires = "expires=" + d.toGMTString();
//var name = "style=" + sheet + ";";
//document.cookie = name + expires;