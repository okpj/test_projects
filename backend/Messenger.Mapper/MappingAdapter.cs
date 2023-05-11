using Mapster;
using Messenger.Model;

namespace Messenger.Mapper
{
    public class MappingAdapter
    {
        public static void Configure()
        {
            TypeAdapterConfig<Model.User, Contracts.Model.UserDto>.NewConfig()
                .IgnoreNullValues(true)
                .Map(dest => dest.State,
                src => new Contracts.Model.StateDto { Id = (byte)src.State, Title = src.State.ToString() });


            TypeAdapterConfig<Contracts.Model.UserForSaveDto, Model.User>.NewConfig()
               .IgnoreNullValues(true)
               .Map(dest => dest.State, src => (UserState)src.StateId);
        }
    }
}