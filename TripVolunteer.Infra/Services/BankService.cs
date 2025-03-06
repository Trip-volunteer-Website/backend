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
    public class BankService : IBankService
    {
        private readonly IBankRepository _bankRepo;
        public BankService(IBankRepository bankRepo)
        {
            _bankRepo = bankRepo;
        }
        public void CreateBank(Bank bank)
        {
            _bankRepo.CreateBank(bank);
        }

        public void DeleteBank(int bankId)
        {
            _bankRepo.DeleteBank(bankId);
        }

        public List<Bank> GetAllBanks()
        {
           return _bankRepo.GetAllBanks();
        }

        public Bank GetBankById(int bankId)
        {
            return _bankRepo.GetBankById(bankId);
        }

        public decimal ProcessPayment(int bankId, decimal amount)
        {
            return _bankRepo.ProcessPayment(bankId, amount);
        }

        public void UpdateBank(Bank bank)
        {
            _bankRepo.UpdateBank(bank);
        }
    }
}
