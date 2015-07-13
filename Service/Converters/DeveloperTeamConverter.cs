using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class DeveloperTeamConverter
    {
        public static Dto.DeveloperTeam ToDto(Dmn.DeveloperTeam domain)
        {
            List<Dto.Developer> devs = new List<Dto.Developer>();

            foreach (Dmn.Developer dev in domain.TeamMembers)
            {
                devs.Add(DeveloperConvert.ToDto(dev));
            }

            return new Dto.DeveloperTeam()
            {
                Id = domain.Id,
                TeamMembers = devs,
                TeamName = domain.TeamName
            };
        }
    }
}
