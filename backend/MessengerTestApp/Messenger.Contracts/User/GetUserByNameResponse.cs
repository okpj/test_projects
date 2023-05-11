using Messenger.Contracts.Base;
using Messenger.Contracts.Model;

namespace Messenger.Contracts.User;

public class GetUserByNameResponse: BaseResponse
{
    public GetUserByNameResponse() { }
    public GetUserByNameResponse(ResponseCode code) : base(code) { }

    public UserDto? User { get; set; }
}
