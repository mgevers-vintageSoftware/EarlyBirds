using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class DeveloperTeam
    {
        private static int IdNumber = 0;
        
        public DeveloperTeam(int id, ICollection<Developer> team, string name)
        {
            this.Id = id;
            this.TeamMembers = team;
            this.TeamName = name;
        }

        public DeveloperTeam(ICollection<Developer> team, string name)
        {
            this.Id = ++IdNumber;
            this.TeamMembers = team;
            this.TeamName = name;
        }

        public int Id { get; set; }
        public ICollection<Developer> TeamMembers { get; set; }
        public string TeamName { get; set; }

        public void AddDeveloperToTeam(Developer dev)
        {
            this.TeamMembers.Add(dev);
        }

        public void Update(int id, ICollection<Developer> team, string name)
        {
            this.Id = id;
            this.TeamMembers = team;
            this.TeamName = name;
        }

        public bool RemoveDeveloper(Developer dev)
        {
            if (this.TeamMembers.Contains(dev))
            {
                this.TeamMembers.Remove(dev);
                return true;
            }

            // Console.WriteLine("team did not contain developer : " + dev.ToString());
            return false;
        }

        public string GetMembers()
        {
            string ret = null;
            foreach (Developer dev in this.TeamMembers)
            {
                ret += dev.ToString() + "\n";
            }

            return ret;
        }

        public override string ToString()
        {
            return "team name = " + this.TeamName + ", has " + this.TeamMembers.Count + " members";
        }
    }
}
