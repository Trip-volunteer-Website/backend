using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IInvoiceService
    {
        List<Invoice> GetAllInvoices();
        void makeInvoice(Invoice invoice);
        void DeleteInvoice(int id);
        public void updateInvoice(Invoice invoice);
        Invoice GetInvoiceById(int id);
    }
}
