
$(document).ready(function ($) {
    
    /*function ShowNewBlockForCardPaymentType() {*/
    $('input.radioButton').click(function () {
        var items = document.getElementsByName('radioButton');
        var v = null;
        for (var i = 0; i < items.length; i++) {
            if (items[i].checked) {
                v = items[i].id;
                break;
            }
        }
        if (v == "Visa / MasterCard") {
            document.getElementById('blockForCardPayment').style.display = 'block';
        }
        else {
            document.getElementById('blockForCardPayment').style.display = 'none';
        }
       
        $("#returnCheckedRbValue").val(v);

    });

    $('#phone').mask('8(999) 999-99-99');
    $('#maskAccountNumber').mask('9999 9999 9999 9999');
    $('#maskaccountDate').mask('99/99');
    $('#accountCvv').mask('999');
});