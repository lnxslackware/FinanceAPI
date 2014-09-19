var app = angular.module('finance');


app.controller('MainController', ['$scope', '$http', function ($scope, $http) {
    $scope.average = 0;
    var orderUrl = 'http://financeapi.apphb.com/api/Order';
    var stockUrl = 'http://financeapi.apphb.com/api/Stock';

    var doOrders = function (data) {
        $scope.orders = data || [];
    };

    var errorOrders = function () {
        $scope.orders = [];
        console.error("DATABASE ERROR");
    };

    var doStocks = function (data) {
        console.log(data);
        $scope.stocks = data || [];
    };

    var errorStocks = function () {
        $scope.stocks = [];
        console.error("DATABASE ERROR");
    };

    $http.get(orderUrl).success(doOrders).error(errorOrders);
    $http.get(stockUrl).success(doStocks).error(errorStocks);
}]);
