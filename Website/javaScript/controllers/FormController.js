(function () {
    'use strict';

    var app = angular.module('earlybirds');
    app.controller('FormController', FormController);

    FormController.$inject = ['$http']; 

    function FormController($http) {
        /* jshint validthis:true */
        var vm = this;

        var urlTicket = "http://localhost:2001/tickets/";
        //var urlFeature = "http://localhost:2001/features";
        //var urlTicInfo = "http://localhost:2001/ticket-Information";
        //var urlLocation = "http://localhost:2001/web-locations/";
        //var urlDevTeam = "http://localhost:2001/developer-teams";
        //var urlDev = "http://localhost:2001/developers";
        //var urlCustomers = "http://localhost:2001/customers";
        vm.nameFresh = true;
        vm.conFresh = true;
        vm.emailFresh = true;
        vm.messageFresh = true;
        vm.titleFresh = true;
        vm.prioFresh = true;

        vm.click = function () {
            vm.nameFresh = false;
            vm.conFresh = false;
            vm.emailFresh = false;
            vm.messageFresh = false;
            vm.titleFresh = false;
            vm.prioFresh = false;

            var name = document.getElementById("name").value;
            var website = document.getElementById("website").value;
            var webpage = document.getElementById("webpage").value;
            var message = document.getElementById("message").value;
            var priority = document.getElementById("ticketPriority").value;
            var method = ($('input[name="contact"]:checked').val());

            vm.checkForm();
        };

        vm.submitForm = function () {
            vm.nameFresh = false;
            vm.conFresh = false;
            vm.emailFresh = false;
            vm.messageFresh = false;
            vm.titleFresh = false;
            vm.prioFresh = false;

            var name = document.getElementById("name").value;
            var website = document.getElementById("website").value;
            var webpage = document.getElementById("webpage").value;
            var message = document.getElementById("message").value;
            var priority = document.getElementById("ticketPriority").value;
            var method = ($('input[name="contact"]:checked').val());

            vm.checkForm();
            
            vm.ticketCreated = createTicket(name, website, webpage, message, priority, method);

            $http.post(urlTicket, vm.ticketCreated).then(onTicketSubmitSuccess, onTicketSubmitError);
        };

        function onTicketSubmitSuccess() {
            vm.resultMessage = "Created Ticket Successfully";
        }

        function onTicketSubmitError() {
            vm.resultMessage = "Creation Didn't Work";
        }


        function createTicket(name, website, webpage, message, priority, method) {
            var ret = {
                "ticketInfo": {
                    "id": 17,
                    "priority": priority,
                    "devNotes": ""
                },
                "contactInfo": {
                    "id": 0,
                    "name": name,
                    "phoneNumber": "123-456-7890",
                    "email": "unset",
                    "message": message,
                    "twitterHandle": "@unset",
                    "facebookName": "unset",
                    "contactMethod": method
                },
                "featureToFix": {
                    "id": 0,
                    "location": {
                        "id": 0,
                        "url": website + "/" + webpage,
                        "website": website,
                        "webpage": webpage
                    },
                    "team": {
                        "id": 0,
                        "teamMembers": [
                          {
                              "id": 0,
                              "name": "unassigned",
                              "phoneNumber": "unassigned",
                              "email": "unassigned"
                          },
                          {
                              "id": 0,
                              "name": "unassigned",
                              "phoneNumber": "unassigned",
                              "email": "unassigned"
                          }
                        ],
                        "teamName": "unassigned"
                    },
                    "isBroken": true,
                    "name": "not yet named"
                }
            }

            return ret;
        }

        vm.checkForm = function () {
            var name = document.getElementById("name").value;
            var website = document.getElementById("website").value;
            var webpage = document.getElementById("webpage").value;
            var message = document.getElementById("message").value;
            var priority = document.getElementById("ticketPriority").value;
            var method = ($('input[name="contact"]:checked').val());

            vm.highlightInvalid(name, website, webpage, message, priority, method);
            vm.logInputs(name, website, webpage, message, priority, method);
        }

        vm.highlightInvalid = function (name, website, webpage, message, priority, method) {
            var normal = "#e8eeef";
            var pink = "pink";
            

            if (name == "") {
                if(!vm.nameFresh)
                    document.getElementById("name").style.background = pink;
            } else {
                vm.nameFresh = false;
                document.getElementById("name").style.background = normal;
            }

            if (website == "") {
                if(!vm.conFresh)
                    document.getElementById("website").style.background = pink;
            } else {
                vm.conFresh = false;
                document.getElementById("website").style.background = normal;
            }

            if (webpage == "") {
                if(!vm.emailFresh)
                    document.getElementById("webpage").style.background = pink;
            } else {
                vm.emailFresh = false;
                document.getElementById("webpage").style.background = normal;
            }

            if (message == "") {
                if (!vm.messageFresh)
                    document.getElementById("message").style.background = pink;
            } else {
                vm.messageFresh = false;
                document.getElementById("message").style.background = normal;
            }

            if (priority == "") {
                if (!vm.prioFresh)
                    document.getElementById("ticketPriority").style.background = pink;
            } else {
                vm.prioFresh = false;
                document.getElementById("ticketPriority").style.background = normal;
            }
        };

        vm.logInputs = function (name, website, webpage, message, priority, method) {
            console.log("name = " + name);
            console.log("website = " + website);
            console.log("webpage = " + webpage);
            console.log("message = " + message);
            console.log("priority = " + priority);
            console.log("method = " + method);
        };

        activate();

        function activate() { }
    }
})();
