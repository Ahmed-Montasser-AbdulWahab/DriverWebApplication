using System.ComponentModel.DataAnnotations;

namespace DriverWebApplication.CustomValidators
{
    public class CheckAgeValidatorAttribute : ValidationAttribute
    {
        private readonly int _age ;

        private const string _defaultMessage = "{0} should be before than {2} to be at least {1} years old.";

        public CheckAgeValidatorAttribute(int age)
        {
            _age = age;
        }

        

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if(value == null)
            {
                return null;
            }

            DateTime date_of_birth = Convert.ToDateTime(value);

            var years = (DateTime.Now - date_of_birth).TotalDays / 365;

            if(years < _age)
            {
                return new ValidationResult(string.Format(ErrorMessage ?? _defaultMessage, validationContext.DisplayName,
                    _age, DateTime.Now.Subtract(TimeSpan.FromDays(_age*365))));
            }

            return ValidationResult.Success;

        }
    }
}
