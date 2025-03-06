using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class BankRepository : IBankRepository
    {
        private readonly IDbContext _dbContext;

        public BankRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateBank(Bank bank)
        {
            var p = new DynamicParameters();
            p.Add("b_amount", bank.Amount, DbType.Decimal, ParameterDirection.Input);
            p.Add("card_number", bank.Cardnumber, DbType.String, ParameterDirection.Input);
            p.Add("cardhold_name", bank.Cardholdname, DbType.String, ParameterDirection.Input);
            p.Add("b_cvv", bank.Cvv, DbType.String, ParameterDirection.Input);
            p.Add("expiry_date", bank.Expirydate, DbType.Date, ParameterDirection.Input);

            _dbContext.Connection.Execute("bank_package.makebank", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteBank(int bankId)
        {
            var p = new DynamicParameters();
            p.Add("bank_id", bankId, DbType.Int32, ParameterDirection.Input);

            _dbContext.Connection.Execute("bank_package.deletebank", p, commandType: CommandType.StoredProcedure);

        }

        public List<Bank> GetAllBanks()
        {
            return _dbContext.Connection.Query<Bank>(
               "bank_package.GetAllbank", commandType: CommandType.StoredProcedure).ToList();
        }

        public Bank GetBankById(int bankId)
        {
            var p = new DynamicParameters();
            p.Add("bank_id", bankId, DbType.Int32, ParameterDirection.Input);

            return _dbContext.Connection.QueryFirstOrDefault<Bank>(
                "bank_package.getbankbyid", p, commandType: CommandType.StoredProcedure);
        }

        public decimal ProcessPayment(int bankId, decimal amount)
        {
            var p = new DynamicParameters();
            p.Add("p_bankId", bankId, DbType.Int32, ParameterDirection.Input);
            p.Add("p_amount", amount, DbType.Decimal, ParameterDirection.Input);

            var result = _dbContext.Connection.QueryFirstOrDefault<decimal>(
                "bank_package.ProcessPayment", p, commandType: CommandType.StoredProcedure);

            return result;
        }

        public void UpdateBank(Bank bank)
        {
            var p = new DynamicParameters();
            p.Add("bank_id", bank.Bankid, DbType.Int32, ParameterDirection.Input);
            p.Add("b_amount", bank.Amount, DbType.Decimal, ParameterDirection.Input);
            p.Add("card_number", bank.Cardnumber, DbType.String, ParameterDirection.Input);
            p.Add("cardhold_name", bank.Cardholdname, DbType.String, ParameterDirection.Input);
            p.Add("b_cvv", bank.Cvv, DbType.String, ParameterDirection.Input);
            p.Add("expiry_date", bank.Expirydate, DbType.Date, ParameterDirection.Input);

            _dbContext.Connection.Execute("bank_package.updatebank", p, commandType: CommandType.StoredProcedure);

        }
    }
}
