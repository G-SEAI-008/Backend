namespace DependencyInjection.Services;

class PostService
{
    private readonly IUserService _userService;

    public PostService(IUserService userService)
    {
        _userService = userService;
    }
}