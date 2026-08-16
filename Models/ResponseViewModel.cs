namespace CanteenManagement_2._0.Models
{
    public class ResponseViewModel<T>
    {
        public string Message { get; set; } = "";
        public bool Success { get; set; }=false;
        public T Data { get; set; }
    }
}
