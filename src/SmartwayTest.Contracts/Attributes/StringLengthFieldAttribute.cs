using System.ComponentModel.DataAnnotations;

namespace SmartwayTest.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class StringLengthFieldAttribute : LengthAttribute
{
    public StringLengthFieldAttribute(int min, int max) : base(min, max)
    { }

    public StringLengthFieldAttribute(int length) : base(length, length)
    { }

    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            if (MinimumLength == MaximumLength)
                ErrorMessage = $"The {name} field must be exactly {MaximumLength} characters long.";
            else
                ErrorMessage = $"The {name} field must be between {MinimumLength} and {MaximumLength} characters long.";

        }

        return base.FormatErrorMessage(name);
    }
}
