using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;

namespace Service.Converters
{
    public static class TicketInformationConverter
    {
        public static Dto.TicketInformation ToDto(Dmn.TicketInformation domain)
        {
            return new Dto.TicketInformation()
            {
                Id = domain.Id,
                Priority = domain.Priority,
                DevNotes = domain.DevNotes
            };
        }
    }
}
