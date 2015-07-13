(function () {
    'use strict';

    angular
        .module('earlybirds')
        .config(config);

    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $locationProvider.html5Mode(true);

        $routeProvider
            .when('/', {
                templateUrl: '/javaScript/templates/home.html'
            })
            .when('/ticket-entry/:ticketId', {
                templateUrl: '/javaScript/templates/ticket-entry.html',
                controller: 'TicketEntryController',
                controllerAs: 'entryCtrl'
            }).when('/view-tickets', {
                templateUrl: '/javaScript/templates/view-tickets.html',
                controller: 'TicketTableController',
                controllerAs: 'ticketCtrl'
            }).when('/contact-us', {
                templateUrl: '/javaScript/templates/contact.html',
                controller: 'ContactController',
                controllerAs: 'conCtrl'
            }).when('/create-ticket', {
                templateUrl: '/javaScript/templates/create-ticket.html',
                controller: 'FormController',
                controllerAs: 'formCtrl'
            })
            .otherwise({
                templateUrl: '/javaScript/templates/not-found.html',
            });
    }
}());