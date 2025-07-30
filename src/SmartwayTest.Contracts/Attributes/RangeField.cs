using System.ComponentModel.DataAnnotations;

namespace SmartwayTest.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
public class RangeField(double min, double max) : RangeAttribute(min, max)
{
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = $"The {name} field must be between {Minimum} and {Maximum}.";
        }

        return base.FormatErrorMessage(name);
    }
}
