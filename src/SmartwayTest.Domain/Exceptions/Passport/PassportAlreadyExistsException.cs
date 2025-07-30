using SmartwayTest.Domain.Exceptions.Common;

namespace SmartwayTest.Domain.Exceptions.Passport;

public class PassportAlreadyExistsException() : EntityAlreadyExistsException(nameof(Entities.Passport));