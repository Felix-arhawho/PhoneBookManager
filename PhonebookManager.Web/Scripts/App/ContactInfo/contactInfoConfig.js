var app = angular.module("ContactInfo", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "/ContactInfo/ListOfContactInfo",
            controller: "listController"
        })
        .when("/ViewContactInfo", {
            templateUrl: "/ContactInfo/ViewContactInfo",
            controller: "viewController"
        }) 
        .when("/CreateContactInfo", {
            templateUrl: "/ContactInfo/CreateContactInfo",
            controller: "createController"
        })
        .when("/EditContactInfo", {
            templateUrl: "/ContactInfo/EditContactInfo",
            controller: "editController"
        })
        .when("/DeleteContactInfo", {
            templateUrl: "/ContactInfo/DeleteContactInfo",
            controller: "deleteController"
        })
})
