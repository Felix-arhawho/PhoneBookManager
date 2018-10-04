var app = angular.module("ContactInfo");

app.controller("listController", function ($scope, $window, $http) {

    $scope.paginationViewModel = {
        pageIndex: 1,
        pageSize: 4
    }


    var getContactInfos = function () {
        var accessToken = localStorage.getItem('accessToken');
        $http({
            method: 'POST',
            url: '/api/ContactInfo/PaginatedContactInfo',
            headers: {
                'Authorization': 'Bearer ' + accessToken
            },
            data: $scope.paginationViewModel
        }).then(function OnSuccess(response) {
            $scope.contactInfos = response.data.contactInfos;
            $scope.beginningOfTheList = response.data.beginningOfTheList;
            $scope.endOfTheList = response.data.endOfTheList;
        }, function OnError() {
            console.log("Error");
        })
    }

    $scope.listOfContactInfo = function () {
        getContactInfos();
    }

    $scope.nextPage = function () {
        $scope.paginationViewModel.pageIndex += 1;
        getContactInfos();
    }

    $scope.previousPage = function () {
        $scope.paginationViewModel.pageIndex -= 1;
        getContactInfos();
    }


    //var firstRowNumber = 0;
    //$scope.getSerialNumber = function () {
    //    $scope.serialNumber += firstRowNumber;
    //}

    $scope.logout = function () {
        localStorage.removeItem('accessToken');
        window.location.href = "/";
    }
})