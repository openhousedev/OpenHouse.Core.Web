var _idControlName = null;
var _displayControlName = null;

$(document).ready(function () {
    $("#txtPersonSearch").keyup(function (event) {
        if (event.keyCode === 13) {
            populatePersonSearchResults();
        }
    });
});

//Display  search dialog
function openPersonSeach(idControlName, displayControlName) {
    $('#modalPersonSearch').modal('show');
    _idControlName = idControlName; //Set ID input control name to populate
    _displayControlName = displayControlName; //Set display control name to populate
}

//Populate search results
function populatePersonSearchResults() {
    var searchString = $('#txtPersonSearch').val(); //Get search string

    if (searchString.length > 0) { //Check search string is present

        //JSON object to send
        var sendData = {
            searchString: searchString,
            displayType: 'selector'
        };

        $.ajax({
            url: '/Persons/_PersonSearch',
            contentType: 'application/json',
            type: 'GET',
            data: sendData,
            beforeSend: function () {
                $('#person-search-result').fadeOut();
                $('#person-search-result').LoadingOverlay("show");
            },
            success: function (data) { //AJAX Success
                $('#person-search-result').html(data); //Populate HTML from data
                $('#person-search-result').LoadingOverlay("hide");
                $('#person-search-result').fadeIn(); //Fade in
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(textStatus, errorThrown); //Log error
                $('#person-search-result').LoadingOverlay("hide");
                $('#person-search-result').fadeIn(); //Fade in
                $('#person-search-result').html(''); //Clear search results
                alert('Error loading search results'); //Display error
            }
        });
    }
}

//On person selected
function selectPerson(personId, displayAddress) {
    $(_idControlName).val(personId); //Populate given ID control
    $(_displayControlName).val(displayAddress); //Populate given display control
    clearPersonSearch(); //Clear search results
}

function clearPersonSearch() {
    $('#modalPersonSearch').modal('hide'); //Hide modal
    $('#person-search-result').html(''); //Clear search result HTML
    $('#txtPersonSearch').val(''); //Clear search text box
}