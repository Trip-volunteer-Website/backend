using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentSarvice paymentSarvice;

        public PaymentController(IPaymentSarvice paymentSarvice)
        {
           this.paymentSarvice = paymentSarvice;
        }

        [HttpGet]
        public List<Payment> GetAllPayment()
        {
            return paymentSarvice.GetAllPayment();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Payment GetPaymentById(int id)
        {

            return paymentSarvice.GetPaymentById(id);
        }

        [HttpPost]
        public void CreatePayment(Payment payment)
        {
            paymentSarvice.CreatePayment(payment);
        }
        [HttpPut]
        public void UpdateLPayment(Payment payment)
        {
            paymentSarvice.UpdatePayment(payment);
        }

        [HttpDelete]
        [Route("DeleteLogin/{id}")]
        public void DeletePayment(int id)
        {
            paymentSarvice.DeletePayment(id);
        }
    }
}
