using c969.models;
using MySql.Data.MySqlClient;
using System;
using System.ComponentModel;
using System.Linq;
using System.Windows.Forms;

namespace c969
{
    public partial class RegisterCustomer : Form
    {
        private int userId;
        public RegisterCustomer(int userId)
        {
            InitializeComponent();
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
           
           userDb.RetrieveCustomers();
           comboBox.DataSource = UserDb.customerAppointments;
            comboBox.DisplayMember = "customerName";
           comboBox.DropDownStyle = ComboBoxStyle.DropDownList;

            userDb.RetrieveCountryCity();// Populate the ComboBox with multiple-choice options
            countryBox.DataSource = UserDb.multipleChoiceCountry;
            cityBox.DataSource = UserDb.multipleChoiceCountry;///connects to the list of countries
            cityBox.DisplayMember = "City";// Display the city name
            countryBox.DisplayMember = "Country";// Display the country name
            countryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cityBox.DropDownStyle = ComboBoxStyle.DropDownList;
            this.userId = userId;
            userIdlabel.Text = userId.ToString();
            RemoveDuplicatesFromComboBox();
            
            
        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            NametextBox.Visible = true;
            AddresstextBox2.Visible = true;
            countryBox.Visible = true;
            cityBox.Visible = true;
            ZipcodetextBox4.Visible = true;
            PhonetextBox5.Visible = true;
            label3.Visible = true;
            label4.Visible = true;
            label5.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            saveBtn.Visible = true;
            comboBox.Visible = false;



        }
        private void RemoveDuplicatesFromComboBox()
        {
            comboBox.DataSource = UserDb.customerAppointments
                .GroupBy(c => c.customerName)
                .Select(g => g.First())
                .ToList();
        
        }

  

        public static int GenerateCustomerID()
        {
            Random random = new Random();
            int newID = random.Next(100, 999); // Generates a random number between 1000 and 9999
            return newID;

        }
        public static int GenerateAddressId()
        {
            Random random = new Random();
            int newID = random.Next(1, 100);
            return newID;

        }

        private void saveBtn_Click(object sender, EventArgs e)
        {
            //register customer
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
           

            try
            {
                

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
                    string postalCode = ZipcodetextBox4.Text;
                    string phone = (PhonetextBox5.Text).ToString();
                    string country = CountrytextBox.SelectedText; // Get the selected country
                    string city = CitytextBox.SelectedText; // Get the selected city from the TextBox
                    int cityId = userDb.SelectCityId(cityBox.Text);
                    int countryId = userDb.SelectCountryId(cityBox.Text);
                    string cityName = cityBox.SelectedItem.ToString();
                    int customerId = GenerateCustomerID();
                    int addressId = GenerateAddressId();


                    UserInfo userInformation = new UserInfo(customerId, customerName, addressId, address, postalCode, phone, cityId);
             
                    // Insert user profile information
                    userDb.InsertProfileInfo(userInformation);


                 //enter country and city into database
                    userDb.InsertCityIntoDatabase(cityId, cityName, addressId);
                    userDb.InsertCountryIntoDatabase(countryId, cityId);

                    // Display a message to the user
                    MessageBox.Show("Profile information saved successfully");
                   NametextBox.Enabled = false;
                    AddresstextBox2.Enabled = false;
                  PhonetextBox5.Enabled = false;
                    ZipcodetextBox4.Enabled = false;
                    countryBox.Enabled = false;
                    cityBox.Enabled = false;
                    saveBtn.Enabled = false;
                    comboBox.Visible = false;

                }
              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error in save : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logIn_Click(object sender, EventArgs e)
        {
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

            int customerId;
            int userId = int.Parse(userIdlabel.Text);
            if (comboBox.Visible != false)
            {
               
                customerId = userDb.SelectCustomerId(comboBox.Text);
            }
            else
            {
                customerId = userDb.SelectCustomerId(NametextBox.Text);

            }
            //prevent form to open if customerId is 0 or null 
            if (customerId == 0)
            {
                MessageBox.Show("Please select another customer, customer recently deleted or unavailable ");
                return;
            }
            else
            {
                MainForm mainForm = new MainForm(customerId, userId);
                mainForm.Show();
                this.Close();
            }
        }
    

   

        private void ZipcodetextBox4_TextChanged_1(object sender, EventArgs e)
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

        private void PhonetextBox5_TextChanged_1(object sender, EventArgs e)
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
    }
}
