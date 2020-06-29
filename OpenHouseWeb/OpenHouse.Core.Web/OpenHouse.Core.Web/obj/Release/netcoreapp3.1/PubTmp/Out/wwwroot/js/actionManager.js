var _actionId;
var _tenancyId;

//Display modal to create new action
function createAction(tenancyId) {
    _actionId = null;
    _tenancyId = tenancyId;
    _actionId = null;
    $('#modalActionCreate').modal('show');
}

function editAction(actionId, tenancyId) {
    _actionId = actionId;
    _tenancyId = tenancyId;

    $.LoadingOverlay("show");
    getAction(actionId)
        .then(data => {
            $('#selectedUserId').val(data.assignedUserId);
            $('#txtActionDueDate').val(moment(data.actionDueDate).format('YYYY-MM-DD'));
            $('#selActionType').val(data.actionTypeId);
            getUser(data.assignedUserId)
                .then(data => {
                    $('#selectedUserDisplay').val(data.userName);
                    $.LoadingOverlay("hide");
                    $('#modalActionCreate').modal('show');
                })
                .catch(error => {
                    $.LoadingOverlay("hide");
                    alert('Error loading assigned user');
                });
        })
        .catch(error => {
            $.LoadingOverlay("hide");
        });
}

function viewAction(actionId) {
    $.LoadingOverlay("show");
    getAction(actionId)
        .then(data => {
            $('#selectedUserId').val(data.assignedUserId);
            $('#selectedUserId').attr('disabled', true);
            $('#txtActionDueDate').val(moment(data.actionDueDate).format('YYYY-MM-DD'));
            $('#txtActionDueDate').attr('disabled', true);
            $('#selActionType').val(data.actionTypeId);
            $('#btnProcessAction').hide();
            getUser(data.assignedUserId)
                .then(data => {
                    $('#selectedUserDisplay').val(data.userName);
                    $.LoadingOverlay("hide");
                    $('#modalActionCreate').modal('show');
                })
                .catch(error => {
                    $.LoadingOverlay("hide");
                    alert('Error loading assigned user');
                });
        })
        .catch(error => {
            $.LoadingOverlay("hide");
        });
}

function validateAction() {
    var formIsValid = true;
    var aDate = moment($('#txtActionDueDate').val());
    var actionDateIsValid = aDate.isValid();
    var selectedUserID = $('#selectedUserId').val()

    if (!actionDateIsValid) {
        $('#actionUserIdValidationResult').val('Please select a user to assign to.');
        formIsValid = false;
    }
    else {
        $('#actionUserIdValidationResult').val('');
    }

    if (selectedUserID.length == 0) {
        $('#actionDueDateValidationResult').val('Please enter an action due date')
        formIsValid = false;
    }
    else {
        $('#actionDueDateValidationResult').val('')
    }

    return formIsValid;
}

function processAction() {
    var assigneeUserId = $('#selectedUserId').val();
    var dueDate = new moment($('#txtActionDueDate').val());
    var actionType = $('#selActionType').val();

    if (validateAction()) {
        $.LoadingOverlay("show");

        if (_actionId == null) { //If existing action Id not set, create action
            postAction(assigneeUserId, dueDate, actionType)
                .then(data => {
                    clearActionModal();
                    location.reload(); //Reload form on completion
                })
                .catch(error => {
                    console.log(error.message);
                    $.LoadingOverlay("hide");
                    alert('Error creating action');
                });
        }
        else {
            putAction(_actionId, assigneeUserId, dueDate, actionType)
                .then(data => {
                    clearActionModal();
                    location.reload(); //Reload form on completion
                })
                .catch(error => {
                    console.log(error.message);
                    $.LoadingOverlay("hide");
                    alert('Error updating action');
                });
        }
    }
}

//POST action object
function postAction(assigneeUserId, actionDueDate, actionTypeId) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            actionTypeId: actionTypeId,
            tenancyId: _tenancyId,
            assignedUserId: assigneeUserId,
            actionDueDate: actionDueDate,
            actionCompletedDate: null,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/Actions',
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

//PUT existing action object
function putAction(actionId, assigneeUserId, actionDueDate, actionTypeId) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            actionId: actionId,
            actionTypeId: actionTypeId,
            tenancyId: _tenancyId,
            assignedUserId: assigneeUserId,
            actionDueDate: actionDueDate,
            actionCompletedDate: null,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/Actions/' + actionId,
            type: 'PUT',
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

//GET existing action object
function getAction(actionId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/Actions/' + actionId,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
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

function getUser(userId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/Users/' + userId,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
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

//Clear down action modal popup
function clearActionModal() {
    $('#btnProcessAction').show();
    $('#selectedUserId').val('');
    $('#selectedUserId').removeAttr('disabled');
    $('#txtActionDueDate').val('');
    $('#txtActionDueDate').removeAttr('disabled');
    $('#selectedUserDisplay').val('');
    $('#txtActionDueDate').removeAttr('disabled');
    $('#actionUserIdValidationResult').val('');
    $('#actionDueDateValidationResult').val('')
}