using Infrastructure.Services.GitHub;

namespace Presentation.GraphQL;

public class Query(GitHubGraphQLService gitHubGraphQLService)
{
    private readonly GitHubGraphQLService _gitHubGraphQLService = gitHubGraphQLService;

    public async Task<User> GetUser(int avatarSize = 152)
    {
        string query = $@"
            query {{
              user(login: ""bmsant"") {{
                avatarUrl(size: {avatarSize})
                bio
                email
                name
              }}
            }}";

        var result = await _gitHubGraphQLService.QueryGitHubAsync<dynamic>(query);
        return new User
        {
            AvatarUrl = result.user.avatarUrl,
            Bio = result.user.bio,
            Email = result.user.email,
            Name = result.user.name,
        };
    }
}
