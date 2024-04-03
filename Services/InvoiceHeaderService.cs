
namespace Invoice_Management_Api.Services
{
    public class InvoiceHeaderService : IInvoiceHeaderService
    {
        private readonly AppDbContext _context;

        public InvoiceHeaderService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<InvoiceHeader>> GetAll()
        {
            var invoice_header = await _context.InvoiceHeaders.Include(i => i.InvoiceDetails)
                .Include(i => i.Branch).Include(i => i.Cashier).ToListAsync();
            return (invoice_header);
        }

        public async Task<InvoiceHeader> GetById(int id)
        {
            var invoice_header = await _context.InvoiceHeaders.Include(i => i.InvoiceDetails)
                .Include(i => i.Branch).Include(i => i.Cashier).SingleOrDefaultAsync(i=>i.ID==id);
            return (invoice_header);
        }

        public async Task<InvoiceHeader> GetByIdWithNoInclude(int id)
        {
            var invoice_header = await _context.InvoiceHeaders.SingleOrDefaultAsync(i => i.ID == id);
            return (invoice_header);
        }
        public async Task<InvoiceHeader> Create(InvoiceHeader invoiceHeader)
        {
            await _context.InvoiceHeaders.AddAsync(invoiceHeader);
            _context.SaveChanges();
            return (invoiceHeader);
        }
        public InvoiceHeader Update(InvoiceHeader invoiceHeader)
        {
            _context.InvoiceHeaders.Update(invoiceHeader);
            _context.SaveChanges();
            return (invoiceHeader);
        }

        public InvoiceHeader Delete(InvoiceHeader invoiceHeader)
        {
            _context.InvoiceHeaders.Remove(invoiceHeader);
            _context.SaveChanges();
            return (invoiceHeader);
        }

        public bool IsValidInvHeaderID(int id)
        {
            return (_context.InvoiceHeaders.Any(i=>i.ID==id));
        }
    }
}
