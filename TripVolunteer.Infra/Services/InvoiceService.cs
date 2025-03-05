using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IInvoiceRepository _invoiceRepository;
        public InvoiceService(IInvoiceRepository
        invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public void DeleteInvoice(int id)
        {
            _invoiceRepository.DeleteInvoice(id);
        }

        public List<Invoice> GetAllInvoices()
        {
            return _invoiceRepository.GetAllInvoices();
        }

        public Invoice GetInvoiceById(int id)
        {
            return _invoiceRepository.GetInvoiceById(id);
        }

        public void makeInvoice(Invoice invoice)
        {
            _invoiceRepository.makeInvoice(invoice);
        }

        public void updateInvoice(Invoice invoice)
        {
            _invoiceRepository.updateInvoice(invoice);
        }
    }
}
