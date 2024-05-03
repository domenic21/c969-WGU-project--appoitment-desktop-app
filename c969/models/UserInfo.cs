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
        public int phone { get; set; }

        public int customerId { get; set; }
   
  
       
     
        public UserInfo(int userId, string UserName,int customerId, string address,  int postalCode, int phone, string city, int cityId,
            string coyntry, int countryId)
        {
            this.UserId = userId;
            this.UserName = UserName;
            this.address = address;
            this.city = city;
            this.cityId = cityId;
            this.country = country;
            this.countryId = countryId;
            this.postalCode = postalCode;
            this.phone = phone;
            this.city = city;
            this.country = country;
            this.customerId = customerId;


        }

        public UserInfo(int userId, string city, int cityId)
        {
            this.UserId = userId;
            this.city = city;
            this.cityId = cityId;


        }

        public UserInfo (int userId, string userName, int customerId, string address, int postalCode, int phone)
        {
          this.UserId = userId;
            this.UserName = userName;
            this.address = address;
            this.postalCode = postalCode;
            this.phone = phone;
            this.customerId = customerId;

        }
    }
}
