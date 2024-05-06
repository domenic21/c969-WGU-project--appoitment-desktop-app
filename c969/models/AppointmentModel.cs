using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.models
{
    public class AppointmentModel
    {
        public int appointmentId { get; set; }
        public int customerId { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        
        public DateTime start { get; set; }
       
        public DateTime end { get; set; }
        public DateTime createDate { get; set; }
        public string createdBy { get; set; }
        public DateTime lastUpdate { get; set; }
        public string lastUpdateBy { get; set; }
        

        public AppointmentModel(int appointmentId, string title, string description, DateTime start, DateTime end)
        {
            this.appointmentId = appointmentId;
         
            this.title = title;
            this.description = description;


            this.start = start;
            this.end = end;
  

        }


        public AppointmentModel(int userId,int appointmentId, string title, string description, DateTime start)
        {
            this.appointmentId = appointmentId;
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.start = start;
          


        }

        public AppointmentModel (DateTime start, int appointmentId)
        {
            this.start = start;
            this.appointmentId = appointmentId;

        }
    }
}
