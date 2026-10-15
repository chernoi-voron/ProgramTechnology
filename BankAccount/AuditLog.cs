using System;
using System.Collections.Generic;
using System.Text;

namespace Bank;

/// <summary>
/// Класс логов содержащий номер аккаунта, тип опперации, количество и дату
/// </summary>
public record AuditLog(int NumberOfAccount, string TypeOfOperation, decimal Amount, DateTime Date);

