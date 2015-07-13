using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class DeveloperConvert
    {
        public static Dto.Developer ToDto(Dmn.Developer domain)
        {
            return new Dto.Developer()
            {
              Id = domain.Id,
                Name = domain.Name,
                PhoneNumber = domain.PhoneNumber,
                Email = domain.Email
            };
        }
    }
}  
