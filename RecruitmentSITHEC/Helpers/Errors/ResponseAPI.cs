namespace RecruitmentSITHEC.Helpers.Errors;

public class ResponseAPI
{
    public int StatusCode { get; set; }
    public bool Ok { get; set; }
    public string Message { get; set; }


    //constructor
    public ResponseAPI(int statusCode, string message = null, bool BanderaOk = false)
    {
        StatusCode = statusCode;
        Ok = BanderaOk;
        Message = message ?? GetDefaultMessage(statusCode);
    }

    private string GetDefaultMessage(int statusCode)
    {
        return statusCode switch
        {
            400 => "You have made an incorrect request.",
            401 => "Unauthorized user",
            404 => "The resource you have tried to request does not exist.",
            405 => "This HTTP method is not allowed on the server.",
            500 => "Server error. It's not you, it's me. Contact the systems area.",
            _ => "Unidentified"
        };
    }
}
