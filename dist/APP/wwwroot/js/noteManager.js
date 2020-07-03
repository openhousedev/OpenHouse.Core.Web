var _noteParentId = null;
var _noteParentType = null;
var noteId = null;

//Display modal to create new note
function createNote(noteParentId, noteParentType) {
    _noteId = null;
    _noteParentId = noteParentId;
    _noteParentType = noteParentType;
    $('#modalNoteCreate').modal('show');
}

//Load existing note and display in modal for edit
function editNote(noteId, noteParentId, noteParentType) {
    _noteId = noteId;
    _noteParentId = noteParentId;
    _noteParentType = noteParentType;

    $.LoadingOverlay("show");

    getNote(noteId)
        .then(data => { //On get note success
            $('#txtNoteText').val(data.note1); //Display note text
            $.LoadingOverlay("hide");
            $('#modalNoteCreate').modal('show');

        })
        .catch(error => { //On get note error
            $.LoadingOverlay("hide");
            alert('Error loading note');
        });
}

//Load existing note and display in modal readonly
function viewNote(noteId) {
    $.LoadingOverlay("show");
    getNote(noteId)
        .then(data => { //On get note success
            $('#txtNoteText').val(data.note1); //Display note text
            $('#txtNoteText').attr('disabled', 'disabled'); //Set textarea read only
            $('#btnSaveNote').hide(); //Hide save note button
            $.LoadingOverlay("hide");
            $('#modalNoteCreate').modal('show');
        })
        .catch(error => { //On get note error
            $.LoadingOverlay("hide");
            alert('Error loading note');
        });
}

//Process note for saving
function processNote() {
    var noteText = $('#txtNoteText').val().trim();
    $.LoadingOverlay("show");

    if (_noteId == null) { //If existing note Id note set, create new note
        postNote(noteText)
            .then(data => { //On post note success
                postNoteParent(data.noteId) //Create parent object (e.g. PropertyNote or TenancyNote)
                    .then(data => {
                        clearNoteModal();
                        location.reload(); //Reload form on completion
                    })
                    .catch(error => {
                        console.log(error.message);
                        $.LoadingOverlay("hide");
                        alert('Error assigning note to parent');
                    });
            })
            .catch(error => { //On post note error
                console.log(error.message);
                $.LoadingOverlay("hide");
                alert('Error loading note');
            });
    }
    else {
        putNote(noteText) // If existing note Id set, update existing
            .then(data => { //Update note successful
                clearNoteModal();
                location.reload(); //Reload form on completion
            })
            .catch(error => {
                console.log(error.message); //Update note error
                $.LoadingOverlay("hide");
                alert('Error updating note');
            });
    }
}

//Clear down note modal popup
function clearNoteModal() {
    $('#txtNoteText').val('').removeAttr('disabled');
    $('#btnSaveNote').show();
}

//POST PropertyNote or TenancyNote
function postNoteParent(noteId) {
    return new Promise((resolve, reject) => {
        var sendData;

        if (_noteParentType == 'PropertyNote') { //Assign note to property
            _apiLocation = _apiLocation + 'api/PropertyNotes';

            sendData = {
                propertyId: _noteParentId,
                noteId: noteId
            };
        }
        else if (_noteParentType == 'TenancyNote') { //Assign note to tenancy
            _apiLocation = _apiLocation + 'api/TenancyNotes';

            sendData = {
                tenancyId: _noteParentId,
                noteId: noteId
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

//POST note object
function postNote(noteText) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            note1: noteText,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/Notes',
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

//PUT existing note object
function putNote(noteText) {
    return new Promise((resolve, reject) => {
        var recordDT = new moment().toISOString();

        var sendData = {
            noteId: _noteId,
            note1: noteText,
            createdByUserId: _loggedInUserId,
            createdDT: recordDT,
            updatedByUserID: _loggedInUserId,
            updatedDT: recordDT
        };

        var sendJson = JSON.stringify(sendData);

        $.ajax({
            url: _apiLocation + 'api/Notes/' + _noteId,
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

//GET existing note object
function getNote(noteId) {
    return new Promise((resolve, reject) => {
        $.ajax({
            url: _apiLocation + 'api/Notes/' + noteId,
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