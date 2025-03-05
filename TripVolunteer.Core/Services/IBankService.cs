using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IBankService
    {
        List<Bank> GetAllBanks();
        Bank GetBankById(int bankId);
        void CreateBank(Bank bank);
        void UpdateBank(Bank bank);
        void DeleteBank(int bankId);
        decimal ProcessPayment(int bankId, decimal amount);
    }
}
