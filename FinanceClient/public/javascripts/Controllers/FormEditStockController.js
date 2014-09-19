app.controller('FormEditStockController', ['$scope', '$http', function ($scope, $http) {
    $scope.stock = {};

    var postSuccess = function () {
        $scope.stock = {};
        $scope.formEditStock.$setPristine();
    };

    var dataBaseError = function () {
        console.log("DATABASE ERROR.");
    };

    $scope.updateAccount = function () {
        $http.put("http://financeapi.apphb.com/api/Stock", JSON.stringify($scope.stock)).
            success(postSuccess).
            error(dataBaseError);

    };
}]);