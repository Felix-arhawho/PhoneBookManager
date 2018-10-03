var app = angular.module("ContactInfo");

app.controller("createController", function ($scope, $http, $window) {

    $scope.contactInfo = {};

    $scope.createContactInfo = function (contactInfo) {
        $scope.contactInfo = contactInfo;
        var accessToken = localStorage.getItem('accessToken');

        $http({
            url: '/api/ContactInfo/CreateContactInfo',
            method: 'POST',
            data: contactInfo,
            headers: {
                'Authorization': 'Bearer ' + accessToken
            }
        }).then(function OnSuccess(response) {
            alert(response.data);
            window.location.href = "/ContactInfo/Index";
        }, function OnError(response) {
            console.log(response);
        })
    }


    $scope.backToList = function () {
        window.location.href = "/ContactInfo/Index";
    }
})