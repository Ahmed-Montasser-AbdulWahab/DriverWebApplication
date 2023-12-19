using DriverWebApplication.Models;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace DriverWebApplication.CustomValidators
{
    public class NumberPlatesAttribute : ValidationAttribute
    {
        private readonly string _otherFieldName;
        public NumberPlatesAttribute(string otherFieldName) {
            _otherFieldName = otherFieldName;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            string? newStyle = Convert.ToString(value);

            PropertyInfo? oldStyleProperty = validationContext.ObjectType.GetProperty(_otherFieldName);
            if(oldStyleProperty == null) { return null; }
            string? oldStyle = oldStyleProperty?.GetValue(validationContext.ObjectInstance)?.ToString();


            if(string.IsNullOrEmpty(oldStyle) && string.IsNullOrEmpty(newStyle)) {

                return new ValidationResult(
                    ErrorMessage ?? "Please Enter NumberPlates in either old-Style or new-Style",
                    new string[] {nameof(oldStyle), validationContext.MemberName!}
                    );
            }
            else if (!(string.IsNullOrEmpty(oldStyle) || string.IsNullOrEmpty(newStyle)))
            {
                return new ValidationResult(
                    ErrorMessage ?? "Enter in either new style or old style fields",
                    new string[] { nameof(oldStyleProperty), validationContext.MemberName! }
                    );
            }
            return ValidationResult.Success;

        }
    }
}
