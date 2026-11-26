using System;
using System.Collections.Generic;
using System.Text;

namespace GuessNumber.core.GameSettings
{
    public interface ISettings
    {
        int Cost { get; }
        int? MaxAttempts {  get; }

    }
}
