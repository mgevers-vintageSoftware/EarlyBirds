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
    public class DeveloperService
    {
        #region Developer Interaction

        public static List<Dto.Developer> GetAllDevelopers()
        {
            List<Dto.Developer> developers = new List<Dto.Developer>();

            foreach (Dmn.Developer developer in Dmn.DummyDatabase.Developers)
            {
                developers.Add(DeveloperConvert.ToDto(developer));
            }

            return developers;
        }

        public static Dto.Developer GetDeveloper(int id)
        {
            Dmn.Developer developer = Dmn.DummyDatabase.Developers.FirstOrDefault(i => i.Id == id);
            return DeveloperConvert.ToDto(developer);
        }

        public static Dto.Developer GetDeveloper(string name)
        {
            Dmn.Developer developer = Dmn.DummyDatabase.Developers.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
            return DeveloperConvert.ToDto(developer);
        }

        public static Dto.Developer PostDeveloper(string name, string phoneNumber, string email)
        {
            Dmn.Developer developer = new Dmn.Developer(name, phoneNumber, email);
            Dmn.DummyDatabase.Developers.Add(developer);
            return DeveloperConvert.ToDto(developer);
        }

        public static bool PutDeveloper(int id, string name, string phoneNumber, string email)
        {
            Dmn.Developer developer = Dmn.DummyDatabase.Developers.FirstOrDefault(i => i.Id == id);
            if (developer == null)
            {
                return false;
            }

            developer.Id = id;
            developer.Name = name;
            developer.PhoneNumber = phoneNumber;
            developer.Email = email;

            return true;
        }

        public static bool DeleteDeveloper(int id)
        {
            Dmn.Developer del = Dmn.DummyDatabase.Developers.FirstOrDefault(i => i.Id == id);

            if (Dmn.DummyDatabase.Developers.Contains(del))
            {
                Dmn.DummyDatabase.Developers.Remove(del);
                return true;
            }
            return false;
        }

        #endregion
    }
}
