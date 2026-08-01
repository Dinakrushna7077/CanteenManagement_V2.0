namespace CanteenManagement_2._0.Models
{
    public class LoginResult
    {
        public User? user { get; set; } = null;
        public string Message { get; set; } = "";
        public bool Success {  get; set; }=false;
    }
}
