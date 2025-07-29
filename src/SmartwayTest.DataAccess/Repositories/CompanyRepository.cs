using SmartwayTest.Contracts.Dapper;
using SmartwayTest.DataAccess.Scripts;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.DataAccess.Repositories;

public class CompanyRepository : ICompanyRepository
{
    private readonly IDapperContext _context;

    public CompanyRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<bool> IsCompanyByIdExistsAsync(int companyId)
    {
        var result = await _context.ExecuteWithResult<bool>(new QueryObject(
            Sql.IsCompanyByIdExists,
            new { id = companyId }));

        return result;
    }
}
