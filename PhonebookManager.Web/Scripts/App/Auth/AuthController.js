var app = angular.module("Auth", []);
app.controller("AuthController", function ($scope, $http, $window) {
    $scope.User = {};

    $scope.login = function () {

        console.log('Username: ' + $scope.User.username + ' Password: ' + $scope.User.password);

        $http({
            url: "/token",
            method: "POST",
            data: $.param({
                grant_type: 'password',
                username: $scope.User.username,
                password: $scope.User.password                
            }),
            headers: {
                'Content-Type': 'application/x-www-form-urlencoded'
            }
        }).then(function OnSuccess(response) {
            window.location.pathname = 'ContactInfo/Index';
            console.log(response.data);
            }, function OnError(response) {
                console.log(response);
            })
    }
})