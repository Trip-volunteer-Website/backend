using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IInvoiceRepository
    {
        List<Invoice> GetAllInvoices();
        void makeInvoice(Invoice invoice);
        void DeleteInvoice(int id);
        public void UpdateCourse(Invoice invoice);
        Invoice GetInvoiceById(int id);
    }
}
