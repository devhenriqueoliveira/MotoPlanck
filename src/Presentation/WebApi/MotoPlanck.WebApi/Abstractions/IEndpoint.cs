﻿namespace MotoPlanck.WebApi.Abstractions
{
    public interface IEndpoint
    {
        void MapEndpoint(IEndpointRouteBuilder app);
    }
}
