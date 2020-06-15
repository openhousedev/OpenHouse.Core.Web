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
            $('#txtAlertText').val(data.alert1); //Display alert text
            $('#txtAlertText').attr('disabled', 'disabled'); //Set textarea read only
            $('#btnSaveAlert').hide(); //Hide save alert button
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
    var alertText = $('#txtAlertText').val().trim();
    $.LoadingOverlay("show");

    if (_alertId == null) { //If existing alert Id alert set, create new alert
        postAlert(alertText)
            .then(data => { //On post alert success
                clearAlertModal();
                location.reload(); //Reload form on completion
            })
            .catch(error => { //On post alert error
                console.log(error.message);
                $.LoadingOverlay("hide");
                alert('Error loading alert');
            });
    }
    else {
        putAlert(alertText) // If existing alert Id set, update existing
            .then(data => { //Update alert successful
                clearAlertModal();
                location.reload(); //Reload form on completion
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
    $('#txtAlertText').val('').removeAttr('disabled');
    $('#btnSaveAlert').show();
}

//POST PropertyAlert or TenancyAlert
function postAlertParent(alertId) {
    return new Promise((resolve, reject) => {
        var sendData;

        if (_alertParentType == 'PropertyAlert') { //Assign alert to property
            _apiLocation = _apiLocation + 'api/PropertyAlerts';

            sendData = {
                propertyId: _alertParentId,
                alertId: alertId
            };
        }
        else if (_alertParentType == 'TenancyAlert') { //Assign alert to tenancy
            _apiLocation = _apiLocation + 'api/TenancyAlerts';

            sendData = {
                tenancyId: _alertParentId,
                alertId: alertId
            };
        }

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
function putAlert(alertText, alertTypeId, startDT, endDT) {
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