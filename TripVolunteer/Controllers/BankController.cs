using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private readonly IBankService _bankService;

        public BankController(IBankService bankService)
        {
            _bankService = bankService;
        }

        
        [HttpGet]
        public List<Bank> GetAllBanks()
        {
            return _bankService.GetAllBanks();
        }

        
        [HttpGet]
        [Route("getbyid/{id}")]
        public Bank GetBankById(int id)
        {
            return _bankService.GetBankById(id);
        }

       
        [HttpPost]
        public void CreateBank(Bank bank)
        {
            _bankService.CreateBank(bank);
        }

       
        [HttpPut]
        public void UpdateBank(Bank bank)
        {
            _bankService.UpdateBank(bank);
        }

        [HttpDelete]
        [Route("deleteBank/{id}")]
        public void DeleteBank(int id)
        {
            _bankService.DeleteBank(id);
        }


        [HttpPost]
        [Route("processPay/{id}/{amount}")]
        public void ProcessPayment(int id, decimal amount)
        {
            _bankService.ProcessPayment(id, amount);
        }
               
    }
}

