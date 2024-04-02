using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CashiersController : ControllerBase
    {
        private readonly ICashierService _cashierService;
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;
        public CashiersController(ICashierService cashierService, IMapper mapper, IBranchService branchService)
        {
            _cashierService = cashierService;
            _mapper = mapper;
            _branchService = branchService;
        }
        // GET: api/<CashiersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var cashiers = await _cashierService.GetAll();
            var dataToView = _mapper.Map<IEnumerable<GetCashiersResponse>>(cashiers);
            return Ok(dataToView);
        }

        // GET api/<CashiersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var cashier = await _cashierService.GetById(id);
            if (cashier is null)
                return NotFound();
            var dataToView = _mapper.Map<GetCashiersResponse>(cashier);
            return Ok(dataToView);
        }
        [HttpGet("GetByBranch")]
        public async Task<IActionResult> GetByBranch(string branch)
        {
            var cashiers = await _cashierService.GetByBranch(branch);
            if (cashiers.IsNullOrEmpty())
                return NotFound();
            var dataToView = _mapper.Map<IEnumerable<GetCashiersResponse>>(cashiers);
            return Ok(dataToView);
        }

        // POST api/<CashiersController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateCashierRequest cashier)
        {
            
            var isValidBranchID = _branchService.IsValidBranchID(cashier.BranchID);

            if (!isValidBranchID)
                return BadRequest("Branch Id Didn't Found");

            var cashierToAdd = new Cashier { CashierName = cashier.CashierName, BranchID = cashier.BranchID };
            await _cashierService.Create(cashierToAdd);
            return Ok(cashierToAdd);

        }

        // PUT api/<CashiersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateCashierRequest cashier)
        {
            
            var isValidBranchID = _branchService.IsValidBranchID(cashier.BranchID);

            if (!isValidBranchID)
                return BadRequest("Branch Id Didn't Found");

            var cashierToUpdate = await _cashierService.GetByIdWithNoInclude(id);

            if (cashierToUpdate is null)
                return NotFound();

            cashierToUpdate.CashierName = cashier.CashierName;

            cashierToUpdate.BranchID = cashier.BranchID;

            _cashierService.Update(cashierToUpdate);

            return Ok(cashierToUpdate);
        }

        // DELETE api/<CashiersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var cashierToDelete = await _cashierService.GetByIdWithNoInclude(id);
            if (cashierToDelete is null)
                return NotFound();
            _cashierService.Delete(cashierToDelete);
            return Ok(cashierToDelete);
        }
    }
}
