var app = angular.module('finance');
app.controller('FormRemoveAccountController', ['$scope', '$http', function ($scope, $http) {
    $scope.student = undefined;
    $scope.students = [];
    var url = 'http://localhost:3000/students/';

    var errorStudents = function () {
        $scope.students = [];
        console.error("DATABASE ERROR");
    };

    $http.get(url).success(function (data) {
        $scope.students = data.students || [];
    }).error(errorStudents);

    $scope.removeAccount = function () {
        var finalURL = url + $scope.student;

        // $http.delete(finalURL); this is supposed to work if the server was fine.

        Connection.deleteJSON(finalURL, function () {
            $http.get(url).success(function (data) {
                $scope.students = data.students || [];
            }).error(errorStudents);
        });

        $scope.student = undefined;
        $scope.formAddStudentForm.$setPristine();
    }
}]);

