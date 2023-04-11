using data.interfaces;

namespace data.concrete;

public class MongoDbConfig : IDatabaseConfig
{
  public string ConnectionString { get; set; } = null!;

  public string DatabaseName { get; set; } = null!;
}