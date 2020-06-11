var _idControlName = null;
var _displayControlName = null;

//Display  search dialog
function openPropertySeach(idControlName, displayControlName) {
    $('#modalPropertySearch').modal('show');
    _idControlName = idControlName; //Set ID input control name to populate
    _displayControlName = displayControlName; //Set display control name to populate
}

//Populate search results
function populatePropertySearchResults() {
    var searchString = $('#txtPropertySearch').val(); //Get search string

    if (searchString.length > 0) { //Check search string is present

        //JSON object to send
        var sendData = {
            searchString: searchString,
            displayType: 'selector'
        };

        $.ajax({
            url: '/Home/_PropertySearch',
            contentType: 'application/json',
            type: 'GET',
            data: sendData,
            beforeSend: function () {
                $('#property-search-result').fadeOut();
                $('#property-search-result').LoadingOverlay("show");
            },
            success: function (data) { //AJAX Success
                $('#property-search-result').html(data); //Populate HTML from data
                $('#property-search-result').LoadingOverlay("hide");
                $('#property-search-result').fadeIn(); //Fade in
            },
            error: function (jqXHR, textStatus, errorThrown) { //AJAX Error
                console.log(textStatus, errorThrown); //Log error
                $('#property-search-result').LoadingOverlay("hide");
                $('#property-search-result').fadeIn(); //Fade in
                $('#property-search-result').html(''); //Clear search results
                alert('Error loading search results'); //Display error
            }
        });
    }
}

//On property selected
function selectProperty(propertyId, displayAddress) {
    $(_idControlName).val(propertyId); //Populate given ID control
    $(_displayControlName).val(displayAddress); //Populate given display control
    clearPropertySearch(); //Clear search results
}

function clearPropertySearch() {
    $('#modalPropertySearch').modal('hide'); //Hide modal
    $('#property-search-result').html(''); //Clear search result HTML
    $('#txtPropertySearch').val(''); //Clear search text box
}