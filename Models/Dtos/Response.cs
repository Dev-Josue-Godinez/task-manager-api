using System.Net;

namespace Models.Dtos
{
    public class Response<T>
    {
        public T? Data { get; set; }
        public required HttpStatus Status { get; set; }
        
    }

    public class HttpStatus
    {
        public HttpStatusCode StatusCode { get; set; }
        public string? StatusMessage { get; set; }
    }
}
