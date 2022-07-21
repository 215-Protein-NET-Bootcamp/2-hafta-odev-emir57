using _3_hafta.DataAccess.Abstract;
using _3_hafta.DataAccess.Concrete.Contexts;
using _3_hafta.Entity.Concrete;
using Core.DataAccess;
using Dapper;
using WriteParameter;

namespace _3_hafta.DataAccess.Concrete.Dapper
{
    public class DpDepartmentDal : IEntityRepository<Department>, IDepartmentDal
    {
        private readonly string _table = "Department";
        private readonly string _schema = "dbo";
        private readonly DpPatikaDbContext _context;

        public DpDepartmentDal(DpPatikaDbContext context)
        {
            _context = context;
        }

        public async Task<bool> AddAsync(Department entity)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
                    .GenerateInsertQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                int row = await con.ExecuteAsync(command, entity);
                return row > 0 ? true : false;
            }
        }

        public async Task AddRangeAsync(IEnumerable<Department> entities)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
                    .GenerateInsertQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                foreach (var entity in entities)
                {
                    await con.ExecuteAsync(command, entity);
                }
            }
        }

        public async Task<bool> DeleteAsync(Department entity)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
                    .GenerateDeleteQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                int row = await con.ExecuteAsync(command, entity);
                return row > 0 ? true : false;
            }
        }

        public async Task DeleteRangeAsync(IEnumerable<Department> entities)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
                    .GenerateDeleteQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                foreach (var entity in entities)
                {
                    await con.ExecuteAsync(command, entity);
                }
            }
        }

        public async Task<List<Department>> GetAllAsync()
        {
            using (var con = _context.CreateConnection())
            {
                string query = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
                    .GenerateGetAllQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                var result = await con.QueryAsync<Department>(query);
                return result.ToList();
            }
        }

        public async Task<Department> GetByIdAsync(int id)
        {
            using (var con = _context.CreateConnection())
            {
                string query = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
                    .GenerateGetByIdQuery(id);
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                return await con.QuerySingleOrDefaultAsync<Department>(query);
            }
        }

        public async Task<bool> UpdateAsync(Department entity)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
                    .GenerateUpdateQuery();
                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                int row = await con.ExecuteAsync(command, entity);
                return row > 0 ? true : false;
            }
        }

        public async Task UpdateRangeAsync(IEnumerable<Department> entities)
        {
            using (var con = _context.CreateConnection())
            {
                string command = new QueryGenerate<Department>()
                    .SelectSchema(_schema)
                    .SelectTable(_table)
                    .SelectIdColumn(x => x.DepartmentId)
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
