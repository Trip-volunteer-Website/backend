using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TripVolunteer.Core.DTO
{
    public class PaymentDto
    {
        public int BankId { get; set; }
        public int RequestId { get; set; }
        public string Method { get; set; }
        public decimal Amount { get; set; }
        public int UserId { get; set; }
    }
}
