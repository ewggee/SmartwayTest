namespace SmartwayTest.DataAccess.Repositories;

public interface IPassportRepository
{
    Task<bool> IsPassportByIdExistsAsync(int passportId);
}