using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Service;

namespace Domain
{
    public class Program
    {
        public static void Main()
        {
            DeveloperTeam devTeamTest = CreateDevTeam();
            Feature testFeature = CreateFeature(devTeamTest);
            Ticket tic1 = CreateRandomTicket(testFeature, 1);

            // Console.WriteLine("\n\nstart of Ticket info:\n" + tic1 + "\nend of Ticket info\n");
            // Console.WriteLine("\nTeam Members:\n" + testFeature.Team.GetMembers());

            // DatabaseInteract.WriteTicketToDatabase("TicketInfo", tic1.TicketInfo);

            // TicketInformation ticInfo = DatabaseInteract.GetTicketInfoFromDatabase(1);

            // Console.WriteLine(ticInfo);           
            Console.ReadLine();

        }

        public static Dictionary<int, T> LoadDictionary<T>(ICollection<T> numbers)
        {
            if (numbers == null)
            {
                return null;
            }

            Dictionary<int, T> ret = new Dictionary<int, T>();
            int key = 0;
            foreach (T i in numbers)
            {
                AddToDictionary(ret, key++, i);
            }

            return ret;
        }

        public static void AddToDictionary<T>(Dictionary<int, T> dictionary, int key, T value)
        {
            try
            {
                if (dictionary != null)
                {
                    dictionary.Add(key, value);
                }
            }
            catch (ArgumentException)
            {
                // error logging goes here
            }
        }

        public static Ticket CreateRandomTicket(Feature feature, int index)
        {
            NumberLine prio = new NumberLine(1, 5);
            string name = "Customer 1";
            string contactMethod = "facebook";
            string phoneNumber = "123-456-7890";
            string email = "fakeEmail@gmail.com";
            string message = "Customer complaint here";
            string twitterHandle = "@fakeTwitter";
            string facebook = "face book name";
            Priority priority = (Priority)prio.Unsorted.First();
            string devNotes = "developer notes here";

            Customer c = new Customer(name, email, phoneNumber, message, twitterHandle, facebook, contactMethod);
            TicketInformation t = new TicketInformation(priority, devNotes);

            return new Ticket(t, c, feature);
        }

        public static DeveloperTeam CreateDevTeam()
        {
            DeveloperTeam ret;
            string[] devNames = { "Mike Jones", "Dave Jones", "Steve Jones", "Linda Jones"};
            string phone = "123-456-7890";
            string email = "email@gmail.com";
            List<Developer> team = new List<Developer>();
            for (int i = 0; i < 4; i++)
            {
                team.Add(new Developer(devNames[i], phone, email));
            }

            ret = new DeveloperTeam(team, "optic");
            return ret;
        }

        public static Feature CreateFeature(DeveloperTeam team)
        {
            string tempUrl = "earlyBirds.com/viewTickets/ticket1";
            string website = "earlyBirds";
            string webpage = "viewTicket1";
            string name = "printerButton";

            WebLocation location = new WebLocation(tempUrl, website, webpage);
            return new Feature(location, team, true, name);
        }

        public static void TestPrint()
        {
            Console.WriteLine("Hello World");
        }
    }
}
