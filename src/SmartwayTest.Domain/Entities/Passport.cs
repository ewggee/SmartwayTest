namespace SmartwayTest.Domain.Entities;

public class Passport : IEntity
{
    public int Id { get; set; }

    public string Type { get; set; }

    public string Number { get; set; }
}
