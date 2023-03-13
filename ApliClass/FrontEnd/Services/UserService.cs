using FrontEnd.Models;

namespace FrontEnd.Services;

public class UserService : GenericServices<UserViewModel>
{
    public UserService(ILogger<UserService> logger, IConfiguration configuration)
        : base(configuration.GetSection("BackendURLs")["ShipperPath"], logger)
    {
    }
}