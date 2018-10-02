var app = angular.module("Auth", []);
app.controller("AuthController", function ($scope, $http, $window) {
    $scope.User = {};

    $scope.login = function () {
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
            var result = response.data;
            localStorage.setItem('accessToken', result.access_token);
            window.location.href = "/ContactInfo/Index";
            }, function OnError(response) {
                alert("Sorry, an error occurred. Please try again later");
            })
    }
})