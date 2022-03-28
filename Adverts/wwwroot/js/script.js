function setUpDefaultProductsOption(prodElem) {
    prodElem.append($('<option/>', {
        value: "",
        text: "-- wybierz rodzaj produktu --"
    }));
}