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
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbContext _dbConext;


        public PaymentRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }
        public async Task<Payment> CreatePayment(Payment payment)
        {

            var p = new DynamicParameters();
            p.Add("payment_paidat", payment.Paidat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("payment_method", payment.Paymentmethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("payment_amount", payment.Amount, dbType: DbType.Int32, direction: ParameterDirection.Input);

            // OUT parameter to retrieve the new payment ID
            p.Add("payment_id", dbType: DbType.Int32, direction: ParameterDirection.Output);

            await _dbConext.Connection.ExecuteAsync("payment_package.makepayment", p, commandType: CommandType.StoredProcedure);

            // Retrieve the generated payment ID
            payment.Paymentid = p.Get<int>("payment_id");

            return payment;
        }

        public void DeletePayment(int id)
        {
            var p = new DynamicParameters();
            p.Add("payment_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("payment_package.deletepayment", p, commandType: CommandType.StoredProcedure);
        }

        public List<Payment> GetAllPayment()
        {

            IEnumerable<Payment> result = _dbConext.Connection
                                      .Query<Payment>("payment_package.GetAllpayment"
                                      , commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Payment GetPaymentById(int id)
        {
            var p = new DynamicParameters();
            p.Add("payment_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Payment> result = _dbConext.Connection.Query<Payment>
                ("payment_package.getpaymentbyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        /*  public List<Payment> GetTotalPayment(Payment payment)
          {

          }*/
        //(payment_id in payment.paymentid%TYPE,payment_paidat in payment.paidat%TYPE
        //,payment_method in payment.paymentmethod%TYPE ,payment_amount in payment.amount%TYPE)
        public void UpdatePayment(Payment payment)
        {
            var p = new DynamicParameters();
            p.Add("payment_id", payment.Paymentid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("payment_paidat", payment.Paidat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("payment_method", payment.Paymentmethod, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("payment_amount", payment.Amount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("payment_package.updatepayment", p, commandType: CommandType.StoredProcedure);

        }

    }
}
