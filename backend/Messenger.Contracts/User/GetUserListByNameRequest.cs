using Messenger.Contracts.Base;

namespace Messenger.Contracts.User;

public class GetUserListByNameRequest : BaseRequest
{
    public string Name { get; set; }
}
