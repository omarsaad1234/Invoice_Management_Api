
namespace Invoice_Management_Api.Services
{
    public class CityService : ICityService
    {
        private readonly AppDbContext _context;
        public CityService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<City>> GetAll()
        {
            return await _context.Cities.Include(c=>c.Branches).ToListAsync();
        }

        public async Task<City> GetById(int id)
        {
            return await _context.Cities.Include(c => c.Branches).SingleOrDefaultAsync(c => c.ID == id);
        }
        public async Task<City> GetByIdWithNoInclude(int id)
        {
            return await _context.Cities.SingleOrDefaultAsync(c => c.ID == id);
        }
        public async Task<City> Create(City city)
        {
            await _context.AddAsync(city);
            _context.SaveChanges();
            return(city);
        }

        public City Update(City city)
        {
            _context.Cities.Update(city);
            _context.SaveChanges();
            return city;
        }

        public City Delete(City city)
        {
            _context.Cities.Remove(city);
            _context.SaveChanges();
            return city;
        }

        public bool IsValidCityID(int id)
        {
            return _context.Cities.Any(c => c.ID == id);
        }

       
    }
}
