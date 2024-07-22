using System;
using System.Windows.Forms;

namespace c969
{
    public partial class ModifyForm : Form
    {


        public ModifyForm(int appointmentId, string time, int userId, int customerId)
        {
            InitializeComponent();
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");


            apptOrderLabel.Text = appointmentId.ToString();
            userIdLabel.Text = userId.ToString();
            customerLabel.Text = customerId.ToString();
            userDb.GetAppoitmentsInfo(appointmentId);
            endPicker.Format = DateTimePickerFormat.Custom;
            endPicker.CustomFormat = "MM/dd/yyyy HH:mm tt";
            startPicker.Format = DateTimePickerFormat.Custom;
            startPicker.CustomFormat = "MM/dd/yyyy HH:mm tt";

            typeComboBox.Items.Add("Consultation");
            typeComboBox.Items.Add("Follow-up");
            typeComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            typeComboBox.SelectedIndex = 0;
            startPicker.Value = TimeZoneInfo.ConvertTime(DateTime.Today.AddHours(9), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));
            endPicker.Value = TimeZoneInfo.ConvertTime(DateTime.Today.AddHours(17), TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"));

        
          
        }





        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {

            UserDb UserDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

            int customerId = int.Parse(customerLabel.Text);
            int userId = int.Parse(userIdLabel.Text);
            MainForm mainForm = new MainForm(customerId, userId);
            mainForm.Show();

            this.Hide();


        }






        private void deleteApptBtn_Click(object sender, EventArgs e)
        {
            try
            {

                int appointmentId = int.Parse(apptOrderLabel.Text);
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                userDb.DeleteAppointment(appointmentId);
                MessageBox.Show("Appointment Deleted");

                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }




        private void modifyApptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text) || string.IsNullOrEmpty(typeComboBox.Text))
                {
                    MessageBox.Show("Please select and appointment and complete the required information 116");
                }

                // dont allow the selection of weekends 

                else if (startPicker.Value.DayOfWeek == DayOfWeek.Saturday || endPicker.Value.DayOfWeek == DayOfWeek.Sunday)
                {
                    MessageBox.Show("Appointments cannot be scheduled on weekends. Please select a weekday.");
                }
                else
                {
                    string description = textBox2.Text;
                    string title = textBox1.Text;
                    int appointmentId = int.Parse(apptOrderLabel.Text);
                    int customerId = int.Parse(customerLabel.Text);
                    int userId = int.Parse(userIdLabel.Text);
                    string type = typeComboBox.Text;
                    //update


                    DateTime start = startPicker.Value;
                    DateTime end = endPicker.Value;


                    // Update the appointment details 

                    // userDb.UpdateTimeAppt(appointmentId, timeText);
                    DateTime localTimeEnd = TimeZoneInfo.ConvertTime(endPicker.Value, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
                    DateTime localTimestart = TimeZoneInfo.ConvertTime(startPicker.Value, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
                    string endTime = localTimeEnd.ToString("hh:mm tt");
                    string startTime = localTimestart.ToString("HH:mm tt");
                    localLabel.Text = $"Your local time : {endTime}";
                    localTimelbl.Text = $"Your local time : {startTime}";
                    // check for overlapping appointments true or false and times are not the same
                    bool overlap = userDb.CheckForOverlappingAppointments(start);
                    //bussines hopurs 9 am to 5 pm
                    // Define the business hours 
                    DateTime businessStart = DateTime.Today.AddHours(9);
                    DateTime businessEnd = DateTime.Today.AddHours(17);
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
                    //check hours are between 9 am to 5 pm
                    else if (startPicker.Value.TimeOfDay < businessStart.TimeOfDay || 
                      endPicker.Value.TimeOfDay > businessEnd.TimeOfDay  )
                    {
                        MessageBox.Show("Appointments can only be scheduled between 9:00 AM and 5:00 PM. Please select a different time.");
                    }
                    else
                    {
                        userDb.UpdateAppointment(appointmentId, description, title, type, customerId, start, end);
                        if (MessageBox.Show($"Appointment Updated: Your appointment in your local time will be at :{startTime} and end {endTime}", "Confirmation", MessageBoxButtons.OK) == DialogResult.OK)
                        {


                            // Open the MainForm
                            MainForm mainForm = new MainForm(customerId, userId);
                            mainForm.Show();
                            this.Close();
                        }
                        else
                        {
                            return;
                        }

                    }

                }




            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message);
            }
        }

        private void startPicker_ValueChanged(object sender, EventArgs e)
        {
            DateTime localTimestart = TimeZoneInfo.ConvertTime(startPicker.Value, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
            string startTime = localTimestart.ToString("hh:mm:ss tt");

            localTimelbl.Text = $"Your local time : {startTime}";
        }




        private void endPicker_ValueChanged_1(object sender, EventArgs e)
        {
            DateTime localTimeEnd = TimeZoneInfo.ConvertTime(endPicker.Value, TimeZoneInfo.FindSystemTimeZoneById("Eastern Standard Time"), TimeZoneInfo.Local);
            string endTime = localTimeEnd.ToString("hh:mm:ss tt");
            localLabel.Text = $"Your local time : {endTime}";
        }
    }
}




