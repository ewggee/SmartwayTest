using SmartwayTest.Contracts.Dapper;
using SmartwayTest.DataAccess.Scripts;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.DataAccess.Repositories;

public class PassportRepository : IPassportRepository
{
    private readonly IDapperContext _context;

    public PassportRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<bool> IsPassportByIdExistsAsync(int passportId)
    {
        var result = await _context.ExecuteWithResult<bool>(new QueryObject(
            Sql.IsPassportByIdExists,
            new { id = passportId }));

        return result;
    }
}
