var app = angular.module("ContactInfo");

app.controller("listController", function ($scope, $window) {
    $scope.logout = function () {
        localStorage.removeItem('accessToken');
        window.location.href = "/";
    }
})