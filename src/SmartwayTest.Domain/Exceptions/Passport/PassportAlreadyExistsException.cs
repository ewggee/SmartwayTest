namespace SmartwayTest.Domain.Exceptions.Passport;

public class PassportAlreadyExistsException(string number) : Exception($"Passport with number {number} already exists.");