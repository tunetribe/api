using tunetribe.Api.Database.Interfaces;

namespace tunetribe.Api.Configurations;

public class DatabaseConfiguration: IDatabaseConfiguration
{
    public string ConnectionString { get; set; }
    public string Schema { get; set; }
    
}