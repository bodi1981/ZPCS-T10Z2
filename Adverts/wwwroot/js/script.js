function setUpDefaultProductsOption(prodElem) {
    prodElem.append($('<option/>', {
        value: "",
        text: "-- wybierz rodzaj produktu --"
    }));
}

$('#category').change(function () {
    var selectedCategory = $("#category").val();
    var productsSelect = $('#product');
    productsSelect.empty();

    if (selectedCategory != null && selectedCategory != '') {
        productsSelect.prop("disabled", false);
        $.getJSON('/Advert/GetProducts', { categoryId: selectedCategory }, function (products) {
            if (products != null && !jQuery.isEmptyObject(products)) {
                setUpDefaultProductsOption(productsSelect);

                $.each(products, function (index, product) {
                    productsSelect.append($('<option/>', {
                        value: product.id,
                        text: product.name
                    }));
                });
            };
        });
    } else {
        productsSelect.prop("disabled", true);
        setUpDefaultProductsOption(productsSelect);
    }
});