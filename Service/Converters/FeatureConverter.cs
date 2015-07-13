using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class FeatureConverter
    {
        public static Dto.Feature ToDto(Dmn.Feature domain)
        {
            return new Dto.Feature()
            {
                Id = domain.Id,
                Location = WebLocationConverter.ToDto(domain.Location),
                Team = DeveloperTeamConverter.ToDto(domain.Team),
                IsBroken = domain.IsBroken,
                Name = domain.Name
            };
        }
    }
}
