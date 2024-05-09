using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace c969
{
    public partial class ReportsForm : Form
    {
        private bool isListBoxPopulated;

        public ReportsForm()
        {
            InitializeComponent();

            // Set the ComboBox style to DropDownList
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Add options to the ComboBox
            comboBox1.Items.Add("Option 1");
            comboBox1.Items.Add("Option 2");

            // Select the first option by default
            comboBox1.SelectedIndex = 0;
        }

       

        private void PopulateListBoxWithOption1()
        {
            // Clear the ListBox items
            listBox1.Items.Clear();

            // Retrieve data and populate ListBox based on Option 1
            UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");
            userDb.GetCustomerSchedules();

            foreach (var appointment in UserDb.reports)
            {
                string formattedAppointment = $"{appointment.title} - {appointment.userId} ({appointment.start.Month})";
                listBox1.Items.Add(formattedAppointment);
            }
        }
        private void PopulateListBoxWithOption2()
        {
            // Clear the ListBox items
            listBox1.Items.Clear();

            // Retrieve data and populate ListBox based on Option 1
            UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");
            userDb.GetCustomerSchedules();

            foreach (var appointment in UserDb.reports)
            {
                string formattedAppointment = $"{appointment.title} - {appointment.userId} ({appointment.start})";
                listBox1.Items.Add(formattedAppointment);
            }
        }


        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Get the selected item from the ComboBox
            string selectedItem = comboBox1.SelectedItem.ToString();

            // Handle different options based on the selected item
            switch (selectedItem)
            {
                case "The number of appointment types by month":
                  
                    if (!isListBoxPopulated) 
                    {
                        PopulateListBoxWithOption1();
                        isListBoxPopulated = true; 
                    }
                    break;
                case "Option 2":
                    if (!isListBoxPopulated)
                    {
                        PopulateListBoxWithOption1();
                        isListBoxPopulated = true;
                    }
                    break;
                default:
                    // Handle other options
                    break;
            }
        }
    }

}