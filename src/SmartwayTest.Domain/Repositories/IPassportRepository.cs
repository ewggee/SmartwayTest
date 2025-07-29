namespace SmartwayTest.Domain.Repositories;

public interface IPassportRepository
{
    Task<bool> IsPassportByIdExistsAsync(int passportId);
}