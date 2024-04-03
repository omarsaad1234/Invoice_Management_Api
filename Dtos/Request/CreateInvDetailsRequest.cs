namespace Invoice_Management_Api.Dtos.Request
{
    public class CreateInvDetailsRequest
    {
        public int InvoiceHeaderID { get; set; }
        public string ItemName { get; set; }
        public float ItemCount { get; set; }
        public float ItemPrice { get; set; }
        
    }
}
