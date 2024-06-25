using System;

namespace c969.models
{
    public class UserInfo
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string address { get; set; }
        public string address2 { get; set; }
        public string city { get; set; }

        public int cityId { get; set; }
        public string country { get; set; }
        public int countryId { get; set; }

        public int postalCode { get; set; }
        public string phone { get; set; }

        public int customerId { get; set; }

        public int addressId { get; set; }
        public string customerName { get; set; }
  
       
     
  
        
        public UserInfo(int customerId, string customerName,int addressId, string address, int postalCode, string phone, int cityId)

        {
            this.customerName = customerName;
            this.address = address;
            this.cityId = cityId;
            this.postalCode = postalCode;
            this.phone = phone;
            this.addressId = addressId;
            this.customerId = customerId;


        }

        

        public UserInfo(int userId, string city, int cityId)
        {
            this.UserId = userId;
            this.city = city;
            this.cityId = cityId;


        }

       

    }
}
