using SmartwayTest.Domain.Entities;

namespace SmartwayTest.Domain.Repositories;

public interface IPassportRepository
{
    Task<bool> IsPassportExistsAsync(Passport passport);
    Task<int> AddPassportAsync(Passport passport);
    Task UpdatePassportAsync(Passport passport);
}