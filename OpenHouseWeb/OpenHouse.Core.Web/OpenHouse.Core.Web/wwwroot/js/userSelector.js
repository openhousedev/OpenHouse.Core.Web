var _idControlName = null;
var _displayControlName = null;

$(document).ready(function () {
    $("#txtUserSearch").keyup(function (event) {
        if (event.keyCode === 13) {
            populateUserSearchResults();
        }
    });
});

//Display  search dialog
function openUserSeach(idControlName, displayControlName) {
    $('#modalUserSearch').modal('show');
    _idControlName = idControlName; //Set ID input control name to populate
    _displayControlName = displayControlName; //Set display control name to populate
}

//Populate search results
function populateUserSearchResults() {
    var searchString = $('#txtUserSearch').val(); //Get search string

    if (searchString.length > 0) { //Check search string is present

        //JSON object to send
        var sendData = {
            searchString: searchString,
            displayType: 'selector'
        };

        $.ajax({
            url: '/Users/_UserSearch',
            contentType: 'application/json',
            type: 'GET',
            data: sendData,
            beforeSend: function () {
                $('#user-search-result').fadeOut();
                $('#user-search-result').LoadingOverlay("show");
            },
            success: function (data) { //AJAX Success
                $('#user-search-result').html(data); //Populate HTML from data
                $('#user-search-result').LoadingOverlay("hide");
                $('#user-search-result').fadeIn(); //Fade in
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(textStatus, errorThrown); //Log error
                $('#user-search-result').LoadingOverlay("hide");
                $('#user-search-result').fadeIn(); //Fade in
                $('#user-search-result').html(''); //Clear search results
                alert('Error loading search results'); //Display error
            }
        });
    }
}

//On user selected
function selectUser(userId, displayAddress) {
    $(_idControlName).val(userId); //Populate given ID control
    $(_displayControlName).val(displayAddress); //Populate given display control
    clearUserSearch(); //Clear search results
}

function clearUserSearch() {
    $('#modalUserSearch').modal('hide'); //Hide modal
    $('#user-search-result').html(''); //Clear search result HTML
    $('#txtUserSearch').val(''); //Clear search text box
}