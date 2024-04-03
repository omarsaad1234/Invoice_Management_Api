namespace Invoice_Management_Api.Dtos.Response
{
    public class GetInvDetailsResponse
    {
        public string CustomerName { get; set; }
        public string ItemName { get; set; }
        public float ItemCount { get; set; }
        public float ItemPrice { get; set; }
        public float SubTotal { get; set; }
    }
}
