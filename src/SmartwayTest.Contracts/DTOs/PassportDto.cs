using SmartwayTest.Contracts.Attributes;

namespace SmartwayTest.Contracts.DTOs;

public class PassportDto
{
    [StringLengthField(length: 4)]
    public string Type { get; set; }

    [StringLengthField(length: 6)]
    public string Number { get; set; }
}
