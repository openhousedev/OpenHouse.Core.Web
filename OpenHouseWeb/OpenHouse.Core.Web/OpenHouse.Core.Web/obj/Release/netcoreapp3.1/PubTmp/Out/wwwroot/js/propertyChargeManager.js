var _propertyId = null;
var _propertyChargeId = null;

//Display modal to create new propertyCharge
function createPropertyCharge(propertyId) {
    _propertyChargeId = null;
    _propertyId = propertyId;
    $('#modalPropertyChargeCreate').modal('show');
}

//Load existing propertyCharge and display in modal for edit
function editPropertyCharge(propertyChargeId, propertyId) {
    _propertyChargeId = propertyChargeId;
    _propertyId = propertyId;

    $.LoadingOverlay("show");

    getPropertyCharge(propertyChargeId)
        .then(data => { //On get propertyCharge success
            $('#selRentAccountId').val(data.rentAccountId);
            $('#txtPropertyChargeValue').val(data.charge); //Display propertyCharge text
            $('#txtPropertyChargeStartDate').val(new moment(data.startDT).format('YYYY-MM-DD'));
            $('#txtPropertyChargeEndDate').val(new moment(data.endDT).format('YYYY-MM-DD'));
            $.LoadingOverlay("hide");
            $('#modalPropertyChargeCreate').modal('show');

        })
        .catch(error => { //On get propertyCharge error
            $.LoadingOverlay("hide");
            alert('Error loading Property Charge');
        });
}

//Load existing propertyCharge and display in modal readonly
function viewPropertyCharge(propertyChargeId, propertyId) {
    $.LoadingOverlay("show");
    getPropertyCharge(propertyChargeId)
        .then(data => { //On get propertyCharge success
            $('#selRentAccountId').val(data.rentAccountId); //Select rend account id
            $('#selRentAccountId').attr('disabled', true);
            $('#txtPropertyChargeValue').val(data.chargeAmount); //Display propertyCharge amount
            $('#txtPropertyChargeValue').attr('disabled', true);
            $('#txtPropertyChargeStartDate').val(new moment(data.startDT).format('YYYY-MM-DD')); //Display property charge start date
            $('#txtPropertyChargeStartDate').attr('disabled', true);
            $('#txtPropertyChargeEndDate').val(new moment(data.endDT).format('YYYY-MM-DD')); //Display property charge end date
            $('#txtPropertyChargeStartDate').attr('disabled', true);
            $('#btnSavePropertyCharge').hide(); //Hide save propertyCharge button
            $.LoadingOverlay("hide");
            $('#modalPropertyChargeCreate').modal('show');

        })
        .catch(error => { //On get propertyCharge error
            $.LoadingOverlay("hide");
            alert('Error loading Property Charge');
        });
}

//Process propertyCharge for saving
function processPropertyCharge() {

    var rentAccountId = $('#selRentAccountId').val();
    var chargeAmount = $('#txtPropertyChargeValue').val();

    if (chargeAmount.length == 0) {
        $('#txtPropertyChargeValidationResult').text('Please enter valid charge amount');
    }
    else {
        var startDT = new moment($('#txtPropertyChargeStartDate').val()).set({ hour: 0, minute: 0, second: 0, millisecond: 0 }).format('YYYY-MM-DD');
        var endDT = $('#txtPropertyChargeEndDate').val();

        if (endDT.length > 0) {
            endDT = new moment(endDT).set({ hour: 0, minute: 0, second: 0, millisecond: 0 }).format('YYYY-MM-DD');
        }
        if (isNaN(chargeAmount)) {
            $('#txtPropertyChargeValidationResult').text('Invalid charge amount')

        }
        else {
            propertyChargeAmount = parseFloat(chargeAmount);

            $.LoadingOverlay("show");

            if (_propertyChargeId == null) { //If existing propertyCharge Id propertyCharge set, create new propertyCharge
                postPropertyCharge(rentAccountId, _propertyId, chargeAmount, startDT, endDT)
                    .then(data => { //On post propertyCharge success
                        clearPropertyChargeModal();
                        location.reload(); //Reload form on completion
                    })
                    .catch(error => { //On post propertyCharge error
                        console.log(error.message);
                        $.LoadingOverlay("hide");
                        alert('Error creating propertyCharge');
                    });
            }
            else {
                putPropertyCharge(_propertyChargeId, rentAccountId, _propertyId, chargeAmount, startDT, endDT) // If existing propertyCharge Id set, update existing
                    .then(data => { //Update propertyCharge successful
                        clearPropertyChargeModal();
                        location.reload(); //Reload form on completion
                    })
                    .catch(error => {
                        console.log(error.message); //Update propertyCharge error
                        $.LoadingOverlay("hide");
                        alert('Error updating propertyCharge');
                    });
            }
        }
    }
}

//Clear down propertyCharge modal popup
function clearPropertyChargeModal() {
    $('#selRentAccountId').removeAttr('disabled').val('1');
    $('#txtPropertyChargeText').val('').removeAttr('disabled');
    $('#txtPropertyChargeStartDate').val(new moment().format('YYYY-MM-DD')).removeAttr('disabled');;
    $('#txtPropertyChargeEndDate').val('').removeAttr('disabled');;
    $('#btnSavePropertyCharge').show();
}

//POST propertyCharge object
function postPropertyCharge(rentAccountId, propertyId, chargeAmount, startDT, endDT) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            propertyId: propertyId,
            rentAccountId: rentAccountId,
            charge: chargeAmount,
            startDT: startDT,
            endDT: endDT,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/PropertyCharges',
            type: 'POST',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            success: function (data) { //Get propertyCharge success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(jqXHR.responseText); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//PUT existing propertyCharge object
function putPropertyCharge(propertyChargeId, rentAccountId, propertyId, chargeAmount, startDT, endDT) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            propertyChargeId: propertyChargeId,
            propertyId: propertyId,
            rentAccountId: rentAccountId,
            charge: chargeAmount,
            startDT: startDT,
            endDT: endDT,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };


        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/PropertyCharges/' + _propertyChargeId,
            type: 'PUT',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            success: function (data) { //Get propertyCharge success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(jqXHR.responseText); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//GET existing propertyCharge object
function getPropertyCharge(propertyChargeId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/PropertyCharges/' + propertyChargeId,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
            success: function (data) { //Get propertyCharge success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(errorThrown); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}