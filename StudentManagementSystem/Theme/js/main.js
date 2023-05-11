$(document).ready(() => {
    var Error = document.getElementById("ViewBagError");
   
    if (Error != undefined) {
        ShowError(Error.innerHTML);
    }
    var Success = document.getElementById("ViewBagSuccess");
    if (Success != undefined) {
        ShowSuccess(Success.innerHTML);
    }
});