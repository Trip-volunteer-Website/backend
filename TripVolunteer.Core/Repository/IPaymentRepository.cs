using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IPaymentRepository
    {
        List<Payment> GetAllPayment();
        Task<Payment> CreatePayment(Payment payment);
        void UpdatePayment(Payment payment);
        void DeletePayment(int id);
        Payment GetPaymentById(int id);
      //  List<Payment> GetTotalPayment(Payment payment);
    }
}
