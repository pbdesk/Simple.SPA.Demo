/// <reference path="../../../../Scripts/_references.js" />

var CustomersListController = function ($scope, CustomerFactory) {
    $scope.isBusy = false;
    $scope.data = CustomerFactory.Items;
    $scope.sortField = "SiteId";

    if (CustomerFactory.IsReady() == false) {
        $scope.isBusy = true;
        CustomerFactory.GetItems(false)
            .then(function (result) {
                //success
                ToastSuccess(result.length + " Customers found.")

            },
            function () {
                //error
                alert("Error");
            })
            .then(function () {
                $scope.isBusy = false;
            }
            );
    }

    $scope.Delete = function () {

        var id = this.i.Id;

        var r = confirm("Delete Confirmation? Deleting Customer: " + this.i.FirstName);
        if (r == true) {
            CustomerFactory.DelItem(this.i.Id)
            .then(
                function () {
                    //successes
                    $("#itemTR_" + id).fadeOut(2000);
                },
                function () {
                    //error
                    ToastError("Error in deleteing. Please refer to server logs.", "CustomersListController.Delete");
                }
            );
        }
        else {

        }


    }

    $scope.Refresh = function () {
        $scope.isBusy = true;
        CustomerFactory.GetItems(true)
            .then(function () {
                //success
                //$scope.$apply();
            },
            function () {
                //error
                alert("Error");
            })
            .then(function () {
                $scope.isBusy = false;
            }
            );
    }


}

CustomersListController.$inject = ['$scope', 'CustomerFactory'];