$(document).ready(function () {
    $('.deleteProduct').click(function () {
        var clicked = $(this);    
        
        if (confirm("Are you sure?")) {
            clicked.attr('disabled', 'disabled');
            var modelName = clicked.attr('data-name');
            var url = '/Product/RemoveProduct?modelName=' + modelName;
            console.log(url);

            $.get(url).done(function (answer) {
               
            });
        }

    });

    $('#getCheckedValues').click(function () {

        var minPrice = $('#minPrice').val(); // +
        var maxPrice = $('#maxPrice').val(); // +
        var categoryName = $('#categoryName').attr('data-name');

        var checkedCheckboxes = document.getElementsByClassName("inputClass");
        var brandNames = "";
        for (var index = 0; index < checkedCheckboxes.length; index++) {
            if (checkedCheckboxes[index].checked) {
                console.log(checkedCheckboxes[index].value);
                brandNames += checkedCheckboxes[index].value;
                brandNames += ", ";
            }
        }

        var url = '/Product/FilterProductbyPriceAndBrandName?categoryName=' + categoryName
            + '&minPrice=' + minPrice + '&maxPrice=' + maxPrice + '&brandNames=' + brandNames;

        $.get(url).done(function (answer) {
            if (answer) {

                window.location = url;
                console.log("success");
            }
        });

    });
});

/*

 function getCheckedCheckBoxes() {
  var selectedCheckBoxes = document.querySelectorAll('input.checkbox:checked');

  var checkedValues = Array.from(selectedCheckBoxes).map(cb => cb.value);

  console.log(checkedValues);

  return checkedValues; // для использования в нужном месте
}

 */


/*
 * 
 * $('.deleteProduct').click(function () {
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

 function getCheckedCheckBoxes() {
  var checkboxes = document.getElementsByClassName('checkbox');
  var checkboxesChecked = []; // можно в массиве их хранить, если нужно использовать
  for (var index = 0; index < checkboxes.length; index++) {
     if (checkboxes[index].checked) {
        checkboxesChecked.push(checkboxes[index].value); // положим в массив выбранный
        alert(checkboxes[index].value); // делайте что нужно - это для наглядности
     }
  }
  return checkboxesChecked; // для использования в нужном месте
}

 */

