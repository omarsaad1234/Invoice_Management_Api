
namespace Invoice_Management_Api.Services
{
    public class InvoiceDetailsService : IInvoiceDetailsService
    {
        private readonly AppDbContext _context;

        public InvoiceDetailsService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceDetail>> GetAll()
        {
            return (await _context.InvoiceDetails.Include(i => i.InvoiceHeader).ToListAsync());
        }

        public async Task<InvoiceDetail> GetById(int id)
        {
            var invoice_detail = await _context.InvoiceDetails.Include(i => i.InvoiceHeader).SingleOrDefaultAsync(i => i.ID == id);
            return (invoice_detail);
        }

        public async Task<InvoiceDetail> GetByIdWithNoInclude(int id)
        {
            var invoice_detail = await _context.InvoiceDetails.SingleOrDefaultAsync(i => i.ID == id);
            return (invoice_detail);
        }
        public async Task<InvoiceDetail> Create(InvoiceDetail invoiceDetail)
        {
            await _context.InvoiceDetails.AddAsync(invoiceDetail);
            _context.SaveChanges();
            return (invoiceDetail);
        }

        public InvoiceDetail Update(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Update(invoiceDetail);
            _context.SaveChanges();
            return (invoiceDetail);
        }

        public InvoiceDetail Delete(InvoiceDetail invoiceDetail)
        {
            _context.InvoiceDetails.Remove(invoiceDetail);
            _context.SaveChanges();
            return (invoiceDetail);
        }

    }
}
