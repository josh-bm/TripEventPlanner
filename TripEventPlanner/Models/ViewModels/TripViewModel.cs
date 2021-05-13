using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TripEventPlanner.Models.ViewModels
{
    public class TripViewModel
    {
        public string Name { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string ImageUrl { get; set; }
    }
}