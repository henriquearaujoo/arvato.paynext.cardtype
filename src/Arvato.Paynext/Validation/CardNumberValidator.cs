using System.Text.RegularExpressions;
using Arvato.Paynext.Extensions;

namespace Arvato.Paynext.Validation;

public static class CardNumberValidator
{
    public static bool IsValid(string cardNumber)
    {
        if (string.IsNullOrWhiteSpace(cardNumber))
            return false;

        string digits = cardNumber.OnlyDigits();
        
        if (!IsMatch(digits))
            return false;
        
        return IsMod10ValidNumber(digits);
    }

    private static bool IsMatch(string number)
    {
        return new Regex(@"^([\-\s]?[0-9]{4}){4}$").IsMatch(number)
               || new Regex(@"^([\-\s]?[0-9]{5}){3}$").IsMatch(number);
    }

    private static bool IsMod10ValidNumber(string number)
    {
        int checkSum = ComputeCheckSumFromRightMostDigit(number);
        
        checkSum = ComputeNotIncludedCheckSumDigits(number, checkSum);
        
        return IsMod10(checkSum);
    }

    private static int ComputeCheckSumFromRightMostDigit(string number)
    {
        int checkSum = 0;
        for (int i = number.Length - 1; i >= 0; i -= 2)
            checkSum += (number[i] - '0');
        return checkSum;
    }

    private static int ComputeNotIncludedCheckSumDigits(string number, int checkSum)
    {
        for (int i = number.Length - 2; i >= 0; i -= 2)
        {
            int val = ((number[i] - '0') * 2);
            while (val > 0)
            {
                checkSum += (val % 10);
                val /= 10;
            }
        }

        return checkSum;
    }

    private static bool IsMod10(int checkSum)
    {
        return ((checkSum % 10) == 0);
    }
    
}