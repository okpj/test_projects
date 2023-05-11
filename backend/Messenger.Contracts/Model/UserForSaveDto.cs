namespace Messenger.Contracts.Model
{
    public class UserForSaveDto
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Password { get; set; }

        public byte StateId { get; set; }
    }
}
