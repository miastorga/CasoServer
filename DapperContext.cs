using System.Data;
using System.Data.SqlClient;

namespace Caso;
public class DapperContext
{
  private readonly IConfiguration _configuration;
  private readonly string _connectionString;

  public DapperContext(IConfiguration configuration)
  {
    _configuration = configuration;
    _connectionString = _configuration.GetConnectionString("SqlServer");
  }

  public IDbConnection CreateConnection()
  {
    return new SqlConnection(_connectionString);
  }
}