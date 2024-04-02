using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;
        public CitiesController(ICityService cityService, IMapper mapper)
        {
            _cityService = cityService;
            _mapper = mapper;
        }
        // GET: api/<CitiesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cities = await _cityService.GetAll();
            var dataToView = _mapper.Map<IEnumerable<GetCitiesResponse>>(cities);
            return Ok(dataToView);
        }

        // GET api/<CitiesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var city = await _cityService.GetById(id);

            if (city is null)
                return NotFound();
            var dataToView = _mapper.Map<GetCitiesResponse>(city);
            return Ok(dataToView);
        }

        // POST api/<CitiesController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCityRequest city)
        {
            City cityToCreate = new City { CityName = city.CityName };
            await _cityService.Create(cityToCreate);
            return Ok(cityToCreate);
        }

        // PUT api/<CitiesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateCityRequest city)
        {
            var cityToUpdate = await _cityService.GetByIdWithNoInclude(id);
            if (cityToUpdate is null)
                return NotFound();
            cityToUpdate.CityName = city.CityName;
            _cityService.Update(cityToUpdate);
            return Ok(cityToUpdate);
        }

        // DELETE api/<CitiesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cityToDelete = await _cityService.GetByIdWithNoInclude(id);
            if (cityToDelete is null)
                return NotFound();
            _cityService.Delete(cityToDelete);
            return Ok(cityToDelete);
        }
    }
}
