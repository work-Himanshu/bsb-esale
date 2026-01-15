namespace BSBESales.DTOs;

public class ApiErrorResponse
{
    public int StatusCode { get; set; }
    public string Message { get; set; }
    public string ErrorType { get; set; }
    public string TraceId { get; set; }
}
