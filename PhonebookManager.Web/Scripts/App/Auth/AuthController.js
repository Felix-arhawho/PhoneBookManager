var app = angular.module("Auth", ["validator", "validator.rules"]);
app.controller("AuthController", function ($scope, $http, $window, $validator) {
    $scope.User = {};

    $scope.login = function () {
        $validator.validate($scope, 'User')

            .success(function () {

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
                    console.log(response);
                    alert("Sorry, username does not exist");

                })

                console.log('success');
            })
            .error(function () {
                //alert("You are mad");
            });
    }
})