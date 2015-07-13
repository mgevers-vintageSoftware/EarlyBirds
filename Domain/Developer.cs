using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Developer
    {
        private static int IdNumber = 0;
        
        public Developer(string name, string phoneNumber, string email)
        {
            this.Id = ++IdNumber;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public Developer(int id, string name, string phoneNumber, string email)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        
        public void Update(int id, string name, string phoneNumber, string email)
        {
            this.Id = id;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
        }

        public override string ToString()
        {
            return "name = " + this.Name + ", phone number = " + this.PhoneNumber + ", email = " + this.Email;
        }
    }
}
