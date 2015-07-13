using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class CustomerConverter
    {
        public static Dto.Customer ToDto(Dmn.Customer domain)
        {
            return new Dto.Customer()
            {
                Id = domain.Id,
                Name = domain.Name,
                PhoneNumber = domain.PhoneNumber,
                Email = domain.Email,
                Message = domain.Message,
                TwitterHandle = domain.TwitterHandle,
                FacebookName = domain.FacebookName,
                ContactMethod = domain.ContactMethod
            };
        }
    }
}
