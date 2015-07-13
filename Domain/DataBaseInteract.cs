using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public static class DatabaseInteract
    {
    ////    public const string Prefix = @"C:\Users\mgevers\Documents\Visual Studio 2015\Projects\EarlyBirds\Domain\DataBaseFiles\";

    ////    public static int GetNextIdFromTable(string table)
    ////    {
    ////        string[] text = System.IO.File.ReadAllLines(Prefix + table +".txt");
    ////        return Convert.ToInt32(text[0]);
    ////    }

    ////    public static TicketInformation GetTicketInfoFromDatabase(int index)
    ////    {
    ////        string table = "TicketInfo";
    ////        string[] text = System.IO.File.ReadAllLines(Prefix + table + ".txt");
    ////        if (index >= text.Length)
    ////        {
    ////            return null;
    ////        }
    ////        string ticket = text[index];
    ////        string[] args = GetArgs(ticket);

    ////        int id = Convert.ToInt32(args[0]);
    ////        Priority priority = (Priority)Enum.Parse(typeof(Priority), args[1]);
    ////        string devNotes = args[2];

    ////        return new TicketInformation(id, priority, devNotes);
    ////    }

    ////    public static void WriteTicketToDatabase(string table, TicketInformation info)
    ////    {   
    ////        if (info == null)
    ////        {
    ////            return;
    ////        }
    ////        List<string> text = new List<string>(System.IO.File.ReadAllLines(Prefix + table + ".txt"));
    ////        text[0] = (GetNextIdFromTable(table) + 1).ToString();
    ////        text.Add(info.Id + ", " + info.Priority + ", " + info.DevNotes);

    ////        System.IO.File.WriteAllLines(Prefix + table + ".txt", text);
    ////    }

    ////    public static string[] GetArgs(string s)
    ////    {
    ////        return s.Split(',').ToArray();
    ////    }
    }
}
