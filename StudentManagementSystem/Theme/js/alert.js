var errorBox = ` <div class="note">
            Something went wrong
        </div>`;

function ShowSuccess(stringdata) {
    var box = $('.notification').append(errorBox);
    var note = $('.notification .note').html(stringdata);
    $('.notification .note').addClass("note-success");
    $(box).animate({
        top: "5%"
    },1000);
    setTimeout(function () {
        $(box).remove();
    }, 5000);
}
function ShowError(stringdata) {
    var box = $('.notification').append(errorBox);
    $('.notification .note').html(stringdata);
    $('.notification .note').addClass("note-error");
    $(box).animate({
        top: "5%"
    }, 1000);
    setTimeout(function () {
        $(box).remove();
    }, 5000);
}