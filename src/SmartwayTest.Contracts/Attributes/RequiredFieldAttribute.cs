using System.ComponentModel.DataAnnotations;

namespace SmartwayTest.Contracts.Attributes;

[AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
class RequiredField : RequiredAttribute
{
    public override string FormatErrorMessage(string name)
    {
        if (string.IsNullOrEmpty(ErrorMessage))
        {
            ErrorMessage = $"The {name} field is required.";
        }

        return base.FormatErrorMessage(ErrorMessage);
    }
}
