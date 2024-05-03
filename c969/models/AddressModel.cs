using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace c969.models
{
    public  class AddressModel
    {
      public  int addressId { get; set; }
      public  string address { get; set; }
      public int cityId { get; set; }
      public string postalCode { get; set; }
       public string phone { get; set; }
       
        public AddressModel(int addressId, string address, int cityId, string postalCode, string phone)
        {
            this.addressId = addressId;
            this.address = address;
            this.cityId = cityId;
            this.postalCode = postalCode;
            this.phone = phone;
           
        }
        



    }
}
