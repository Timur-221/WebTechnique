// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
window.addEventListener("load", function () {
    // Устанавливаем ширину полосы загрузки на 100% для начала
    document.getElementById("loading-bar").style.width = "100%";

    // Ждем 500 миллисекунд, затем скрываем полосу загрузки и изменяем цвет на прозрачный
    setTimeout(function () {
        document.getElementById("loading-bar").style.width = "0%";
        document.getElementById("loading-bar").style.backgroundColor = "transparent";
    }, 500);
});