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
    public class FeatureService
    {
        public static List<Dto.Feature> GetAllFeatures()
        {
            List<Dto.Feature> features = new List<Dto.Feature>();

            foreach (Dmn.Feature feature in Dmn.DummyDatabase.Features)
            {
                features.Add(FeatureConverter.ToDto(feature));
            }

            return features;
        }

        public static Dto.Feature GetFeature(int id)
        {
            Dmn.Feature feature = Dmn.DummyDatabase.Features.FirstOrDefault(i => i.Id == id);
            return FeatureConverter.ToDto(feature);
        }

        public static Dto.Feature GetFeature(string name)
        {
            Dmn.Feature feature = Dmn.DummyDatabase.Features.FirstOrDefault(i => i.Name.ToLower() == name.ToLower());
            return FeatureConverter.ToDto(feature);
        }

        public static Dto.Feature PostFeature(string url, string website, string webpage, int id, List<Dto.Developer> devs, string teamName, bool isBroken, string featureName)
        {
            List<Dmn.Developer> dmnDevs = new List<Domain.Developer>();

            foreach (Dto.Developer dev in devs)
            {
                dmnDevs.Add(new Dmn.Developer(dev.Name, dev.PhoneNumber, dev.Email));
            }


            Dmn.WebLocation location = new Dmn.WebLocation(url, website, webpage);
            Dmn.DeveloperTeam team = new Dmn.DeveloperTeam(id, dmnDevs, teamName);
            Dmn.Feature feature = new Dmn.Feature(location, team, isBroken, featureName);
            Dmn.DummyDatabase.Features.Add(feature);
            return FeatureConverter.ToDto(feature);
        }

        public static bool PutFeature(int fid, string url, string website, string webpage, int did, List<Dto.Developer> devs, string teamName, bool isBroken, string featureName)
        {
            Dmn.Feature feature = Dmn.DummyDatabase.Features.FirstOrDefault(i => i.Id == fid);
            if (feature == null)
            {
                return false;
            }
            
            List<Dmn.Developer> dmnDevs = new List<Domain.Developer>();

            foreach (Dto.Developer dev in devs)
            {
                dmnDevs.Add(new Dmn.Developer(dev.Name, dev.PhoneNumber, dev.Email));
            }

            Dmn.WebLocation location = new Dmn.WebLocation(url, website, webpage);
            Dmn.DeveloperTeam team = new Dmn.DeveloperTeam(did, dmnDevs, teamName);
            feature.Update(fid, location, team, isBroken, featureName);
            return true;
        }

        public static bool DeleteFeature(int id)
        {
            Dmn.Feature del = Dmn.DummyDatabase.Features.FirstOrDefault(i => i.Id == id);

            if (Dmn.DummyDatabase.Features.Contains(del))
            {
                Dmn.DummyDatabase.Features.Remove(del);
                return true;
            }
            return false;
        }
    }
}
