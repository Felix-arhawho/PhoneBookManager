var app = angular.module("ContactInfo");

app.controller("listController", function ($scope, $window, $http) {
    $scope.serialNumber = 0;
    $scope.listOfContactInfo = function () {
        var accessToken = localStorage.getItem('accessToken');
        $http({
            method: 'GET',
            url: '/api/ContactInfo/GetAllContactInfo',
            headers: {
                'Authorization': 'Bearer ' + accessToken
            }
        }).then(function OnSuccess(response) {
            $scope.contactInfos = response.data;
            }, function OnError() {
                console.log("Error");
            })
    }


    $scope.logout = function () {
        localStorage.removeItem('accessToken');
        window.location.href = "/";
    }
})