using SmartwayTest.Domain.Exceptions.Common;

namespace SmartwayTest.Domain.Exceptions.Passport;

public class PassportNotFoundException : EntityNotFoundException
{
    public PassportNotFoundException(int id) : base(nameof(Entities.Passport), id)
    { }

    public PassportNotFoundException() : base(nameof(Entities.Passport))
    { }
}
