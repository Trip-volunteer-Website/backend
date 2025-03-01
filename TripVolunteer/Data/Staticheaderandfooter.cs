using System;
using System.Collections.Generic;

namespace TripVolunteer.API.Data
{
    public partial class Staticheaderandfooter
    {
        public decimal Id { get; set; }
        public string? Email { get; set; }
        public decimal? Phonenumber { get; set; }
        public string? Name { get; set; }
        public string? Logo { get; set; }
        public string? Location { get; set; }
        public string? Content { get; set; }
    }
}
