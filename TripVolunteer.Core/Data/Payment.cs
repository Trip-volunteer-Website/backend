using System;
using System.Collections.Generic;

namespace TripVolunteer.Core.Data
{
    public partial class Payment
    {
        public Payment()
        {
            Triprequests = new HashSet<Triprequest>();
        }

        public decimal Paymentid { get; set; }
        public DateTime? Paidat { get; set; }
        public string Paymentmethod { get; set; } = null!;
        public decimal Amount { get; set; }

        public virtual ICollection<Triprequest> Triprequests { get; set; }
    }
}
