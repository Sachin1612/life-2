using data.mongo;
using Microsoft.AspNetCore.Mvc;
using models;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
  
  public readonly IMongoRepository<User> _peopleRepository;
  public UserController(IMongoRepository<User> peopleRepository)
  {
    _peopleRepository = peopleRepository;
  }
  
}