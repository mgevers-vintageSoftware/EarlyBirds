using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Customer
    {
        private static int IdNumber = 0;
        
        public Customer(int id, string name, string email, string phoneNumber, string message, string twitterHandle, string facebookName, string contactMethod)
        {
            this.Id = id;
            this.ContactMethod = contactMethod;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Message = message;
            this.TwitterHandle = twitterHandle;
            this.FacebookName = facebookName;
        }

        public Customer(string name, string email, string phoneNumber, string message, string twitterHandle, string facebookName, string contactMethod)
        {
            this.Id = ++IdNumber;
            this.ContactMethod = contactMethod;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Message = message;
            this.TwitterHandle = twitterHandle;
            this.FacebookName = facebookName;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Message { get; set; }
        public string TwitterHandle { get; set; }
        public string FacebookName { get; set; }
        public string ContactMethod { get; set; }

        public void Update(int id, string name, string email, string phoneNumber, string message, string twitterHandle, string facebookName, string contactMethod)
        {
            this.Id = id;
            this.ContactMethod = contactMethod;
            this.Name = name;
            this.PhoneNumber = phoneNumber;
            this.Email = email;
            this.Message = message;
            this.TwitterHandle = twitterHandle;
            this.FacebookName = facebookName;
        }

        public override string ToString()
        {
            return "{Customer name = " + this.Name + ", contact method = " + this.ContactMethod + "}";
        }
    }    
}
