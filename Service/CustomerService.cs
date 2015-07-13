using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dmn = Domain;
using Dto = Service.Dto;
using Service.Converters;

namespace Service
{
    public class CustomerService
    {
        #region Customer Interactions

        public static List<Dto.Customer> GetAllCustomers()
        {
            List<Dto.Customer> customers = new List<Dto.Customer>();

            foreach (Dmn.Customer customer in Dmn.DummyDatabase.Customers)
            {
                customers.Add(CustomerConverter.ToDto(customer));
            }

            return customers;
        }

        public static Dto.Customer GetCustomer(int id)
        {
            Dmn.Customer customer = Dmn.DummyDatabase.Customers.FirstOrDefault(i => i.Id == id);
            return CustomerConverter.ToDto(customer);
        }

        public static Dto.Customer GetCustomer(string name)
        {
            Dmn.Customer customer = Dmn.DummyDatabase.Customers.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
            return CustomerConverter.ToDto(customer);
        }

        public static Dto.Customer PostCustomer(string name, string email, string phoneNumber, string message, string twitterHandle, string facebookName, string contactMethod)
        {
            Dmn.Customer cust = new Dmn.Customer(name, email, phoneNumber, message, twitterHandle, facebookName, contactMethod);
            Dmn.DummyDatabase.Customers.Add(cust);
            return CustomerConverter.ToDto(cust);
        }

        public static bool PutCustomer(int id, string name, string email, string phoneNumber, string message, string twitterHandle, string facebookName, string contactMethod)
        {
            Dmn.Customer customer = Dmn.DummyDatabase.Customers.FirstOrDefault(i => i.Id == id);
            if (customer == null)
            {
                return false;
            }
            customer.Update(id, name, email, phoneNumber, message, twitterHandle, facebookName, contactMethod);
            return true;
        }

        public static bool DeleteCustomer(int id)
        {
            Dmn.Customer del = Dmn.DummyDatabase.Customers.FirstOrDefault(i => i.Id == id);

            if (Dmn.DummyDatabase.Customers.Contains(del))
            {
                Dmn.DummyDatabase.Customers.Remove(del);
                return true;
            }
            return false;
        }

        #endregion
    }
}
