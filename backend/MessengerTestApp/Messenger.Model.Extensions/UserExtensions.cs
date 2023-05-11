using Messenger.Util;

namespace Messenger.Model.Extensions
{
    public static class UserExtensions
    {
        public static void UpdateUser(this User oldUser, User newUser)
        {
            oldUser.State = newUser.State;
            oldUser.Name = newUser.Name;
            oldUser.Password = PasswordHasher.CreateHash(newUser.Password);
        }
    }
}