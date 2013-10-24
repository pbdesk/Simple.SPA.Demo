/// <reference path="../../../../Scripts/_references.js" />

var CustomersEditController = function ($scope, $routeParams, $window, CustomerFactory) {
    $scope.PageHeading = "Edit";
    $scope.IsEditMode = true; // false for create mode
    var originalItem = {};

    var currentId = $routeParams.Id;

    if (currentId > 0) {
        var s = CustomerFactory.GetItem(currentId);
        originalItem = PBDeskJS.Utils.Clone(s);
        //angular.copy(s, originalItem);
        $scope.NewItem = PBDeskJS.Utils.Clone(s);

    }

    $scope.Save = function () {

        if (PBDeskJS.Utils.DeepCompare($scope.NewItem, originalItem)) {
            ToastInfo("No Changes to Save");
        }
        else {


            CustomerFactory.UpdItem($scope.NewItem)
            .then(
                function () {
                    //success
                    ToastSuccess("Customer information updated successfully")
                    $window.location = "#/";

                },
                function () {
                    //error
                    ToastError("Error while saving Customer information.","CustomersEditController.Save")
                }
            );
        }
        
    }

    $scope.cancel = function () {
        //angular.copy(originalItem, $scope.NewItem);
    }

    $scope.Delete = function () {

        var r1 = false;
        var r2 = false;

        if (!PBDeskJS.Utils.DeepCompare($scope.NewItem, originalItem)) {
            //if user has updated any field on the edit form
            r1 = confirm("You are deleting the record. Current changes will be lost.")
            if (r1 == false) {
                return;
            }
        }
        if (r1 == false) {
            r2 = confirm("Delete Confirmation? This record will be deleted.");
            if (r2 == false) {
                return;
            }
        }

        CustomerFactory.DelItem($scope.NewItem.Id)
        .then(
            function () {
                //successes
                //$("#itemTR_" + id).fadeOut(2000);
                ToastSuccess("Record deleted successfully.")
                $window.location = "#/";
            },
            function () {
                //error
                ToastError("Error in deleteing. Please refer to server logs.", "CustomersEditController.Delete");
            }
        );



    }

}

CustomersEditController.$inject = ['$scope', '$routeParams', '$window', 'CustomerFactory'];