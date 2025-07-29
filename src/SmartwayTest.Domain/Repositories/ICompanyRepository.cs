namespace SmartwayTest.Domain.Repositories;

public interface ICompanyRepository
{
    Task<bool> IsCompanyByIdExistsAsync(int companyId);
}