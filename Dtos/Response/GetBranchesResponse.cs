namespace Invoice_Management_Api.Dtos.Response
{
    public class GetBranchesResponse
    {
        public string BranchName {  get; set; }
        public string City { get; set; }
        public List<string> Cashiers {  get; set; }
    }
}
