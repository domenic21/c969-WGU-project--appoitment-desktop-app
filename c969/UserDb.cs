using c969.models;
using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using Org.BouncyCastle.Asn1.Cms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;




namespace c969
{
    public class UserDb : db
    {
        public UserDb(string server, string port, string db, string user, string password)
            : base(server, port, db, user, password)
        {

        }



        public static BindingList<CityModel> multipleChoiceCountry = new BindingList<CityModel>();
        public static BindingList<AppointmentModel> appointmentModels = new BindingList<AppointmentModel>();
        public static BindingList<AppointmentModel> appointmentsTaken = new BindingList<AppointmentModel>();
        public static BindingList<AppointmentModel> reports = new BindingList<AppointmentModel>();
        public static BindingList<AppointmentModel> availableAppointments = new BindingList<AppointmentModel>();
        public static BindingList<UserModel> customerAppointments = new BindingList<UserModel>();



        public void InsertAllDummyData()
        {
            try
            {
                Connect();

                string query = @"UPDATE appointment
                  SET start = DATE_ADD(NOW(), INTERVAL 10 MINUTE)
                  WHERE appointmentId = 1;";

                string query1 = @"INSERT IGNORE INTO `client_schedule`.`appointment` (
                   `appointmentId`, `description`, 
                  `start`, `end`, `createDate`, `createdBy`, `lastUpdate`, 
                   `lastUpdateBy` ) VALUES 
                   (3, 'Appointment Description', '2024-06-10 09:00:00', '2024-06-10 10:00:00', NOW(), 'System', NOW(), 'System'),
                  (4, 'Appointment Description', '2024-05-13 12:00:00', '2024-05-13 13:00:00', NOW(), 'System', NOW(), 'System'), 
                   (5, 'Appointment Description', '2024-05-20 09:00:00', '2024-05-20 10:00:00', NOW(), 'System', NOW(), 'System'),
                 (6, 'Appointment Description', '2024-05-23 13:00:00', '2024-05-20 10:00:00', NOW(), 'System', NOW(), 'System'),
                 (7, 'Appointment Description', '2024-05-25 09:00:00', '2024-05-20 10:00:00', NOW(), 'System', NOW(), 'System'),
                    (8, 'Appointment Description', '2024-05-30 10:00:00', '2024-05-20 10:00:00', NOW(), 'System', NOW(), 'System'),
                    (9, 'Appointment Description', '2024-05-27 15:00:00', '2024-05-20 10:00:00', NOW(), 'System', NOW(), 'System')
                     
                      ;
                    ";
                string query4 = @"ALTER TABLE `client_schedule`.`appointment`
                                     CHANGE COLUMN `customerId` `customerId` INT NULL,
                                     CHANGE COLUMN `userId` `userId` INT NULL;

                                    ;";
                string query5 = @"INSERT IGNORE INTO appointment (appointmentId, customerId, userId, title, description)
                             VALUES (1, 1, 1, 'test', 'test');
                           ";


                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand(query4, _connection))
                {
                    command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand(query1, _connection))
                {
                    command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand(query5, _connection))
                {
                    command.ExecuteNonQuery();
                }




            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection queries");
            }
        }
        //changes to the configuration of the database at the virtual enviroment
        public void dbConfig() {
            try { 
                Connect();
        
                string query1 = @"ALTER TABLE client_schedule.address
                  MODIFY COLUMN address VARCHAR(50) DEFAULT NULL,
                   MODIFY COLUMN address2 VARCHAR(50) DEFAULT NULL,
                  MODIFY COLUMN cityId INT(10) DEFAULT NULL,
                  MODIFY COLUMN postalCode VARCHAR(10) DEFAULT NULL,
                   MODIFY COLUMN phone VARCHAR(20) DEFAULT NULL,
                   MODIFY COLUMN createDate DATETIME DEFAULT NULL,
                   MODIFY COLUMN createdBy VARCHAR(40) DEFAULT NULL,
                    MODIFY COLUMN lastUpdate TIMESTAMP DEFAULT NULL,
                  MODIFY COLUMN lastUpdateBy VARCHAR(40) DEFAULT NULL; ";

                string query2 = @"ALTER TABLE `client_schedule`.`customer` 
                 DROP FOREIGN KEY `customer_ibfk_1`;
                 ALTER TABLE `client_schedule`.`customer` 
                  CHANGE COLUMN `customerName` `customerName` VARCHAR(45) NULL ,
                 CHANGE COLUMN `addressId` `addressId` INT NULL ,
                 CHANGE COLUMN `active` `active` TINYINT(1) NULL ,
                 CHANGE COLUMN `createDate` `createDate` DATETIME NULL ,
                  CHANGE COLUMN `createdBy` `createdBy` VARCHAR(40) NULL ,
                  CHANGE COLUMN `lastUpdateBy` `lastUpdateBy` VARCHAR(40) NULL ;
                    ALTER TABLE `client_schedule`.`customer` 
                   ADD CONSTRAINT `customer_ibfk_1`
                   FOREIGN KEY (`addressId`)
                   REFERENCES `client_schedule`.`address` (`addressId`);";

                string query3 = @"ALTER TABLE `client_schedule`.`appointment` 
                      DROP FOREIGN KEY `appointment_ibfk_2`,
                      DROP FOREIGN KEY `appointment_ibfk_1`;
                    ALTER TABLE `client_schedule`.`appointment` 
                      DROP INDEX `appointment_ibfk_1` ,
                      DROP INDEX `userId` 
                         ;";
                string query4 = @" ALTER TABLE `client_schedule`.`address` 
                      DROP FOREIGN KEY `address_ibfk_1`;
                      ALTER TABLE `client_schedule`.`address` 
                        DROP INDEX `cityId` ;
 
                            ";
                string query5 = @"ALTER TABLE `client_schedule`.`appointment` 
                  CHANGE COLUMN `title` `title` VARCHAR(255)  NULL ,
                      CHANGE COLUMN `description` `description` TEXT  NULL ,
                 CHANGE COLUMN `location` `location` TEXT  NULL ,
                    CHANGE COLUMN `contact` `contact` TEXT  NULL ,
                  CHANGE COLUMN `type` `type` TEXT  NULL ,
                   CHANGE COLUMN `url` `url` VARCHAR(255)  NULL ,
                   CHANGE COLUMN `start` `start` DATETIME  NULL ,
                     CHANGE COLUMN `end` `end` DATETIME  NULL ,
                  CHANGE COLUMN `createDate` `createDate` DATETIME  NULL ,
                    CHANGE COLUMN `createdBy` `createdBy` VARCHAR(40)  NULL ,
                  CHANGE COLUMN `lastUpdate` `lastUpdate` TIMESTAMP  NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP ,
                    CHANGE COLUMN `lastUpdateBy` `lastUpdateBy` VARCHAR(40)  NULL ;";
                using (MySqlCommand command = new MySqlCommand(query4, _connection))
                {
                    command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand(query5, _connection))
                {
                    command.ExecuteNonQuery();
                }

                using (MySqlCommand command = new MySqlCommand(query1, _connection))
                {
                    command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand(query3, _connection))
                {
                    command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand(query2, _connection))
                {
                    command.ExecuteNonQuery();
                }
            }
            catch (MySqlException ex)
            {
                
            }
        
        
        
        
        
        }

        public void RegisterUser(UserModel user) {

            try {

                Connect();
                string query = "INSERT  INTO `client_schedule`.`user`(userId,userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy) " +
                              "VALUES (@UserId,@UserName, @Password, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy);"; 

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@UserName", user.userName);
                    
                    command.Parameters.AddWithValue("@UserId", user.userId);
                    command.Parameters.AddWithValue("@Password", user.password);
                    command.Parameters.AddWithValue("@Active", user.active);
                    command.Parameters.AddWithValue("@CreateDate", user.createDate);
                    command.Parameters.AddWithValue("@CreatedBy", user.createdBy);
                    command.Parameters.AddWithValue("@LastUpdate", user.lastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", user.lastUpdateBy);

                    int rowsAffected = command.ExecuteNonQuery();
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }
        
        
        
        
        
        
        } 

         // CHECKKKKKKKKKKKKKK

        public void RegisterCustomer(UserModel user, UserInfo Info)
        {
            try
            {
                Connect();
                string query = "INSERT IGNORE INTO `client_schedule`.`user`(userId,userName, password, active, createDate, createdBy, lastUpdate, lastUpdateBy)" +
                "VALUES (@UserId,@UserName, @Password, @Active, @CreateDate, @CreatedBy, @LastUpdate, @LastUpdateBy)";

                string insertQueryCustomer = @"UPDATE `client_schedule`.`customer`
                        SET `customerName` = @CustomerName,
                       `addressId` = @addressId
                          WHERE `customerId` = @CustomerId;";

                string insertCustomer = @"INSERT INTO `client_schedule`.`customer` (customerId, customerName, addressId) VALUES (@CustomerId, @UserName, @addressId);";

                using (MySqlCommand command = new MySqlCommand(insertCustomer, _connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", user.customerId); // Assuming customerId is the same as UserId
                    command.Parameters.AddWithValue("@addressId", Info.addressId); // Add addressId parameter
                    command.Parameters.AddWithValue("@CustomerName", user.customerName);
                    command.ExecuteNonQuery();



                }
                using (MySqlCommand command = new MySqlCommand(insertQueryCustomer, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", Info.UserId); // Assuming customerId is the same as UserId
                    command.Parameters.AddWithValue("@addressId", Info.addressId); // Add addressId parameter
                    command.Parameters.AddWithValue("@UserName", Info.UserName);
                    command.ExecuteNonQuery();



                }

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@UserName", user.userName);
                    command.Parameters.AddWithValue("@CustomerName", user.customerName);
                    command.Parameters.AddWithValue("@CustomerId", user.customerId);
                    command.Parameters.AddWithValue("@UserId", user.userId);
                    command.Parameters.AddWithValue("@Password", user.password);
                    command.Parameters.AddWithValue("@Active", user.active);
                    command.Parameters.AddWithValue("@CreateDate", user.createDate);
                    command.Parameters.AddWithValue("@CreatedBy", user.createdBy);
                    command.Parameters.AddWithValue("@LastUpdate", user.lastUpdate);
                    command.Parameters.AddWithValue("@LastUpdateBy", user.lastUpdateBy);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();


                
            
                    string addressInsert = $"INSERT INTO `client_schedule`.`address`(addressId, address,  postalCode, phone) " +
                   $"VALUES (@addressId, @address, @postalCode, @phone)";

                    using (MySqlCommand insertCommand = new MySqlCommand(addressInsert, _connection))
                    {

                        command.Parameters.AddWithValue("@addressId", Info.addressId);
                        command.Parameters.AddWithValue("@address", Info.address);
                        command.Parameters.AddWithValue("@postalCode", Info.postalCode);
                        command.Parameters.AddWithValue("@phone", Info.phone);
                        //command.Parameters.AddWithValue("@country", Info.country);


                        command.ExecuteNonQuery();
                        // Check the rows affected and handle errors if necessary
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

                string insertQueryCustomer = @"UPDATE `client_schedule`.`customer`
                        SET `customerName` = @CustomerName,
                       `addressId` = @addressId
                          WHERE `customerId` = @CustomerId;";
                string insertCustomer = @"INSERT INTO `client_schedule`.`customer` (customerId, customerName, addressId) VALUES (@CustomerId, @CustomerName, @addressId);";


                string addressInsert = $"INSERT INTO `client_schedule`.`address`(addressId, address,  postalCode, phone) " +
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
                    command.Parameters.AddWithValue("@customerId", Info.customerId); 
                    command.Parameters.AddWithValue("@addressId", Info.addressId); // Add addressId parameter
                    command.Parameters.AddWithValue("@CustomerName", Info.customerName);
                    command.ExecuteNonQuery();


                  
                }
                using (MySqlCommand command = new MySqlCommand(insertCustomer, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", Info.customerId); 
                    command.Parameters.AddWithValue("@addressId", Info.addressId); 
                    command.Parameters.AddWithValue("@CustomerName", Info.customerName);
                    command.ExecuteNonQuery();


                    Disconnect();
                }
            }
            catch (MySqlException ex)
            {

                MessageBox.Show("error query INSERT 341: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }



        public void InsertCityIntoDatabase(int cityId, string cityName, int addressId)
        {
            // Perform the database insertion using the cityId and userId
            // For example:
            try
            {
                Connect();
                string Query = @"UPDATE `client_schedule`.`address` SET `cityId` = @cityId WHERE (`addressId` = @addressId);";

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
                string Query = @"UPDATE `client_schedule`.`city` SET `countryId` = @countryId WHERE (`cityId` = @cityId);";

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
                string query = "SELECT * FROM `client_schedule`.`user` WHERE userName = @UserName AND password = @Password";

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
        public UserInfo UserInformation(int customerId)
        {
            UserInfo userInfo = null;
            // Initialize UserInfo object
            try
            {
                Connect();
                // Query to retrieve user information
               
                string query = @"SELECT c.customerName, a.address, a.address2, a.cityId,
                     a.postalCode, a.phone, ci.city, co.country,a.addressId
                           FROM customer c
                        JOIN address a ON c.addressId = a.addressId
                       JOIN city ci ON a.cityId = ci.cityId
                               JOIN country co ON ci.countryId = co.countryId
                               WHERE c.customerId = @customerId;
                                    ";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add parameters
                    command.Parameters.AddWithValue("@customerId", customerId);

                    // Execute the query
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read()) // Check if the user exists in the database
                        {
                            // Retrieve user information from the reader
                            string customerName = reader.GetString("customerName");
                            string address = reader.GetString("address");
                            int postalCode = reader.GetInt32("postalCode");
                            string phone = reader.GetString("phone");
                            int cityId = reader.GetInt32("cityId");
                            string city = reader.GetString("city");
                            string country = reader.GetString("country");
                            int addressId = reader.GetInt32("addressId");

                            // Create a new UserInfo object
                            userInfo = new UserInfo( customerId, customerName, addressId,address, postalCode, phone, cityId, country ,city);
                        }
                    }
                }

                Disconnect();

                return userInfo; // Return the retrieved 
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection retrieving data 499");
                return null;
            }
        }
        // retrieve customers 

        public void RetrieveCustomers()
        {
            try
            {
                Connect();
                string query = @"SELECT * FROM client_schedule.customer;";


                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int customerId = reader.GetInt32("customerId");
                            string customerName = reader.GetString("customerName");

                            UserModel user = new UserModel(customerName, customerId);
                            customerAppointments.Add(user);
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

                // Update the user information
                string updateCustomerQuery = @"UPDATE customer AS c
                       JOIN address AS a ON c.customerId = @CustomerId
                           SET c.customerName = @CustomerName
                             WHERE c.customerId = @CustomerId;
                                                       ";

                using (MySqlCommand command = new MySqlCommand(updateCustomerQuery, _connection))
                {

                    command.Parameters.AddWithValue("@UserName", Info.UserName);
                    command.Parameters.AddWithValue("@UserId", Info.UserId);
                    command.Parameters.AddWithValue("@CustomerName", Info.customerName);
                    command.Parameters.AddWithValue("@NewAddress", Info.address);
                    command.Parameters.AddWithValue("@Address2", Info.address2);
                    command.Parameters.AddWithValue("@PostalCode", Info.postalCode);
                    command.Parameters.AddWithValue("@Phone", Info.phone);
                    command.Parameters.AddWithValue("@CustomerId", Info.customerId);
                    int rowsAffected = command.ExecuteNonQuery();

                }

                // Update the address information
                string updateAddressQuery = @"UPDATE address SET address = @NewAddress, 
                                                                
                                                                postalCode = @PostalCode, 
                                                                phone = @phone                     
                                            WHERE addressId = @AddressId;";

                using (MySqlCommand command = new MySqlCommand(updateAddressQuery, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@NewAddress", Info.address);                 
                    command.Parameters.AddWithValue("@PostalCode", Info.postalCode);
                    command.Parameters.AddWithValue("@phone", Info.phone);
                    command.Parameters.AddWithValue("@AddressId", Info.addressId);
                    command.Parameters.AddWithValue("@cityId", Info.cityId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection 631");
            }
        }



        public int GetCurrentID(string userName)
        {
            int currentID = 0;
            try
            {
                Connect();
                string query = @"SELECT userId FROM `client_schedule`.`user` WHERE userName = @UserName;";

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

        public int GetCustomerId(string customerName)
        {
           int customerId= 0;
            try
            {
                Connect();
                string query = @"SELECT customerId FROM `client_schedule`.`customer` WHERE customerName = @customerName ;";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@customerName", customerName);

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

        public void DeleteUser(int userId, int customerId)
        {
            try
            {
                Connect();
                string query = @"DELETE FROM `client_schedule`.`user` WHERE (`userId` = @userId);";
                string query2 = @"DELETE FROM `client_schedule`.`customer` WHERE (`customerId` = @CustomerId);";
                string query3 = @"-- Step 1: Create a Temporary Table
                      CREATE TEMPORARY TABLE temp_appointment_ids
                       SELECT appointmentId 
                      FROM client_schedule.appointment 
                   WHERE userId = @userId;

                   -- Step 2: Update the appointments
                     UPDATE client_schedule.appointment
                  SET customerId = NULL, userId = NULL, title = NULL, description = NULL
                   WHERE appointmentId IN (SELECT appointmentId FROM temp_appointment_ids);

                   -- Step 3: (Optional) Drop the temporary table
                    DROP TEMPORARY TABLE IF EXISTS temp_appointment_ids;";

                using (MySqlCommand command = new MySqlCommand(query3, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@userId", userId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@userId", userId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }
                using (MySqlCommand command = new MySqlCommand(query2, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection 697");
            }
        }

        public void DeleteProfileInfo( int userId)
        {
            try
            {

                int addressId = GetAddressId(userId);

                Connect();
                string query1 = "UPDATE `client_schedule`.`customer` SET `addressId` = null WHERE `customerId` = @customerId;";
                string query2 = "DELETE FROM `client_schedule`.`customer` WHERE `customerId` = @customerId;";
                string query3_create_temp_table = @"CREATE TEMPORARY TABLE temp_appointment_ids
                                            AS SELECT appointmentId 
                                            FROM client_schedule.appointment 
                                            WHERE userId = @userId;";
                string query4_update_appointments = @"UPDATE client_schedule.appointment
                                              SET customerId = NULL, userId = NULL, title = NULL, description = NULL
                                              WHERE appointmentId IN (SELECT appointmentId FROM temp_appointment_ids);";
                string query5_drop_temp_table = "DROP TEMPORARY TABLE IF EXISTS temp_appointment_ids;";
              
                // Update addressId to null
                using (MySqlCommand command = new MySqlCommand(query1, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", userId);
                    int rowsAffected = command.ExecuteNonQuery();
                }
    

                // Delete customer
                using (MySqlCommand command = new MySqlCommand(query2, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", userId);
                    int rowsAffected = command.ExecuteNonQuery();
                }

                // Create temporary table
                using (MySqlCommand command = new MySqlCommand(query3_create_temp_table, _connection))
                {
                    command.Parameters.AddWithValue("@userId", userId);
                    int rowsAffected = command.ExecuteNonQuery();
                }

                // Update appointments
                using (MySqlCommand command = new MySqlCommand(query4_update_appointments, _connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();
                }

                // Drop temporary table
                using (MySqlCommand command = new MySqlCommand(query5_drop_temp_table, _connection))
                {
                    int rowsAffected = command.ExecuteNonQuery();


                    Disconnect();
                }

            }
            catch (MySqlException ex)
            {
                
            }
        }

        public int GetAddressId(int customerId)
        {
            int addressId = 0;
            try
            {
                Connect();
                string query = "SELECT addressId FROM `client_schedule`.`customer` WHERE customerId = @CustomerId";

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
                string query = "SELECT cityId FROM `client_schedule`.`city` WHERE city = @City";

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
                MessageBox.Show(ex.Message, "Error retrieving cityId dbselectedcity 870");
            }

            return cityId;
        }
        public int SelectCountryId(string city)
        {
            int countryId = 0;
            try
            {
                Connect();

                string getCountryId = "SELECT countryId FROM `client_schedule`.`city` WHERE city = @City";



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
                MessageBox.Show(ex.Message, "Error retrieving countryId dbselectedcity 903 ");
            }

            return countryId;
        }

        //select customerId
        public int SelectCustomerId(string customerName)
        {
            int customerId = 0;
            try
            {
                Connect();

                string getCountryId = "SELECT customerId FROM `client_schedule`.`customer` WHERE customerName = @CustomerName;";



                using (MySqlCommand command = new MySqlCommand(getCountryId, _connection))
                {
                    // Add the parameter to avoid SQL injection
                    command.Parameters.AddWithValue("@CustomerName", customerName);

                    // Execute the query and retrieve the cityId
                    object result = command.ExecuteScalar(); // ExecuteScalar is used to retrieve a single value
                    if (result != null)
                    {
                        customerId = Convert.ToInt32(result);
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "Error retrieving customerId dbselectedcity 938 ");
               }
            return customerId;
        }


        
        //select all appoitments from the db for each user
        public void GetAppoitments(int customerId)
        {
           
            try
            {
                Connect();
                string query = @"SELECT appointmentId, title, description, start FROM `client_schedule`.`appointment` WHERE customerId = @CustomerId;";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@CustomerId", customerId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = reader.GetInt32("appointmentId");

                            string title = reader.GetString("title");
                            string description = reader.GetString("description");
                            DateTime start = reader.GetDateTime("start");




                            AppointmentModel appointmentModel = new AppointmentModel(customerId, appointmentId, title, description, start);
                           appointmentsTaken.Add(appointmentModel);
                        }
                    }
                }
                Disconnect();

            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection 972");
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

        public List<AppointmentModel> SearchApptAll()
        {
            // Create a list to store the retrieved data
            List<AppointmentModel> appointments = new List<AppointmentModel>();

            try
            {
                Connect();

                string query = @"SELECT *
                            FROM `client_schedule`.`appointment`
                  WHERE userId IS NULL AND customerId IS NULL;
                             ";
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int appointmentId = reader.GetInt32("appointmentId");
                            DateTime start = reader.GetDateTime("start");

                            AppointmentModel appointmentModel = new AppointmentModel(start, appointmentId);
                            availableAppointments.Add(appointmentModel);
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

        //get all appointments
        public void GetAllAppointments()
        {
            try
            {
                Connect();
                string query = @"SELECT *
                            FROM `client_schedule`.`appointment`
                  WHERE userId IS NULL AND customerId IS NULL;
                             ";

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            
                            DateTime start = reader.GetDateTime("start");
                            // Skip appointments with date 1/1/0001
                            if (start.Date == DateTime.MinValue.Date)
                            {
                                continue;
                            }
                            AppointmentModel appointmentModel = new AppointmentModel( start);
                            availableAppointments.Add(appointmentModel);
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
                string query = @"UPDATE `client_schedule`.`appointment` SET `customerId` = null  WHERE (`appointmentId` = @appointmentId);";

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
        public void UpdateAppointment(int appointmentId, string description, string title, int userId, int customerId)
        {
            try
            {
                Connect();
                string query = @"UPDATE `client_schedule`.`appointment` SET   `title` = @Title, `description` = @Description WHERE (`appointmentId` = @AppointmentId);";
                string query2 = @"UPDATE `client_schedule`.`appointment` SET `customerId` = @customerId, `userId` = @userId  WHERE (`appointmentId` = @appointmentId);";
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameters to avoid SQL injection


                    command.Parameters.AddWithValue("@Title", title);
                    command.Parameters.AddWithValue("@Description", description);
                    command.Parameters.AddWithValue("@AppointmentId", appointmentId);

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                }
                using (MySqlCommand command = new MySqlCommand(query2, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);
                    command.Parameters.AddWithValue("@userId" , userId);
                    command.Parameters.AddWithValue("@customerId", customerId);
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


        // get appointment info

        public void GetAppoitmentsInfo(int appointmentId)
        {
            try
            {
                Connect();
                string query = @"SELECT  title, description FROM `client_schedule`.`appointment` WHERE appointmentId =  @appointmentId";

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
                string query = "SELECT userName FROM `client_schedule`.`user` WHERE userId = @UserId";
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

       /* public void AlertAppointments(int userId, DateTime localtime)
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
        }*/

        public bool AlertAppointment(int userId, DateTime localtime)
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
                            return true; // Indicate that there is an appointment within 15 minutes
                        }
                    }
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "No connection", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return false; // No appointments within 15 minutes
        }


        // insert appointment new request 
        public void InsertAppointment(int customerId,int  Id, string title, string description, DateTime start)
        {
            try
            {
           
                Connect();
                string query = @"INSERT INTO `client_schedule`.`appointment` (`customerId`, `userId`,`title`,`description`, `start`) 
                                VALUES ( @customerId, @userId, @title, @description,   @start);";

 

        
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    // Add the parameters to avoid SQL injection
                    
                    command.Parameters.AddWithValue("@userId", Id);  
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@start", start);
                    command.Parameters.AddWithValue("@title", title);
                    command.Parameters.AddWithValue("@description", description);
         
        
                   


                

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

        // get all appointments REPORTS//




        public void GetType1()
        {


            try
            {
                string query = @"SELECT type ,start 
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

                            DateTime start = reader.GetDateTime("start");
                            string type = reader.GetString("type");


                            AppointmentModel appointmentModel = new AppointmentModel(type, start);
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

        public void GetScheduleForEach()
        {


            try
            {
                string query = @"SELECT title,  userId, start , description,appointmentId
                              FROM appointment
                            WHERE userId IS NOT NULL
                              ;";

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
        public void GetReport3()
        {
            try
            {
                string query = @"SELECT DATE(start) AS appointment_day, 
                                   TIME(start) AS appointment_time, 
                                   appointmentId, 
                                   COUNT(*) AS appointments_count
                                FROM appointment
                                GROUP BY DATE(start), TIME(start), appointmentId;";

                Connect();

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            DateTime appointmentDay = reader.GetDateTime("appointment_day");
                            TimeSpan appointmentTime = reader.GetTimeSpan("appointment_time");
                            int appointmentId = reader.GetInt32("appointmentId");
                            int appointmentsCount = reader.GetInt32("appointments_count");

                            AppointmentModel appointmentModel = new AppointmentModel(appointmentDay, appointmentTime, appointmentId, appointmentsCount);
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

        public void UpdateTimeAppt(int appointmentId, string time)
        {
            try
            {
  
                string query = @"
                    UPDATE appointment
                    SET start = CONCAT(DATE(start), ' ', @time)
                    WHERE appointmentId = @appointmentId;";

                Connect();

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);
                    command.Parameters.AddWithValue("@time", time);
                    command.ExecuteNonQuery();
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred while updating the appointment time.", "Error" + ex.Code + ex.Message);
            }
        }

        public DateTime GetAppointmentTime(int appointmentId)
        {

            try
            {
                /*string query = @"SELECT DATE_FORMAT(start, '%H:%i') AS start
                           FROM appointment
                                WHERE appointmentId = @appointmentId; 
                                 ";*/
                string query = @"SELECT start
                           FROM appointment
                                WHERE appointmentId = @appointmentId; 
                                 ";

                Connect();
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@appointmentId", appointmentId);


                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Retrieve the formatted time as a string
                            return reader.GetDateTime("start");
                            
                        }
                    }
                }
            }

            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection");
            }

            return DateTime.MinValue;// Return the default value if no appointment time is found
        }

        public void DeleteCustomer(int customerId)
        {
            try
            {
                Connect();
                string query = @"DELETE FROM `client_schedule`.`customer` WHERE (`customerId` = @customerId);";
            

                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                
                    command.ExecuteNonQuery();
                }
               



                Disconnect();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("An error occurred while deleting the customer's appointments.", "Error" + ex.Code + ex.Message);
            }
        }

        public void AddCustomer(UserInfo info, int customerId , string customerName , int addressId)
        {
            try
            {
                Connect();
                string query = @"INSERT INTO `client_schedule`.`customer` (customerId, customerName, addressId) VALUES (@customerId, @customerName, @addressId);";
                string addressInsert = $"INSERT INTO `client_schedule`.`address`(addressId, address,  postalCode, phone) " +
              $"VALUES (@addressId, @address, @postalCode, @phone)";

                using (MySqlCommand insertCommand = new MySqlCommand(addressInsert, _connection))
                {

                    insertCommand.Parameters.AddWithValue("@addressId", info.addressId);
                    insertCommand.Parameters.AddWithValue("@address", info.address);
                    insertCommand.Parameters.AddWithValue("@postalCode", info.postalCode);
                    insertCommand.Parameters.AddWithValue("@phone", info.phone);
                    //command.Parameters.AddWithValue("@country", Info.country);


                    insertCommand.ExecuteNonQuery();
                    // Check the rows affected and handle errors if necessary
                }
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    command.Parameters.AddWithValue("@customerId", customerId);
                    command.Parameters.AddWithValue("@customerName", customerName);
                    command.Parameters.AddWithValue("@addressId", addressId);
                    command.ExecuteNonQuery();
                }

                Disconnect();
            }
            catch (MySqlException ex)
            {
              //Console.WriteLine(ex.Message );
            }
        }


    }
}



