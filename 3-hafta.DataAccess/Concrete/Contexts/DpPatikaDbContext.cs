using Microsoft.Extensions.Configuration;
using Npgsql;
using System.Data;

namespace _3_hafta.DataAccess.Concrete.Contexts
{
    public class DpPatikaDbContext
    {
        private readonly IConfiguration _configuration;
        public DpPatikaDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public IDbConnection CreateConnection()
        {
            return new NpgsqlConnection(_configuration.GetConnectionString("PostgreSqlConnection"));
        }
    }
}
