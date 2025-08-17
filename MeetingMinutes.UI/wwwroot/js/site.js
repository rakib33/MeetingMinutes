// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

$(document).ready(function () {

    // Track touched fields
    const touchedFields = new Set();   
   
    // Function to validate a field
    function validateField(field, errorId, errorMessage) {
        if (!field.val() || (field.is('select') && field.val() === "")) {
            field.addClass('is-invalid');
            $(errorId).text(errorMessage).show();
            return false;
        } else {
            field.removeClass('is-invalid');
            $(errorId).hide();
            return true;
        }
    }

    // Mark field as touched when interacted with
    $('input, select, textarea').on('focus change', function () {
        const field = $(this);
        const fieldId = field.attr('id');
        touchedFields.add(fieldId);

        // For dropdowns, validate immediately on change
        if (field.is('select') && $(this).val() === "") {
            const errorId = '#' + fieldId + '-error';
            validateField(field, errorId, $(errorId).text());
        }
    });

    // Validate on Save Changes click
    $('#saveChanges').click(function () {
        let isValid = true;

        // Validate meetingagenda
        isValid = validateField($('#customername'), '#customername-error', 'Please select a customer') && isValid;
        // Validate meetingagenda
        isValid = validateField($('#meetingagenda'), '#meetingagenda-error', 'Please enter a meeting agenda') && isValid;

        // Validate meetingdiscussion
        isValid = validateField($('#meetingdiscussion'), '#meetingdiscussion-error', 'Please select a meeting discussion') && isValid;

        // Validate time
        isValid = validateField($('#attendclientside'), '#attendclientside-error', 'Please select a time') && isValid;
        isValid = validateField($('#attendhostside'), '#attendhostside-error', 'Please select a time') && isValid;

        // Validate first name
        isValid = validateField($('#meetingplace'), '#meetingplace-error', 'Please enter your first name') && isValid;

        // Validate last name
        isValid = validateField($('#meetingdecision'), '#meetingdecision-error', 'Please enter your last name') && isValid;


        if (isValid) {
            alert('Form submitted successfully!');
            // Here you would typically submit the form
        }
    });

    // Clear validation when user starts typing/selecting
    $('input, select, textarea').on('input change', function () {
        const field = $(this);
        const fieldId = field.attr('id');

        if (touchedFields.has(fieldId)) {
            const errorId = '#' + fieldId + '-error';
            if (field.val()) {
                field.removeClass('is-invalid');
                $(errorId).hide();
            } else {
                validateField(field, errorId, $(errorId).text());
            }
        }
    });
     

});