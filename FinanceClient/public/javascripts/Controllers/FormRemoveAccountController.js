var app = angular.module('finance');
app.controller('FormRemoveAccountController', ['$scope', '$http', function ($scope, $http) {
    $scope.student = undefined;
    $scope.orders = [];
    var url = 'http://localhost:3000/orders/';

    var errorStudents = function () {
        $scope.orders = [];
        console.error("DATABASE ERROR");
    };

    $http.get(url).success(function (data) {
        $scope.orders = data.orders || [];
    }).error(errorStudents);

    $scope.removeAccount = function () {
        var finalURL = url + $scope.student;

        // $http.delete(finalURL); this is supposed to work if the server was fine.

        Connection.deleteJSON(finalURL, function () {
            $http.get(url).success(function (data) {
                $scope.orders = data.orders || [];
            }).error(errorStudents);
        });

        $scope.student = undefined;
        $scope.formAddStudentForm.$setPristine();
    }
}]);

