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
                    location
                  }}
                }}";

        var result = await _gitHubGraphQLService.QueryGitHubAsync<dynamic>(query);
        return new User
        {
            AvatarUrl = result.user.avatarUrl,
            Bio = result.user.bio,
            Email = result.user.email,
            Name = result.user.name,
            Location = result.user.location
        };
    }

    public async Task<List<Organization>> GetOrganizations(int first = 10, int avatarSize = 152)
    {
        string query = $@"
                query {{
                  user(login: ""bmsant"") {{
                    organizations(first: {first}) {{
                      nodes {{
                        avatarUrl(size: {avatarSize})
                        name
                      }}
                    }}
                  }}
                }}";

        var result = await _gitHubGraphQLService.QueryGitHubAsync<dynamic>(query);
        var organizations = new List<Organization>();

        foreach (var org in result.user.organizations.nodes)
        {
            organizations.Add(new Organization
            {
                AvatarUrl = org.avatarUrl,
                Name = org.name
            });
        }

        return organizations;
    }

    public async Task<List<Follower>> GetFollowers(int first = 10, int avatarSize = 152)
    {
        string query = $@"
                query {{
                  user(login: ""bmsant"") {{
                    followers(first: {first}) {{
                      nodes {{
                        avatarUrl(size: {avatarSize})
                        name
                      }}
                    }}
                  }}
                }}";

        var result = await _gitHubGraphQLService.QueryGitHubAsync<dynamic>(query);
        var followers = new List<Follower>();

        foreach (var follower in result.user.followers.nodes)
        {
            followers.Add(new Follower
            {
                AvatarUrl = follower.avatarUrl,
                Name = follower.name
            });
        }

        return followers;
    }
}
