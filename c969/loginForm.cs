using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace c969
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            // Set the current culture to Spanish
            CultureInfo culture = CultureInfo.CurrentCulture;

            RegionInfo regionInfo = new RegionInfo(culture.Name);

            string countryCode = regionInfo.TwoLetterISORegionName;

            // Set the text box language based on the country code
            switch (countryCode)
            {
                case "US": // English text
                    LoginLabel.Text = "Sign In";
                    UserLabel.Text = "User";
                    label3.Text = "Password";
                    button1.Text = "Login";
                    RegisterBtn.Text = "Register";
                    label1.Text = "New User?";
                    break;
                case "ES":// Spanish text
                    LoginLabel.Text = "Inicio de Sesion";
                    UserLabel.Text = "Usuario";
                    label3.Text = "Contraseña";
                    button1.Text = "Iniciar sesión";
                    RegisterBtn.Text = "Registrarse";
                    label1.Text = "Nuevo Usuario?";
                      break;
            }

        }

       
        private void RegisterBtn_Click(object sender, EventArgs e)
        {
            RegistrationForm registrationForm = new RegistrationForm();
            registrationForm.Show();
        }

        // login button
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");
                string userName = UserNametextBox.Text;
                string password = PasswordtextBox.Text;

                
                // Check if the username or password is empty
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a username and password");
                }
                int currentUserId = userDb.GetCurrentID(userName); // Retrieve the current user ID

                // Validate the user login
                if (userDb.ValidateUser(userName, password))
                {
                    // If the user login is successful, open the MainForm
                    this.Hide();
                    MainForm mainForm = new MainForm(userName, currentUserId);
                    mainForm.Show();
                }
                else
                {
                    // If the user login fails, display a message
                    MessageBox.Show("Login Failed, No user found");
                }
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "no connection login");
            }
        }

        // Form closing event
        private void loginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // End any process and exit the application
            Environment.Exit(0);
        }
    }
}
