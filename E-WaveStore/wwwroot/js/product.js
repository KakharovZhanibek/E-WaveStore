$(document).ready(function () {
    $('.deleteProduct').click(function () {
        var clicked = $(this);
        clicked.attr('disabled', 'disabled');

        var modelName = clicked.attr('data-name');
        var url = '/Product/RemoveProduct?modelName=' + modelName;
        console.log(url);

        $.get(url).done(function (answer) {
            if (answer) {
                clicked.closest('.deleteCard').remove();
            }
        });
    });
});