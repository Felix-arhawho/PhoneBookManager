var app = angular.module("ContactInfo");

app.controller("deleteController", function ($scope, $http, $window, $routeParams) {
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
        console.log(response.data);

    }, function OnError(response) {
        console.log(response);
    })


    $scope.deleteContactInfo = function (id) {
        $http({
            method: 'POST',
            url: '/api/ContactInfo/DeleteContactInfo/' + id,
            headers: {
                'Authorization': 'Bearer ' + accessToken
            }
        }).then(function OnSuccess(response) {
            alert("Contact Info Deleted Successfully");
            window.location.href = "/ContactInfo/Index";
        }, function OnError(response) {
            console.log(response);
        })
    }

    $scope.backToList = function () {
        window.location.href = "/ContactInfo/Index";
    }
})