namespace Invoice_Management_Api.Models
{
    public class InvoiceDetail
    {
        public int ID {  get; set; }
        [Required,MaxLength(200)]
        public string ItemName {  get; set; }
        [Required]
        public float ItemCount {  get; set; }
        [Required]
        public float ItemPrice {  get; set; }
        public virtual InvoiceHeader InvoiceHeader {  get; set; }
        [Required,ForeignKey("InvoiceHeader")]
        public int InvoiceHeaderID {  get; set; }
    }
}
