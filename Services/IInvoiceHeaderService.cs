namespace Invoice_Management_Api.Services
{
    public interface IInvoiceHeaderService
    {
        public Task<IEnumerable<InvoiceHeader>> GetAll();
        public Task<InvoiceHeader> GetById(int id);
        public Task<InvoiceHeader> GetByIdWithNoInclude(int id);
        public Task<InvoiceHeader> Create(InvoiceHeader invoiceHeader);
        public InvoiceHeader Update(InvoiceHeader invoiceHeader);
        public InvoiceHeader Delete(InvoiceHeader invoiceHeader);
        public bool IsValidInvHeaderID(int id);
    }
}
