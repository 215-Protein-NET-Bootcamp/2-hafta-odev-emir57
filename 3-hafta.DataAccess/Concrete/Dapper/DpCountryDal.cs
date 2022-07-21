using _3_hafta.DataAccess.Abstract;
using _3_hafta.DataAccess.Concrete.Contexts;
using _3_hafta.Entity.Concrete;
using Core.DataAccess;
using Dapper;
using WriteParameter;

namespace _3_hafta.DataAccess.Concrete.Dapper
{
    public class DpCountryDal : IEntityRepository<Country>, ICountryDal
    {
        private readonly string _table = "country";
        private readonly string _schema = "dbo";
        private readonly DpPatikaDbContext _context;
        public DpCountryDal(DpPatikaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Country entity)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateInsertQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                int row = await con.ExecuteAsync(command, entity);
                return row > 0 ? true : false;
            }
        }

        public async Task AddRangeAsync(IEnumerable<Country> entities)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateInsertQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                foreach (var entity in entities)
                {
                    await con.ExecuteAsync(command, entity);
                }
            }
        }

        public async Task<bool> DeleteAsync(Country entity)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateDeleteQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                int row = await con.ExecuteAsync(command, entity);
                return row > 0 ? true : false;
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<Country> entities)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateDeleteQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                foreach (var entity in entities)
                {
                    await con.ExecuteAsync(command, entity);
                }
            }
        }

        public async Task<List<Country>> GetAllAsync()
        {
            using (var con = _context.CreateConnection())
            {
                string query = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateGetAllQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                var result = await con.QueryAsync<Country>(query);
                return result.ToList();
            }
        }

        public async Task<Country> GetByIdAsync(int id)
        {
            using (var con = _context.CreateConnection())
            {
                string query = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateGetByIdQuery(id);
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                return await con.QuerySingleOrDefaultAsync<Country>(query);
            }
        }

        public async Task<bool> UpdateAsync(Country entity)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateUpdateQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                int row = await con.ExecuteAsync(command, entity);
                return row > 0 ? true : false;
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<Country> entities)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Country>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.CountryId)
                    .GenerateUpdateQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                foreach (var entity in entities)
                {
                    await con.ExecuteAsync(command, entity);
                }
            }
        }
    }
}
