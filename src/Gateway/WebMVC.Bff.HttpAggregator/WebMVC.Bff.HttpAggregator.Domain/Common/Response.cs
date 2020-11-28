namespace WebMVC.Bff.HttpAggregator.Domain.Common
{
    public class Response<T>
    {
        public Response(T data, string msg, bool error)
        {
            Data = data;
            Message = msg;
            Error = error;
        }

        public T Data { get; set; }
        public string Message { get; set; }
        public bool Error { get; set; }
    }
}