using System;
using System.Collections.Generic;

namespace TripVolunteer.Core.Data
{
    public partial class Userr
    {
        public Userr()
        {
            Logins = new HashSet<Login>();
            Testimonials = new HashSet<Testimonial>();
            Triprequests = new HashSet<Triprequest>();
        }

        public decimal Userid { get; set; }
        public string Email { get; set; } = null!;
        public string? Phone { get; set; }
        public string Fname { get; set; } = null!;
        public string Lname { get; set; } = null!;
        public string? Country { get; set; }
        public string? Imagepath { get; set; }
        public decimal Age { get; set; }
        public decimal Roleid { get; set; }

        public virtual Role? Role { get; set; } 
        public virtual ICollection<Login> Logins { get; set; }
        public virtual ICollection<Testimonial> Testimonials { get; set; }
        public virtual ICollection<Triprequest> Triprequests { get; set; }
    }
}
