using Messenger.Contracts.Base;

namespace Messenger.Contracts.User
{
    public class AddOrUpdateUserResponse: BaseResponse
    {
        public AddOrUpdateUserResponse() { }
        public AddOrUpdateUserResponse(ResponseCode code) : base(code) { }

        public int? Id { get; set; }
    }
}
