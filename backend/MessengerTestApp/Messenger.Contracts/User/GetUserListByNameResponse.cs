using Messenger.Contracts.Base;
using Messenger.Contracts.Model;

namespace Messenger.Contracts.User
{
    public class GetUserListByNameResponse : BaseResponse
    {
        public GetUserListByNameResponse() { }
        public GetUserListByNameResponse(ResponseCode code) : base(code) { }

        public IEnumerable<UserDto> Users { get; set; }
    }
}
