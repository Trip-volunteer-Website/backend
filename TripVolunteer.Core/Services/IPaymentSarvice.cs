using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.DTO;

namespace TripVolunteer.Core.Services
{
    public interface IPaymentSarvice
    {
        List<Payment> GetAllPayment();
        void CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int id);
        Payment GetPaymentById(int id);
        Task<bool> PayAndGenerateInvoiceAsync(PaymentDto dto);
    }
}
