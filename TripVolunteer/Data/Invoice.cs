using System;
using System.Collections.Generic;

namespace TripVolunteer.API.Data
{
    public partial class Invoice
    {
        public decimal Invoiceid { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Invoicelink { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Requestid { get; set; }

        public virtual Triprequest? Request { get; set; }
    }
}
