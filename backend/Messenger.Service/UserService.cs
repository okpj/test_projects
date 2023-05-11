using Messenger.Repository.Interfaces;
using Messenger.Contracts.User;
using Messenger.Service.Interfaces;
using Mapster;
using Messenger.Contracts.Model;

namespace Messenger.Service;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }


    public async Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest request)
    {
        var user = await _userRepository.GetUserByIdAsync(request.Id);
        if (user is not null)
        {
            return new GetUserByIdResponse(Contracts.Base.ResponseCode.OK)
            {
                User = user.Adapt<UserDto>()
            };
        }
        return new GetUserByIdResponse(Contracts.Base.ResponseCode.NotFound);


    }

    public async Task<GetUserByNameResponse> GetUserByName(GetUserByNameRequest request)
    {
        var user = await _userRepository.GetUserByNameAsync(request.Name);
        if (user is not null)
        {
            return new GetUserByNameResponse(Contracts.Base.ResponseCode.OK)
            {
                User = user.Adapt<UserDto>(),
            };
        }
        return new GetUserByNameResponse(Contracts.Base.ResponseCode.NotFound);
    }

    public async Task<GetUserListByNameResponse> GetUsersByName(GetUserListByNameRequest request)
    {
        var users = await _userRepository.GetUsersByNameAsync(request.Name);
        return new GetUserListByNameResponse(Contracts.Base.ResponseCode.OK)
        {
            Users = users.Adapt<List<UserDto>>()
        };
    }

    public async Task<AddOrUpdateUserResponse> CreateUserAsync(AddOrUpdateUserRequest request)
    {
        Model.User? dbUser;
        var user = request.User.Adapt<Model.User>();
        if (request.User.Id is null)
        {
            dbUser = await _userRepository.TryCreateAsync(user);
            if (dbUser is not null)
            {
                return new AddOrUpdateUserResponse(Contracts.Base.ResponseCode.OK) { Id = user.Id };
            }
        }

        dbUser = await _userRepository.GetUserByIdAsync(request.User.Id!.Value);
        request.User.Adapt(dbUser);
        var updateResult = await _userRepository.TryUpdateAsync(user);
        return new AddOrUpdateUserResponse(updateResult ? Contracts.Base.ResponseCode.OK
            : Contracts.Base.ResponseCode.Error)
        {
            Id = dbUser?.Id
        };
    }
}