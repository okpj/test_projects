using Messenger.Contracts.Base;

namespace Messenger.Contracts.User;

public class GetUserByIdRequest : BaseRequest
{
    public int Id { get; set; }
}
