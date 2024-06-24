using c969.models;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Bcpg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
                    string userName = NametextBox.Text;
                    string address = AddresstextBox2.Text;
                    int postalCode = int.Parse(ZipcodetextBox4.Text);
                    string phone = (PhonetextBox5.Text).ToString();
                    string country = CountrytextBox.SelectedText; // Get the selected country
                    string city = CitytextBox.SelectedText; // Get the selected city from the TextBox
                    int cityId = userDb.SelectCityId(cityBox.Text);
                    int countryId = userDb.SelectCountryId(cityBox.Text);
                    string cityName = cityBox.SelectedItem.ToString();
                    int customerId = GenerateCustomerID();
                    int addressId = GenerateAddressId();


                    UserInfo userInformation = new UserInfo(userId, userName, customerId, address, postalCode, phone, cityId, addressId);
             
                    // Insert user profile information
                    userDb.InsertProfileInfo(userInformation);

                
            


                 //enter country and city into database
                    userDb.InsertCityIntoDatabase(cityId, cityName, addressId);
                    userDb.InsertCountryIntoDatabase(countryId, cityId);

               

                    // Display a message to the user
                    MessageBox.Show("Profile information saved successfully");
                }
              
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error in save : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void logIn_Click(object sender, EventArgs e)
        {
           /* MainForm mainForm = new MainForm( );
            mainForm.Show();*/
        }
    }
}
