using Messenger.Contracts.Base;
using Messenger.Contracts.Model;

namespace Messenger.Contracts.User
{
    public class AddOrUpdateUserRequest : BaseRequest
    {
        public UserForSaveDto User { get; set; }
    }
}
