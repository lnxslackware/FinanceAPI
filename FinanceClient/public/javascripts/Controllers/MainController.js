var app = angular.module('finance');


app.controller('MainController', ['$scope', '$http', function ($scope, $http) {
    $scope.average = 0;
    var url = 'http://localhost:3000/orders/';

    var doStudents = function (data) {
        $scope.orders = data.orders || [];
    };

    var errorStudents = function () {
        $scope.orders = [];
        console.error("DATABASE ERROR");
    };

    $http.get(url).success(doStudents).error(errorStudents);
}]);
