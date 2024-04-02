namespace Invoice_Management_Api.Services
{
    public interface IBranchService
    {
        public Task<IEnumerable<Branch>> GetAll();
        public Task<Branch> GetById(int id);
        public Task<Branch> GetByIdWithNoInclude(int id);
        public Task<Branch> Create(Branch branch);
        public Branch Update(Branch branch);
        public Branch Delete(Branch branch);
        public bool IsValidBranchID(int id);
    }
}
