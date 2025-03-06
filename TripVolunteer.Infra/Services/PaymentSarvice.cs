using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class PaymentSarvice : IPaymentSarvice
    {
        private readonly IPaymentRepository paymentRepository;
        public PaymentSarvice(IPaymentRepository paymentRepository)
        {
            this.paymentRepository = paymentRepository; 
        }

        public void CreatePayment(Payment payment)
        {
           paymentRepository.CreatePayment(payment);
        }

        public void DeletePayment(int id)
        {
           paymentRepository.DeletePayment(id);
        }

        public List<Payment> GetAllPayment()
        {
         return  paymentRepository.GetAllPayment();
        }

        public Payment GetPaymentById(int id)
        {
            return paymentRepository.GetPaymentById(id);
        }

        public void UpdatePayment(Payment payment)
        {
           paymentRepository.UpdatePayment(payment);
        }
    }
}
