

const getDashboard = () => {
    $.ajax({
        url: '/homepage',
        type: 'GET',
        success: function (result) {
            $('#target').html(result);
        },
        error: function (error) {
            console.log('Failed to load partial view:', error);
        }
    });
};

$(document).ready(() => {
    getDashboard();

    $(document).on("click", "#Cancel", () => {
        console.log("dashboard closed...");
        getDashboard();
    });


    const setFieldError = (fieldName, message = "") => {
        $(`[data-valmsg-for='${fieldName}']`).text(message);
    };

    const clearAllErrors = () => {
        $("[data-valmsg-for]").text("");
    };

    const isValidForm = () => {
        clearAllErrors();

        const alias = ($("#Alias").val() || "").trim();
        const name = ($("#Name").val() || "").trim();
        const gmail = ($("#GmailId").val() || "").trim();
        const mobile = ($("#MobileNo").val() || "").trim();
        const contact = ($("#GuardianMobile").val() || "").trim();
        const address = ($("#Address").val() || "").trim();

        const emailRegex = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
        const phoneRegex = /^[0-9]{10}$/;

        let isValid = true;

        if (!alias) {
            setFieldError("Alias", "Alias is required.");
            isValid = false;
        }

        if (!name) {
            setFieldError("Name", "Name is required.");
            isValid = false;
        }

        if (!gmail) {
            setFieldError("GmailId", "Email ID is required.");
            isValid = false;
        } else if (!emailRegex.test(gmail)) {
            setFieldError("GmailId", "Please enter a valid email address.");
            isValid = false;
        }

        if (!mobile) {
            setFieldError("MobileNo", "Mobile number is required.");
            isValid = false;
        } else if (!phoneRegex.test(mobile)) {
            setFieldError("MobileNo", "Mobile number must be a valid 10-digit number.");
            isValid = false;
        }

        if (!contact) {
            setFieldError("GuardianMobile", "Guardian mobile is required.");
            isValid = false;
        } else if (!phoneRegex.test(contact)) {
            setFieldError("GuardianMobile", "Guardian mobile must be a valid 10-digit number.");
            isValid = false;
        }

        if (!address) {
            setFieldError("Address", "Address is required.");
            isValid = false;
        }

        return isValid;
    };

    $(document).on("submit", "#createCustomerForm", (event) => {
        event.preventDefault();
        console.log("Form submit triggered");

        if (isValidForm()) {
            console.log("New Customer Created");
        }
    });
});
