using c969.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace c969
{
    public partial class ModifyForm : Form
    {
        

        public ModifyForm(int appointmentId, string time, int userId)
        {
            InitializeComponent();
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

            timeMinusBtn.Visible = false;
            apptOrderLabel.Text = appointmentId.ToString();
            Timelabel.Visible = false;
            userIdLabel.Text = userId.ToString();
                 // Get the user's time zone
            DateTime StartTime = DateTime.Parse(time);
            Timelabel.Text = StartTime.ToString("HH:mm:ss");
            userDb.GetAppoitmentsInfo(appointmentId);
   



        }
 
        



        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            int userId = int.Parse(userIdLabel.Text);
            UserDb UserDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!"); 
            string userName = UserDb.GetUserName(userId);
            MainForm mainForm = new MainForm(userName, userId);
            mainForm.Show();
           
            this.Hide();
       

        }






        private void deleteApptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string description = richTextBox1.Text.ToString();
                string title = textBox1.Text.ToString();
                int appointmentId = int.Parse(apptOrderLabel.Text);
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                userDb.DeleteAppointment(appointmentId);
                MessageBox.Show("Appointment Deleted");
                MainForm mainForm = new MainForm(userDb.GetUserName(appointmentId), appointmentId);
                mainForm.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }






        private void changeApptBtn_Click(object sender, EventArgs e)
        {

            Timelabel.Visible = true;
            modifyApptBtn.Visible = true;
            timeMinusBtn.Visible = true;
            timeAddBtn.Visible = true;


        }

        private void timeAddBtn_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(Timelabel.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                time = time.AddMinutes(30);
                Timelabel.Text = time.ToString("HH:mm:ss");

                // Define the business hours 
                DateTime businessStart = DateTime.Today.AddHours(9);
                DateTime businessEnd = DateTime.Today.AddHours(17);

                // Check if the new time is within business hours
                if (time.TimeOfDay < businessStart.TimeOfDay || time.TimeOfDay >= businessEnd.TimeOfDay)
                {
                    MessageBox.Show("Time must be between 09:00 and 17:00. Please try again.");
                    DateTime resetTime = DateTime.Today.AddHours(9);
                    Timelabel.Text = resetTime.ToString("HH:mm:ss");
                   
                
                }
                else
                {
                    // Update the Timelabel with the new time

                    Timelabel.Text = time.ToString("HH:mm:ss");
                    string timeText = time.ToString("HH:mm:ss");
                    DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.Parse(timeText), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
                    localTimelbl.Text = $"Your local time : {localTime.Hour:D2}:{localTime.Minute:D2}";
                }
            }
            else
            {
                MessageBox.Show("Invalid time format");
            }
        }

        private void timeMinusBtn_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(Timelabel.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                time = time.AddMinutes(-30); // Subtract 30 minutes
                Timelabel.Text = time.ToString("HH:mm:ss");
                // Define the business hours 
                DateTime businessStart = DateTime.Today.AddHours(9);
                DateTime businessEnd = DateTime.Today.AddHours(17);

                // Check if the new time is within business hours
                if (time.TimeOfDay < businessStart.TimeOfDay || time.TimeOfDay >= businessEnd.TimeOfDay)
                {
                    MessageBox.Show("Time must be between 09:00 and 17:00. Please try again.");
                    DateTime resetTime = DateTime.Today.AddHours(9);
                    Timelabel.Text = resetTime.ToString("HH:mm:ss");

                 
                }
                else
                {
                    // Update the Timelabel with the new time
                    Timelabel.Text = time.ToString("HH:mm:ss");
                    string timeText = time.ToString("HH:mm:ss");
                    DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.Parse(timeText), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
                    localTimelbl.Text = $"Your local time : {localTime.Hour:D2}:{localTime.Minute:D2}"; // Show just the hours and minutes
                }
            }
            else
            {
                MessageBox.Show("Invalid time format");
            }
        }

        private void modifyApptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string description = richTextBox1.Text;
                string title = textBox1.Text;
                int appointmentId = int.Parse(apptOrderLabel.Text);

                // Ensure Timelabel.Text is in "HH:mm:ss" format
                string timeText = Timelabel.Text;
                if (!TimeSpan.TryParse(timeText, out TimeSpan timeSpan))
                {
                    MessageBox.Show("Invalid time format. Please use HH:mm:ss format.");
                    return;
                }

                // Retrieve the current appointment's start date to combine with the new time
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                DateTime currentStartDate = userDb.GetAppointmentTime(appointmentId);
                int userId = int.Parse(userIdLabel.Text);

                // Update the appointment details
                userDb.UpdateAppointment(appointmentId, description, title, userId);
                userDb.UpdateTimeAppt(appointmentId, timeText);
                DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.Parse(timeText), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);


                if (MessageBox.Show($"Appointment Updated: Your appointment in your local time will be at :{localTime}", "Confirmation", MessageBoxButtons.OK) == DialogResult.OK)
                {
                   
                    string username = userDb.GetUserName(userId);
                    // Open the MainForm
                    MainForm mainForm = new MainForm(username, userId);
                    mainForm.Show();
                    this.Close();
                }
                else {
                  return;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }
    }
}




