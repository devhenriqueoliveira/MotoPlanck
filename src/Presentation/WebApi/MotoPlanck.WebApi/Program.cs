using MotoPlanck.Application;
using MotoPlanck.WebApi.Extensions;
using MotoPlanck.Infrastructure.CrossCutting;
using MotoPlanck.Infrastructure.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services
    .AddEndpointsApiExplorer()
    .AddInfrastructure()
    .AddBuilderEndpoints()
    .AddSwaggerExtensions()
    .AddAuthorizationExtension()
    .AddAuthenticationExtensions()
    .AddApplication(builder.Configuration)
    .AddPersistence(builder.Configuration);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.AddEndpoints();
app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();

await app.RunAsync();