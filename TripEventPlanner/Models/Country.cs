using System;
using System.Collections.Generic;

#nullable disable

namespace TripEventPlanner.Models
{
    public partial class Country
    {
        public Country()
        {
            Locations = new HashSet<Location>();
        }

        public short CountryId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Location> Locations { get; set; }
    }
}
