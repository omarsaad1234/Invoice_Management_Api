using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceHeadersController : ControllerBase
    {
        private readonly IInvoiceHeaderService _invoiceHeaderService;
        private readonly ICashierService _cashierService;
        private readonly IBranchService _branchService;
        private readonly IMapper _mapper;

        public InvoiceHeadersController(IInvoiceHeaderService invoiceHeaderService, ICashierService cashierService, IBranchService branchService, IMapper mapper)
        {
            _invoiceHeaderService = invoiceHeaderService;
            _cashierService = cashierService;
            _branchService = branchService;
            _mapper = mapper;
        }

        // GET: api/<InvoiceHeadersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoiceHeaders = await _invoiceHeaderService.GetAll();

            var dataToView = _mapper.Map<IEnumerable<GetInvHeadersResponse>>(invoiceHeaders);

            return Ok(dataToView);
        }

        // GET api/<InvoiceHeadersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var invoiceHeader = await _invoiceHeaderService.GetById(id);

            if (invoiceHeader is null)
                return NotFound();

            var dataToView = _mapper.Map<GetInvHeadersResponse>(invoiceHeader);

            return Ok(dataToView);
        }

        // POST api/<InvoiceHeadersController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateInvHeaderRequest invoiceHeader)
        {
            var isValidCashierId = _cashierService.IsValidCashierID(invoiceHeader.CashierID);


            if (!isValidCashierId)
                return BadRequest("Invalid Cashier Id");

            var cashier = await _cashierService.GetByIdWithNoInclude(invoiceHeader.CashierID);

            var invoiceHeaderToCreate = new InvoiceHeader
            {
                CustomerName = invoiceHeader.CustomerName,
                InvoiceDate = invoiceHeader.InvoiceDate,
                CashierID = invoiceHeader.CashierID,
                BranchID = cashier.BranchID
            };
        

            await _invoiceHeaderService.Create(invoiceHeaderToCreate);

            return Ok(invoiceHeaderToCreate);

        }

        // PUT api/<InvoiceHeadersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateInvHeaderRequest invoiceHeader)
        {
            var invoiceHeaderToUpdate = await _invoiceHeaderService.GetByIdWithNoInclude(id);

            if (invoiceHeaderToUpdate is null)
                return NotFound();

            var isValidCashierId = _cashierService.IsValidCashierID(invoiceHeader.CashierID);


            if (!isValidCashierId)
                return BadRequest("Invalid Cashier Id");

            var cashier = await _cashierService.GetByIdWithNoInclude(invoiceHeader.CashierID);

            invoiceHeaderToUpdate.CustomerName = invoiceHeader.CustomerName;
            invoiceHeaderToUpdate.InvoiceDate = invoiceHeader.InvoiceDate;
            invoiceHeaderToUpdate.CashierID = invoiceHeader.CashierID;
            invoiceHeaderToUpdate.BranchID = cashier.BranchID;

            _invoiceHeaderService.Update(invoiceHeaderToUpdate);

            return Ok(invoiceHeaderToUpdate);
        }

        // DELETE api/<InvoiceHeadersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoiceHeaderToDelete = await _invoiceHeaderService.GetByIdWithNoInclude(id);

            if (invoiceHeaderToDelete is null)
                return NotFound();

            _invoiceHeaderService.Delete(invoiceHeaderToDelete);

            return Ok(invoiceHeaderToDelete);
        }
    }
}
