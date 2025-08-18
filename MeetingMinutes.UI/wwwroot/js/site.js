$(document).ready(function () {
    $('#timeInput').timepicker({
        timeFormat: 'h:mm p', // 12-hour format with AM/PM
        interval: 10,         // 15 minute increments
        //minTime: '6:00am',    // Earliest time
        //maxTime: '11:30pm',   // Latest time
        //defaultTime: 'now',   // Default to current time
        //startTime: '6:00am',  // First time in dropdown
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
});

$(document).ready(function () {
    let customers = [];
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

});

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
        /*     if (fieldId !== "timepicker")*/
        touchedFields.add(fieldId);

        // For dropdowns, validate immediately on change
        if (field.is('select') && $(this).val() === "") {
            const errorId = '#' + fieldId + '-error';
            validateField(field, errorId, $(errorId).text());
        }
    });

    // Validate on Save Changes click
    $('#saveChanges').click(function () {

        if (IsFormValid) {

        }

        SaveProduct();
    });

    function IsFormValid() {

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
            //alert('Form submitted successfully!');
            // Here you would typically submit the form
        }
        return isValid;
    }


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
   
    /*    product add to table and save*/
    let products = [];
    let editIndex = -1;

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
    $("#addProductService").click(function () {

        const productId = $("#productDropdown").val();
        const productName = $("#productDropdown option:selected").text();
        const unit = $("#unitInput").val();
        const quantity = $("#quantity").val();

        //for new fresh data
        if (!productId) {
            alert("Please select a product.");
            return;
        }
        if (quantity < 1) {
            alert("Please select a quantity.");
            return;
        }
        if (unit < 0) {
            alert("unit should have a value.");
            return;
        }
        //first check if data is for edited 
        if (editIndex >= 0) {

            products[editIndex] = {
                id: productId,
                name: productName,
                quantity: quantity,
                unit: unit
            };

            refreshTable();
            clearForm();
            cancelEdit();
        }

        else
        {
          //for new record
            products.push({
                id: productId,
                name: productName,
                quantity: quantity,
                unit: unit
            });

            refreshTable();
            clearForm();
        }
    });

    // Edit button in table
    $(document).on("click", ".edit-btn", function () {
        editIndex = $(this).data("index");
        const product = products[editIndex];

        $("#productDropdown").val(product.id);
        $("#unitInput").val(product.unit);
        $("#quantity").val(product.quantity);

        $("#addBtn").hide();
        $("#updateBtn").show();
        $("#cancelBtn").show();
    });

    // Update button click
    $("#updateBtn").click(function () {
        if (editIndex >= 0) {
            const productId = $("#productDropdown").val();
            const productName = $("#productDropdown option:selected").text();
            const unit = $("#unitInput").val();

            products[editIndex] = {
                id: productId,
                name: productName,
                unit: unit
            };

            refreshTable();
            clearForm();
            cancelEdit();
        }
    });

    // Cancel button click
    $("#cancelBtn").click(function () {
        cancelEdit();
        clearForm();
    });

    // Delete button in table
    $(document).on("click", ".delete-btn", function () {
        if (confirm("Are you sure you want to delete this product?")) {
            const index = $(this).data("index");
            products.splice(index, 1);
            refreshTable();
        }
    });

    // Save button click
    function SaveProduct(){
        if (products.length === 0) {
            alert("No products to save");
            return;
        }

        $.ajax({
            url: "/Product/SaveProducts",
            type: "POST",
            contentType: "application/json",
            data: JSON.stringify(products),
            success: function (response) {
                alert(response.message);
            },
            error: function () {
                alert("Error saving products");
            }
        });
    };

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

    function clearForm() {
        $("#productDropdown").val("");
        $("#unitInput").val("");
        $("#quantity").val("");
    }

    function cancelEdit() {
        editIndex = -1;
        $("#addBtn").show();
        $("#updateBtn").hide();
        $("#cancelBtn").hide();
    }

});