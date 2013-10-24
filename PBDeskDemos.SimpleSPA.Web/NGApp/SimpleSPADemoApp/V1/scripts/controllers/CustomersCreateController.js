/// <reference path="../../../../Scripts/_references.js" />

var CustomersCreateController = function ($scope, $window, CustomerFactory) {
    $scope.PageHeading = "Create New Customer";
    $scope.IsEditMode = false; // true for edit mode
    $scope.NewItem = {};
    $scope.Save = function () {

        CustomerFactory.AddItem($scope.NewItem)
        .then(
            function (newlyCreatedItem) {
                //success
                ToastSuccess("");
                $window.location = "#/";
            },
            function (errorOb, status) {
                //error
                ToastError("Error in Save[CustomersCreateController]. Please refer to server logs.");
            }
        );
    }

    $scope.cancel = function () {
    }
}

CustomersCreateController.$inject = ['$scope', '$window', 'CustomerFactory'];