namespace ERYAZ.WebClient.Models.User
{
    public class LogOnModel
    {
        public string User { get; set; }
        public string Pass { get; set; }
        public List<string> ErrorMessage { get; set; }

        public LogOnModel()
        {
            ErrorMessage = new List<string>();
        }
    }
}
