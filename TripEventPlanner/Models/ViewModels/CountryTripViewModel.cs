using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripEventPlanner.Models.ViewModels
{
    public class CountryTripViewModel
    {
        public Country Country { get; set; }
        public List<Trip> Trips { get; set; }
    }
}