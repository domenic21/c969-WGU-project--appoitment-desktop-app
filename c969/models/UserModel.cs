using System;


namespace c969.models
{
    public class UserModel
    {
        public int userId { get; set; }

        public int customerId { get; set; }

        public string userName { get; set; }

        public string customerName { get; set; }
        public string password { get; set; }
        public int active { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
        //registration constructor
        public UserModel(int userId,int customerId, string customerName, string userName, string password, int active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            this.userId = userId;
            this.userName = userName;
            this.customerName = customerName;
            this.customerName = customerName;
            this.password = password;
            this.active = active;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.lastUpdateBy = lastUpdateBy;
        }

        public UserModel(int userId, string userName, string password, int active, DateTime createDate, string createdBy, DateTime lastUpdate, string lastUpdateBy)
        {
            this.userId = userId;
            this.userName = userName;
            this.password = password;
            this.active = active;
            this.createDate = createDate;
            this.createdBy = createdBy;
            this.lastUpdate = lastUpdate;
            this.lastUpdateBy = lastUpdateBy;
        }
        //login constructor
        public UserModel(string userName)
        {
            this.userName = userName;
        }

        public UserModel(string customerName, int customerId )
        {
            this.customerName = customerName;
            this.customerId = customerId;
        }






    }
}

