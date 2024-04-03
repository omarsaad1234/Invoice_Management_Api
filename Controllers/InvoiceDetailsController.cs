using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Invoice_Management_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InvoiceDetailsController : ControllerBase
    {
        private readonly IInvoiceDetailsService _invoiceDetailsService;

        private readonly IInvoiceHeaderService _invoiceHeaderService;

        private readonly IMapper _mapper;

        public InvoiceDetailsController(IInvoiceDetailsService invoiceDetailsService, IMapper mapper, IInvoiceHeaderService invoiceHeaderService)
        {
            _invoiceDetailsService = invoiceDetailsService;
            _invoiceHeaderService = invoiceHeaderService;
            _mapper = mapper;
        }

        // GET: api/<InvoiceDetailsController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var invoice_details=await _invoiceDetailsService.GetAll();

            var dataToView = _mapper.Map<IEnumerable<GetInvDetailsResponse>>(invoice_details);

            return Ok(dataToView);
        }

        // GET api/<InvoiceDetailsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetByID(int id)
        {
            var invoice_detail = await _invoiceDetailsService.GetById(id);

            if (invoice_detail is null)
                return NotFound();

            var dataToView = _mapper.Map<GetInvDetailsResponse>(invoice_detail);

            return Ok(dataToView);
        }

        // POST api/<InvoiceDetailsController>
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateInvDetailsRequest invoice_detail)
        {
            var isValidInvHeaderId = _invoiceHeaderService.IsValidInvHeaderID(invoice_detail.InvoiceHeaderID);

            if (!isValidInvHeaderId)
                return BadRequest("Invalid Invoice Header Id!");

            var invoiceDetailToCreate = new InvoiceDetail
            {
                InvoiceHeaderID = invoice_detail.InvoiceHeaderID,
                ItemName = invoice_detail.ItemName,
                ItemCount = invoice_detail.ItemCount,
                ItemPrice = invoice_detail.ItemPrice
            };
            await _invoiceDetailsService.Create(invoiceDetailToCreate);

            return Ok(invoiceDetailToCreate);

        }

        // PUT api/<InvoiceDetailsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromForm] CreateInvDetailsRequest invoice_detail)
        {
            var invoiceDetailToUpdate = await _invoiceDetailsService.GetByIdWithNoInclude(id);

            if (invoiceDetailToUpdate is null)
                return NotFound();

            var isValidInvHeaderId = _invoiceHeaderService.IsValidInvHeaderID(invoice_detail.InvoiceHeaderID);

            if (!isValidInvHeaderId)
                return BadRequest("Invalid Invoice Header Id!");

            invoiceDetailToUpdate.InvoiceHeaderID = invoice_detail.InvoiceHeaderID;
            invoiceDetailToUpdate.ItemName = invoice_detail.ItemName;
            invoiceDetailToUpdate.ItemCount = invoice_detail.ItemCount;
            invoiceDetailToUpdate.ItemPrice = invoice_detail.ItemPrice;

            _invoiceDetailsService.Update(invoiceDetailToUpdate);

            return Ok(invoiceDetailToUpdate);
        }

        // DELETE api/<InvoiceDetailsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var invoiceDetailToDelete = await _invoiceDetailsService.GetByIdWithNoInclude(id);

            if (invoiceDetailToDelete is null)
                return NotFound();

            _invoiceDetailsService.Delete(invoiceDetailToDelete);

            return Ok(invoiceDetailToDelete);
        }
    }
}
