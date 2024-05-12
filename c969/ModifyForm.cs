using c969.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace c969
{
    public partial class ModifyForm : Form
    {
      

        public ModifyForm( int appointmentId)
        {
            InitializeComponent();
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");

            userDb.GetAppoitmentsInfo( appointmentId);
            LoadAppointments();
            label1.Text = appointmentId.ToString();
        }

        private void LoadAppointments()
        {

            List<string> formattedAppointments = FormatAppointments(UserDb.appointmentModels);
           
           
        }
        private List<string> FormatAppointments(BindingList<AppointmentModel> appointments)
        {

            List<string> formattedAppointments = new List<string>();
            foreach (var appointment in appointments)
            {
                string formattedAppointment = $"Your appointment is at : {appointment.start} {appointment.appointmentId}";
                richTextBox1.Text = appointment.description;
                textBox1.Text = appointment.title;
                formattedAppointments.Add(formattedAppointment);
            }
            return formattedAppointments;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
           try { 
             string description = richTextBox1.Text.ToString();
            string title = textBox1.Text.ToString();
            int appointmentId = int.Parse(label1.Text);
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                userDb.UpdateAppointment(appointmentId, description, title);
                MessageBox.Show("Appointment Updated");
               this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
          
        }

        private void deleteApptBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string description = richTextBox1.Text.ToString();
                string title = textBox1.Text.ToString();
                int appointmentId = int.Parse(label1.Text);
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
    }
}




