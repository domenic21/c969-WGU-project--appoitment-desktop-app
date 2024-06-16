using c969.models;
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
    public partial class addCustomerForm : Form
    {
        private int currentUserId;
        public addCustomerForm(int currentUserId)
        {
            InitializeComponent();
            label2.Text = currentUserId.ToString();
           
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            userName.Text = userDb.GetUserName(currentUserId);
            userDb.RetrieveCountryCity();// Populate the ComboBox with multiple-choice options
            countryBox.DataSource = UserDb.multipleChoiceCountry;
            cityBox.DataSource = UserDb.multipleChoiceCountry;///connects to the list of countries
            cityBox.DisplayMember = "City";// Display the city name
            countryBox.DisplayMember = "Country";// Display the country name
            countryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cityBox.DropDownStyle = ComboBoxStyle.DropDownList;


        }
        public static int GenerateID()
        {
            Random random = new Random();
            int newID = random.Next(1000, 9999); // Generates a random number between 1000 and 9999
            return newID;

        }
        public static int GenerateAddressId()
        {
            Random random = new Random();
            int newID = random.Next(1, 100);
            return newID;

        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
           string userName = label1.Text;
            int userId = currentUserId;
            MainForm mainForm = new MainForm(userName, userId);
            mainForm.Show();
        }

        //add customer button
        private void button2_Click(object sender, EventArgs e)
        {
         
         

            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                int userId = int.Parse(label2.Text);




                //data input textbox validation 
                if (string.IsNullOrEmpty(customerNamelbl.Text) ||
                    string.IsNullOrEmpty(AddresstextBox2.Text) ||
                    string.IsNullOrEmpty(ZipcodetextBox4.Text) ||
                    string.IsNullOrEmpty(PhonetextBox5.Text))

                {

                    MessageBox.Show("Please fill in all the fields");
                }
                else
                {
                    string customerName = customerNamelbl.Text;
                   
                  
                    string address = AddresstextBox2.Text;
                    int zipcode = Convert.ToInt32(ZipcodetextBox4.Text);
                    string phone = (PhonetextBox5.Text).ToString();
                    int cityId = userDb.SelectCityId(cityBox.Text);
                    int countryId = userDb.SelectCountryId(cityBox.Text);
                    string cityName = cityBox.SelectedItem.ToString();
                    int addressId = GenerateAddressId();


                    UserInfo userInformation = new UserInfo(userId, customerName, userId, addressId, address, zipcode, phone, cityId);
            
                    userDb.InsertProfileInfo(userInformation);
                    userDb.AddCustomer(userInformation, userId, customerName, addressId);

                    userDb.InsertCityIntoDatabase(cityId, cityName, addressId);
                    userDb.InsertCountryIntoDatabase(countryId, cityId);

                    MessageBox.Show("Customer Registered");
                    MainForm mainForm = new MainForm(userName.Text, userId);
                    mainForm.Show();
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "no connection insert Customer");
            }
            this.Close();


        }
    }
}
