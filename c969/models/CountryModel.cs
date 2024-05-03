using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.models
{
     public class CountryModel
    { 
        public int countryId { get; set; }
        public string country { get; set; }
       
        public CountryModel(int countryId, string country)
        {
            this.countryId = countryId;
            this.country = country;
       
        }
    }
}
