using System;
using System.Collections.Generic;

namespace TripVolunteer.Core.Data
{
    public partial class Trip
    {
        public Trip()
        {
            Triprequests = new HashSet<Triprequest>();
        }

        public decimal Tripid { get; set; }
        public string Tripname { get; set; } = null!;
        public string Location { get; set; } = null!;
        public DateTime Startdate { get; set; }
        public DateTime Enddate { get; set; }
        public decimal Price { get; set; }
        public decimal Minage { get; set; }
        public string? Description { get; set; }
        public decimal Maxvolunteers { get; set; }
        public decimal Maxusers { get; set; }
        public string? Status { get; set; }
        public decimal? Longitude { get; set; }
        public decimal? Latitude { get; set; }

        public virtual ICollection<Triprequest> Triprequests { get; set; }
    }
}
