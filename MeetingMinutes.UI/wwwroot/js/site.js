$(document).ready(function () {

    let customers = [];
    // Track touched fields
    const touchedFields = new Set();
    /* product add to table and save*/
    let products = [];
    let editIndex = -1;


    $('#timeInput').timepicker({
        timeFormat: 'h:mm p', // 12-hour format with AM/PM
        interval: 10,         // 15 minute increments
        //minTime: '6:00am',    // Earliest time
        //maxTime: '11:30pm',   // Latest time
        //defaultTime: 'now',   // Default to current time
        startTime: '6:00am',  // First time in dropdown
        dynamic: false,       // Don't scroll to current time
        dropdown: true,       // Show dropdown
        scrollbar: true,      // Show scrollbar
        change: function (time) {
            console.log('Time selected: ' + time);
        }
    });

    // Alternative: Open timepicker on icon click too
    $('.input-group-text').click(function () {
        $('#timeInput').timepicker('show');
    });

    // Check initial selection
    var initialSelection = $('input[name="options"]:checked').val();
    updateSelectionDisplay(initialSelection);

    // Handle change event
    $('input[name="options"]').change(function () {
        var selectedValue = $(this).val();
        updateSelectionDisplay(selectedValue);
    });

    // Function to update display
    function updateSelectionDisplay(value) {
        $("#customername").empty();
        $("#customername").append(
            $("<option>").val('').text("select customer name")
        );
        if (value === "Corporate") {
            // Load products dropdown
            $.get("/Customer/GetCorporateCustomers", function (data) {
                $.each(data, function (i, customer) {
                    $("#customername").append(
                        $("<option>").val(customer.id).text(customer.name)
                    );
                });
            });
        }
        else {
            // Load products dropdown
            $.get("/Customer/GetIndividualCustomers", function (data) {
                $.each(data, function (i, customer) {
                    $("#customername").append(
                        $("<option>").val(customer.id).text(customer.name)
                    );
                });
            });
        }
    }

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

    // Load products dropdown
    $.get("/Product/GetProducts", function (data) {
        $.each(data, function (i, product) {
            $("#productDropdown").append(
                $("<option>").val(product.id).text(product.name)
            );
        });
    });

    // Product dropdown change event
    $("#productDropdown").change(function () {
        const productId = $(this).val();
        if (productId) {
            $.get("/Product/GetProducts", function (data) {
                const selectedProduct = data.find(p => p.id == productId);
                $("#unitInput").val(selectedProduct.unit);
            });
        } else {
            $("#unitInput").val("");
        }
    });

    // Add button click for new record or edit exisiting record
    $("#addProduct").click(function () {

        const productId = $("#productDropdown").val();
        const productName = $("#productDropdown option:selected").text();
        const unit = $("#unitInput").val();
        const quantity = $("#quantity").val();

        let isValid = true;

        // Validate meetingagenda
        isValid = validateField($('#productDropdown'), '#productDropdown-error', 'Please select a product') && isValid;
        isValid = validateField($('#quantity'), '#quantity-error', 'Please enter quantity') && isValid;

        if (!isValid)
            return isValid;

        if (editIndex >= 0) {

            products[editIndex] = {
                id: productId,
                name: productName,
                quantity: quantity,
                unit: unit
            };

            refreshTable();
            clearProductForm();
            cancelEdit();
        }

        else {
            //for new record
            products.push({
                id: productId,
                name: productName,
                quantity: quantity,
                unit: unit
            });

            refreshTable();
            clearProductForm();
        }
    });

    // Edit button in table
    $(document).on("click", ".edit-btn", function () {
        editIndex = $(this).data("index");
        const product = products[editIndex];
        $("#productDropdown").val(product.id);
        $("#unitInput").val(product.unit);
        $("#quantity").val(product.quantity);
    });

    //// Update button click
    //$("#updateBtn").click(function () {
    //    if (editIndex >= 0) {
    //        const productId = $("#productDropdown").val();
    //        const productName = $("#productDropdown option:selected").text();
    //        const unit = $("#unitInput").val();

    //        products[editIndex] = {
    //            id: productId,
    //            name: productName,
    //            unit: unit
    //        };

    //        refreshTable();
    //        clearProductForm();
    //        cancelEdit();
    //    }
    //});

    // Cancel button click
    //$("#cancelBtn").click(function () {
    //    cancelEdit();
    //    clearProductForm();
    //});

    // Delete button in table
    $(document).on("click", ".delete-btn", function () {
      
        const $button = $(this);
        const index = $button.data("index");
        const productName = $button.closest('tr').find('td:eq(2)').text(); // Get product name from table

        const modal = new bootstrap.Modal(document.getElementById('deleteConfirmModal'));

        // Update modal content dynamically
        $('#deleteConfirmModal .modal-body').html(`
        <p>Are you sure you want to delete:<strong>${productName}</strong>?</p>       
        <p class="text-danger">This action cannot be undone!</p>
    `);

        // Store data on confirm button
        $('#confirmDeleteBtn')
            .data('index', index)
            .off('click') // Remove previous handlers
            .click(function () {
                products.splice(index, 1);
                refreshTable();
                showSuccessAlert('Product deleted successfully');
                modal.hide();
            });

        modal.show();

        //if (confirm("Are you sure you want to delete this product?")) {
        //    const index = $(this).data("index");
        //    products.splice(index, 1);
        //    refreshTable();
        //}
    });


    // Helper functions
    function refreshTable() {
        const tableBody = $("#productTable tbody");
        tableBody.empty();

        $.each(products, function (index, product) {
            tableBody.append(
                `<tr>
                            <td>${index + 1}</td>
                            <td style="display:none">${product.id}</td>
                            <td>${product.name}</td>
                            <td>${product.quantity}</td>
                            <td>${product.unit}</td>
                            <td>
                              <button class="btn btn-sm btn-warning edit-btn" data-index="${index}">
                                 <i class="bi bi-pencil"></i> Edit
                              </button>
                            </td>
                            <td>
                              <button class="btn btn-sm btn-danger delete-btn" data-index="${index}">
                                 <i class="bi bi-trash"></i> Delete
                              </button>
                            </td>
                        </tr>`
            );
        });
    }

    function clearProductForm() {
        $("#productDropdown").val("");
        $("#unitInput").val("");
        $("#quantity").val("");
    }

    function cancelEdit() {
        editIndex = -1;
        $("#addBtn").show();
    }

    function IsFormValid() {

        let isValid = true;

        // Validate meeting agenda
        isValid = validateField($('#customername'), '#customername-error', 'Please select a customer') && isValid;

        // Validate meeting agenda
        isValid = validateField($('#meetingagenda'), '#meetingagenda-error', 'Please enter meeting agenda') && isValid;

        // Validate meeting discussion
        isValid = validateField($('#meetingdiscussion'), '#meetingdiscussion-error', 'Please enter meeting discussion') && isValid;

        // Validate attend clientside
        isValid = validateField($('#attendclientside'), '#attendclientside-error', 'Please enter present client side') && isValid;

        // Validate attend hostside
        isValid = validateField($('#attendhostside'), '#attendhostside-error', 'Please enter present self side') && isValid;

        // Validate meeting place
        isValid = validateField($('#meetingplace'), '#meetingplace-error', 'Please enter meeting place') && isValid;

        // Validate meeting decision
        isValid = validateField($('#meetingdecision'), '#meetingdecision-error', 'Please enter meeting decision') && isValid;

        return isValid;
    }

    /**
     * Save button click
     * @returns
     */
    async function SaveProduct() {
        if (products.length === 0) {
            return;
        }
        return $.ajax({
            url: "/Product/SaveProducts",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(products),
        });
    };
    async function SaveMeeting() {
        // Collect form data
        const meetingData = {
            customerId: $("#customername").val(),
            meetingDate: $("#datepicker").val(),
            meetingTime: $("#timeInput").val(),
            meetingAgenda: $("#meetingagenda").val(),
            meetingDiscussion: $("#meetingdiscussion").val(),
            attendClientSide: $("#attendclientside").val(),
            attendHostSide: $("#attendhostside").val(),
            meetingPlace: $("#meetingplace").val(),
            meetingDecision: $("#meetingdecision").val()
        };
        console.log(JSON.stringify(meetingData));
        // Send data to server
        return $.ajax({
            url: "/Meeting/SaveMeeting",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(meetingData)
        });
    }

    // Validate on Save Changes click
    $('#saveChanges').click(function () {
        (async () => {

            if (!IsFormValid()) {
                return false;
            }
            const $btn = $(this).prop('disabled', true);
            // Show loading indicator
            $('#loadingIndicator').show();

            try {
                // 1. First save meeting
                const meetingResponse = await SaveMeeting();
                console.log(meetingResponse);
                // 2. Only if meeting saved successfully, save product
                const productResponse = await SaveProduct();
                console.log(productResponse);
                showSuccessAlert('Data saved successfully!');
                clearForm();
            } catch (error) {
                showErrorAlert('Saved failed');
                console.log('Error saving data: ' + (error.responseJSON?.message || error.statusText));
            } finally {
                $btn.prop('disabled', false);
                $('#loadingIndicator').hide();
            }
        })(); // Immediately invoke the async function
    });

    function clearForm() {

        $("#customername").val("");
        $("#datepicker").val("");
        $("#timeInput").val("");
        $("#meetingplace").val("");
        $("#attendclientside").val("");
        $("#attendhostside").val("");
        $("#meetingagenda").val("");
        $("#meetingdiscussion").val("");
        $("#meetingdecision").val("");

        ClearTable();
        clearProductForm();
    }
    function ClearTable() {
        const tableBody = $("#productTable tbody");
        tableBody.empty();
    };
   
    /**
     toast notification for success and error messages
     */
    function showSuccessAlert(message) {
        const toast = new bootstrap.Toast(document.getElementById('successToast'));
        $('#toastMessage').text(message);
        $('#successToast')
            .removeClass('bg-danger')
            .addClass('bg-success')
            .find('.bi')
            .removeClass('bi-exclamation-triangle-fill')
            .addClass('bi-check-circle-fill');
        toast.show();
    }

    function showErrorAlert(message) {
        const toast = new bootstrap.Toast(document.getElementById('successToast'));
        $('#toastMessage').text(message);
        $('#successToast')
            .removeClass('bg-success')
            .addClass('bg-danger')
            .find('.bi')
            .removeClass('bi-check-circle-fill')
            .addClass('bi-exclamation-triangle-fill');
        toast.show();
    }
});