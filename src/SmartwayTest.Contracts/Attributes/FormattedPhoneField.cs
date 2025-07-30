using System.ComponentModel.DataAnnotations;

namespace SmartwayTest.Contracts.Attributes;

public class FormattedPhoneField() : RegularExpressionAttribute(@"^\+7\s\(\d{3}\)\s\d{3}\s\d{2}-\d{2}$")
{
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = $"The {name} field must be in the format: +7 (XXX) XXX XX-XX";
        }

        return base.FormatErrorMessage(name);
    }
}
