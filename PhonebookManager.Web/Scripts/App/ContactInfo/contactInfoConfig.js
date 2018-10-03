var app = angular.module("ContactInfo", ["ngRoute"]);

app.config(function ($routeProvider) {
    $routeProvider
        .when("/", {
            templateUrl: "/ContactInfo/ListOfContactInfo",
            controller: "listController"
        })
        .when("/ViewContactInfo/:id", {
            templateUrl: "/ContactInfo/ViewContactInfo",
            controller: "viewController"
        }) 
        .when("/CreateContactInfo", {
            templateUrl: "/ContactInfo/CreateContactInfo",
            controller: "createController"
        })
        .when("/EditContactInfo/:id", {
            templateUrl: "/ContactInfo/EditContactInfo",
            controller: "editController"
        })
        .when("/DeleteContactInfo/:id", {
            templateUrl: "/ContactInfo/DeleteContactInfo",
            controller: "deleteController"
        })
        .otherwise({
            redirectTo: "/"
        })
})
