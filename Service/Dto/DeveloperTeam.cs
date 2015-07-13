using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class DeveloperTeam
    {
        public static int IdNumber = 0;
        public int Id { get; set; }
        public List<Developer> TeamMembers { get; set; }
        public string TeamName { get; set; }
    }
}
