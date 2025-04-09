using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.DTO;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using QuestPDF.Helpers;
using TripVolunteer.Core.Common;
using TripVolunteer.Infra.Common; 



namespace TripVolunteer.Infra.Services
{
    public class PaymentSarvice : IPaymentSarvice
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IBankRepository _bankRepo;
        private readonly IInvoiceRepository _invoiceRepo;
        private readonly IUserRepository _userRepository; // ✅ أضفناها
        private readonly IEmailService _emailService;
        private readonly ITripRequestRepository tripReq;

        public PaymentSarvice(
            IPaymentRepository paymentRepository,
            IBankRepository bankRepo,
            IInvoiceRepository invoiceRepo,
            IUserRepository userRepository, // ✅ هنا كمان
            IEmailService emailService,
            ITripRequestRepository _tripReq)
        {
            this.paymentRepository = paymentRepository;
            _bankRepo = bankRepo;
            _invoiceRepo = invoiceRepo;
            _userRepository = userRepository; // ✅
            _emailService = emailService;
            tripReq = _tripReq;
        }

        public async Task<Payment> CreatePayment(Payment payment)
        {
            var createdPayment = await paymentRepository.CreatePayment(payment);
           
           return createdPayment;
        }

        public void DeletePayment(int id)
        {
            paymentRepository.DeletePayment(id);
        }

        public List<Payment> GetAllPayment()
        {
            return paymentRepository.GetAllPayment();
        }

        public Payment GetPaymentById(int id)
        {
            return paymentRepository.GetPaymentById(id);
        }

        public void UpdatePayment(Payment payment)
        {
            paymentRepository.UpdatePayment(payment);
        }

        // ✅ العملية الموحدة
        //public async Task<bool> PayAndGenerateInvoiceAsync(PaymentDto dto)
        //{
        //    // 1. خصم المبلغ من البنك
        //    var result = _bankRepo.ProcessPayment(dto.BankId, dto.Amount);

        //    if (result == -1)
        //        throw new Exception("Insufficient balance.");
        //    if (result == -2)
        //        throw new Exception("Bank ID not found.");
        //    if (result == -3)
        //        throw new Exception("Unexpected error occurred.");

        //    // 2. جلب الإيميل من قاعدة البيانات
        //    var userEmail = _userRepository.GetEmailUsingCursor(dto.UserId);
        //    if (string.IsNullOrEmpty(userEmail))
        //        throw new Exception("User email not found.");

        //    // 3. حفظ الدفع
        //    var payment = new Payment
        //    {
        //        Paidat = DateTime.Now,
        //        Paymentmethod = dto.Method,
        //        Amount = dto.Amount
        //    };
        //    paymentRepository.CreatePayment(payment);

        //    // 4. إنشاء الفاتورة
        //    var invoice = new Invoice
        //    {
        //        Title = "Payment Invoice",
        //        Description = $"Invoice for request #{dto.RequestId}",
        //        Invoicelink = $"invoices/invoice_{dto.RequestId}.pdf",
        //        Amount = dto.Amount,
        //        Requestid = dto.RequestId
        //    };
        //    _invoiceRepo.makeInvoice(invoice);

        //    // 5. توليد PDF مؤقت
        //    var pdfBytes = GeneratePdf(invoice);

        //    // 6. إرسال الإيميل
        //    await _emailService.SendEmailWithPDFAsync(userEmail, "Your Invoice", "Please find attached invoice.", pdfBytes);

        //    return true;
        //}


        //Payment with storing Invoice 
        public async Task<bool> PayAndGenerateInvoiceAsync(PaymentDto dto)
        {
            // 1. خصم المبلغ من البنك
            var result = _bankRepo.ProcessPayment(dto.BankId, dto.Amount);

            if (result == -1)
                throw new Exception("Insufficient balance.");
            if (result == -2)
                throw new Exception("Bank ID not found.");
            if (result == -3)
                throw new Exception("Unexpected error occurred.");

            // 2. جلب الإيميل من قاعدة البيانات
            var userEmail = _userRepository.GetEmailUsingCursor(dto.UserId);
            if (string.IsNullOrEmpty(userEmail))
                throw new Exception("User email not found.");

            // 3. حفظ الدفع
            var payment = new Payment
            {
                Paidat = DateTime.Now,
                Paymentmethod = dto.Method,
                Amount = dto.Amount
            };
            var createdPayment = await paymentRepository.CreatePayment(payment);
            decimal paymentID = createdPayment.Paymentid;
            tripReq.UpdateTripRequestPayment(dto.RequestId,paymentID);

            // 4. إنشاء الفاتورة
            var invoice = new Invoice
            {
                Title = "Payment Invoice",
                Description = $"Invoice for request #{dto.RequestId}",
                Invoicelink = $"invoices/invoice_{dto.RequestId}.pdf",
                Amount = dto.Amount,
                Requestid = dto.RequestId
            };
            _invoiceRepo.makeInvoice(invoice);

            // 5. توليد PDF مؤقت
            var pdfBytes = GeneratePdf(invoice);

            // ✅ 6. حفظ الملف داخل مجلد Angular assets/invoices
            var fileName = $"invoice_{dto.RequestId}.pdf";
            var folderPath = Path.Combine("C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\invoices");
            var filePath = Path.Combine(folderPath, fileName);

            // ✅ تأكد من وجود المجلد، وإذا لم يكن موجوداً فأنشئه
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            // ✅ حفظ ملف PDF فعلياً على المسار المحدد
            await File.WriteAllBytesAsync(filePath, pdfBytes);

            // 7. إرسال الإيميل مع نسخة مرفقة من الفاتورة
            await _emailService.SendEmailWithPDFAsync(userEmail, "Your Invoice", "Please find attached invoice.", pdfBytes);

            
            return true;
        }

        private byte[] GeneratePdf(Invoice invoice)
        {
            using var stream = new MemoryStream();

            Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(40);
                    page.Size(PageSizes.A4);
                    page.PageColor(Colors.White);
                    page.DefaultTextStyle(x => x.FontSize(12));

                    page.Content().Column(col =>
                    {
                        // ✅ عنوان أنيق للفاتورة
                        col.Item().AlignCenter().Text(text =>
                        {
                            text.Span("Trip Volunteer - Invoice")
                                .FontSize(22)
                                .Bold()
                                .FontColor(Colors.Blue.Medium);
                        });

                        // ✅ فاصل
                        col.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                        // ✅ محتوى الفاتورة داخل إطار
                        col.Item().Border(1).BorderColor(Colors.Grey.Lighten2).Padding(20).Column(content =>
                        {
                            content.Item().Text($"Invoice Date: {DateTime.Now:dd/MM/yyyy}").Bold();
                            content.Item().Text($"Request ID: {invoice.Requestid}");
                            content.Item().Text($"Title: {invoice.Title}");
                            content.Item().Text($"Description: {invoice.Description}");

                            content.Item().PaddingVertical(10).LineHorizontal(1).LineColor(Colors.Grey.Lighten2);

                            content.Item().Row(row =>
                            {
                                row.RelativeItem().Text("Total Amount").Bold();
                                row.ConstantItem(100).AlignRight().Text($"{invoice.Amount} JD").Bold().FontSize(14);
                            });
                        });

                        // ✅ رسالة شكر بأسفل الصفحة
                        col.Item().PaddingTop(25).AlignCenter().Text("Thank you for your payment!")
                            .Italic()
                            .FontColor(Colors.Grey.Darken2);
                    });
                });
            }).GeneratePdf(stream);

            return stream.ToArray();
        }



    }
}
