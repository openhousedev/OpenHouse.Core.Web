var _tenancyId = null;
var _alertId = null;

//Display modal to create new alert
function createAlert(tenancyId) {
    _alertId = null;
    _tenancyId = tenancyId;
    $('#modalAlertCreate').modal('show');
}

//Load existing alert and display in modal for edit
function editAlert(alertId, tenancyId) {
    _alertId = alertId;
    _tenancyId = tenancyId;

    $.LoadingOverlay("show");

    getAlert(alertId)
        .then(data => { //On get alert success
            $('#selAlertTypeId').val(data.alertTypeId);
            $('#txtAlertText').val(data.alertText); //Display alert text
            $('#txtAlertStartDate').val(new moment(data.startDT).format('YYYY-MM-DD'));
            $('#txtAlertEndDate').val(new moment(data.endDT).format('YYYY-MM-DD'));
            $.LoadingOverlay("hide");
            $('#modalAlertCreate').modal('show');

        })
        .catch(error => { //On get alert error
            $.LoadingOverlay("hide");
            alert('Error loading alert');
        });
}

//Load existing alert and display in modal readonly
function viewAlert(alertId) {
    $.LoadingOverlay("show");
    getAlert(alertId)
        .then(data => { //On get alert success
            $('#selAlertTypeId').val(data.alertTypeId);
            $('#selAlertTypeId').attr('disabled', 'disabled');
            $('#txtAlertText').val(data.alertText); //Display alert text
            $('#txtAlertText').attr('disabled', 'disabled'); //Set textarea read only
            $('#btnSaveAlert').hide(); //Hide save alert button
            $('#txtAlertStartDate').val(new moment(data.startDT).format('YYYY-MM-DD'));
            $('#txtAlertStartDate').attr('disabled', 'disabled');
            $('#txtAlertEndDate').val(new moment(data.endDT).format('YYYY-MM-DD'));
            $('#txtAlertEndDate').attr('disabled', 'disabled');
            $.LoadingOverlay("hide");
            $('#modalAlertCreate').modal('show');
        })
        .catch(error => { //On get alert error
            $.LoadingOverlay("hide");
            alert('Error loading alert');
        });
}

//Process alert for saving
function processAlert() {
    var alertTypeId = $('#selAlertTypeId').val();
    var alertText = $('#txtAlertText').val().trim();
    var startDT = new moment($('#txtAlertStartDate').val()).toISOString();
    var endDT = $('#txtAlertEndDate').val();

    if (endDT.length > 0) {
        endDT = new moment(endDT).toISOString();
    }

    $.LoadingOverlay("show");

    if (_alertId == null) { //If existing alert Id alert set, create new alert
        postAlert(alertText, alertTypeId, startDT, endDT)
            .then(data => { //On post alert success
                postAlertParent(data.alertId, _tenancyId)
                    .then(data => {
                        clearAlertModal();
                        location.reload(); //Reload form on completion
                    })
                    .catch(error => {
                        console.log(error.message);
                        $.LoadingOverlay("hide");
                        alert('Error creating alert parent');
                    })
            })
            .catch(error => { //On post alert error
                console.log(error.message);
                $.LoadingOverlay("hide");
                alert('Error creating alert');
            });
    }
    else {
        putAlert(_alertId, alertText, alertTypeId, startDT, endDT) // If existing alert Id set, update existing
            .then(data => { //Update alert successful
                postAlertParent(data.alertId, _tenancyId)
                    .then(data => {
                        clearAlertModal();
                        location.reload(); //Reload form on completion
                    })
                    .catch(error => {
                        console.log(error.message);
                        $.LoadingOverlay("hide");
                        alert('Error creating alert parent');
                    })
            })
            .catch(error => {
                console.log(error.message); //Update alert error
                $.LoadingOverlay("hide");
                alert('Error updating alert');
            });
    }
}

//Clear down alert modal popup
function clearAlertModal() {
    $('#selAlertTypeId').val('1');
    $('#selAlertTypeId').removeAttr('disabled');
    $('#txtAlertText').val('').removeAttr('disabled');
    $('#txtAlertStartDate').val(new moment().format('YYYY-MM-DD'));
    $('#txtAlertStartDate').removeAttr('disabled');
    $('#txtAlertEndDate').val('');
    $('#txtAlertEndDate').removeAttr('disabled');
    $('#btnSaveAlert').show();
}

//POST PropertyAlert or TenancyAlert
function postAlertParent(alertId, tenancyId) {
    return new Promise((resolve, reject) => {
        var sendData;

        _apiLocation = _apiLocation + 'api/TenancyAlerts';

        sendData = {
            tenancyId: tenancyId,
            alertId: alertId
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation,
            type: 'POST',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            cache: true,
            success: function (data) { //AJAX Success
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(errorThrown); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//POST alert object
function postAlert(alertText, alertTypeId, startDT, endDT) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            alertText: alertText,
            alertTypeId: alertTypeId,
            startDT: startDT,
            endDT: endDT,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/Alerts',
            type: 'POST',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            success: function (data) { //Get alert success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(jqXHR.responseText); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//PUT existing alert object
function putAlert(alertId, alertText, alertTypeId, startDT, endDT) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            alertId: _alertId,
            alertText: alertText,
            alertTypeId: alertTypeId,
            startDT: startDT,
            endDT: endDT,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/Alerts/' + _alertId,
            type: 'PUT',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            success: function (data) { //Get alert success - return data
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
function getAlert(alertId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/Alerts/' + alertId,
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