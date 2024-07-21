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
       
        public int userId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        
        public DateTime start { get; set; }
       
       public DateTime end { get; set; }

        public string type { get; set; }
        public string location { get; set; }

        public DateTime appointmentDay { get; set; }
        public TimeSpan appointmentTime { get; set; }
        public int appointmentsCount { get; set; }
        
        public int customerId { get; set; }

        public string customerName { get; set; }

      

        public AppointmentModel(DateTime appointmentDay, TimeSpan appointmentTime,int  appointmentId, int appointmentsCount) 
        {
         this.appointmentId = appointmentId;
            this.appointmentDay = appointmentDay;
            this.appointmentTime = appointmentTime;
            this.appointmentsCount = appointmentsCount;
        
        }
    


        public AppointmentModel(int userId,int appointmentId, string title,string type, string description, DateTime start, DateTime end)
        {
            this.appointmentId = appointmentId;
            this.userId = userId;
            this.title = title;
            this.description = description;
            this.start = start;
            this.end = end;
            this.type = type;


        }

        public AppointmentModel( int appointmentId,   DateTime start, DateTime end)
        {
            this.appointmentId = appointmentId;
      
            this.start = start;
            this.end = end;



        }

        public AppointmentModel(int customerId, string customerName, int appointmentId, string title, string description, DateTime start, DateTime end)
        {
            this.appointmentId = appointmentId;
      
            this.title = title;
            this.description = description;
            this.start = start;
            this.end = end;
            this.customerId = customerId;
            this.customerName = customerName;



        }

        public AppointmentModel (DateTime start, int appointmentId)
        {
            this.start = start;
            this.appointmentId = appointmentId;

        }

        public AppointmentModel( string type ,DateTime start)
        {
          this.type = type;
            this.start = start; 
        }

        public AppointmentModel(int appointmentId, string  title, string description)
        {
            this.appointmentId = appointmentId;
            this.title = title;
            this.description = description;
          
        }

        public AppointmentModel(  DateTime start, DateTime end, int appointmentId)
        {
        
            this.end = end;
            this.appointmentId = appointmentId;
            this.start = start;
        }   

 



    }
}
