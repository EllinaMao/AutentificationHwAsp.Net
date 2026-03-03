using Homework.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Homework.Validation
{
    public class UniqueEmailAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
            {
                return ValidationResult.Success;
            }

            var userRepo = validationContext.GetService(typeof(IUser)) as IUser;
            if (userRepo == null)
            {
                return ValidationResult.Success;
            }

            var email = value.ToString();
            var emailExists = userRepo.EmailExistsAsync(email).GetAwaiter().GetResult();

            if (emailExists)
            {
                return new ValidationResult("Этот email уже зарегистрирован.");
            }

            return ValidationResult.Success;
        }
    }
}
