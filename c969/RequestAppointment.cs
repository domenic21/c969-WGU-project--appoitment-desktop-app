using System;
using System.Globalization;
using System.Linq;
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
            DateTime endTime = DateTime.Today.AddHours(10);
            Timelabel.Text = time.ToString("HH:mm:ss");
            endLabel.Text = endTime.ToString("HH:mm:ss");
            Timelabel.Enabled = false;
            endLabel.Enabled = false;
            typeComboBox.Items.Add("Consultation");
            typeComboBox.Items.Add("Follow-up");
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            

        }
        

        private void mainMenubtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainForm mainForm = new MainForm(Convert.ToInt32(customerLabel.Text), Convert.ToInt32(labeluser.Text));
            mainForm.Show();
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

                if (string.IsNullOrEmpty(titletextBox.Text) || string.IsNullOrEmpty(descriptionText.Text) || string.IsNullOrEmpty(typeComboBox.Text))
                {
                    MessageBox.Show("Please select and appointment and complete the required information 116");
                }

                // dont allow the selection of weekends 

                else if (monthCalendar1.SelectionStart.DayOfWeek == DayOfWeek.Saturday || monthCalendar1.SelectionStart.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Appointments cannot be scheduled on weekends. Please select a weekday.");
                }
                else
                {

                    string title = titletextBox.Text;
                    string description = descriptionText.Text;
                    string type = typeComboBox.Text;
                    int customerId = Convert.ToInt32(customerLabel.Text);
                    int Id = Convert.ToInt32(labeluser.Text);
                    string time = Timelabel.Text;
                    string endTime = endLabel.Text;
                    DateTime selectedDate = monthCalendar1.SelectionStart;
                    string formattedDate = selectedDate.ToString("yyyy-MM-dd");

                    // Parse the date and time string into a DateTime object
                    DateTime start = DateTime.ParseExact($"{formattedDate} {time}", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    DateTime end = DateTime.ParseExact($"{formattedDate} {endTime}", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    // Convert the date and time to Eastern Standard Time
                    DateTime estTime = TimeZoneInfo.ConvertTimeToUtc(start, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

                    string est = estTime.ToString(" HH:mm:ss");
                    string timeEst = DateTime.Parse(time).ToString("HH:mm:ss");



                    // check for overlapping appointments true or false and times are not the same
                    bool overlap = userDb.CheckForOverlappingAppointments(start);
                    if (overlap)
                    {
                        MessageBox.Show("An appointment already exists at this time or start and end time are the same. Please select a different time.");
                    }
                    else if (start.TimeOfDay == end.TimeOfDay)
                    {


                        MessageBox.Show("Start and end time cannot be the same. Please select a different time.");
                    }
                    else if (start.TimeOfDay > end.TimeOfDay) // check if start time is greater than end time
                    {

                        MessageBox.Show("Start cant be greater than end time. Please select a different time.");
                    }
                    else
                    {
                        userDb.InsertAppointment(customerId, Id, title, type, description, start, end);
                        MessageBox.Show("Appointment added successfully");
                        this.Hide();
                     
                        MainForm mainForm = new MainForm(customerId, Id);
                        mainForm.Show();
                    }





                }

            }

            catch
            {
                MessageBox.Show("Please select and appointment and complete the required information 145");


            }
        }

        private void addE_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(endLabel.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                time = time.AddMinutes(30);
                endLabel.Text = time.ToString("HH:mm:ss");

                // Define the business hours 
                DateTime businessStart = DateTime.Today.AddHours(9);
                DateTime businessEnd = DateTime.Today.AddHours(17);

                // Check if the new time is within business hours
                if (time.TimeOfDay < businessStart.TimeOfDay || time.TimeOfDay >= businessEnd.TimeOfDay)
                {
                    MessageBox.Show("Time must be between 09:00 and 17:00. Please try again.");
                    DateTime resetTime = DateTime.Today.AddHours(9);
                    endLabel.Text = resetTime.ToString("HH:mm:ss");

                    localLabel.Text = $"Your local time : ";
                }
                else
                {
                    // Update the Timelabel with the new time

                    endLabel.Text = time.ToString("HH:mm:ss");
                    string timeText = time.ToString("HH:mm:ss");
                    DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.Parse(timeText), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
                    localLabel.Text = $"Your local time : {localTime.Hour:D2}:{localTime.Minute:D2}";
                }
            }
            else
            {
                MessageBox.Show("Invalid time format");
            }
        }

        private void minusE_Click(object sender, EventArgs e)
        {
            if (DateTime.TryParseExact(endLabel.Text, "HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime time))
            {
                time = time.AddMinutes(-30); // Subtract 30 minutes
                endLabel.Text = time.ToString("HH:mm:ss");
                // Define the business hours 
                DateTime businessStart = DateTime.Today.AddHours(9);
                DateTime businessEnd = DateTime.Today.AddHours(17);

                // Check if the new time is within business hours
                if (time.TimeOfDay < businessStart.TimeOfDay || time.TimeOfDay >= businessEnd.TimeOfDay)
                {
                    MessageBox.Show("Time must be between 09:00 and 17:00. Please try again.");
                    DateTime resetTime = DateTime.Today.AddHours(10);
                    endLabel.Text = resetTime.ToString("HH:mm:ss");

                    localLabel.Text = $"Your local time : ";
                }
                else
                {
                    // Update the Timelabel with the new time
                    endLabel.Text = time.ToString("HH:mm:ss");
                    string timeText = time.ToString("HH:mm:ss");
                    DateTime localTime = TimeZoneInfo.ConvertTime(DateTime.Parse(timeText), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
                    localLabel.Text = $"Your local time : {localTime.Hour:D2}:{localTime.Minute:D2}"; // Show just the hours and minutes
                }
            }
            else
            {
                MessageBox.Show("Invalid time format");
            }
        }

        private void localTimelbl_Click(object sender, EventArgs e)
        {

        }
    }
}
