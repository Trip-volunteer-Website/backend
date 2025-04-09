using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.DTO;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;
using TripVolunteer.Infra.Repository;
using TripVolunteer.Infra.Services;

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

        [HttpPost]
        [Route("pay")]
        public async Task<IActionResult> Pay([FromBody] PaymentDto dto)
        {
            try { 
            
                await paymentSarvice.PayAndGenerateInvoiceAsync(dto);
                return Ok("✅ Payment completed and invoice sent to your email.");
            }
            catch (Exception ex)
            {
                return BadRequest($"❌ Payment failed: {ex.Message}");
            }
        }
    }
}
