using GraphQL;
using GraphQL.Client.Http;

namespace Infrastructure.Services.GitHub;

public class GitHubGraphQLService(GraphQLHttpClient client)
{
    private readonly GraphQLHttpClient _client = client;

    public async Task<TResponse> QueryGitHubAsync<TResponse>(string query, object? variables = null)
    {
        var request = new GraphQLRequest
        {
            Query = query,
            Variables = variables
        };
        var response = await _client.SendQueryAsync<TResponse>(request);

        return response.Data;
    }
}
