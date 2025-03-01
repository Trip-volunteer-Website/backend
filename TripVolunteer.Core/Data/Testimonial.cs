using System;
using System.Collections.Generic;

namespace TripVolunteer.Core.Data
{
    public partial class Testimonial
    {
        public decimal Testimonialid { get; set; }
        public decimal Userid { get; set; }
        public string Content { get; set; } = null!;
        public string? Status { get; set; }

        public virtual Userr User { get; set; } = null!;
    }
}
