using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;

/// <summary>
/// 
/// </summary>
public record AuditLog(int NumberOfAccount, string TypeOfOperation, decimal Amount, DateTime Date);

