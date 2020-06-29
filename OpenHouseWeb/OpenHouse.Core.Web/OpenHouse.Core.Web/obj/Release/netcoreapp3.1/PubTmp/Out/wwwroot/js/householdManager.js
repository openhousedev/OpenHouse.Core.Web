var _tenancyId = null;
var _tenancyHouseholdId = null;

//Display modal to create new TenancyHousehold record
function createTenancyHousehold(tenancyId) {
    _tenancyHouseholdId = null;
    _tenancyId = tenancyId;
    $('#modalTenancyHouseholdCreate').modal('show');
}

//Load existing TenancyHousehold record and display in modal for edit
function editTenancyHousehold(tenancyHouseholdId) {
    _tenancyHouseholdId = tenancyHouseholdId;

    $.LoadingOverlay("show");

    getTenancyHousehold(tenancyHouseholdId)
        .then(data => { //On get note success
            _tenancyId = data.tenancyId;
            $('#selLeadTenantRelationship').val(data.leadTenantRelationshipId); //Set tenant relationship values
            $('#selJointTenantRelationship').val(data.jointTenantRelationshipId);

            getPerson(data.personId) //Get person record
                .then(data => {
                    $('#selectedHouseholdPersonId').val(data.personId); //Set personId value
                    $('#selectedHouseholdPersonDisplay').val(data.firstName + ' ' + data.surname); //Display person name
                    $.LoadingOverlay("hide"); //Hide loader
                    $('#modalTenancyHouseholdCreate').modal('show'); //Show modal popul
                })
                .catch(error => { //On get Person error
                    $.LoadingOverlay("hide");
                    alert('Error retrieving household member person record')
                });
        })
        .catch(error => { //On get TenancyHousehold error
            $.LoadingOverlay("hide");
            alert('Error loading Tenancy Household');
        });
}

//Process note for saving
function processTenancyHousehold() {
    var leadTenantRelationshipId = $('#selLeadTenantRelationship').val();
    var jointTenantRelationshipId = $('#selJointTenantRelationship').val();
    var personId = $('#selectedHouseholdPersonId').val();

    $.LoadingOverlay("show");

    if (_tenancyHouseholdId == null) { //If existing note Id note set, create new note
        postTenancyHousehold(_tenancyId, personId, leadTenantRelationshipId, jointTenantRelationshipId)
            .then(data => { //On post tenancy household success
                clearTenancyHouseholdModal();
                location.reload(); //Reload form on completion
            })
            .catch(error => { //On post note error
                console.log(error.message);
                $.LoadingOverlay("hide");
                alert('Error creating record');
            });
    }
    else {
        putTenancyHousehold(_tenancyHouseholdId, _tenancyId, personId, leadTenantRelationshipId, jointTenantRelationshipId)
            .then(data => { //On put tenancy household success
                clearTenancyHouseholdModal();
                location.reload(); //Reload form on completion
            })
            .catch(error => { //On put tenancy household error
                console.log(error.message);
                $.LoadingOverlay("hide");
                alert('Error updating record');
            });
    }
}

function showDeleteTenancyHouseholdConfirmation(tenancyHouseholdId) {
    _tenancyHouseholdId = tenancyHouseholdId;
    $('#modalTenancyHouseholdDelete').modal('show');
}

function confirmDeleteTenancyHousehold() {
    $.LoadingOverlay("show");

    deleteTenancyHousehold(_tenancyHouseholdId)
        .then(data => { //On deletion success
            location.reload(); //Reload form on completion
        })
        .catch(error => { //On deletion error
            console.log(error.message);
            $.LoadingOverlay("hide");
            alert('Error loading note');
        });
}

//Clear down TenancyHousehold modal popup
function clearTenancyHouseholdModal() {
    $('#selLeadTenantRelationship').val('1');
    $('#selJointTenantRelationship').val('1');
    $('#selectedHouseholdPersonId').val('');
    $('#selectedHouseholdPersonDisplay').val('');

}

//POST TenancyHousehold object
function postTenancyHousehold(tenancyId, personId, leadTenantRelationshipId, jointTenantRelationshipId) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            tenancyId: tenancyId,
            personId: personId,
            leadTenantRelationshipId: leadTenantRelationshipId,
            jointTenantRelationshipId: jointTenantRelationshipId,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/TenancyHouseholds',
            type: 'POST',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            success: function (data) { //Get note success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(jqXHR.responseText); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//PUT existing TenancyHousehold object
function putTenancyHousehold(tenancyHouseholdId, tenancyId, personId, leadTenantRelationshipId, jointTenantRelationshipId) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            tenancyHouseholdId: tenancyHouseholdId,
            tenancyId: tenancyId,
            personId: personId,
            leadTenantRelationshipId: leadTenantRelationshipId,
            jointTenantRelationshipId: jointTenantRelationshipId,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/TenancyHouseholds/' + tenancyHouseholdId,
            type: 'PUT',
            contentType: 'application/json',
            data: sendJson,
            dataType: 'json',
            success: function (data) { //Get note success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(jqXHR.responseText); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//GET existing TEnancyHousehold object
function getTenancyHousehold(tenancyHouseholdId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/TenancyHouseholds/' + tenancyHouseholdId,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
            success: function (data) { //Get note success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(errorThrown); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//DELETE existing TEnancyHousehold object
function deleteTenancyHousehold(tenancyHouseholdId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/TenancyHouseholds/' + tenancyHouseholdId,
            type: 'DELETE',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
            success: function (data) { //Get note success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(errorThrown); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}

//GET person object
function getPerson(personId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/Persons/' + personId,
            type: 'GET',
            contentType: 'application/json',
            dataType: 'json',
            cache: true,
            success: function (data) { //Get note success - return data
                resolve(data); //Return data
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(errorThrown); //Log error
                reject(errorThrown); //Return
            }
        });
    });
}