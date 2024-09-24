namespace KavsarApi.DTOs;
public class Response<T>
{
    public int StatusCode { get; set; }
    public List<string> Errors { get; set; } = new();
    public T? Data { get; set; }
    public Response(T data)
    {
        StatusCode = (int)HttpStatusCode.OK;
        Data = data;
    }
    public Response(HttpStatusCode code,string message)
    {
        Errors.Add(message);
        StatusCode = (int)code;
    }
    public Response(HttpStatusCode code,List<string> errors)
    {
        Errors = errors;
        StatusCode = (int)code;
    }
}