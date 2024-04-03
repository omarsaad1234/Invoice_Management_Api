namespace Invoice_Management_Api.Dtos.Request
{
    public class CreateInvHeaderRequest
    {
        public string CustomerName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public int CashierID { get; set; }
    }
}
