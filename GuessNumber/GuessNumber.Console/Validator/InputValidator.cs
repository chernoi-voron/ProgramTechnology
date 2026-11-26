using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Validator
{
    public class InputValidator : IInputValidator
    {
        public const int LoginMinLength = 3;
        public const int LoginMaxLength = 20;
        public const int NameMinLength = 2;
        public const int NameMaxLength = 20;

        public ValidationResult ValidateLogin(string? login)
        {
            if (string.IsNullOrWhiteSpace(login))
            {
                return ValidationResult.Fail("Login must not be empty");
            }
            if (login.Length < LoginMinLength || login.Length > LoginMaxLength)
            {
                return ValidationResult.Fail($"Login must be {LoginMinLength}-{LoginMaxLength} characters long");
            }
            foreach (var c in login)
            {
                if (c == ',')
                {
                    return ValidationResult.Fail("Login must contain only letters");
                }
            }
            return ValidationResult.Ok();
        }

        public ValidationResult ValidateName(string? name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return ValidationResult.Fail("Name must not be empty");
            }
            if (name.Length < NameMinLength || name.Length > NameMaxLength)
            {
                return ValidationResult.Fail($"Name must be {NameMinLength}-{NameMaxLength} characters long");
            }
            foreach (var c in name)
            {
                if (c == ',')
                {
                    return ValidationResult.Fail("Name must contain only letters");
                }
            }
            return ValidationResult.Ok();
        }

        public ValidationResult ValidatePositiveNumber(int value, string fieldName)
        {
            if (value <= 0)
            {
                return ValidationResult.Fail($"{fieldName} must be positive");
            }
            return ValidationResult.Ok();
        }
        public ValidationResult ValidateRangeGenerator(int min, int max)
        {
            if (min >= max)
            {
                return ValidationResult.Fail($"Min must be less than Max");
            }
            return ValidationResult.Ok();
        }
    }
}
