using SmartwayTest.Contracts.Dapper;
using SmartwayTest.DataAccess.Scripts;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.DataAccess.Repositories;

public class DepartmentRepository : IDepartmentRepository
{
    private readonly IDapperContext _context;

    public DepartmentRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<bool> IsDepartmentByIdExistsAsync(int departmentId)
    {
        var result = await _context.ExecuteWithResult<bool>(new QueryObject(
            Sql.IsDeparmentByIdExists,
            new { id = departmentId }));

        return result;
    }
}
