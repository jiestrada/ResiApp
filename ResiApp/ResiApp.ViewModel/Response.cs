namespace ResiApp.ViewModel
{
    public class Response<T>
    {
        public bool Success { get; set; }
        public string Message { get; set; } = "";
        public string Url { get; set; }
        public T? Data { get; set; }
        
        public Response(bool success, string message, T? data = default, string url="")
        {
            Success = success;
            Message = message;
            Data = data;
            Url = url;
        }
    }
}
