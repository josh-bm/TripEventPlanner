using System;
using System.Collections.Generic;

#nullable disable

namespace TripEventPlanner.Models
{
    public partial class Activity
    {
        public short ActivityId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Adress { get; set; }
        public DateTime? Date { get; set; }
        public decimal? Price { get; set; }
        public short? ActivityTypeId { get; set; }

        public virtual ActivityType ActivityType { get; set; }
    }
}
