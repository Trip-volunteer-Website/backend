using System;
using System.Collections.Generic;

namespace TripVolunteer.Core.Data
{
    public partial class Post
    {
        public decimal Postid { get; set; }
        public string? Imagepath { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime? Createdat { get; set; }
    }
}
