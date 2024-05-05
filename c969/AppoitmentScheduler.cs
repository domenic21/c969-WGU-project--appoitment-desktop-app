using c969.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
            


        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd"); // Format the date

            UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");
            List<AppointmentModel> appointments = userDb.SearchAppt(formattedDate);


            // Set the DataSource property of the DataGridView
            //datagrid2.DataSource = appointments;

            if (appointments.Count > 0) // If there are appointments available
            {
                textBoxcount.Text = "";
                comboBoxappt.DataSource = appointments;
                comboBoxappt.DisplayMember = "Start"; 
                
            }
            else
            {
                comboBoxappt.DataSource = null;
               
                textBoxcount.Text = $"No appointments available on {formattedDate}.";
                apptOrderLabel.Text = "";
                datetextbox.Text = "";
            }


        }

        private void comboBoxappt_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxappt.SelectedItem != null)
            {
                // Cast the selected item to your AppointmentModel class
                AppointmentModel selectedAppointment = (AppointmentModel)comboBoxappt.SelectedItem;

                // Retrieve the appointment ID and any other information you need
                int appointmentId = selectedAppointment.appointmentId;
                DateTime startTime = selectedAppointment.start;
                

                // Display the appointment information in the text box
                apptOrderLabel.Text = appointmentId.ToString();
                datetextbox.Text = startTime.ToString("yyyy-MM-dd");
                //convert to the local time
                DateTime localStartTime = TimeZoneInfo.ConvertTime(startTime, TimeZoneInfo.Local);
                timetextBox.Text = localStartTime.ToString("HH:mm:ss");
                titletextBox.Text = selectedAppointment.title;
                 descriptionText.Text = selectedAppointment.description;


            }
        }
    }
}
