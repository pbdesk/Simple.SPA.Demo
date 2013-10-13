/// <reference path="toastr.js" />

function ToastSuccess(message, title) {
    var toasterSuccessOptions = {

    };
    toastr.success(message, title, toasterSuccessOptions);
}

function ToastError(message, title) {
    var toasterErrorOptions = {
        "closeButton": true,
        "timeOut": "0"
    };

    toastr.error(message, title, toasterErrorOptions);
}

function ToastInfo(message, title) {
    var toasterInfoOptions = {

    };
    toastr.info(message, title, toasterInfoOptions);
}

function ToastWarning(message, title) {
    var toasterWarningOptions = {

    };
    toastr.warning(message, title, toasterWarningOptions);
}

