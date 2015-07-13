using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class WebLocation
    {
        private static int IdNumber = 2;
        
        public WebLocation(string url, string website, string webpage)
        {
            this.Id = ++IdNumber;
            this.Url = url;
            this.Website = website;
            this.Webpage = webpage;
        }

        public WebLocation(int id, string url, string website, string webpage)
        {
            this.Id = id;
            this.Url = url;
            this.Website = website;
            this.Webpage = webpage;
        }

                public int Id { get; set; }
        public string Url { get; set; }
        public string Website { get; set; }
        public string Webpage { get; set; }

        public void Update(int id, string url, string website, string webpage)
        {
            this.Id = id;
            this.Url = url;
            this.Website = website;
            this.Webpage = webpage;
        }

        public override string ToString()
        {
            return "Location = " + this.Url;
        }
    }
}
