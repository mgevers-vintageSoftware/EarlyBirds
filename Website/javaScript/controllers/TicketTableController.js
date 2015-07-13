(function () {
    'use strict';

    var app = angular.module('earlybirds');
    app.controller('TicketTableController', TicketTableController);

    TicketTableController.$inject = ['$http'];

    function TicketTableController($http) {
        /* jshint validthis:true */
        var vm = this;
        var url = "http://localhost:2001/tickets";

        var onSuccess = function (response) {
            vm.tickets = response.data;
        };

        var onError = function (reason) {
            vm.error = "could not fetch the data"
        };

        vm.priority5 = function (ticket) {
            return false;
            //return ticket.ticketInfo.priority == 5;
        };

        vm.orderPriority = function () {
            hideTables();
            document.getElementById("priorityTicketTable").style.visibility = "visible";
            document.getElementById("priorityTicketTable").style.position = "relative";
        };

        vm.orderID = function () {
            hideTables();
            document.getElementById("idTicketTable").style.visibility = "visible";
            document.getElementById("idTicketTable").style.position = "relative";
        };

        vm.orderWebsite = function () {
            hideTables();
            document.getElementById("websiteTicketTable").style.visibility = "visible";
            document.getElementById("websiteTicketTable").style.position = "relative";
        };

        vm.searchPriority = function () {
            var prio = document.getElementById("priorityDropDown").value;
            hideTables();
            var table = "p" + prio + "Table";

            document.getElementById(table).style.visibility = "visible";
            document.getElementById(table).style.position = "relative";
        };

        var hideTables = function () {
            document.getElementById("idTicketTable").style.visibility = "hidden";
            document.getElementById("idTicketTable").style.position = "absolute";
            document.getElementById("priorityTicketTable").style.visibility = "hidden";
            document.getElementById("priorityTicketTable").style.position = "absolute";
            document.getElementById("p1Table").style.visibility = "hidden";
            document.getElementById("p1Table").style.position = "absolute";
            document.getElementById("p2Table").style.visibility = "hidden";
            document.getElementById("p2Table").style.position = "absolute";
            document.getElementById("p3Table").style.visibility = "hidden";
            document.getElementById("p3Table").style.position = "absolute";
            document.getElementById("p4Table").style.visibility = "hidden";
            document.getElementById("p4Table").style.position = "absolute";
            document.getElementById("p5Table").style.visibility = "hidden";
            document.getElementById("p5Table").style.position = "absolute";
            document.getElementById("websiteTicketTable").style.visibility = "hidden";
            document.getElementById("websiteTicketTable").style.position = "absolute";
        }

        $http.get(url).then(onSuccess, onError);

        activate();

        function activate() { }
    }
    
})();