using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace c969.models
{
    public class AppoitmentModel
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
        public AppoitmentModel(int appointmentId, int customerId, int userId, string title, string description, DateTime start, DateTime end, DateTime createDate,  DateTime lastUpdate)
        {
            this.appointmentId = appointmentId;
            this.customerId = customerId;
            this.userId = userId;
            this.title = title;
            this.description = description;
          
          
            this.start = start;
            this.end = end;
            this.createDate = createDate;
            this.lastUpdate = lastUpdate;
            
        }

        public AppoitmentModel (DateTime start, int appointmentId)
        {
            this.start = start;
            this.appointmentId = appointmentId;

        }
    }
}
