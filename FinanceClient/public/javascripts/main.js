var app = angular.module('finance', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: '/partials/home.html', controller: "FormAddAccountController"})
        .when('/remove', { templateUrl: '/partials/remove.html', controller: "FormRemoveAccountController"})
        .when('/add', { templateUrl: '/partials/add.html', controller: "MainController"})
        .when('/stock-add',{templateUrl: '/partials/stock-add.html', controller: "FormAddStockController"})
        .when('/stock-edit',{templateUrl: '/partials/stock-edit.html', controller: "FormEditStockController"})
        .when('/stock-remove',{templateUrl: '/partials/stock-remove.html', controller: "FormRemoveStockController"})
        .otherwise({redirectTo: '/'});
}]);
