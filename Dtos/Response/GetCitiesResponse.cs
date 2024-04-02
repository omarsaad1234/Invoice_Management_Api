namespace Invoice_Management_Api.Dtos.Response
{
    public class GetCitiesResponse
    {
        public string CityName { get; set; }
        public List<string> Branches {  get; set; }
    }
}
