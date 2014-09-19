var app = angular.module('finance');
app.controller('FormEditAccountController', ['$scope', '$http', function ($scope, $http) {
    $scope.student = {};

    var postSuccess = function () {
        $scope.student = {};
        $scope.formAddStudentForm.$setPristine();
    };

    var dataBaseError = function () {
        console.log("DATABASE ERROR.");
    };

    $scope.updateAccount = function () {
        $http.post("http://localhost:3000/orders/", JSON.stringify($scope.student)).
            success(postSuccess).
            error(dataBaseError);

    };
}]);