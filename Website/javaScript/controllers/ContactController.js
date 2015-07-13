(function () {
    'use strict';

    var app = angular.module('earlybirds');
    app.controller('ContactController', ContactController);

    ContactController.$inject = ['$http']; 

    function ContactController($http) {
        /* jshint validthis:true */
        var vm = this;
        vm.nameFresh = true;
        vm.emailFresh = true;
        vm.messageFresh = true;
        vm.urlFresh = true;
        
        vm.submitForm = function () {
            vm.nameFresh = false;
            vm.emailFresh = false;
            vm.messageFresh = false;
            vm.urlFresh = false;
            var putUrl = 'http://localhost:2001/tickets/';
            var name = document.getElementById("name").value;
            var email = document.getElementById("email").value;
            var message = document.getElementById("message").value;
            var url = document.getElementById("url").value;
            vm.checkForm(name, email, message, url);
            vm.ticketCreated = createTicket(name, email, message, url);
            $http.post(putUrl, vm.ticketCreated).then(onTicketSubmitSuccess, onTicketSubmitError);
        };

        vm.click = function () {
            vm.nameFresh = false;
            vm.emailFresh = false;
            vm.messageFresh = false;
            vm.urlFresh = false;
            var putUrl = 'http://localhost:2001/tickets/';
            var name = document.getElementById("name").value;
            var email = document.getElementById("email").value;
            var message = document.getElementById("message").value;
            var url = document.getElementById("url").value;
            vm.checkForm(name, email, message, url);
        };

        function onTicketSubmitSuccess() {
            vm.resultMessage = "Created Ticket Successfully";
        }

        function onTicketSubmitError() {
            vm.resultMessage = "Creation Didn't Work";
        }

        function createTicket(name, email, message, url) {
            var ret = {
                "ticketInfo": {
                    "id": 17,
                    "priority": 0,
                    "devNotes": ""
                },
                "contactInfo": {
                    "id": 0,
                    "name": name,
                    "phoneNumber": "123-456-7890",
                    "email": email,
                    "message": message,
                    "twitterHandle": "@unset",
                    "facebookName": "unset",
                    "contactMethod": "Company Website"
                },
                "featureToFix": {
                    "id": 0,
                    "location": {
                        "id": 0,
                        "url": url,
                        "website": "unassigned",
                        "webpage": "unassigned"
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

        vm.checkForm = function (name, email, message, url) {
            var name = document.getElementById("name").value;
            var email = document.getElementById("email").value;
            var message = document.getElementById("message").value;
            var url = document.getElementById("url").value;
            vm.highlightInvalid(name, email, message,url);
            vm.logInputs(name, email, message,url);
        };

        vm.highlightInvalid = function (name, email, message, url) {
            var normal = "#e8eeef";
            var pink = "pink";

            vm.logInputs(name, email, message, url);

            if (name == "") {
                if (!vm.nameFresh)
                    document.getElementById("name").style.background = pink;
            } else {
                vm.nameFresh = false;
                document.getElementById("name").style.background = normal;
            }

            if (email == "" || !email.includes("@") || !email.includes(".")) {
                if (!vm.emailFresh)
                    document.getElementById("email").style.background = pink;
            } else {
                vm.emailFresh = false;
                document.getElementById("email").style.background = normal;
            }

            if (message == "") {
                if (!vm.messageFresh)
                    document.getElementById("message").style.background = pink;
            } else {
                vm.messageFresh = false;
                document.getElementById("message").style.background = normal;
            }

            if (url == "") {
                if (!vm.urlFresh) 
                    document.getElementById("url").style.background = pink;
            } else {
                vm.urlFresh = false;
                document.getElementById("url").style.background = normal;
            }
        };

        vm.logInputs = function (name, email, message, url) {
            console.log("name = " + name);
            console.log("email = " + email);
            console.log("message = " + message);
            console.log("url = " + url);
        };

        activate();

        function activate() { }
    }
})();
