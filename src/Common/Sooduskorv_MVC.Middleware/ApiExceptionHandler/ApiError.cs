namespace Catalog.API.Middleware
{
    public class ApiError
    {
        public string Id { get; set; }
        public short Status { get; set; }
        public string StatusCode { get; set; }
        public string Links { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
    }
}