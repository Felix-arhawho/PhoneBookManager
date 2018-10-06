var app = angular.module("ContactInfo");

app.controller("listController", function ($scope, $window, $http) {

    $scope.contactInfoViewModel = {
        paginationViewModel: {
            pageIndex: 1,
            pageSize: 4
        }
    }

    $scope.contactInfos = {};

    var listOfContactInfo = function () {
        var accessToken = localStorage.getItem('accessToken');
        //blockUI.start();
        $http({
            method: 'POST',
            url: '/api/ContactInfo/GetAllContactInfo',
            headers: {
                'Authorization': 'Bearer ' + accessToken
            },
            data: $scope.contactInfoViewModel
        }).then(function OnSuccess(response) {
            $scope.contactInfos = response.data.contactInfos;
            $scope.beginningOfTheList = response.data.beginningOfTheList;
            $scope.endOfTheList = response.data.endOfTheList;
        }, function OnError() {
            console.log("Error");
        })
        //blockUI.stop();
    }

    $scope.getListOfContactInfo = function () {
        listOfContactInfo();
    }

    $scope.nextPage = function () {
        $scope.contactInfoViewModel.paginationViewModel.pageIndex += 1;
        listOfContactInfo();
    }

    $scope.previousPage = function () {
        $scope.contactInfoViewModel.paginationViewModel.pageIndex -= 1;
        listOfContactInfo();
    }



    //$scope.searchViewModel = {
    //    searchBy: "",
    //    searchContent: ""
    //}

    //var searchContactInfo = function () {
    //    var accessToken = localStorage.getItem('accessToken');
    //    $http({
    //        method: 'POST',
    //        url: '/api/ContactInfo/GetAllContactInfo',
    //        headers: {
    //            'Authorization': 'Bearer ' + accessToken
    //        },
    //        data: $scope.searchViewModel
    //    }).then(function OnSuccess(response) {
    //        $scope.contactInfos = response.data;
    //        }, function OnError() {
    //            console.log("Error");
    //        })
    //}

    //$scope.getSearchedContactInfo = function () {
    //    searchContactInfo();
    //}


    $scope.logout = function () {
        localStorage.removeItem('accessToken');
        window.location.href = "/";
    }
})