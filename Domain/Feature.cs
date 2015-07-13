using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Feature
    {
        private static int IdNumber = 0;
        
        public Feature(WebLocation location, DeveloperTeam team, bool broken, string name)
        {
            this.Id = ++IdNumber;
            this.IsBroken = broken;
            this.Team = team;
            this.Location = location;
            this.Name = name;
        }

        public Feature(int id, WebLocation location, DeveloperTeam team, bool broken, string name)
        {
            this.Id = id;
            this.IsBroken = broken;
            this.Team = team;
            this.Location = location;
            this.Name = name;
        }

        public int Id { get; set; }
        public WebLocation Location { get; set; }
        public DeveloperTeam Team { get; set; }
        public bool IsBroken { get; set; }
        public string Name { get; set; }

        public void Update(int id, WebLocation location, DeveloperTeam team, bool broken, string name)
        {
            this.Id = id;
            this.IsBroken = broken;
            this.Team = team;
            this.Location = location;
            this.Name = name;
        }

        public override string ToString()
        {
            return this.Location.ToString() + ", \n" + this.Team.ToString() + ", isbroken = " + this.IsBroken;
        }
    }
}
