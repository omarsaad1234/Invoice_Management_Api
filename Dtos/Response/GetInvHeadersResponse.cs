namespace Invoice_Management_Api.Dtos.Response
{
    public class GetInvHeadersResponse
    {
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Cashier { get; set; }
        public string Branch { get; set; }
        public List<InvDetailsDto> Items { get; set; }
        public double Total {  get; set; }
    }
}
