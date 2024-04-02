using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BranchesController : ControllerBase
    {
        private readonly IBranchService _branchService;
        private readonly ICityService _cityService;
        private readonly IMapper _mapper;

        public BranchesController(IBranchService branchService, IMapper mapper, ICityService cityService)
        {
            _branchService = branchService;
            _mapper = mapper;
            _cityService = cityService;
        }

        // GET: api/<BranchesController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var branches = await _branchService.GetAll();

            var dataToView = _mapper.Map<IEnumerable<GetBranchesResponse>>(branches);

            return Ok(dataToView) ;
        }

        // GET api/<BranchesController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var branch = await _branchService.GetById(id);

            if (branch is null)
                return NotFound();

            var dataToView = _mapper.Map<GetBranchesResponse>(branch);

            return Ok(dataToView);
        }

        // POST api/<BranchesController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateBranchRequest branch)
        {
            var isValidCityId = _cityService.IsValidCityID(branch.CityID);

            if (!isValidCityId)
                return BadRequest("Not Valid City ID");

            var branchToCreate = new Branch { BranchName = branch.BranchName, CityID = branch.CityID };

            await _branchService.Create(branchToCreate);

            return Ok(branchToCreate);
        }

        // PUT api/<BranchesController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateBranchRequest branch)
        {
            var isValidCityId = _cityService.IsValidCityID(branch.CityID);

            if (!isValidCityId)
                return BadRequest("Not Valid City ID");

            var branchToUpdate = await _branchService.GetByIdWithNoInclude(id);

            if (branchToUpdate is null)
                return NotFound();

            branchToUpdate.BranchName = branch.BranchName;

            branchToUpdate.CityID = branch.CityID;

            _branchService.Update(branchToUpdate);

            return Ok(branchToUpdate);
        }

        // DELETE api/<BranchesController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var branchToDelete = await _branchService.GetByIdWithNoInclude(id);

            if (branchToDelete is null)
                return NotFound();

            _branchService.Delete(branchToDelete);

            return Ok(branchToDelete);
        }
    }
}
