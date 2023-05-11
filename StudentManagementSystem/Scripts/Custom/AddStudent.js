﻿$(() => {
    $('#TeacherSelection').select2({
        multiple: true
    });

    

    $('#TeacherSelection').on('change', () => {

        $('#Teacher').val($('#TeacherSelection').select2('data').map(el => el.id).join(','));

    });

    if ($('.putValue').length > 0) {
        $('#TeacherSelection').val($('.putValue').val().split(','));
        $('#TeacherSelection').trigger('change');
    }


    $('#country').off().change(function () {
        var id = $('#country').val();
        $('#state').html("");
        $('#City').html("");
        $('#state').html(`<option value="-1">-- Select State --</option>`);
        $('#City').html(`<option value="-1">-- Select City --</option>`);
        $.ajax({
            url: `/Home/GetState/${id}`,
            method: 'GET',
            success: function (res) {
                var data = res;
                data.forEach(ele => {
                    $('#state').append(`<option value="${ele.Id}">${ele.StateName}</option>`);
                });
            }
        });
    });
    $('#state').off().change(function () {
        var id = $('#state').val();
        $('#City').html("");
        $('#City').html(`<option value="-1">-- Select City --</option>`);
        $.ajax({
            url: `/Home/GetCity/${id}`,
            method: 'GET',
            success: function (res) {
                var Data = res;
                Data.forEach(ele => {
                    $('#City').append(`<option value="${ele.Id}">${ele.CityName}</option>`);
                });
            }

        });
    });
})
