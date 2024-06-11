using c969.models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;


namespace c969
{
    public partial class AppoitmentScheduler : Form


    {

        public AppoitmentScheduler(int currentUserId)
        {
            InitializeComponent();
            localTimelabel.Text = "Your local time:" + DateTime.Now.ToString();
            estTimelabel.Text = "EST TIME:" + TimeZoneInfo.ConvertTime(DateTime.Now, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time")).ToString();
            this.StartPosition = FormStartPosition.CenterScreen;
            comboBoxappt.DropDownStyle = ComboBoxStyle.DropDownList;
            labeluser.Text = currentUserId.ToString();

            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            string userName = userDb.GetUserName(currentUserId);
            label8.Text = userName;
            monthCalendar1.MaxSelectionCount = 1;
            textBoxcount.ReadOnly = true;
            apptOrderLabel.ReadOnly = true;
            datetextbox.ReadOnly = true;
          
            this.Size = new System.Drawing.Size(850, 550);



        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd"); // Format the date

            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            List<AppointmentModel> appointments = userDb.SearchAppt(formattedDate);


            // Set the DataSource property of the DataGridView
            //datagrid2.DataSource = appointments;

            if (appointments.Count > 0) // If there are appointments available
            {
                textBoxcount.Text = "";
                comboBoxappt.DataSource = appointments;
                comboBoxappt.DisplayMember = "Start";

                labelappt.Text = $"Appointments available: {appointments.Count} .";
                // titletextBox.Text = appointments[comboBoxappt.SelectedIndex].title;//display the title of the first appointment

            }
            else
            {
                comboBoxappt.DataSource = null;

                textBoxcount.Text = $"No appointments available on {formattedDate}.";
                apptOrderLabel.Text = "";
                datetextbox.Text = "";
                labelappt.Text = "";
            }


        }

        private void comboBoxappt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxappt.SelectedItem != null)
            {
                // Cast the selected item to your AppointmentModel class
                AppointmentModel selectedAppointment = (AppointmentModel)comboBoxappt.SelectedItem;

                // Retrieve the appointment ID 
                int appointmentId = selectedAppointment.appointmentId;
                DateTime startTime = selectedAppointment.start;


                // Display the appointment information in the text box
                apptOrderLabel.Text = appointmentId.ToString();
                datetextbox.Text = startTime.ToString("yyyy-MM-dd");
                //convert to the local time
                TimeZoneInfo userTimeZone = TimeZoneInfo.Local; // Get the user's time zone
                DateTime localStartTime = TimeZoneInfo.ConvertTime(startTime, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), userTimeZone);
                Timelabel.Text = localStartTime.ToString("HH:mm:ss");
                titletextBox.Text = selectedAppointment.title;
                descriptionText.Text = selectedAppointment.description;


            }

        }

        private void logout_Click(object sender, EventArgs e)
        {
            Close();
            loginForm login = new loginForm();
            login.Show();
        }

        private void Month_CheckedChanged(object sender, EventArgs e)
        {
            int month = monthCalendar1.SelectionStart.Month;
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

            List<AppointmentModel> appointments = userDb.FilterAppointmentsByMonth(month);
            // unchecked after each request 

            if (appointments.Count > 0) // If there are appointments available
            {
                textBoxcount.Text = "";
                comboBoxappt.DataSource = appointments;
                comboBoxappt.DisplayMember = "Start";

            }
            else
            {
                comboBoxappt.DataSource = null;

                textBoxcount.Text = $"No appointments available on 2024/{month}.";
                apptOrderLabel.Text = "";
                datetextbox.Text = "";
                labelappt.Text = "";
                Month.Checked = false;
            }

            switch (month)
            {
                case 1:
                    labelappt.Text = $"January has {appointments.Count} appointments.";
                    break;
                case 2:
                    labelappt.Text = $"February has {appointments.Count} appointments.";
                    break;
                case 3:
                    labelappt.Text = $"March has {appointments.Count} appointments.";
                    break;
                case 4:
                    labelappt.Text = $"April has {appointments.Count} appointments.";
                    break;
                case 5:
                    labelappt.Text = $"May has {appointments.Count} appointments.";
                    break;
                case 6:
                    labelappt.Text = $"June has {appointments.Count} appointments.";
                    break;
                case 7:
                    labelappt.Text = $"July has {appointments.Count} appointments.";
                    break;
                case 8:
                    labelappt.Text = $"August has {appointments.Count} appointments.";
                    break;
                case 9:
                    labelappt.Text = $"September has {appointments.Count} appointments.";
                    break;
                case 10:
                    labelappt.Text = $"October has {appointments.Count} appointments.";
                    break;
                case 11:
                    labelappt.Text = $"November has {appointments.Count} appointments.";
                    break;
                case 12:
                    labelappt.Text = $"December has {appointments.Count} appointments.";
                    break;
            }

        }

        private void weekCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd"); // Format the date

            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            List<AppointmentModel> appointments = userDb.FilterAppointmentsByWeek(formattedDate);


            // Set the DataSource property of the DataGridView
            //datagrid2.DataSource = appointments;

            if (appointments.Count > 0) // If there are appointments available
            {
                textBoxcount.Text = "";
                comboBoxappt.DataSource = appointments;
                comboBoxappt.DisplayMember = "Start";
                labelappt.Text = $"Week has {appointments.Count} appointments.";
            }
            else
            {
                comboBoxappt.DataSource = null;
                textBoxcount.Text = $"No appointments available week {formattedDate}.";
                apptOrderLabel.Text = "";
                datetextbox.Text = "";
                weekCheckBox.Checked = false;

            }


        }

        private void addApptBtn_Click(object sender, EventArgs e)
        {
            try
            {

                // select insert appointment into the db
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

                if (string.IsNullOrEmpty(titletextBox.Text) || string.IsNullOrEmpty(descriptionText.Text))
                {
                    MessageBox.Show("Please select and appointment and complete the required information");
                }
                else
                {

                    string title = titletextBox.Text;
                    string description = descriptionText.Text;
                    int appointmentId = Convert.ToInt32(apptOrderLabel.Text);
                    int customerId = int.Parse(labeluser.Text);
                    string time = Timelabel.Text;
                    string date = datetextbox.Text;
                    // Parse the date and time string into a DateTime object
                    DateTime start = DateTime.ParseExact($"{date} {time}", "yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    // Convert the date and time to Eastern Standard Time
                    DateTime estTime = TimeZoneInfo.ConvertTimeToUtc(start, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));




                    AppointmentModel appointment = new AppointmentModel(customerId, appointmentId, title, description, estTime);
                    userDb.UpdateTimeAppt(appointmentId, time);
                    userDb.InsertAppointment(appointment);

                }
                MessageBox.Show("Appointment added successfully");
            }

            catch
            {
                MessageBox.Show("Please select and appointment and complete the required information");


            }
        }

        private void titletextBox_TextChanged(object sender, EventArgs e)
        {
            titletextBox.MaxLength = 20;
            if (titletextBox.Text.Length >= 20)
            {
                MessageBox.Show("Please enter only 12 characters.");
                titletextBox.Text = titletextBox.Text.Remove(titletextBox.Text.Length - 1); // Remove the last character
            }
        }

        private void descriptionText_TextChanged(object sender, EventArgs e)
        {
            descriptionText.MaxLength = 150;
            if (descriptionText.Text.Length >= 150)
            {
                MessageBox.Show("Please enter only 150 characters.");
                descriptionText.Text = descriptionText.Text.Remove(descriptionText.Text.Length - 1); // Remove the last character
            }
        }

        private void mainMenubtn_Click(object sender, EventArgs e)
        {
            this.Hide();

            try
            {

                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                string userName = label8.Text;
                int userId = userDb.GetCurrentID(userName);


                MainForm mainForm = new MainForm(userName, userId);
                mainForm.Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

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

        private void changeApptBtn_Click(object sender, EventArgs e)
        {

        }

        private void Timelabel_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
