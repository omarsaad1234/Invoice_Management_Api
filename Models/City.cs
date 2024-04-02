namespace Invoice_Management_Api.Models
{
    public class City
    {
        
        public int ID {  get; set; }
        [Required]
        public string CityName {  get; set; }
        public List<Branch> Branches {  get; set; }

    }
}
