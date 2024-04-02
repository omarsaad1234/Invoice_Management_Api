using System.Text.Json.Serialization;

namespace Invoice_Management_Api.Models
{
    public class Branch
    {
        public int ID {  get; set; }
        [Required]
        public string BranchName {  get; set; }
        public virtual City? City {  get; set; }

        [Required,ForeignKey("City")]
        public int CityID {  get; set; }
        public List<Cashier> Cashiers { get; set; }
        public List<InvoiceHeader> InvoiceHeaders {  get; set; }
    }
}
