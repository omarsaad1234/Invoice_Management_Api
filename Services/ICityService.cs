namespace Invoice_Management_Api.Services
{
    public interface ICityService
    {
        public Task<IEnumerable<City>> GetAll();
        public Task<City> GetById(int id);
        public Task<City> GetByIdWithNoInclude(int id);
        public Task<City> Create(City city);
        public City Update(City city);
        public City Delete(City city);
        public bool IsValidCityID(int id);

    }
}
