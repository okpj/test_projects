using Messenger.Contracts.Base;

namespace Messenger.Contracts.User;

public class GetUserByNameRequest : BaseRequest
{
    public string Name { get; set; }
}
