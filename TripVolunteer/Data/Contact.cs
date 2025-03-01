using System;
using System.Collections.Generic;

namespace TripVolunteer.API.Data
{
    public partial class Contact
    {
        public decimal Contactid { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Phonenumber { get; set; }
        public string? Content { get; set; }
    }
}
