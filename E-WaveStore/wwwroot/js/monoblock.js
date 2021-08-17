﻿$(document).ready(function () {
    $('.deleteMonoblock').click(function () {
        var clicked = $(this);
        clicked.attr('disabled', 'disabled');

        var modelName = clicked.attr('data-name');
        var url = '/Monoblock/RemoveMonoblock?modelName=' + modelName;
        console.log(url);

        $.get(url).done(function (answer) {
            if (answer) {
                clicked.closest('.keyTest').remove();
            }
        });
    });


});