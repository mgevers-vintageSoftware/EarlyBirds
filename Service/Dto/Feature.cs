using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Feature
    {
        public int Id { get; set; }
        public WebLocation Location { get; set; }
        public DeveloperTeam Team { get; set; }
        public bool IsBroken { get; set; }
        public string Name { get; set; }
    }
}
