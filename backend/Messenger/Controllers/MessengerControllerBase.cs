namespace Messenger.Controllers;

public class MessengerControllerBase : ControllerBase
{
    protected IActionResult CreateResponse<TResponse>(TResponse response) where TResponse : BaseResponse 
    {
        return response.Code switch
        {
            ResponseCode.OK => Ok(response),
            ResponseCode.NotFound => NotFound(response),
            ResponseCode.Error => BadRequest(response),
            _ => Ok(response)
        };
    }
}
