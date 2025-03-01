using System;
using System.Collections.Generic;

namespace TripVolunteer.Core.Data
{
    public partial class Statichome
    {
        public decimal Id { get; set; }
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
        public string? P1 { get; set; }
        public string? P2 { get; set; }
        public string? P3 { get; set; }
        public string? Img1path { get; set; }
        public string? Img2path { get; set; }
        public string? Img3path { get; set; }
    }
}
