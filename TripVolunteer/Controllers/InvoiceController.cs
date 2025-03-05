using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceController : ControllerBase
    {
        private readonly IInvoiceService invoiceService;
        public InvoiceController(IInvoiceService
        invoiceService)
        {
            this.invoiceService = invoiceService;
        }

        [HttpGet]
        public List<Invoice> GetAllInvoices()
        {
            return invoiceService.GetAllInvoices();
        }

        [HttpPost]
        public void makeInvoice(Invoice invoice)
        {
            invoiceService.makeInvoice(invoice);
        }

        [HttpPut]
        public void UpdateInvoice(Invoice invoice)
        {
            invoiceService.updateInvoice(invoice);
        }

        [HttpDelete]
        [Route("DeleteInvoice/{id}")]
        public void DeleteInvoice(int id)
        {
            invoiceService.DeleteInvoice(id);
        }

        [HttpGet]
        [Route("GetInvoiceById/{id}")]
        public Invoice GetInvoiceById(int id)
        {
            return invoiceService.GetInvoiceById(id);
        }
    }

}
