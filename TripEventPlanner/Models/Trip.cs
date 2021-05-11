using System;
using System.Collections.Generic;

#nullable disable

namespace TripEventPlanner.Models
{
    public partial class Trip
    {
        public Trip()
        {
            Users = new HashSet<User>();
        }

        public short TripId { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public short? LocationId { get; set; }

        public virtual Location Location { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
