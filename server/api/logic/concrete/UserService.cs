
using models;
using services.interfaces;

namespace services.concretes;

public class UserService : IUserService
{

    public Task<IEnumerable<User>> GetUsers()
    {
        throw new NotImplementedException();
    }

}