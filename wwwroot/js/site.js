// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(function () {
    $('[data-toggle="tooltip"]').tooltip();
})

// Modal for creating 
$('#deleteModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget); // Button that triggered the modal
    var id = button.data('id'); // Extract info from data-* attributes
    var type = button.data('type');
    var action = button.data('action');
    var modal = $(this);
    modal.find('.modal-title').text("Usuwanie");
    modal.find('#deleteModalSubmitButton').attr('href', action + `?id=${id}&type=${type}`);

})

// Modal for adding events for specyfic building
$('#eventModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget); // Button that triggered the modal
    var id = button.data('id'); // Extract info from data-* attributes
    var modal = $(this);
    var links = modal.find("a");
    links.each(function (index) {
        $(this).attr('href', $(this).data('action') + '?obiektGospodarczyID=' + id)
    });
})

// Modal for adding events for specyfic building
$('#pdfGeneratorModal').on('show.bs.modal', function (event) {
    var button = $(event.relatedTarget); // Button that triggered the modal
    var modal = $(this);
})

