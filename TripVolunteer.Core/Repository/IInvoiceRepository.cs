using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAllInvoices();
        void makeInvoice(Invoice invoice);
        void DeleteInvoice(int id);
        public void updateInvoice(Invoice invoice);
        Invoice GetInvoiceById(int id);
    }
}
