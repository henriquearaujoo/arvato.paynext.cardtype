namespace Arvato.Paynext.WebApi.Model;

public class ErrorResponse
{
    public string Type { get; set; }
    public string Message { get; set; }
    public string StackTrace { get; set; }
    public IDictionary<string, string[]> Details { get; set; }

    public ErrorResponse(Exception ex)
    {
        Type = ex.GetType().Name;
        Message = ex.Message;
        StackTrace = ex.ToString();
    }
}