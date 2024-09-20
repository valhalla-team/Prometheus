using Infrastructure;
using Presentation.GraphQL;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructureServices();

builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGraphQL();

app.Run();
