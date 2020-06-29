// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//Dynamically create modal to show message
function showMessage(title, msg) {
    $("body").append(`<!-- Modal -->
        <div class="modal fade" id="MessageModal" role="dialog">
        <div class="modal-dialog">
            <!-- Modal content-->
          <div class="modal-content">
                <div class="modal-header">
                    <h5 id="lblMessageModalTitle" class="modal-title">Modal Header</h5>
                    <button type="button" class="close" data-dismiss="modal">&times;</button> 
                </div>
                <div class="modal-body">
                    <p id="lblMessageText"></p>
                </div>
                <div class="modal-footer">
                    <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                </div>
            </div>
        </div>
    </div > `);

    $('#lblMessageModalTitle').text(title);
    $('#lblMessageText').text(msg);
    $('#MessageModal').modal('show');
};