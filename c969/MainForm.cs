using c969.models;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;




namespace c969
{
    public partial class MainForm : Form
    {
        private string username; // Create a property to store the user
        private int currentUserId;




        public MainForm(string username, int currentUserId)
        {
            InitializeComponent();
            this.username = username;// Set the username property to the username passed in
            NametextBox.Text = username;// Set the text box to the username
            this.currentUserId = currentUserId;// Set the currentUserId property to the currentUserId passed in
            UserIdlabel.Text = ' ' + " Hello , " + username;
            labeluserId.Text = currentUserId.ToString();// Set the label to the username
            //InitializeFormData(currentUserId, username);// Initialize the form data
            DeactivateTextBoxes();// Deactivate the text boxes
            UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");
            userDb.RetrieveCountryCity();// Populate the ComboBox with multiple-choice options
            countryBox.DataSource = UserDb.multipleChoiceCountry;
            cityBox.DataSource = UserDb.multipleChoiceCountry;///connects to the list of countries
            cityBox.DisplayMember = "City";// Display the city name
            countryBox.DisplayMember = "Country";// Display the country name
            countryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cityBox.DropDownStyle = ComboBoxStyle.DropDownList;
            InitializeFormData(currentUserId);
        }

        //separation of concerns
        private void InitializeFormData(int currentUserId)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");

                UserInfo userInfo = userDb.UserInformation(currentUserId);


                // Check if userInfo is null before accessing its properties
                if (userInfo != null)
                {
                    // Set the text box values only if the corresponding properties are not null
                    NametextBox.Text = userInfo.UserName;
                    AddresstextBox2.Text = userInfo.address;
                    ZipcodetextBox4.Text = userInfo.postalCode.ToString();
                    PhonetextBox5.Text = userInfo.phone.ToString();
                    CitytextBox.Text = userInfo.city;
                    modifyBtn.Enabled = true; // Enable the modify button
                    profileRegistrationBtn.Hide(); // Hide the registration button
                    saveProfileBtn.Enabled = true; // Enable the save button
                    saveBtn.Enabled = false; // Disable the save button
                    saveBtn.Hide(); // Hide the save button
                }
                else
                {
                    // No user information found, handle it accordingly (e.g., display default values, leave text boxes empty
                    MessageBox.Show("Please dont forget to complete your registration"); // Display a message to the user
                    profileRegistrationBtn.Show(); // Show the registration button
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

                UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");

                UserInfo userInfo = userDb.UserInformation(currentUserId);
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
                    int phone = int.Parse(PhonetextBox5.Text);
                    string country = CountrytextBox.SelectedText; // Get the selected country
                    string city = CitytextBox.SelectedText; // Get the selected city from the TextBox
                    int cityId = int.Parse(CitytextBox.SelectedText);
                    int countryId = int.Parse(CountrytextBox.SelectedText);

                    // Get the selected city
                    int userId = int.Parse(labeluserId.Text);
                    int customerId = userId;
                    if (customerId == 0) // Assuming 0 represents an invalid customerId
                    {
                        MessageBox.Show("Failed to retrieve customer ID. Please try again or contact support.");
                    }

                    UserInfo userInformation = new UserInfo(currentUserId, userName, customerId, address, postalCode, phone, city, cityId, country
                        , countryId);
                    // Update the user information

                    userDb.UpdateUser(userInformation);




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

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            try
            {

                UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");

                UserInfo userInfo = userDb.UserInformation(currentUserId);
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
                    int phone = int.Parse(PhonetextBox5.Text);
                    int userId = int.Parse(labeluserId.Text);
                    int customerId = userId;
                    if (customerId == 0) // Assuming 0 represents an invalid customerId
                    {
                        MessageBox.Show("Failed to retrieve customer ID. Please try again or contact support.");
                    }

                    UserInfo userInformation = new UserInfo(customerId, userName, customerId, address, postalCode, phone);


                    // Update the user information
                    userDb.InsertProfileInfo(userInformation);

                    // Save the updated user information
                    // userDb.UpdateProfileUser(userInfo);

                    // Deactivate the text boxes
                    DeactivateTextBoxes();

                    // Display a message to the user
                    MessageBox.Show("Profile information saved successfully");
                }
                saveProfileBtn.Show();
                modifyBtn.Show();
                modifyBtn.Enabled = true;
                saveBtn.Hide();
                saveProfileBtn.Show();
                profileRegistrationBtn.Hide();

            }
            catch (Exception ex)
            {

                MessageBox.Show("error : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void deleteAddressBtn_Click(object sender, EventArgs e)
        {

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
            PhonetextBox5.MaxLength = 9;
            if (System.Text.RegularExpressions.Regex.IsMatch(PhonetextBox5.Text, "[^0-9]")) // Check if the input is not a number 
            {
                MessageBox.Show("Please enter only numbers.");
                PhonetextBox5.Text = PhonetextBox5.Text.Remove(PhonetextBox5.Text.Length - 1);// Remove the last character
            }
            //trimmed the phone number to 10 digits
            if (PhonetextBox5.Text.Length > 9)
            {
                MessageBox.Show("Please enter only 10 digits.");
                PhonetextBox5.Text = PhonetextBox5.Text.Remove(PhonetextBox5.Text.Length - 1);// Remove the last character
            }

        }

        private void cityBox_SelectedIndexChanged_1(object sender, EventArgs e)
        { 
             // Retrieve the selected city model from the combobox
             CityModel selectedCity = cityBox.SelectedItem as CityModel;
             if (selectedCity != null)
             {
                 // Get the city ID
                 int cityId = selectedCity.cityId;
                 string cityName = selectedCity.city.ToString();
                 int userId = int.Parse(labeluserId.Text);
                 // Display the city ID
                 CitytextBox.Text = cityId.ToString() + cityName;
                 UserInfo city = new UserInfo(userId, cityName ,cityId);
                 UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");
                 if (userId == 0) // Assuming 0 represents an invalid userId
                 {
                     MessageBox.Show("Failed to retrieve user ID. Please try again or contact support.");
                 }
                 else 
                 {

                     userDb.UpdateUser(city);
                 }
           
        }

    }

    private void countryBox_SelectedIndexChanged(object sender, EventArgs e)
    {
         CityModel selectedCountry = countryBox.SelectedItem as CityModel;
        if (selectedCountry != null)
        {
           int countryId = selectedCountry.countryId;

           string countryName = selectedCountry.country;
            CountrytextBox.Text = countryName.ToString() + countryId;


        }
    }
}


}

