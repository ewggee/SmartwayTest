namespace SmartwayTest.Domain.Entities;

public class Department : IEntity
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Phone { get; set; }

    public int CompanyId { get; set; }
}
