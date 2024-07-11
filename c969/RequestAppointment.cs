using c969.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace c969
{
    public partial class RequestAppointment : Form
    {
        private int userId; 
        public RequestAppointment(int userId, int customerId)
        {
            InitializeComponent();
            customerLabel.Text = customerId.ToString();
            labeluser.Text = userId.ToString();
            //generate random number for appointment ID
            Random random = new Random();
            int randomNumber = random.Next(1, 1000);
            userId = userId;
            // Set the default time to 9:00 AM
            DateTime time = DateTime.Today.AddHours(9);
            Timelabel.Text = time.ToString("HH:mm:ss");
        }

        private void mainMenubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
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

                    localTimelbl.Text = $"Your local time : ";
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

                    localTimelbl.Text = $"Your local time : ";
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
        //create appointment
        private void addApptBtn_Click(object sender, EventArgs e)
        {
            try
            {

                // select insert appointment into the db
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

                if (string.IsNullOrEmpty(titletextBox.Text) || string.IsNullOrEmpty(descriptionText.Text))
                {
                    MessageBox.Show("Please select and appointment and complete the required information 116");
                }
                else
                {

                    string title = titletextBox.Text;
                    string description = descriptionText.Text;
                    
                  
                    int customerId = Convert.ToInt32(customerLabel.Text);
                    int Id = Convert.ToInt32(labeluser.Text);
                    string time = Timelabel.Text;
                    DateTime selectedDate = monthCalendar1.SelectionStart;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd");
              
                    // Parse the date and time string into a DateTime object
                    DateTime start = DateTime.ParseExact($"{formattedDate} {time}", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    // Convert the date and time to Eastern Standard Time
                    DateTime estTime = TimeZoneInfo.ConvertTimeToUtc(start, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
                 
                    string est = estTime.ToString(" HH:mm:ss");
                    string timeEst = DateTime.Parse(time).ToString("HH:mm:ss");


                    AppointmentModel appointment = new AppointmentModel(customerId,Id, title, description, start);

                   // userDb.UpdateTimeAppt(appointmentId, est);

                   
                    userDb.InsertAppointment(appointment);
                
                }
                MessageBox.Show("Appointment added successfully");
            }

            catch
            {
                MessageBox.Show("Please select and appointment and complete the required information 145");


            }
        }

        
    }
}
