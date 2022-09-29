namespace Arvato.Paynext.Providers;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime Now { get; set; } = DateTime.Now;
}