using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Dto
{
    public class Customer
    {
        public static int IdNumber = 0;
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string TwitterHandle { get; set; }
        public string FacebookName { get; set; }
        public string ContactMethod { get; set; }
    }
}
