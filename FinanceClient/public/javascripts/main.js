var app = angular.module('finance', ['ngRoute']);

app.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/', { templateUrl: '/partials/home.html', controller: "FormAddAccountController"})
        .when('/remove', { templateUrl: '/partials/remove.html', controller: "FormRemoveAccountController"})
        .when('/add', { templateUrl: '/partials/add.html', controller: "MainController"})
        .otherwise({redirectTo: '/'});
}]);
