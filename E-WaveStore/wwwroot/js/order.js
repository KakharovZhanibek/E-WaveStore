/*
$(document).ready(function () {*/
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
        
    
