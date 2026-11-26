using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.Validator
{
    public record ValidationResult(bool IsValid, string? Error)
    {
        public static ValidationResult Ok() => new(true, null);

        public static ValidationResult Fail(string error) => new(false, error);
    }
}
