using c969.models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace c969
{
    public class UserDb : db
    {
        public UserDb(string server, string db, string user, string password)
            : base(server, db, user, password)
        {

        }


        public static BindingList<CityModel> multipleChoiceCountry = new BindingList<CityModel>();


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
                 int GenerateID()
                {
                    Random random = new Random();
                    int newID = random.Next(1000, 9999); // Generates a random number between 1000 and 9999
                    return newID;

                }
                int addressId = GenerateID();
                string insertQueryCustomer = @"UPDATE `c968_db`.`customer`
                        SET `customerName` = @UserName,
                       `addressId` = @addressId
                          WHERE `customerId` = @CustomerId;";


                string addressInsert = $"INSERT INTO `c968_db`.`address`(addressId, address,  postalCode, phone) " +
                    $"VALUES ('{addressId}', @address, @postalCode, @phone)";

                using (MySqlCommand command = new MySqlCommand(addressInsert, _connection))
                {

                    command.Parameters.AddWithValue("@addressId", addressId);
                    command.Parameters.AddWithValue("@address", Info.address);
                    command.Parameters.AddWithValue("@postalCode", Info.postalCode);
                    command.Parameters.AddWithValue("@phone", Info.phone);
                    //command.Parameters.AddWithValue("@country", Info.country);
                   // command.Parameters.AddWithValue("@city", Info.city);

                    command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }
                using (MySqlCommand command = new MySqlCommand(insertQueryCustomer, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", Info.UserId); // Assuming customerId is the same as UserId
                    command.Parameters.AddWithValue("@addressId", addressId); // Add addressId parameter
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
                            int phone = reader.GetInt32("phone");
                            int cityId = reader.GetInt32("cityId");
                            string city = reader.GetString("city");
                            string country = reader.GetString("country");
                            
                            // Create a new UserInfo object
                            userInfo = new UserInfo(retrievedUserId, customerName, customerId, address, postalCode, phone,city, cityId,country);
                        }
                    }
                }

                Disconnect();

                return userInfo; // Return the retrieved 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
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
                                                   ci.cityId = @cityName,
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
                    command.Parameters.AddWithValue("@cityName", Info.city);


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


        public int GetCustomerId(int userId)
        {
            int customerId = 0;
            try
            {
                Connect();
                string query = @"SELECT user.userId, c.customerId
                 from user inner join customer c on user.userId = c.customerId; WHERE userId = @userId";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@CustomerId", customerId);
                    command.Parameters.AddWithValue("@UserId", userId);

                    // Execute the query and retrieve the current ID
                    object result = command.ExecuteScalar(); // ExecuteScaslar is used to retrieve a single value
                    if (result != null)
                    {
                        customerId = Convert.ToInt32(result);
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }

            return customerId;
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
                string query = @"DELETE FROM";
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        }

        public void DeleteAddress(int addressId)
        {
            try
            {
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


    }

}
