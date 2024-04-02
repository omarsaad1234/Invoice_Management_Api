namespace Invoice_Management_Api.Models
{
    public class InvoiceHeader
    {
        public int ID { get; set; }
        [Required]
        public string CustomerName {  get; set; }
        [Required,DataType(DataType.DateTime)]
        public DateTime InvoiceDate {  get; set; }
        public virtual Cashier Cashier {  get; set; }
        public virtual Branch Branch {  get; set; }
        [Required,ForeignKey("Cashier")]
        public int CashierID {  get; set; }
        [Required,ForeignKey("Branch")]
        public int BranchID {  get; set; }
        public List<InvoiceDetail> InvoiceDetails {  get; set; }
    }
}
