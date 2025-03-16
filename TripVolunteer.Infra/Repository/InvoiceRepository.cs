using Dapper;
using System.Data;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class InvoiceRepository : IInvoiceRepository
    {
        private readonly IDbContext _dbContext;

        public InvoiceRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void makeInvoice(Invoice invoice)
        {
            var p = new DynamicParameters();
            p.Add("invoice_title", invoice.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("invoice_description", invoice.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("invoice_link", invoice.Invoicelink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("invoice_amount", invoice.Amount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("request_id", invoice.Requestid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("invoice_package.makeInvoice", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteInvoice(int id)
        {
            var p = new DynamicParameters();
            p.Add("invoice_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("invoice_package.deleteInvoice", p, commandType: CommandType.StoredProcedure);
        }

        public List<Invoice> GetAllInvoices()
        {
            IEnumerable<Invoice> result = _dbContext.Connection.Query<Invoice>
          ("invoice_package.GetAllInvoices", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Invoice GetInvoiceById(int id)
        {
            var p = new DynamicParameters();
            p.Add("invoice_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Invoice> result = _dbContext.Connection.Query<Invoice>
                ("invoice_package.GetInvoiceById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void updateInvoice(Invoice invoice)
        {
            var p = new DynamicParameters();
            p.Add("invoice_id", invoice.Invoiceid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("invoice_title", invoice.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("invoice_description", invoice.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("invoice_link", invoice.Invoicelink, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("invoice_amount", invoice.Amount, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("request_id", invoice.Requestid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("invoice_package.updateInvoice", p, commandType: CommandType.StoredProcedure);
        }
    }

}

