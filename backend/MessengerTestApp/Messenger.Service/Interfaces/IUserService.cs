using Messenger.Contracts.User;

namespace Messenger.Service.Interfaces;

/// <summary>
/// Сервис для выполнения операция над пользователем
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Получить пользователя по id
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<GetUserByIdResponse> GetUserById(GetUserByIdRequest request);

    /// <summary>
    /// Получить пользователя по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<GetUserByNameResponse> GetUserByName(GetUserByNameRequest request);

    /// <summary>
    /// Поиск пользователей по имени
    /// </summary>
    /// <param name="name"></param>
    /// <returns></returns>
    Task<GetUserListByNameResponse> GetUsersByName(GetUserListByNameRequest request);

    /// <summary>
    /// Сохранить пользователя
    /// </summary>
    /// <param name="newUser"></param>
    /// <returns></returns>
    Task<AddOrUpdateUserResponse> CreateUserAsync(AddOrUpdateUserRequest request);
}
