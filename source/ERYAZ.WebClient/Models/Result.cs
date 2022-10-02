namespace ERYAZ.WebClient.Models
{
    public class Result
    {
        public object Item { get; set; }
        public List<string> Messages { get; set; } = new List<string>();
    }
}
