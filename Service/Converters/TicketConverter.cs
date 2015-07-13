using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class TicketConverter
    {
        public static Dto.Ticket ToDto(Dmn.Ticket domain)
        {
            return new Dto.Ticket()
            {
                TicketInfo = TicketInformationConverter.ToDto(domain.TicketInfo),
                ContactInfo = CustomerConverter.ToDto(domain.ContactInfo),
                FeatureToFix = FeatureConverter.ToDto(domain.FeatureToFix)
            };
        }
    }
}
