using System;
using System.Collections.Generic;

#nullable disable

namespace TripEventPlanner.Models
{
    public partial class LocationActivity
    {
        public short LocationId { get; set; }
        public short ActivityId { get; set; }

        public virtual Activity Activity { get; set; }
        public virtual Location Location { get; set; }
    }
}
