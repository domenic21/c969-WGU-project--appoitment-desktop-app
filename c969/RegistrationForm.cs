﻿using c969.models;
using System;

using System.Windows.Forms;

namespace c969
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();


        }


        public static int GenerateID()
        {
            Random random = new Random();
            int newID = random.Next(1000, 9999); // Generates a random number between 1000 and 9999
            return newID;

        }

        private void registerBtn_Click(object sender, EventArgs e)
        {
            try
            {
                UserDb userDb = new UserDb(@"localhost", "3306", "client_schedule", "sqlUser", "Passw0rd!");
                int userId = GenerateID();


                string userName = UserNameTextBox.Text;


                string password = PasswordtextBox.Text;

                UserModel user = new UserModel(userId, userName, password, 1, DateTime.Now, "user", DateTime.Now, "user");

                userDb.RegisterUser(user);


                MessageBox.Show("User Registered");
                loginForm loginForm = new loginForm();



            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "no connection 94");
            }
            this.Close();



        }




    }
}


