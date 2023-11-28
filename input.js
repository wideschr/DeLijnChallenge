'use strict';

window.onload = function() {
    console.log('input.js loaded');

    //get buttons
    var buttonBig = document.getElementById('addBigBus');
    var buttonSmall = document.getElementById('addSmallBus');
    var buttonMedium = document.getElementById('addMediumBus');

    //get the div where to attach the extra field
    var divInputFieldsBig = document.getElementById('inputFieldsBig');
    var divInputFieldsSmall = document.getElementById('inputFieldsSmall');
    var divInputFieldsMedium = document.getElementById('inputFieldsMedium');

    //teller
    var tellerBig = 0;
    var tellerSmall = 0;
    var tellerMedium = 0;

    // add event listener to the button
    buttonBig.addEventListener('click', function(event) {
        event.preventDefault();
        var numInput = document.createElement('input');
        numInput.setAttribute('type', 'number');
        numInput.setAttribute('name', 'b' + tellerBig);
        numInput.setAttribute('id', 'b' + tellerBig);
        numInput.setAttribute('placeholder', 'Bus Nummer');
        divInputFieldsBig.appendChild(numInput);
        tellerBig++;
});
buttonMedium.addEventListener('click', function(event) {
    event.preventDefault();
    var numInput = document.createElement('input');
    numInput.setAttribute('type', 'number');
    numInput.setAttribute('name', 'm' + tellerMedium);
    numInput.setAttribute('id', 'm' + tellerMedium);
    numInput.setAttribute('placeholder', 'Bus Nummer');
    divInputFieldsMedium.appendChild(numInput);
    tellerMedium++;
});
buttonSmall.addEventListener('click', function(event) {
    event.preventDefault();
    var numInput = document.createElement('input');
    numInput.setAttribute('type', 'number');
    numInput.setAttribute('name', 's' + tellerSmall);
    numInput.setAttribute('id', 's' + tellerSmall);
    numInput.setAttribute('placeholder', 'Bus Nummer');
    divInputFieldsSmall.appendChild(numInput);
    tellerSmall++;
});


//Submit form evente
var form = document.getElementById('form');
form.addEventListener('submit', function(event) {
    event.preventDefault();
    var formData = new FormData(form);
    var request = new XMLHttpRequest();
    request.open('POST', 'http://localhost:7180/api/stelplaats');
    request.send(formData);
    request.onload = function() {
        if (request.status === 200) {
            console.log(request.responseText);
            var response = JSON.parse(request.responseText);
            console.log(response);
            if (response.success) {
                console.log('Bus added');
                window.location.href = 'http://localhost:8080/';
            } else {
                console.log('Bus not added');
            }
        } else {
            console.log('Error');
        }
    };
});


};