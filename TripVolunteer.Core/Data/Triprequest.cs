﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace TripVolunteer.Core.Data
{
    public partial class Triprequest
    {
        public Triprequest()
        {
            Invoices = new HashSet<Invoice>();
        }

        public decimal Requestid { get; set; }
        public decimal Userid { get; set; }
        public decimal Tripid { get; set; }
        public string? Requesttype { get; set; }
        public string? Cvfilepath { get; set; }
        public DateTime? Requestedat { get; set; }
        public string? Status { get; set; }
        public decimal? Paymentid { get; set; }


 

        public virtual Payment? Payment { get; set; }
       
        public virtual Trip? Trip { get; set; } 
        
        public virtual Userr? User { get; set; } 
        
        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
