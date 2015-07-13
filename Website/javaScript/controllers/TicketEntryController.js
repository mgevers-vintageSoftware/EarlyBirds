(function () {
    'use strict';

    angular
        .module('earlybirds')
        .controller('TicketEntryController', TicketEntryController);

    TicketEntryController.$inject = ['$http', '$sce', '$routeParams']; 

    function TicketEntryController($http, $sce, $routeParams) {
        /* jshint validthis:true */
        var vm = this;
        vm.ticket = {};
        vm.submit = submit;
        vm.resultMessage = '';

        var updateCount = 0;

        var url = 'http://localhost:2001/tickets/' + $routeParams.ticketId;

        function onTicketLoadedSuccess(response) {
            vm.ticket = response.data;
            getStars(vm.ticket.ticketInfo.priority);

            var contactInfo = vm.ticket.contactInfo;

            getMethodLogo(contactInfo.contactMethod);
            getContactInfo(contactInfo.contactMethod,
                           contactInfo.twitterHandle,
                           contactInfo.facebookName,
                           contactInfo.phoneNumber,
                           contactInfo.email);
        }

        function getContactInfo(method, twitter, fb, phone, email) {
            var html = "";
            var info = "";

            switch (method) {
                case "Twitter":
                    html = "<img class='ticketLogo' src='img/twitter-logo.jpg' />";
                    info = twitter
                    break;
                case "Facebook":
                    html = "<img class='ticketLogo' src='img/facebook-logo.png' />";
                    info = fb;
                    break;
                case "Email":
                    html = "<img class='ticketLogo' src='img/email-logo.jpg' />";
                    info = email;
                    break;
                case "Phone":
                    html = "<img class='ticketLogo' src='img/phone-logo.jpg' />";
                    info = phone;
                    break;
                default:
                    html = "<img class='ticketLogo' src='img/internet-logo.png' />"
                    info = email;
                    break;
            }

            console.log("in method");

            if (info == "") {
                info = "not currently available";
            }
            html += "Contact Information: " + info;
            vm.contactInfo = $sce.trustAsHtml(html);
        }

        function getMethodLogo(method) {
            var html = "";

            switch (method) {
                case "Twitter":
                    html = "<img class='ticketLogo' src='img/twitter-logo.jpg' />";
                    break;
                case "Facebook":
                    html = "<img class='ticketLogo' src='img/facebook-logo.png' />";
                    break;
                case "Email":
                    html = "<img class='ticketLogo' src='img/email-logo.jpg' />";
                    break;
                case "Phone":
                    html = "<img class='ticketLogo' src='img/phone-logo.jpg' />";
                    break;
                default:
                    html = "<img class='ticketLogo' src='img/internet-logo.png' />"
                    break;
            }
            html += "Contact Method: " + method;
            vm.logoMethodImage = $sce.trustAsHtml(html);
        }

        function getStars(priority) {
            var filled = priority;
            var unfilled = 5 - filled;

            console.log(filled + ", " + unfilled)

            var html = "";

            for (var i = 0; i < filled; i++) {
                html += "<img class='priorityVisual' src='img/filled-star.png' />"
            }
            for (var i = 0; i < unfilled; i++) {
                html += "<img class='priorityVisual' src='img/unfilled-star.png' />"
            }

            vm.priorityVisual = $sce.trustAsHtml(html);
            console.log(vm.priorityVisual);
            console.log(html);
        }

        function onTicketLoadedError(reason) {
            vm.resultMessage = "could not fetch the data"
        }

        function submit() {
            $http.put(url, vm.ticket).then(onTicketSubmitSuccess, onTicketSubmitError);
        }

        function onTicketSubmitSuccess() {
            vm.resultMessage = "Updated x" + ++updateCount;
        }

        function onTicketSubmitError() {
            vm.resultMessage = "Update Didn't Work";
        }

        activate();

        function activate() {
            $http.get(url).then(onTicketLoadedSuccess, onTicketLoadedError);
        }
    }
})();
