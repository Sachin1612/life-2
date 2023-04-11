using models;

namespace services.interfaces;

public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
}
