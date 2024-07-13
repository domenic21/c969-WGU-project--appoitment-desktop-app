using MySql.Data.MySqlClient;
using System;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

namespace c969
{
    public partial class loginForm : Form
    {
        public loginForm()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            
          

          

            // Set the text box language based on the country code
            switch (CultureInfo.CurrentCulture.TwoLetterISOLanguageName)
            {
                case "US": // English text
                    LoginLabel.Text = "Sign In";
                    UserLabel.Text = "User";
                    label3.Text = "Password";
                    button1.Text = "Login";
                    RegisterBtn.Text = "Register";
                  
                    break;
                case "ES":// Spanish text
                    LoginLabel.Text = "Inicio de Sesion";
                    UserLabel.Text = "Usuario";
                    label3.Text = "Contraseña";
                    button1.Text = "Iniciar sesión";
                    RegisterBtn.Text = "Registrar Nuevo Usuario";
                  
                    break;
            }
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            userDb.InsertAllDummyData();
            userDb.dbConfig();



        }
        private void LogLogin(string username)
        {
            // Get the current timestamp
            string timestamp = DateTime.Now.ToString();

            // Create the log entry
            string logEntry = $"User: {username} - Timestamp: {timestamp}";

            string filePath = "..\\..\\Login_History.txt";
            

            try
            {
                // Append the log entry to the login history file
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(logEntry);
                }
            }
            catch (Exception ex)
            {
               
                MessageBox.Show($"Failed to log login: {ex.Message}");
            
              
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
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                string userName = UserNametextBox.Text;
                string password = PasswordtextBox.Text;
                int currentUserId = userDb.GetCurrentID(userName);

                // Convert local time zone to Est, pass the current time
                TimeZoneInfo estTimeZone = TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time");
                DateTime localStartTime = DateTime.Now;
                // Convert the local time to EST time zone 
                localStartTime = TimeZoneInfo.ConvertTime(localStartTime, TimeZoneInfo.Local, estTimeZone);
          
                DateTime dateTime = DateTime.Now;

                // Check if the username or password is empty
                if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(password))
                {
                    MessageBox.Show("Please enter a username and password");
                }
                // Retrieve the current user ID

                // Validate the user login
                if (userDb.ValidateUser(userName, password))
                {
                    // If the user login is successful, open the MainForm
                    this.Hide();
                    // alert the user of upcoming appointments 
                    bool hasAppointment = userDb.AlertAppointment(currentUserId, dateTime);
                    bool hasUpcomingAppointment = userDb.AlertAppointments(currentUserId, localStartTime);

                    if (hasAppointment && !hasUpcomingAppointment)
                    {
                        MessageBox.Show("You have an appointment within 15 minutes", "Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (!hasAppointment && hasUpcomingAppointment)
                    {
                        MessageBox.Show("You have upcoming appointments", "Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (hasAppointment && hasUpcomingAppointment)
                    {
                        MessageBox.Show("You have an appointment within 15 minutes and upcoming appointments", "Appointment Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    //mainForm.Show();
                    RegisterCustomer registerCustomerForm = new RegisterCustomer( currentUserId);
                    registerCustomerForm.Show();
                   
                    LogLogin("username");
                }
                else if (userName == "admin" && password == "admin")
                {
                    this.Hide();
                    ReportsForm reportsForm = new ReportsForm();
                    reportsForm.Show();

                }
                else
                {
                    // If the user login fails, display a message
                    MessageBox.Show("Login Failed, No user found");
                    if (CultureInfo.CurrentCulture.TwoLetterISOLanguageName == "es")
                    {
                        MessageBox.Show("Nombre de usuario y contraseña no coinciden.");
                    }
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
