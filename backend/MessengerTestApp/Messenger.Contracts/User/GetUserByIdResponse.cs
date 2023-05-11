using Messenger.Contracts.Base;
using Messenger.Contracts.Model;

namespace Messenger.Contracts.User
{
    public class GetUserByIdResponse : BaseResponse
    {
        public GetUserByIdResponse() { }
        public GetUserByIdResponse(ResponseCode code) : base(code) { }

        public UserDto? User { get; set; }


    }
}
