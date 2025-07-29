using SmartwayTest.Contracts.Dapper;
using SmartwayTest.DataAccess.Scripts;
using SmartwayTest.Domain.Entities;
using SmartwayTest.Domain.Repositories;

namespace SmartwayTest.DataAccess.Repositories;

public class PassportRepository : IPassportRepository
{
    private readonly IDapperContext _context;

    public PassportRepository(IDapperContext context)
    {
        _context = context;
    }

    public async Task<bool> IsPassportExistsAsync(Passport passport)
    {
        var result = await _context.ExecuteWithResult<bool>(new QueryObject(
            Sql.IsPassportExists,
            new { type = passport.Type, number = passport.Number }));

        return result;
    }

    public async Task<int> AddPassportAsync(Passport passport)
    {
        var id = await _context.ExecuteWithResult<int>(new QueryObject(
            Sql.CreatePassport,
            new { type = passport.Type, number = passport.Number }));

        return id;
    }

    public async Task UpdatePassportAsync(Passport passport)
    {
        await _context.ExecuteWithResult<int>(new QueryObject(
            Sql.UpdatePassport,
            new { type = passport.Type, number = passport.Number, id = passport.Id }));
    }
}
