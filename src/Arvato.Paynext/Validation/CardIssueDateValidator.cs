using System.Text.RegularExpressions;

namespace Arvato.Paynext.Validation;

public static class CardIssueDateValidator
{
    public static bool IsValid(string issueDate)
    {
        if (!issueDate.Contains("/"))
            return false;

        var dateParts = issueDate.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
        if (!IsMatch(dateParts[0], dateParts[1]))
            return false;

        return IsExpired(dateParts[0], dateParts[1]);
    }

    private static bool IsMatch(string monthPart, string yearPart)
    {
        var monthCheck = new Regex(@"^(0[1-9]|1[0-2])$");
        var yearCheck = new Regex(@"^20[0-9]{2}$");

        if (!monthCheck.IsMatch(monthPart) 
            || !yearCheck.IsMatch(yearPart))
            return false;

        return true;
    }

    private static bool IsExpired(string monthPart, string yearPart)
    {
        var month = int.Parse(monthPart);
        var year = int.Parse(yearPart);
        var lastDateOfExpiryMonth = GetLastDateExpiryMonth(year, month);
        var cardExpiry = GetCardDateExpiry(year, month, lastDateOfExpiryMonth);

        return cardExpiry > DateTime.Now 
               && cardExpiry < DateTime.Now.AddYears(6);
    }

    private static DateTime GetCardDateExpiry(int year, int month, int lastDateOfExpiryMonth)
    {
        return new DateTime(year, month, lastDateOfExpiryMonth, 23, 59, 59);
    }

    private static int GetLastDateExpiryMonth(int year, int month)
    {
        return DateTime.DaysInMonth(year, month);
    }
}