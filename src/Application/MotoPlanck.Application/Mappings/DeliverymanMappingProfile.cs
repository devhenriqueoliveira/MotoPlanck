using AutoMapper;
using MotoPlanck.Application.Core.Deliverymans.Commands.CreateDeliveryman;
using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Application.Mappings
{
    /// <summary>
    /// Represents the mapping of deliveryman objects
    /// </summary>
    internal sealed class DeliverymanMappingProfile : Profile
    {
        public DeliverymanMappingProfile()
        {
            CreateMap<CreateDeliverymanCommand, Deliveryman>();
            CreateMap<CreateDeliverymanCommand, Deliveryman>();
            CreateMap<CreateDeliverymanCommand, Deliveryman>();
        }
    }
}
