namespace Messenger.Contracts.Base;

public class BaseResponse
{
    public string Error { get; set; }

    public ResponseCode Code { get; set; }

    public BaseResponse() { }
    public BaseResponse(ResponseCode code)
    {
        Code = code;
    }
}
