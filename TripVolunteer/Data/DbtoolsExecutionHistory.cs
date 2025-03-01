using System;
using System.Collections.Generic;

namespace TripVolunteer.API.Data
{
    public partial class DbtoolsExecutionHistory
    {
        public decimal Id { get; set; }
        public string? Hash { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset? CreatedOn { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTimeOffset? UpdatedOn { get; set; }
        public string? Statement { get; set; }
        public decimal? Times { get; set; }
    }
}
