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
    public class WebLocationService
    {
        #region Developer Team Interaction

        public static List<Dto.WebLocation> GetAllWebLocations()
        {
            List<Dto.WebLocation> locations = new List<Dto.WebLocation>();

            foreach(Dmn.WebLocation location in Dmn.DummyDatabase.WebLocations)
            {
                locations.Add(WebLocationConverter.ToDto(location));
            }

            return locations; 
        }

        public static Dto.WebLocation GetWebLocation(int id)
        {
            Dmn.WebLocation location = Dmn.DummyDatabase.WebLocations.FirstOrDefault(i => i.Id == id);
            return WebLocationConverter.ToDto(location);
        }

        public static Dto.WebLocation GetWebLocation(string website)
        {
            Dmn.WebLocation location = Dmn.DummyDatabase.WebLocations.FirstOrDefault(i => i.Website.ToLower() == website.ToLower());
            return WebLocationConverter.ToDto(location);
        }

        public static Dto.WebLocation PostWebLocation(string url, string website, string webpage)
        {
            Dmn.WebLocation location = new Dmn.WebLocation(url, website, webpage);
            Dmn.DummyDatabase.WebLocations.Add(location);
            return WebLocationConverter.ToDto(location);
        }

        public static bool PutWebLocation(int id, string url, string website, string webpage)
        {
            Dmn.WebLocation webLocation = Dmn.DummyDatabase.WebLocations.FirstOrDefault(i => i.Id == id);
            if (webLocation == null)
            {
                return false;
            }

            webLocation.Update(id, url, website, webpage);

            return true;
        }

        public static bool DeleteWebLocation(int id)
        {
            Dmn.WebLocation del = Dmn.DummyDatabase.WebLocations.FirstOrDefault(i => i.Id == id);

            if (Dmn.DummyDatabase.WebLocations.Contains(del))
            {
                Dmn.DummyDatabase.WebLocations.Remove(del);
                return true;
            }
            return false;
        }

        #endregion
    }
}
