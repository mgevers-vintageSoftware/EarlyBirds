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
    public class DeveloperTeamService
    {
        #region Developer Team Interaction

        public static List<Dto.DeveloperTeam> GetAllDeveloperTeams()
        {
            List<Dto.DeveloperTeam> devTeams = new List<Dto.DeveloperTeam>();

            foreach (Dmn.DeveloperTeam devTeam in Dmn.DummyDatabase.DeveloperTeams)
            {
                devTeams.Add(DeveloperTeamConverter.ToDto(devTeam));
            }

            return devTeams;
        }

        public static Dto.DeveloperTeam GetDeveloperTeam(int id)
        {
            Dmn.DeveloperTeam devTeam = Dmn.DummyDatabase.DeveloperTeams.FirstOrDefault(i => i.Id == id);
            return DeveloperTeamConverter.ToDto(devTeam);
        }

        public static Dto.DeveloperTeam GetDeveloperTeam(string name)
        {
            Dmn.DeveloperTeam devTeam =  Dmn.DummyDatabase.DeveloperTeams.FirstOrDefault(i => i.TeamName.ToLower() == name.ToLower());
            return DeveloperTeamConverter.ToDto(devTeam);
        }

        public static void PostDeveloperTeam(List<Dto.Developer> devs, string name)
        {
            List<Dmn.Developer> dmnDevs = new List<Domain.Developer>();

            foreach (Dto.Developer dev in devs)
            {
                dmnDevs.Add(new Dmn.Developer(dev.Id, dev.Name, dev.PhoneNumber, dev.Email));
            }

            Dmn.DeveloperTeam devTeam = new Dmn.DeveloperTeam(dmnDevs, name);
            Dmn.DummyDatabase.DeveloperTeams.Add(devTeam);
        }

        public static bool PutDeveloperTeam(int id, List<Dto.Developer> devs, string name)
        {
            Dmn.DeveloperTeam developerTeam = Dmn.DummyDatabase.DeveloperTeams.FirstOrDefault(i => i.Id == id);
            List<Dmn.Developer> dmnDevs = new List<Domain.Developer>();

            if (developerTeam == null)
            {
                return false;
            }

            foreach (Dto.Developer dev in devs)
            {
                dmnDevs.Add(new Dmn.Developer(dev.Id, dev.Name, dev.PhoneNumber, dev.Email));
            }

            developerTeam.Update(id, dmnDevs, name);
            return true;
        }

        public static bool DeleteDeveloperTeam(int id)
        {
            Dmn.DeveloperTeam del = Dmn.DummyDatabase.DeveloperTeams.FirstOrDefault(i => i.Id == id);

            if (Dmn.DummyDatabase.DeveloperTeams.Contains(del))
            {
               Dmn. DummyDatabase.DeveloperTeams.Remove(del);
                return true;
            }
            return false;
        }

        #endregion
    }
}
