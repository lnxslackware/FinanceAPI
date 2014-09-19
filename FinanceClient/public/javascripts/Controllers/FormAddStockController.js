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
        var text = JSON.stringify($scope.stock);

        $http.post("http://financeapi.apphb.com/api/Stock", text).
            success(postSuccess).
            error(dataBaseError);

    };
}]);