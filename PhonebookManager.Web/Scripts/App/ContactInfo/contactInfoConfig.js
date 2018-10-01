var app = angular.module("ContactInfo", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "/ContactInfo/ListOfContactInfo"
        })
        .when("/ViewContactInfo", {
            templateUrl: "/ContactInfo/ViewContactInfo",
            controller: "ViewController"
        }) 
        .when("/CreateContactInfo", {
            templateUrl: "/ContactInfo/CreateContactInfo"
        })
        .when("/EditContactInfo", {
            templateUrl: "/ContactInfo/EditContactInfo"
        })
        .when("/DeleteContactInfo", {
            templateUrl: "/ContactInfo/DeleteContactInfo"
        })
})

app.controller("ViewController", function ($scope) {
    $scope.message = "View Contact Info";
})