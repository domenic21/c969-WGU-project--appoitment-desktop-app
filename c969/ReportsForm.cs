using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace c969
{
    public partial class ReportsForm : Form
    {


        public ReportsForm()
        {
            InitializeComponent();

            // Set the ComboBox style to DropDownList
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;

            // Add options to the ComboBox
            comboBox1.Items.Add("The number of appointment types by month");
            comboBox1.Items.Add(" Schedule for each customer");
            comboBox1.Items.Add("Customer Name and Id");

            // Select the first option by default
            comboBox1.SelectedIndex = 0;
        }



        private void PopulateListBoxWithOption1()
        {
            // Clear the ListBox items
            listBox1.Items.Clear();

            // Retrieve data and populate ListBox based on Option 1
            UserDb userDb =  new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            userDb.GetType1();

            foreach (var appointment in UserDb.reports)
            {
                if (appointment.type != null)
                {
                    string formattedAppointment = $"Appointment types: {appointment.type.Count()} {appointment.type}  {appointment.start.ToString("MMMM")}";
                    listBox1.Items.Add(formattedAppointment);
                    RemoveDuplicatesFromListBox();
                }
            }


        }
        private void PopulateListBoxWithOption2()
        {
            // Clear the ListBox items
            listBox1.Items.Clear();

            // Retrieve data and populate ListBox based on Option 1
            UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            userDb.GetScheduleForEach();

            foreach (var appointment in UserDb.reports)
            {
                if (appointment.customerId != 0) // Check if customerId is not 0
                {
                    string formattedAppointment = $"{appointment.customerId} {appointment.customerName} -{appointment.title} -({appointment.start})-({appointment.end})";
                    listBox1.Items.Add(formattedAppointment);
                    RemoveDuplicatesFromListBox();
                }
            }
        }
        private void PopulateListBoxWithOption3()
        {
            // Clear the ListBox items
            listBox1.Items.Clear();

            // Retrieve data and populate ListBox based on Option 1
            UserDb userDb =  new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
            userDb.GetReport3();

            foreach (var customer in UserDb.reportsCustomer)
            {

                string formattedAppointment = $"Customer name and Id: {customer.customerName} - {customer.customerId}";
                listBox1.Items.Add(formattedAppointment);
                RemoveDuplicatesFromListBox();
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

                    RemoveDuplicatesFromListBox();
                    PopulateListBoxWithOption1();
                    


                    break;
                case " Schedule for each customer":


                    RemoveDuplicatesFromListBox();


                        PopulateListBoxWithOption2();
                    

                    break;
                case "Customer Name and Id":


                    RemoveDuplicatesFromListBox();
                    PopulateListBoxWithOption3();
                    

                    break;
                default:
                    // Handle other options
                    MessageBox.Show("Invalid option selected");
                    break;
            }
        }
        // LAMBDA EXPRESSION// FUNCTION INCORPORATED IN EACH REPORT OPTION TO AVOID DUPLICATES
        //chose to user lambda expression to avoid creating a new function for each report option 
        //to remove duplicates, better to user lambda expression to avoid code duplication and make the code more readable
        private void RemoveDuplicatesFromListBox()
        {
            var distinctItems = listBox1.Items.Cast<string>().Distinct().ToList();
            listBox1.Items.Clear();
            distinctItems.ForEach(item => listBox1.Items.Add(item));
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }

}