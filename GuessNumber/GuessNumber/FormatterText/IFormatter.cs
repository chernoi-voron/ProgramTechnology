using GuessNumber.core.Stats;
using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace GuessNumber.core.FormatterText
{
    public interface IFormatter
    {
        string Format(IEnumerable<GlobalStatistics> globalstats);
    }
}
