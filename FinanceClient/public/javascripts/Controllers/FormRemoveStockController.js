app.controller('FormRemoveStockController', ['$scope', '$http', function ($scope, $http) {
    $scope.stock = {};

    var postSuccess = function () {
        $scope.stock = {};
        $scope.formRemoveStock.$setPristine();
    };

    var dataBaseError = function () {
        console.log("DATABASE ERROR.");
    };

    $scope.removeStock = function () {
        $http.delete("http://financeapi.apphb.com/api/Stock", JSON.stringify($scope.stock)).
            success(postSuccess).
            error(dataBaseError);

    };
}]);