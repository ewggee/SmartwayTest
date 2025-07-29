
namespace SmartwayTest.DataAccess.Repositories;

public interface ICompanyRepository
{
    Task<bool> IsCompanyByIdExistsAsync(int companyId);
}