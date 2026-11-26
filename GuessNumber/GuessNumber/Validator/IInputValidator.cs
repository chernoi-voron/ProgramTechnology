using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace GuessNumber.core.Validator
{
    public interface IInputValidator
    {
        ValidationResult ValidateLogin(string? login);

        ValidationResult ValidateName(string? name);

        ValidationResult ValidatePositiveNumber(int value, string fieldName);

        ValidationResult ValidateRangeGenerator( int min, int max);
    }
}
