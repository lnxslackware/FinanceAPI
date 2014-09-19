var app = angular.module('finance');

app.controller('FormAddAccountController', ['$scope', '$http', function ($scope, $http) {
    $scope.stock = {};

    var postSuccess = function () {
        $scope.stock = {};
        $scope.formAddStudentForm.$setPristine();
    };

    var dataBaseError = function () {
        console.log("DATABASE ERROR.");
    };

    $scope.addAccount = function () {
        $http.post("http://localhost:3000/orders/", JSON.stringify($scope.stock)).
            success(postSuccess).
            error(dataBaseError);

    };
}]);
