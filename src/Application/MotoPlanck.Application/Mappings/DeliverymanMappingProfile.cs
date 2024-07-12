using AutoMapper;
using MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman;
using MotoPlanck.Application.Extensions;
using MotoPlanck.Domain.Core.Entities;
using MotoPlanck.Domain.Core.Enums;

namespace MotoPlanck.Application.Mappings
{
    /// <summary>
    /// Represents the mapping of deliveryman objects
    /// </summary>
    internal sealed class DeliverymanMappingProfile : Profile
    {
        public DeliverymanMappingProfile()
        {
            CreateMap<CreateDeliverymanCommand, Deliveryman>()
                .ConstructUsing(c => new Deliveryman(c.Cnpj, c.Cnh, c.TypeCnh.ToEnum<ECnhType>(true), c.PictureCnhId.ToBase64(), c.UserId));
        }
    }
}
