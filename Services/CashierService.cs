
namespace Invoice_Management_Api.Services
{
    public class CashierService : ICashierService
    {
        private readonly AppDbContext _context;

        public CashierService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Cashier>> GetAll()
        {
            return await _context.Cashiers.Include(c=>c.Branch).ToListAsync();
        }
        public async Task<IEnumerable<Cashier>> GetByBranch(string branchName)
        {
            return await _context.Cashiers.Include(c => c.Branch).Where(c=>c.Branch.BranchName==branchName).ToListAsync();
        }

        public async Task<Cashier> GetById(int id)
        {
            return await _context.Cashiers.Include(c=>c.Branch).SingleOrDefaultAsync(c => c.ID == id);
        }
        public async Task<Cashier> GetByIdWithNoInclude(int id)
        {
            return await _context.Cashiers.SingleOrDefaultAsync(c => c.ID == id);
        }
        public async Task<Cashier> Create(Cashier cashier)
        {
            await _context.Cashiers.AddAsync(cashier);
            _context.SaveChanges();
            return(cashier);
        }
        public Cashier Update(Cashier cashier)
        {
            _context.Cashiers.Update(cashier);
            _context.SaveChanges();
            return(cashier);
        }

        public Cashier Delete(Cashier cashier)
        {
            _context.Cashiers.Remove(cashier);
            _context.SaveChanges();
            return(cashier);
        }

        public bool IsValidCashierID(int id)
        {
            return (_context.Cashiers.Any(c => c.ID == id));
        }
    }
}
