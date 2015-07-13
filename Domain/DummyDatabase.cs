using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class DummyDatabase
    {
        private static string test = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt utlabore et dolore magna aliqua.Ut enim ad minim veniam, quis nostrud exercitation ullamco labor is nisi ut aliquip ex ea commodo consequat.Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.";

        public static List<Customer> Customers = new List<Customer>()
        {
        new Customer("Mike Jones", "customer@gmail.com", "123-456-7890", test, "@mikeJones", "Mike James Jones", "Twitter"),
        new Customer("John Jones", "customer@gmail.com", "123-456-7890", test, "@mikeJones", "Mike James Jones", "Facebook"),
        new Customer("Andrew Jones", "customer@gmail.com", "123-456-7890", "new Customer Message", "@mikeJones", "Mike James Jones", "Facebook"),
        new Customer("Katie Jones", "customer@gmail.com", "123-456-7890", "new Customer Message", "@mikeJones", "Mike James Jones", "Facebook")
        };

        public static List<Developer> Developers = new List<Developer>()
        {
        new Developer("Steve Dev", "123-456-7890", "dev1@gmail.com"),
        new Developer("David Dev", "123-456-7890", "dev2@gmail.com"),
        new Developer("Joe Dev", "123-456-7890", "dev3@gmail.com"),
        new Developer("Mike Dev", "123-456-7890", "dev4@gmail.com")
        };

        private static DeveloperTeam DevTeam1 = new DeveloperTeam(new List<Developer> {Developers[0], Developers[1]}, "Seal Team 6");
        private static DeveloperTeam DevTeam2 = new DeveloperTeam(new List<Developer> {Developers[2], Developers[3] }, "optic");
        public static List<DeveloperTeam> DeveloperTeams = new List<DeveloperTeam>() {DevTeam1, DevTeam2 };

        private static WebLocation WebLocation1 = new WebLocation(1, "earlyBirds.com/home", "earlyBirds", "home");
        private static WebLocation WebLocation2 = new WebLocation(2, "estateSales.net/home", "estateSales", "home");
        public static List<WebLocation> WebLocations = new List<WebLocation>() {WebLocation1, WebLocation2 };

        private static Feature Feature1 = new Feature(WebLocation1, DeveloperTeams[0], true, "Printer Button");
        private static Feature Feature2 = new Feature(WebLocation2, DeveloperTeams[1], true, "Submit Button");
        public static List<Feature> Features = new List<Feature>(){ Feature1, Feature2 };

        private static TicketInformation TicketInformation1 = new TicketInformation(1, (Priority)1, test);
        private static TicketInformation TicketInformation2 = new TicketInformation(2, (Priority)3, test);
        private static TicketInformation TicketInformation3 = new TicketInformation(3, (Priority)3, test);
        private static TicketInformation TicketInformation4 = new TicketInformation(4, (Priority)5, test);
        private static TicketInformation TicketInformation5 = new TicketInformation(5, (Priority)4, test);
        private static TicketInformation TicketInformation6 = new TicketInformation(6, (Priority)5, test);
        private static TicketInformation TicketInformation7 = new TicketInformation(7, (Priority)1, test);
        private static TicketInformation TicketInformation8 = new TicketInformation(8, (Priority)5, test);
        private static TicketInformation TicketInformation9 = new TicketInformation(9, (Priority)2, test);
        private static TicketInformation TicketInformation10 = new TicketInformation(10, (Priority)5, test);
        private static TicketInformation TicketInformation11 = new TicketInformation(11, (Priority)3, test);
        private static TicketInformation TicketInformation12 = new TicketInformation(12, (Priority)5, test);
 

       public static List<TicketInformation> TicketInformation = new List<TicketInformation>() {TicketInformation1, TicketInformation2, TicketInformation3, TicketInformation4, TicketInformation5, TicketInformation6, TicketInformation7, TicketInformation8, TicketInformation9, TicketInformation10, TicketInformation11, TicketInformation12 };

        private static Ticket Ticket1 = new Ticket(TicketInformation[0], Customers[0], Features[0]);
        private static Ticket Ticket2 = new Ticket(TicketInformation[1], Customers[1], Features[1]);
        private static Ticket Ticket3 = new Ticket(TicketInformation[2], Customers[0], Features[0]);
        private static Ticket Ticket4 = new Ticket(TicketInformation[3], Customers[1], Features[1]);
        private static Ticket Ticket5 = new Ticket(TicketInformation[4], Customers[0], Features[1]);
        private static Ticket Ticket6 = new Ticket(TicketInformation[5], Customers[1], Features[0]);
        private static Ticket Ticket7 = new Ticket(TicketInformation[6], Customers[0], Features[0]);
        private static Ticket Ticket8 = new Ticket(TicketInformation[7], Customers[1], Features[1]);
        private static Ticket Ticket9 = new Ticket(TicketInformation[8], Customers[0], Features[0]);
        private static Ticket Ticket10 = new Ticket(TicketInformation[9], Customers[1], Features[1]);
        private static Ticket Ticket11 = new Ticket(TicketInformation[10], Customers[0], Features[1]);
        private static Ticket Ticket12 = new Ticket(TicketInformation[11], Customers[1], Features[0]);
        public static List<Ticket> Tickets = new List<Ticket>() {Ticket1, Ticket2, Ticket3, Ticket4, Ticket5, Ticket6, Ticket7, Ticket8, Ticket9, Ticket10, Ticket11, Ticket12};
    }
}