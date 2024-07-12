using AutoMapper;
using MotoPlanck.Application.Core.Plans.Commands.CreatePlan;
using MotoPlanck.Application.Core.Plans.Commands.UpdatePlan;
using MotoPlanck.Application.Core.Plans.Contracts.Responses;
using MotoPlanck.Domain.Core.Entities;

namespace MotoPlanck.Application.Mappings
{
    /// <summary>
    /// Represents the mapper of plan objects.
    /// </summary>
    internal sealed class PlanMappingProfile : Profile
    {
        public PlanMappingProfile()
        {
            CreateMap<CreatePlanCommand, Plan>()
                .ConstructUsing(c => new Plan(c.Day, c.Amount, c.RatePercentage))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<UpdatePlanCommand, Plan>()
                .ConstructUsing(c => new Plan(c.Id, c.Day, c.Amount, c.RatePercentage))
                .IgnoreAllPropertiesWithAnInaccessibleSetter();

            CreateMap<Plan, PlanResponse>()
                .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
    }
}
