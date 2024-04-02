
namespace Invoice_Management_Api.Services
{
    public class BranchService : IBranchService
    {
        private readonly AppDbContext _context;

        public BranchService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Branch>> GetAll()
        {
            return await _context.Branches.Include(b=>b.City).Include(b=>b.Cashiers).ToListAsync();
        }

        public async Task<Branch> GetById(int id)
        {
            var branch = await _context.Branches.Include(b => b.City).Include(b => b.Cashiers).SingleOrDefaultAsync(b => b.ID == id);
            return (branch);

        }
        public async Task<Branch> GetByIdWithNoInclude(int id)
        {
            var branch = await _context.Branches.SingleOrDefaultAsync(b => b.ID == id);
            return (branch);
        }
        public async Task<Branch> Create(Branch branch)
        {
            await _context.Branches.AddAsync(branch);
            _context.SaveChanges();
            return (branch);
        }

        public Branch Update(Branch branch)
        {
            _context.Branches.Update(branch);
            _context.SaveChanges();
            return (branch);
        }
        public Branch Delete(Branch branch)
        {
            _context.Remove(branch);
            _context.SaveChanges();
            return (branch);
        }

        public bool IsValidBranchID(int id)
        {
            return _context.Branches.Any(b => b.ID == id);
        }
    }
}
