namespace Invoice_Management_Api.Services
{
    public interface IInvoiceDetailsService
    {
        public Task<IEnumerable<InvoiceDetail>> GetAll();
        public Task<InvoiceDetail> GetById(int id);
        public Task<InvoiceDetail> Create(InvoiceDetail invoiceDetail);
        public InvoiceDetail Update(InvoiceDetail invoiceDetail);
        public InvoiceDetail Delete(InvoiceDetail invoiceDetail);
    }
}
