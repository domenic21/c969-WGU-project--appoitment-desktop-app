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
   
  
       
     
        public UserInfo(int userId, string UserName,int customerId, string address,  int postalCode, string phone, int cityId)
             
        {
            this.UserId = userId;
            this.UserName = UserName;
            this.address = address;
            this.cityId = cityId;
            this.postalCode = postalCode;
            this.phone = phone;
         
            this.customerId = customerId;


        }
        public UserInfo(int userId, string UserName, int customerId,int addressId, string address, int postalCode, string phone, int cityId)

        {
            this.UserId = userId;
            this.UserName = UserName;
            this.address = address;
            this.cityId = cityId;
            this.postalCode = postalCode;
            this.phone = phone;
            this.addressId = addressId;
            this.customerId = customerId;


        }

        public UserInfo(int userId, string UserName, int customerId, string address, int postalCode, string phone, int cityId, int addressId)

        {
            this.UserId = userId;
            this.UserName = UserName;
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

        public UserInfo (int userId, string userName, int customerId, string address, int postalCode, string phone,int cityId, string city, string country)
        {
          this.UserId = userId;
            this.UserName = userName;
            this.address = address;
            this.postalCode = postalCode;
            this.phone = phone;
            this.customerId = customerId;
            this.cityId = cityId;
            this.city = city;
            this.country = country;
            
        }

    }
}
