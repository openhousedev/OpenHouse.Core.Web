var _rentLedgerId = null;
var _tenancyId = null;
var _propertyChargeId = null;

//Load existing alert and display in modal readonly
function viewRentLedger(rentLedgerId) {
    $.LoadingOverlay("show");
    getRentLedger(rentLedgerId)
        .then(data => { //On get alert success
            $('#txtRentAccount').text(data.rentAccount);
            $('#txtRentLedgerPeriodStart').text(new moment(data.periodStartDT).format('DD/MM/YYYY'));
            $('#txtRentLedgerPeriodEnd').text(new moment(data.periodEndDT).format('DD/MM/YYYY'));
            $('#txtAmountDue').text(data.charge);
            $('#txtAmountPaid').text(data.amount);

            if (data.paymentDT != null) {
                $('#txtLedgerPaymentDate').text(moment(data.paymentDT).format('DD/MM/YYYY'));
            }

            $('#txtPaymentSource').text(data.source);
            $('#txtPaymentRef').text(data.paymentProviderReference);
            $.LoadingOverlay("hide");
            $('#modalRentLedger').modal('show');
        })
        .catch(error => { //On get alert error
            $.LoadingOverlay("hide");
            alert('Error loading rent ledger item');
        });
}

function showPaymentModal(rentLedgerId, amountDue, propertyChargeId, tenancyId) {
    _rentLedgerId = rentLedgerId;
    _propertyChargeId = propertyChargeId;
    _tenancyId = tenancyId;

    paymentDate = new moment().format('YYYY-MM-DD');
    $('#txtPaymentAmount').val(amountDue);
    $('#txtPaymentDate').val(paymentDate);
    $('#modalPayment').modal('show');
}

function processPayment() {
    var amount = parseFloat($('#txtPaymentAmount').val());
    var paymentDate = new moment($('#txtPaymentDate').val());
    var paymentSource = $('#selPeymentSource').val();
    var paymentRef = $('#txtPaymentProviderRef').val();
    var paymentId = null;

    postPayment(_rentLedgerId, paymentSource, amount, paymentDate, paymentRef, _propertyChargeId, _tenancyId)
        .then(data => {
            paymentId = data.paymentId;
            getRentLedger(_rentLedgerId)
                .then(data => {
                    data.updatedDT = new moment().toISOString();
                    data.paymentId = paymentId;
                    putRentLedger(data)
                        .then(data => {
                            $.LoadingOverlay("hide");
                            location.reload();
                        })
                        .catch(error => {
                            $.LoadingOverlay("hide");
                            alert('Error updating rent ledger');
                        });
                })
                .catch(error => {
                    $.LoadingOverlay("hide");
                    alert('Error retrieving rent ledger record');
                });
        })
        .catch(error => {
            $.LoadingOverlay("hide");
            alert('Error saving payment');
        });
}

function clearRentLedgerModal() {
    $('#modalRentLedger').modal('hide');
    $('#txtRentAccount').text('');
    $('#txtRentLedgerPeriodStart').text('');
    $('#txtRentLedgerPeriodEnd').text('');
    $('#txtAmountDue').text('');
    $('#txtAmountPaid').text('');
    $('#txtLedgerPaymentDate').text('');
    $('#txtPaymentSource').text('');
    $('#txtPaymentSource').text('');
}

function clearPaymentModal() {
    $('#txtPaymentAmount').val('1');
    $('#txtPaymentAmount').val('');
    $('#txtPaymentDate').val(moment().format('YYYY-MM-DD'));
    $('#modalPayment').modal('hide');
}

//GET existing alert object
function getRentLedger(rentLedgerId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/RentLedgers/' + rentLedgerId,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
            success: function (data) { //Get alert success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(errorThrown); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

function postPayment(rentLedgerId, paymentSourceId, amount, paymentDate, paymentRef, propertyChargeId, tenancyId) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            propertyChargeId: propertyChargeId,
            tenancyId: tenancyId,
            paymentSourceId: paymentSourceId,
            amount: amount,
            paymentDT: paymentDate,
            paymentProviderReference: paymentRef,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/Payments',
            type: 'POST',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            success: function (data) { //Get action success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(jqXHR.responseText); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}
//GET existing alert object
function getRentLedger(rentLedgerId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/RentLedgers/' + rentLedgerId,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
            success: function (data) { //Get alert success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(errorThrown); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

function putRentLedger(rentLedgerEntry) {
    return new Promise((resolve, reject) => {
        var sendJson = JSON.stringify(rentLedgerEntry);

        $.ajax({
            url: _apiLocation + 'api/RentLedgers/' + _rentLedgerId,
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