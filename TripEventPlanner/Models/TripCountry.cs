using System;
using System.Collections.Generic;

#nullable disable

namespace TripEventPlanner.Models
{
    public partial class TripCountry
    {
        public short TripId { get; set; }
        public short CountryId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Trip Trip { get; set; }
    }
}
