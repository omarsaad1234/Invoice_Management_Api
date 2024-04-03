namespace Invoice_Management_Api.Dtos
{
    public class InvDetailsDto
    {
        public string ItemName { get; set; }
        public float ItemCount { get; set; }
        public float ItemPrice { get; set; }
        public float SubTotal { get; set; }
    }
}
