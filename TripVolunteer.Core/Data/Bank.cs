using System;
using System.Collections.Generic;

namespace TripVolunteer.Core.Data
{
    public partial class Bank
    {
        public decimal Bankid { get; set; }
        public decimal? Amount { get; set; }
        public decimal? Cardnumber { get; set; }
        public string? Cardholdname { get; set; }
        public string? Cvv { get; set; }
        public DateTime? Expirydate { get; set; }
    }
}
