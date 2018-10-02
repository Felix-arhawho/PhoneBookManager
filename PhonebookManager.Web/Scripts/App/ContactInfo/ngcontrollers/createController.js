var app = angular.module("ContactInfo");

app.controller("createController", function ($scope, $http, $window) {

    $scope.createContactInfo = function (contactInfo) {
        var contactInfoVM = contactInfo;
        var accessToken = localStorage.getItem('accessToken');
        $http({
            url: '/api/ContactInfo/CreateContactInfo',
            method: 'POST',            
            data: contactInfoVM,
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
})