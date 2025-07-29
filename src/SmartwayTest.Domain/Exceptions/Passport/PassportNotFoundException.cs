namespace SmartwayTest.Domain.Exceptions.Passport;

public class PassportNotFoundException(int id) : EntityNotFoundException(nameof(Entities.Passport), id)
{ }
