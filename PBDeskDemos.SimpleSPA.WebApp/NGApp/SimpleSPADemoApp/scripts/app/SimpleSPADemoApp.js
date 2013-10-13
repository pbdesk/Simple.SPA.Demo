/// <reference path="../../../../Scripts/_references.js" />

var SimpleSPADemoAppName = 'SimpleSPADemoApp';
var SimpleSPADemoApp = angular.module('SimpleSPADemoApp', ['ngRoute']);


SimpleSPADemoApp.config(['$routeProvider', function ($routeProvider) {
    var simpleSPADemoAppViewsPath = "/NGApp/SimpleSPADemoApp/views/";
    $routeProvider
        .when('/', { controller: CustomersListController, templateUrl: simpleSPADemoAppViewsPath + 'CustomerList.html' })
        .when('/Create', { controller: CustomersCreateController, templateUrl: simpleSPADemoAppViewsPath + 'CustomerCreate.html' })
        .when('/Edit/:Id', { controller: CustomersEditController, templateUrl: simpleSPADemoAppViewsPath + 'CustomerCreate.html' })
        .otherwise({ redirectTo: '/' });

}]);
