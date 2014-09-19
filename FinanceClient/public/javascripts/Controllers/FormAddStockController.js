
app.controller('FormAddStockController', ['$scope', '$http', function ($scope, $http) {
    $scope.stock = {};

    var postSuccess = function () {
        $scope.stock = {};
        $scope.formAddStock.$setPristine();
    };

    var dataBaseError = function () {
        console.log("DATABASE ERROR.");
    };

    $scope.addStock = function () {
        $http.post("http://financeapi.apphb.com/api/Stock", JSON.stringify($scope.stock)).
            success(postSuccess).
            error(dataBaseError);

    };
}]);