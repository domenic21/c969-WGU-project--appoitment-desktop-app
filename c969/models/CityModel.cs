using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.models
{
    public class CityModel
    {
        public int cityId { get; set; }
        public string city { get; set; }
        public int countryId { get; set; }

        public string country { get; set; }

        public CityModel(int cityId, string city, int countryId, string country)
        {
            this.cityId = cityId;
            this.city = city;
            this.countryId = countryId;
            this.country = country;
        }

        public override string ToString()
        {
            // Customize the string representation as desired
            return $"{city}, {country}";
        }
    }
}
