using GraphQL.Client.Http;
using GraphQL.Client.Serializer.Newtonsoft;
using Infrastructure.Services.GitHub;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;


namespace Infrastructure;
public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddGraphQLHttpClient();

        return services;
    }

    private static IServiceCollection AddGraphQLHttpClient(this IServiceCollection services)
    {
        services.AddSingleton(sp =>
        {
            var AccessToken = Environment.GetEnvironmentVariable("GITHUB_ACCESS_TOKEN");

            var client = new GraphQLHttpClient("https://api.github.com/graphql", new NewtonsoftJsonSerializer());
            client.HttpClient.DefaultRequestHeaders.Authorization =
                new AuthenticationHeaderValue("Bearer", AccessToken);

            return client;
        });

        services.AddSingleton<GitHubGraphQLService>();

        return services;
    }
}
