using AutoMapper;
using MotoPlanck.Application.Core.Users.Commands.CreateUser;
using MotoPlanck.Application.Core.Users.Contracts.Responses;
using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Application.Mappings
{
    internal sealed class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, UserResponse>();
            CreateMap<CreateUserCommand, User>()
                .ConstructUsing(c => new User(c.FirstName, c.LastName, c.Login, c.Password, c.Email, c.BirthDate, new Role(c.RoleId)))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
