var app = angular.module('finance');
var url = 'http://localhost:3000/students/';

app.controller('MainController', ['$scope', '$http', function ($scope, $http) {
    $scope.students = [];
    $scope.average = 0;

    var doStudents = function (data) {
        $scope.students = data.students || [];

        var sum = 0;

        for (var i = 0; i < $scope.students.length; i++) {
            var student = $scope.students[i];
            sum += student.grade;
        }

        $scope.average = (sum / $scope.students.length ) || 0;
    };

    var errorStudents = function () {
        $scope.students = [];
        console.error("DATABASE ERROR");
    };

    $http.get(url).success(doStudents).error(errorStudents);
}]);
