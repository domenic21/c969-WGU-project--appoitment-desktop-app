using System;
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
            



        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {
            DateTime selectedDate = monthCalendar1.SelectionStart;
            string formattedDate = selectedDate.ToString("yyyy-MM-dd");

            UserDb userDb = new UserDb(@"localhost", "c968_db", "root", "Strenght21$");
            userDb.SearchAppt(formattedDate);
            datagrid2.DataSource = UserDb.availableDay;

            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
