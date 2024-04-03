namespace Invoice_Management_Api.Models
{
    public class Cashier
    {
        public int ID {  get; set; }
        [Required]
        public string CashierName { get; set; }
        public virtual Branch Branch {  get; set; }
        [Required,ForeignKey("Branch")]
        public int BranchID {  get; set; }
        [JsonIgnore]
        public List<InvoiceHeader> InvoiceHeaders {  get; set; }

    }
}
