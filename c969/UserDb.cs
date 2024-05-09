using c969.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace c969
{
    public class UserDb : db
    {
        public UserDb(string server, string db, string user, string password)
            : base(server, db, user, password)
        {

        }


        public static BindingList<CityModel> multipleChoiceCountry = new BindingList<CityModel>();
        public static BindingList<AppointmentModel> appointmentModels = new BindingList<AppointmentModel>();
        public static BindingList<AppointmentModel> reports = new BindingList<AppointmentModel>();

        public IEnumerable<AppointmentModel> CustomerSchedules { get; internal set; }

        public void RegisterUser(UserModel user)
        {
            try
            {
                Connect();
                string query = "INSERT INTO `c968_db`.`user`(userId,userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                "VALUES (@UserId,@UserName, @Password, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@UserName", user.userName);
                    command.Parameters.AddWithValue("@UserId", user.userId);
                    command.Parameters.AddWithValue("@Password", user.password);
                    command.Parameters.AddWithValue("@Active", user.active);
                    command.Parameters.AddWithValue("@CreateDate", user.createDate);
                    command.Parameters.AddWithValue("@CreatedBy", user.createdBy);
                    command.Parameters.AddWithValue("@LastUpdate", user.lastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", user.lastUpdateBy);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();


                    string insertQueryCustomer = @"INSERT INTO `c968_db`.`customer` (customerId, customerName) VALUES (@CustomerId,@customerName)";
                    using (MySqlCommand insertCommand = new MySqlCommand(insertQueryCustomer, _connection))
                    {
                        insertCommand.Parameters.AddWithValue("@CustomerId", user.userId); // Assuming customerId is the same as UserId
                        insertCommand.Parameters.AddWithValue("@customerName", user.userName);
                        insertCommand.ExecuteNonQuery(); // Execute the query to insert the new user ID
                    }


                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }

        }
        public void InsertProfileInfo(UserInfo Info)
        {
            try
            {
                Connect();

                string insertQueryCustomer = @"UPDATE `c968_db`.`customer`
                        SET `customerName` = @UserName,
                       `addressId` = @addressId
                          WHERE `customerId` = @CustomerId;";


                string addressInsert = $"INSERT INTO `c968_db`.`address`(addressId, address,  postalCode, phone) " +
                    $"VALUES (@addressId, @address, @postalCode, @phone)";

                using (MySqlCommand command = new MySqlCommand(addressInsert, _connection))
                {

                    command.Parameters.AddWithValue("@addressId", Info.addressId);
                    command.Parameters.AddWithValue("@address", Info.address);
                    command.Parameters.AddWithValue("@postalCode", Info.postalCode);
                    command.Parameters.AddWithValue("@phone", Info.phone);
                    //command.Parameters.AddWithValue("@country", Info.country);


                    command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }
                using (MySqlCommand command = new MySqlCommand(insertQueryCustomer, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", Info.UserId); // Assuming customerId is the same as UserId
                    command.Parameters.AddWithValue("@addressId", Info.addressId); // Add addressId parameter
                    command.Parameters.AddWithValue("@UserName", Info.UserName);
                    command.ExecuteNonQuery();


                    Disconnect();
                }


            }
            catch (MySqlException ex)
            {

                MessageBox.Show("error query INSERT : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public void InsertCityIntoDatabase(int cityId, string cityName, int addressId)
        {
            // Perform the database insertion using the cityId and userId
            // For example:
            try
            {
                Connect();
                string Query = @"UPDATE `c968_db`.`address` SET `cityId` = @cityId WHERE (`addressId` = @addressId);";

                using (MySqlCommand command = new MySqlCommand(Query, _connection))
                {
                    command.Parameters.AddWithValue("@cityId", cityId);
                    command.Parameters.AddWithValue("@cityName", cityName);
                    command.Parameters.AddWithValue("@addressId", addressId); // Assuming the addressId is 1

                    command.ExecuteNonQuery();


                }
                Disconnect();
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during database insertion
                MessageBox.Show("Error inserting city into the database: " + ex.Message);
            }
        }

        public void InsertCountryIntoDatabase(int countryId, int cityId)
        {
            // Perform the database insertion using the countryId and cityId
            // For example:
            try
            {
                Connect();
                string Query = @"UPDATE `c968_db`.`city` SET `countryId` = @countryId WHERE (`cityId` = @cityId);";

                using (MySqlCommand command = new MySqlCommand(Query, _connection))
                {
                    command.Parameters.AddWithValue("@countryId", countryId);
                    command.Parameters.AddWithValue("@cityId", cityId); // Assuming the cityId is 1

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions that may occur during database insertion
                MessageBox.Show("Error inserting country into the database: " + ex.Message);
            }
        }

        public bool ValidateUser(string userName, string password)
        {
            try
            {
                Connect();
                string query = "SELECT * FROM `c968_db`.`user` WHERE userName = @UserName AND password = @Password";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@UserName", userName);
                    command.Parameters.AddWithValue("@Password", password);

                    // Execute the query
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        return reader.HasRows;
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
                return false;
            }
        }

        // retrieve information from the database
        public UserInfo UserInformation(int currentUserId)
        {
            UserInfo userInfo = null;
            // Initialize UserInfo object
            try
            {
                Connect();
                // Query to retrieve user information
                string query = @"SELECT
                            u.userId,
                            c.customerId,
                             c.customerName,
                   ad.addressId,
                                   ad.address,
                             ad.address2,
                             ad.postalCode,
                                  ad.phone,
                                 ci.cityId,
                               ci.city,
                                 co.country,
                                    co.countryId

                            FROM
                                        user u
                           INNER JOIN customer c ON u.userId = c.customerId
                           INNER JOIN address ad ON c.addressId = ad.addressId
                         INNER JOIN city ci ON ad.cityId = ci.cityId
                         INNER JOIN country co ON ci.countryId = co.countryId
                                     WHERE
                                         u.userId = @userId;";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@userId", currentUserId);

                    // Execute the query
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the user exists in the database
                        {
                            // Retrieve user information from the reader
                            int retrievedUserId = reader.GetInt32("userId");
                            int customerId = reader.GetInt32("customerId");
                            string customerName = reader.GetString("customerName");
                            string address = reader.GetString("address");
                            int postalCode = reader.GetInt32("postalCode");
                            string phone = reader.GetString("phone");
                            int cityId = reader.GetInt32("cityId");
                            string city = reader.GetString("city");
                            string country = reader.GetString("country");

                            // Create a new UserInfo object
                            userInfo = new UserInfo(retrievedUserId, customerName, customerId, address, postalCode, phone, cityId, city, country);
                        }
                    }
                }

                Disconnect();

                return userInfo; // Return the retrieved 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection retrieving data");
                return null;
            }
        }

        //retrieve country and city information to chose from 
        public void RetrieveCountryCity()
        {
            try
            {
                Connect();
                string query = @"SELECT ci.cityId, ci.city, co.country, co.countryId
                                FROM city ci
                                JOIN country co ON ci.countryId = co.countryId;";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int cityId = reader.GetInt32("cityId");
                            string city = reader.GetString("city");
                            int countryId = reader.GetInt32("countryId");
                            string country = reader.GetString("country");

                            CityModel cityModel = new CityModel(cityId, city, countryId, country);
                            multipleChoiceCountry.Add(cityModel);

                        }
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }
        //update the user information

        public void UpdateUser(UserInfo Info)
        {
            try
            {
                Connect();

                // Retrieve the  addressId for the user
                string getAddressIdQuery = "SELECT addressId FROM `c968_db`.`customer` WHERE customerId = @CustomerId";
                int addressId = 0;

                using (MySqlCommand getAddressIdCommand = new MySqlCommand(getAddressIdQuery, _connection))
                {
                    getAddressIdCommand.Parameters.AddWithValue("@CustomerId", Info.UserId);
                    object result = getAddressIdCommand.ExecuteScalar();
                    if (result != null)
                    {
                        addressId = Convert.ToInt32(result);
                    }
                }

                // Update the user information
                string updateCustomerQuery = @"UPDATE user AS u JOIN customer AS c ON u.userId = c.customerId
                                               JOIN address AS a ON c.addressId = a.addressId
                                               SET u.userName = @UserName, 
                                                   c.customerName = @CustomerName, 
                                                   a.address = @NewAddress,
                                                   a.address2 = @Address2,
                                                   a.postalCode = @PostalCode,
                                                
                                                   a.phone = @phone
                                               WHERE u.userId = @UserId;";

                using (MySqlCommand command = new MySqlCommand(updateCustomerQuery, _connection))
                {

                    command.Parameters.AddWithValue("@UserName", Info.UserName);
                    command.Parameters.AddWithValue("@UserId", Info.UserId);
                    command.Parameters.AddWithValue("@CustomerName", Info.UserName);
                    command.Parameters.AddWithValue("@NewAddress", Info.address);
                    command.Parameters.AddWithValue("@Address2", Info.address2);
                    command.Parameters.AddWithValue("@PostalCode", Info.postalCode);
                    command.Parameters.AddWithValue("@phone", Info.phone);


                    int rowsAffected = command.ExecuteNonQuery();

                }

                // Update the address information
                string updateAddressQuery = @"UPDATE address SET address = @NewAddress, 
                                                                address2 = @Address2, 
                                                                postalCode = @PostalCode, 
                                                                phone = @phone
                                                                
                                                              
                                            WHERE addressId = @AddressId;";

                using (MySqlCommand command = new MySqlCommand(updateAddressQuery, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@NewAddress", Info.address);
                    command.Parameters.AddWithValue("@Address2", Info.address2);
                    command.Parameters.AddWithValue("@PostalCode", Info.postalCode);
                    command.Parameters.AddWithValue("@phone", Info.phone);
                    command.Parameters.AddWithValue("@AddressId", addressId);
                    command.Parameters.AddWithValue("@cityId", Info.cityId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }



        public int GetCurrentID(string userName)
        {
            int currentID = 0;
            try
            {
                Connect();
                string query = "SELECT userId FROM `c968_db`.`user` WHERE userName = @UserName";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@UserName", userName);

                    // Execute the query and retrieve the current ID
                    object result = command.ExecuteScalar(); // ExecuteScaslar is used to retrieve a single value
                    if (result != null)
                    {
                        currentID = Convert.ToInt32(result);
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }

            return currentID;
        }

        public void DeleteUser(int userId)
        {
            try
            {
                Connect();
                string query = @"DELETE FROM `c968_db`.`user` WHERE (`userId` = @userId);";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@userId", userId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }

        public void DeleteProfileInfo(int costumerId)
        {
            try
            {
                int addressId = GetAddressId(costumerId);
                Connect();
                string query = @"DELETE FROM address WHERE addressId = @AddressId";


                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@AddressId", addressId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }
        public int GetAddressId(int customerId)
        {
            int addressId = 0;
            try
            {
                Connect();
                string query = "SELECT addressId FROM `c968_db`.`customer` WHERE customerId = @CustomerId";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    // Execute the query and retrieve the addressId
                    object result = command.ExecuteScalar(); // ExecuteScalar is used to retrieve a single value
                    if (result != null)
                    {
                        addressId = Convert.ToInt32(result);
                    }
                    else if (result == null)
                    {
                        addressId = 1;
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error retrieving addressId");
            }

            return addressId;
        }

        public int SelectCityId(string city)
        {
            int cityId = 0;

            try
            {
                Connect();
                string query = "SELECT cityId FROM `c968_db`.`city` WHERE city = @City";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@City", city);

                    // Execute the query and retrieve the cityId
                    object result = command.ExecuteScalar(); // ExecuteScalar is used to retrieve a single value
                    if (result != null)
                    {
                        cityId = Convert.ToInt32(result);
                    }
                }


                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error retrieving cityId dbselectedcity");
            }

            return cityId;
        }
        public int SelectCountryId(string city)
        {
            int countryId = 0;
            try
            {
                Connect();

                string getCountryId = "SELECT countryId FROM `c968_db`.`city` WHERE city = @City";



                using (MySqlCommand command = new MySqlCommand(getCountryId, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@City", city);

                    // Execute the query and retrieve the cityId
                    object result = command.ExecuteScalar(); // ExecuteScalar is used to retrieve a single value
                    if (result != null)
                    {
                        countryId = Convert.ToInt32(result);
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error retrieving cityId dbselectedcity");
            }

            return countryId;
        }

        //Appointment section 
        public void InsertAppointment(AppointmentModel appointment)
        {
            try
            {
                Connect();
                // int appointmentId = ;
                string query = @"UPDATE `c968_db`.`appointment` SET `userId` = @CustomerId, `customerId` = @customerId ,`title` = @Title,
                         `description` = @Description, `start` = @Start
                        WHERE (`appointmentId` = @AppointmentId);";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@AppointmentId", appointment.appointmentId);
                    command.Parameters.AddWithValue("@CustomerId", appointment.userId);
                    command.Parameters.AddWithValue("@Title", appointment.title);
                    command.Parameters.AddWithValue("@Description", appointment.description);
                    command.Parameters.AddWithValue("@Start", appointment.start);
                   

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection appoitment failed to insert");
            }



        }
        //select all appoitments from the db for each user
        public void GetAppoitments(int userId)
        {
            try
            {
                Connect();
                string query = @"SELECT appointmentId, title, description, start FROM `c968_db`.`appointment` WHERE customerId = @CustomerId";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", userId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = reader.GetInt32("appointmentId");

                            string title = reader.GetString("title");
                            string description = reader.GetString("description");
                            DateTime start = reader.GetDateTime("start");




                            AppointmentModel appointmentModel = new AppointmentModel(userId, appointmentId, title, description, start);
                            appointmentModels.Add(appointmentModel);
                        }
                    }
                }
                Disconnect();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }

        }

        public List<AppointmentModel> SearchAppt(string selectedDate)
        {
            // Create a list to store the retrieved data
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            try
            {
                Connect();

                string query = @"SELECT appointmentId, start FROM appointment
                                 WHERE DATE(start) = @date 
                                 AND customerId IS NULL 
                                 AND userId IS NULL ";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add parameter for the selected date
                    command.Parameters.AddWithValue("@date", selectedDate);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = reader.GetInt32("appointmentId");
                            DateTime start = reader.GetDateTime("start");

                            AppointmentModel appointmentModel = new AppointmentModel(start, appointmentId);
                            appointments.Add(appointmentModel);
                        }
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No connection");
            }

            // Return the list containing the retrieved data
            return appointments;
        }





        //FILTERS FOR APPT

        public List<AppointmentModel> FilterAppointmentsByMonth(int month)
        {
            // Create a list to store the retrieved data
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            try
            {
                Connect();

                string query = @"SELECT appointmentId, start, end FROM appointment
                     WHERE MONTH(start) = @month";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add parameter for the selected month
                    command.Parameters.AddWithValue("@month", month);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve data from the reader
                            DateTime start = reader.GetDateTime("start");
                            int appointmentId = reader.GetInt32("appointmentId");

                            // Create an AppointmentModel object and add it to the list
                            AppointmentModel appointment = new AppointmentModel(start, appointmentId);
                            appointments.Add(appointment);
                        }
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No connection");
            }

            // Return the list containing the retrieved data
            return appointments;
        }

        //return filtering by week appoitments 7 days
        public List<AppointmentModel> FilterAppointmentsByWeek(string selectedDate)
        {
            // Create a list to store the retrieved data
            List<AppointmentModel> appointments = new List<AppointmentModel>();
            appointments.Clear();

            try
            {
                Connect();

                string query = @"SELECT * FROM appointment
                               WHERE start >= @selectedDate
                           AND start < DATE_ADD(@selectedDate, INTERVAL 7 DAY)
                                AND customerId is null;";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add parameter for the selected week
                    command.Parameters.AddWithValue("@selectedDate", selectedDate);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Retrieve data from the reader
                            DateTime start = reader.GetDateTime("start");
                            int appointmentId = reader.GetInt32("appointmentId");

                            // Create an AppointmentModel object and add it to the list
                            AppointmentModel appointment = new AppointmentModel(start, appointmentId);
                            appointments.Add(appointment);
                        }
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No connection");
            }

            // Return the list containing the retrieved data
            return appointments;
        }

        //cancel appoitment

        public void DeleteAppointment(int appointmentId)
        {
            try
            {
                Connect();
                string query = @"UPDATE `c968_db`.`appointment` SET `customerId` = null, `userId` = null  WHERE (`appointmentId` = @appointmentId);";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }

        //update appoitment
        public void UpdateAppointment(int appointmentId, string description, string title)
        {
            try
            {
                Connect();
                string query = @"UPDATE `c968_db`.`appointment` SET   `title` = @Title, `description` = @Description WHERE (`appointmentId` = @AppointmentId);";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameters to avoid SQL injection


                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);

                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }

        // get appointment info

        public void GetAppoitmentsInfo(int appointmentId)
        {
            try
            {
                Connect();
                string query = @"SELECT  title, description FROM `c968_db`.`appointment` WHERE appointmentId =  @appointmentId";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string title = reader.GetString("title");
                            string description = reader.GetString("description");


                            AppointmentModel appointmentModel = new AppointmentModel(appointmentId, title, description);
                            appointmentModels.Add(appointmentModel);
                        }
                    }
                }
                Disconnect();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }

        public string GetUserName(int userId)
        {
            try
            {
                Connect();
                string query = "SELECT userName FROM `c968_db`.`user` WHERE userId = @UserId";
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            string userName = reader.GetString("userName");
                            UserModel user = new UserModel(userName);
                            return userName;
                        }
                    }
                }
                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
            return null; // Return null if no user is found
        }


        //Alert if appoitment is within 15 minutes

        public void AlertAppointments(int userId, DateTime localtime)
        {
            try
            {
                Connect();
                string query = @"SELECT * FROM appointment 
                   WHERE start BETWEEN @LocalTime AND DATE_ADD(@LocalTime, INTERVAL 15 MINUTE) 
                   AND userId = @UserId";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UserId", userId);
                    command.Parameters.AddWithValue("@LocalTime", localtime);
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.HasRows)
                        {
                            MessageBox.Show("You have an appointment within 15 minutes", "Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }

        // get all appointments REPORTS//




        public void GetCustomerSchedules()
        {
           

            try
            {
                string query = @"SELECT title, appointmentId, userId, start , description
                              FROM appointment
                            WHERE userId IS NOT NULL
                               ORDER BY MONTH(start);";

                Connect();

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = reader.GetInt32("appointmentId");

                            string title = reader.GetString("title");
                            string description = reader.GetString("description");
                            DateTime start = reader.GetDateTime("start");
                            int userId = reader.GetInt32("userId");


                            AppointmentModel appointmentModel = new AppointmentModel(userId, appointmentId, title, description, start);
                           reports.Add(appointmentModel);
                        }
                    }
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }

            
        }

    }
}



