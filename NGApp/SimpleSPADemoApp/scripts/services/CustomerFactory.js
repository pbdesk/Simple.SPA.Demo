/// <reference path="../../../../Scripts/_references.js" />

(function () {
    'use strict';

    var serviceId = 'CustomerFactory';
    angular.module(SimpleSPADemoAppName).factory(serviceId, ["$http", "$q", '$httpProvider', CustomerFactory]);

    function CustomerFactory($http, $q, $httpProvider) {

        $http.defaults.useXDomain = true;
        delete $httpProvider.defaults.headers.common['X-Requested-With'];

        //#region Internal Methods        

        var _url = "http://pbdeskapi.azurewebsites.net/api/SimpleSPADemo/V1/Customers/";
        var _items = [];
        var _isInit = false;

        var _isReady = function () {
            return _isInit;
        }

        var _getItems = function (hardRefresh) {

            var deferred = $q.defer();

            $http.get(_url)
            .success(function (result, status, headers, config) {
                angular.copy(result, _items);
                _isInit = true;
                deferred.resolve(result);
            })
            .error(function (result, status, headers, config) {
                deferred.reject(result, status);
            });

            return deferred.promise;

        }

        var _getItem = function (id) {
            if (_isReady() == true) {
                var result = $.grep(_items, function (e) { return e.Id == id; });
                if (result.length == 0) {
                    return null;
                } else if (result.length == 1) {
                    return result[0];
                } else {
                    return null;
                }
            }
            else
                return null;
        }

        var _addItem = function (newEnv) {
            var deferred = $q.defer();

            $http.post(_url, newEnv)
                .success(function (result, status, headers, config) {

                    _items.splice(0, 0, result);
                    deferred.resolve(result);

                })
                .error(function (result, status, headers, config) {
                    deferred.reject(result, status);
                });

            return deferred.promise;
        }

        var _updItem = function (updEnv) {
            var deferred = $q.defer();
            $http.put(_url + updEnv.Id, updEnv)
            .success(function (result, status, headers, config) {

                var updatedItemIndex = -1;
                $.each(_items, function (idx, val) {
                    if (val.Id === result.Id) {
                        updatedItemIndex = idx;
                    }
                });

                _items.splice(updatedItemIndex, 1, result);
                deferred.resolve(result);
            })
             .error(function (result, status, headers, config) {
                 deferred.reject(result, status);
             });

            return deferred.promise;
        }

        var _delItem = function (id) {

            var delItemIndex = -1;
            $.each(_items, function (idx, val) {
                if (val.Id === id) {
                    delItemIndex = idx;
                }
            });

            var deferred = $q.defer();
            $http.delete(_url + id)
            .success(function (result, status, headers, config) {
                _items.splice(delItemIndex, 1);
                deferred.resolve();
            })
            .error(function (result, status, headers, config) {
                deferred.reject(result, status);
            });

            return deferred.promise;

        }


        //#endregion

        var service = {
            Items: _items,
            GetItems: _getItems,
            GetItem: _getItem,
            AddItem: _addItem,
            UpdItem: _updItem,
            DelItem: _delItem,
            IsReady: _isReady
        };

        return service;
    }
})();