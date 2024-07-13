using c969.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

using System.Windows.Forms;





namespace c969
{
    public partial class MainForm : Form
    {
 

      public MainForm(int customerId, int userId)
        {
            InitializeComponent();

            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

            customerIdText.Text = customerId.ToString();// Set the text box to the username
            UserIdlabel.Text = userId.ToString();

            //InitializeFormData(currentUserId, username);// Initialize the form data
            DeactivateTextBoxes();// Deactivate the text boxes

            userDb.RetrieveCountryCity();// Populate the ComboBox with multiple-choice options
            countryBox.DataSource = UserDb.multipleChoiceCountry;
            cityBox.DataSource = UserDb.multipleChoiceCountry;
            cityBox.DisplayMember = "City";// Display the city name
            countryBox.DisplayMember = "Country";// Display the country name
            countryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cityBox.DropDownStyle = ComboBoxStyle.DropDownList;
           
            InitializeFormData(customerId);
       

            this.StartPosition = FormStartPosition.CenterScreen;

            RemoveDuplicatesFromComboBox();

            // ReloadForm(); // Call the method to reload the form and clear the list boxes
            // Attach the Form_Load and Form_FormClosed event handlers
            this.FormClosed += MainForm_FormClosed;

        }

        
   



        private void RemoveInvalidAppointments(BindingList<AppointmentModel> appointments)
        {
            // Remove appointments with the default date (1/1/0001)
            for (int i = appointments.Count - 1; i >= 0; i--)
            {
                if (appointments[i].start == DateTime.MinValue)
                {
                    appointments.RemoveAt(i);
                }
            }
        }

     
 



         List <string> FormatAppointments(BindingList<AppointmentModel> appointments) // Format the appointments for display
        {
            List<string> formattedAppointments = new List<string>();
            foreach (var appointment in appointments)
            {
                TimeZoneInfo userTimeZone = TimeZoneInfo.Local; // Get the user's time zone
                int appointmentId = appointment.appointmentId;
                string formattedAppointment = $"Appointments available: " +

                TimeZoneInfo.ConvertTime(appointment.start, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), userTimeZone)
                + " " + appointmentId.ToString();


                formattedAppointments.Add(formattedAppointment);
                listBox.Refresh();
                listBox2.Refresh();
            }

            // Remove duplicates from the formatted appointments list
            formattedAppointments = formattedAppointments.Distinct().ToList();

            return formattedAppointments;
           
        }
         

        // this will ensure that the listbox is cleared when the form is closed so it wont show the previous appointments
        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clear the appointmentsTaken list
            UserDb.appointmentsTaken.Clear();
        }

        //separation of concerns
        private void InitializeFormData(int customerId)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

                UserInfo userInfo = userDb.UserInformation(customerId);
                userDb.GetAllAppointments();
         

             
                

                // Call the GetAppoitments method and receive the list of appointments
                  userDb.GetAppoitments(customerId);

               
        
                RemoveInvalidAppointments(UserDb.appointmentsTaken);
         
                List<string> formattedAppointments2 = FormatAppointments(UserDb.availableAppointments);
                List<string> formattedAppointments = FormatAppointments(UserDb.appointmentsTaken);
                listBox.DataSource = formattedAppointments;
                listBox2.DataSource = formattedAppointments2;

                // Check if userInfo is null before accessing its properties
                if (userInfo != null)
                {
                    // Set the text box values only if the corresponding properties are not null
                    NametextBox.Text = userInfo.customerName;
                    AddresstextBox2.Text = userInfo.address;
                    ZipcodetextBox4.Text = userInfo.postalCode.ToString();
                    PhonetextBox5.Text = userInfo.phone.ToString();
                    CitytextBox.Text = userInfo.city;
                    CountrytextBox.Text = userInfo.country;
                    cityBox.Text = userInfo.city;
                    countryBox.Text = userInfo.country;
                    customerIdText.Text = userInfo.customerId.ToString();
                    modifyBtn.Enabled = true; // Enable the modify button
                    saveProfileBtn.Enabled = true; // Enable the save button
                    
                }
                else
                {
                    // No user information found, handle it accordingly (e.g., display default values, leave text boxes empty
                    MessageBox.Show("Please dont forget to complete your registration"); // Display a message to the user
                 
                                                   // Disable the modify button   // Deactivate the save button
                    saveProfileBtn.Enabled = false;
                    modifyBtn.Enabled = false;
                    saveProfileBtn.Hide(); // Hide the save button
                    modifyBtn.Hide(); // Hide the modify button
                }
            }
            catch (MySqlException ex)
            {
                // Handle exceptions gracefully (e.g., display error message)
                MessageBox.Show("error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        // retrieving the city Id choice by the suer to pass down to the db inserts


        //diactivation of the text boxes
        private void DeactivateTextBoxes()
        {
            NametextBox.Enabled = false;
            AddresstextBox2.Enabled = false;
            ZipcodetextBox4.Enabled = false;
            PhonetextBox5.Enabled = false;
            CountrytextBox.Enabled = false;
            CitytextBox.Enabled = false;
        }


        private void exitBtn_Click(object sender, EventArgs e)
        {

            Application.Exit();

        }

        private void modifyBtn_Click(object sender, EventArgs e)
        {
            // Activate the text boxes
            NametextBox.Enabled = true;
            AddresstextBox2.Enabled = true;
            ZipcodetextBox4.Enabled = true;
            PhonetextBox5.Enabled = true;
            CountrytextBox.Enabled = true;
            CitytextBox.Enabled = true;
            //combo box options
            CountrytextBox.Hide();
            countryBox.Show();
            CitytextBox.Hide();
            cityBox.Show();
            saveProfileBtn.Enabled = true;


        }
        //TODO: save profile information CORRECT THE SAVE PROFILE BUTTON
        private void saveProfileBtn_Click(object sender, EventArgs e)
        {

            try
            {

                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                int customerId = Convert.ToInt32(customerIdText.Text);
                UserInfo userInfo = userDb.UserInformation(customerId);
                //get userId to customer for updates functionality


                //data input textbox validation 
                if (string.IsNullOrEmpty(NametextBox.Text) ||
                    string.IsNullOrEmpty(AddresstextBox2.Text) ||
                    string.IsNullOrEmpty(ZipcodetextBox4.Text) ||
                    string.IsNullOrEmpty(PhonetextBox5.Text))

                {
                    MessageBox.Show("Please fill in all the fields");
                }
                else
                {
                    // Update the user information
                    string customerName = NametextBox.Text;
                    string address = AddresstextBox2.Text;
                    int postalCode = int.Parse(ZipcodetextBox4.Text);
                    string phone = (PhonetextBox5.Text).ToString();
                    string country = CountrytextBox.SelectedText; // Get the selected country
                    string city = CitytextBox.SelectedText; // Get the selected city from the TextBox
                    int cityId = userDb.SelectCityId(cityBox.Text);
                    int countryId = userDb.SelectCountryId(cityBox.Text);
                    string cityName = cityBox.SelectedItem.ToString();
               
                    int addressId = userDb.GetAddressId(customerId);

                    // Get the selected city
                    int userId = int.Parse(labeluserId.Text);
                   
                    if (customerId == 0) // Assuming 0 represents an invalid customerId
                    {
                        MessageBox.Show("Failed to retrieve customer ID. Please try again or contact support.");
                    }

                    UserInfo userInformation = new UserInfo(customerId,customerName,addressId, address, postalCode, phone, cityId);
                    // Update the user information

                    userDb.UpdateUser(userInformation); 
                    userDb.InsertCityIntoDatabase(cityId, cityName, addressId);
                    userDb.InsertCountryIntoDatabase(countryId, cityId);



                    // Save the updated user information
                    // userDb.UpdateProfileUser(userInfo);

                    // Deactivate the text boxes
                    DeactivateTextBoxes();

                    // Display a message to the user
                    MessageBox.Show("Profile information saved successfully");
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void profileRegistrationBtn_Click(object sender, EventArgs e)
        {
            // Activate the text boxes
            NametextBox.Enabled = true;
            AddresstextBox2.Enabled = true;
            ZipcodetextBox4.Enabled = true;
            PhonetextBox5.Enabled = true;
            CountrytextBox.Enabled = true;
            CitytextBox.Enabled = true;
            //combo box options
            CountrytextBox.Hide();
            countryBox.Show();
            CitytextBox.Hide();
            cityBox.Show();
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            int customerId = Convert.ToInt32(customerIdText.Text);
            userDb.DeleteCustomer(customerId);


        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                int customerId = Convert.ToInt32(customerIdText.Text);
                UserInfo userInfo = userDb.UserInformation(customerId);
                //get userId to customer for updates functionality

                //data input textbox validation 
                if (string.IsNullOrEmpty(NametextBox.Text) ||
                    string.IsNullOrEmpty(AddresstextBox2.Text) ||
                    string.IsNullOrEmpty(ZipcodetextBox4.Text) ||
                    string.IsNullOrEmpty(PhonetextBox5.Text))
                {
                    MessageBox.Show("Please fill in all the fields");
                }
                else
                {
                    // Update the user information
                    string userName = NametextBox.Text;
                    string address = AddresstextBox2.Text;
                    int postalCode = int.Parse(ZipcodetextBox4.Text);
                    string phone = (PhonetextBox5.Text).ToString();
                    string country = CountrytextBox.SelectedText; // Get the selected country
                    string city = CitytextBox.SelectedText; // Get the selected city from the TextBox
                    int cityId = userDb.SelectCityId(cityBox.Text);
                    int countryId = userDb.SelectCountryId(cityBox.Text);
                    string cityName = cityBox.SelectedItem.ToString();
                    int userId = int.Parse(labeluserId.Text);


                    // Retrieve the selected city model from the combobox


                    int customerId1 = GenerateID();
                  
                    int addressId = GenerateID();

                    UserInfo userInformation = new UserInfo(customerId1, userName,  addressId,address, postalCode, phone, cityId);

                    // Insert user profile information
                    userDb.InsertProfileInfo(userInformation);

                    // Get the address ID
                    int GenerateID()
                    {
                        Random random = new Random();
                        int newID = random.Next(1000, 9999); // Generates a random number between 1000 and 9999
                        return newID;

                    }


                    // Optionally, do something with the addressId
                    userDb.InsertCityIntoDatabase(cityId, cityName, addressId);
                    userDb.InsertCountryIntoDatabase(countryId, cityId);

                    // Deactivate the text boxes
                    DeactivateTextBoxes();

                    // Display a message to the user
                    MessageBox.Show("Profile information saved successfully");
                }
                saveProfileBtn.Show();
                modifyBtn.Show();
                modifyBtn.Enabled = true;
             

                saveProfileBtn.Show();
             
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error in save : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void deleteAddressBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                int currentUserId = Convert.ToInt32(customerIdText.Text);
                userDb.DeleteProfileInfo(currentUserId);
                MessageBox.Show("Profile information deleted successfully" + MessageBoxButtons.OK);
                AddresstextBox2.ResetText();
                countryBox.ResetText();
                cityBox.ResetText();
                ZipcodetextBox4.ResetText();
                PhonetextBox5.ResetText();
                return;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error in delete : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ZipcodetextBox4_TextChanged(object sender, EventArgs e)
        {
            ZipcodetextBox4.MaxLength = 5;
            if (System.Text.RegularExpressions.Regex.IsMatch(ZipcodetextBox4.Text, "[^0-9]")) // Check if the input is not a number 
            {
                MessageBox.Show("Please enter only numbers.");
                ZipcodetextBox4.Text = ZipcodetextBox4.Text.Remove(ZipcodetextBox4.Text.Length - 1);// Remove the last character
            }
            if (ZipcodetextBox4.Text.Length > 5)
            {
                MessageBox.Show("Please enter only 5 digits.");
                ZipcodetextBox4.Text = ZipcodetextBox4.Text.Remove(ZipcodetextBox4.Text.Length - 1);// Remove the last character
            }
        }

        private void PhonetextBox5_TextChanged(object sender, EventArgs e)
        {
            PhonetextBox5.MaxLength = 12;
            if (System.Text.RegularExpressions.Regex.IsMatch(PhonetextBox5.Text, "[^0-9-]")) // Check if the input is not a number or dash
            {
                MessageBox.Show("Please enter only numbers and dashes.");
                PhonetextBox5.Text = PhonetextBox5.Text.Remove(PhonetextBox5.Text.Length - 1); // Remove the last character
            }
            // Trim the phone number to 12 characters
            if (PhonetextBox5.Text.Length > 12)
            {
                MessageBox.Show("Please enter only 12 characters.");
                PhonetextBox5.Text = PhonetextBox5.Text.Remove(PhonetextBox5.Text.Length - 1); // Remove the last character
            }

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void deleteUserBtn_Click(object sender, EventArgs e)
        {

            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                int customerId = Convert.ToInt32(customerIdText.Text);
                int userId = Convert.ToInt32(labeluserId.Text);

                userDb.DeleteUser(userId, customerId);
                MessageBox.Show("Profile information deleted successfully" + MessageBoxButtons.OK);
                loginForm loginForm = new loginForm();
                loginForm.Show();
                this.Close();
                return;

            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error in delete : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int customerId = Convert.ToInt32(customerIdText.Text);
            int userId = Convert.ToInt32(UserIdlabel.Text);
            AppoitmentScheduler appoitmentScheduler = new AppoitmentScheduler(customerId, userId);
            appoitmentScheduler.Show();
            this.Hide();
        }

        private void NametextBox_TextChanged(object sender, EventArgs e)
        {
            // Set the maximum length of the text box
            NametextBox.MaxLength = 20;
            if (NametextBox.Text.Length > 20)
            {
                MessageBox.Show("Please enter only 12 characters.");
                NametextBox.Text = NametextBox.Text.Remove(NametextBox.Text.Length - 1); // Remove the last character
            }
        }

        private void AddresstextBox2_TextChanged(object sender, EventArgs e)
        {
            AddresstextBox2.MaxLength = 50;
            if (AddresstextBox2.Text.Length > 50)
            {
                MessageBox.Show("Please enter only 12 characters.");
                AddresstextBox2.Text = AddresstextBox2.Text.Remove(AddresstextBox2.Text.Length - 1); // Remove the last character
            }
        }

        private void modifyApptBtn_Click(object sender, EventArgs e)
        {
            if (listBox.SelectedItem != null)
            {
                string selectedAppt = listBox.SelectedItem.ToString();
                // Get the selected appointment 
                int appointmentId = int.Parse(selectedAppt.Split(' ')[selectedAppt.Split(' ').Length - 1]);

                // Get the time from the selected appointment
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                DateTime appointmentTime = 
                    userDb.GetAppointmentTime(appointmentId); 

                // Extract the time portion
                string appointmentTimeOnly = appointmentTime.ToString();
                int userId = Convert.ToInt32(UserIdlabel.Text);
                int customerId = Convert.ToInt32(customerIdText.Text);
                ModifyForm modifyForm = new ModifyForm(appointmentId, appointmentTimeOnly, userId, customerId);
                modifyForm.Show();

                this.Close();

                return;
            }
            else
            {
                modifyApptBtn.Enabled = false;
            }
        }

        private void cancelapptbtn_Click(object sender, EventArgs e)
        {

            if (listBox.SelectedItem != null)
            {
                DialogResult result = MessageBox.Show("Are you sure you want to cancel this appointment?", "Confirmation", MessageBoxButtons.YesNo);

                // Check if the user clicked Yes in the message box
                if (result == DialogResult.Yes)
                {
                    // Get the selected appointment
                    string selectedAppointment = listBox.SelectedItem?.ToString(); // Check if an item is selected
                    if (selectedAppointment != null)
                    {

                        // Find the index of the last space character
                        int lastSpaceIndex = selectedAppointment.LastIndexOf(' ');

                        // Extract the substring after the last space character
                        string appointmentIdString = selectedAppointment.Substring(lastSpaceIndex + 1);

                        // Try parsing the extracted string to an integer
                        if (int.TryParse(appointmentIdString, out int appointmentId))
                        {
                            // Now you have the appointmentId
                            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                                userDb.DeleteAppointment(appointmentId);
                                MessageBox.Show("Appointment canceled successfully");
                                //reload listbox
                                listBox.DataSource = null;
                            listBox.Items.Clear();
                            UserDb.appointmentsTaken.Clear();


                            InitializeFormData(Convert.ToInt32(customerIdText.Text));

                        }
                            else { MessageBox.Show("cant parse Id"); }


                        
                    }
                    else
                    {
                        return;
                    }

                    return;
                   
                }

            }
        }


       
       

        private void changeUserBtn_Click(object sender, EventArgs e)
        {
            int userId = Convert.ToInt32(UserIdlabel.Text);
            RegisterCustomer registerCustomer = new RegisterCustomer(userId);
            registerCustomer.Show();
            listBox.DataSource = null;
            listBox.Items.Clear();


             Close();
        }
        private void RemoveDuplicatesFromComboBox()
        {
           
            countryBox.DataSource = UserDb.multipleChoiceCountry
                .GroupBy(c => c.country)
                .Select(g => g.First())
                .ToList();

            cityBox.DataSource = UserDb.multipleChoiceCountry
                .GroupBy(c => c.city)
                .Select(g => g.First())
                .ToList();
          
        }
     
       
    }


}

