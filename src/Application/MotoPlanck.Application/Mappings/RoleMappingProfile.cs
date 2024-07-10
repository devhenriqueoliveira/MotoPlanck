using AutoMapper;
using MotoPlanck.Application.Core.Roles.Commands.CreateRole;
using MotoPlanck.Application.Core.Roles.Commands.UpdateRole;
using MotoPlanck.Application.Core.Roles.Contracts.Responses;
using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Application.Mappings
{
    internal sealed class RoleMappingProfile : Profile
    {
        public RoleMappingProfile()
        {
            CreateMap<Role, RoleResponse>();

            CreateMap<CreateRoleCommand, Role>()
                .ConstructUsing(c => new Role(c.Name, c.Description, c.Active))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<UpdateRoleCommand, Role>()
                .ConstructUsing(c => new Role(c.Id, c.Name, c.Description, c.Active))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
