using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class WebLocationConverter
    {
        public static Dto.WebLocation ToDto(Dmn.WebLocation domain)
        {
            return new Dto.WebLocation()
            {
                Id = domain.Id,
                Url = domain.Url,
                Webpage = domain.Webpage,
                Website = domain.Website
            };
        }
    }
}
