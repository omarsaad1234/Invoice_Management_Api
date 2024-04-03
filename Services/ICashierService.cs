namespace Invoice_Management_Api.Services
{
    public interface ICashierService
    {
        public Task<IEnumerable<Cashier>> GetAll();
        public Task<IEnumerable<Cashier>> GetByBranch(string branchName);
        public Task<Cashier> GetById(int id);
        public Task<Cashier> GetByIdWithNoInclude(int id);
        public Task<Cashier> Create(Cashier cashier);
        public Cashier Update(Cashier cashier);
        public Cashier Delete(Cashier cashier);
        public bool IsValidCashierID(int id);
    }
}
