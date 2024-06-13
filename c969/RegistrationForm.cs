using c969.models;
using System;

using System.Windows.Forms;

namespace c969
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            userDb.RetrieveCountryCity();// Populate the ComboBox with multiple-choice options
            countryBox.DataSource = UserDb.multipleChoiceCountry;
            cityBox.DataSource = UserDb.multipleChoiceCountry;///connects to the list of countries
            cityBox.DisplayMember = "City";// Display the city name
            countryBox.DisplayMember = "Country";// Display the country name
            countryBox.DropDownStyle = ComboBoxStyle.DropDownList;
            cityBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
        private void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                int userId = GenerateID();




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
                    string userName = UserNameTextBox.Text;
                    string password = PasswordtextBox.Text;
                    string name = NametextBox.Text;
                    string address = AddresstextBox2.Text;
                    int zipcode = Convert.ToInt32(ZipcodetextBox4.Text);
                    string phone = (PhonetextBox5.Text).ToString();
                    int cityId = userDb.SelectCityId(cityBox.Text);
                    int countryId = userDb.SelectCountryId(cityBox.Text);
                    string cityName = cityBox.SelectedItem.ToString();
                    int addressId = GenerateAddressId();

                    UserModel user = new UserModel(userId, userName, password, 1, DateTime.Now, "user", DateTime.Now, "user");
                    UserInfo userInformation = new UserInfo( userId, userName, userId, addressId, address, zipcode, phone, cityId);
                    userDb.RegisterUser(user, userInformation);
                    userDb.InsertProfileInfo(userInformation);
                    

                    userDb.InsertCityIntoDatabase(cityId, cityName, addressId);
                    userDb.InsertCountryIntoDatabase(countryId, cityId);

                    MessageBox.Show("User Registered");
                    loginForm loginForm = new loginForm();
                }






            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "no connection 94");
            }
            this.Close();



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


