/// <reference path="angular.js" />
/// <reference path="C:\Apache24\htdocs\JavaScript\DOM\js\jquery-2.1.4.js" />
/// <reference path="angular-animate.js" />

$(document).ready(function () {

    $(".thumbnail").mouseenter(function () {
        $(this).css('background-color', '#2EFE9A');
    });

    $(".thumbnail").mouseleave(function () {
        $(this).css('background-color', '#ffffff');
    });

});
