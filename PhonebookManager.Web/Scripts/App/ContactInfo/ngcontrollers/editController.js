var app = angular.module("ContactInfo");

app.controller("editController", function ($scope, $http, $window, $routeParams) {
    $scope.contactInfo = {};
    var accessToken = localStorage.getItem('accessToken');
    var id = $routeParams.id;
    $http({
        method: 'GET',
        url: '/api/ContactInfo/GetContactInfoById/' + id,
        params: { id: $routeParams.id },
        headers: {
            'Authorization': 'Bearer ' + accessToken
        }
    }).then(function OnSuccess(response) {
        $scope.contactInfo = response.data;

        var completeName = $scope.contactInfo.fullName;
        var fullNameArray = completeName.split(" ");
        $scope.contactInfo.firstName = fullNameArray[0];
        $scope.contactInfo.lastName = fullNameArray[1];

        }, function OnError(response) {
            console.log(response);
        })

    $scope.editContactInfo = function (data) {
        $http({
            method: 'POST',
            url: '/api/ContactInfo/EditContactInfo',
            data: data,
            headers: {
                'Authorization': 'Bearer ' + accessToken
            }
        }).then(function OnSuccess(response) {
            alert("Contact Info Editted Successfully");
            window.location.href = "/ContactInfo/Index";
            }, function OnError(response) {
                console.log(response);
            })
    }

    $scope.backToList = function () {
        window.location.href = "/ContactInfo/Index";
    }
})