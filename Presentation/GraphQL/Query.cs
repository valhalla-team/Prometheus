namespace Presentation.GraphQL;

public class Query
{
    public UserViewer GetUser() =>
        new UserViewer
        {
            Login = "bmsant",
            ProfileOwner = new ProfileOwner
            {
                Name = "Bruno Santos"
            }
        };
}
public class UserViewer
{
    public string Login { get; set; }
    public ProfileOwner ProfileOwner { get; set; }
}

public class ProfileOwner
{
    public string Name { get; set; }
}
