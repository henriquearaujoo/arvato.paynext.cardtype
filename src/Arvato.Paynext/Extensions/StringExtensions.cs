using System.Text;

namespace Arvato.Paynext.Extensions;

public static class StringExtensions
{
    public static string OnlyDigits(this string value)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in value)
        {
            if (Char.IsDigit(c))
                sb.Append(c);
        }

        return sb.ToString();
    }
}