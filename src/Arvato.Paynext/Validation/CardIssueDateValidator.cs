using System.Text.RegularExpressions;
using Arvato.Paynext.Providers;

namespace Arvato.Paynext.Validation;

public class CardIssueDateValidator
{
    private readonly IDateTimeProvider _dateTimeProvider;

    public CardIssueDateValidator(IDateTimeProvider dateTimeProvider)
    {
        _dateTimeProvider = dateTimeProvider;
    }

    public bool IsValid(string issueDate)
    {
        if (!issueDate.Contains("/"))
            return false;

        var dateParts = issueDate.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        if (!IsMatch(dateParts[0], dateParts[1]))
            return false;

        return IsExpired(dateParts[0], dateParts[1]);
    }

    private bool IsMatch(string monthPart, string yearPart)
    {
        var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
        var yearCheck = new Regex(@"^20[0-9]{2}$");

        if (!monthCheck.IsMatch(monthPart) 
            || !yearCheck.IsMatch(yearPart))
            return false;

        return true;
    }

    private bool IsExpired(string monthPart, string yearPart)
    {
        var month = int.Parse(monthPart);
        var year = int.Parse(yearPart);
        var lastDateOfExpiryMonth = GetLastDateExpiryMonth(year, month);
        var cardExpiry = GetCardDateExpiry(year, month, lastDateOfExpiryMonth);

        return cardExpiry > _dateTimeProvider.Now
               && cardExpiry < _dateTimeProvider.Now.AddYears(6);
    }

    private DateTime GetCardDateExpiry(int year, int month, int lastDateOfExpiryMonth)
    {
        return new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);
    }

    private int GetLastDateExpiryMonth(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }
}