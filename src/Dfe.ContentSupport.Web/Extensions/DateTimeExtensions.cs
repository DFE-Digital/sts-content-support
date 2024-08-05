namespace Dfe.ContentSupport.Web.Extensions;

public static class DateTimeExtensions
{
    public static string ToLongString(this DateTime? dateTime)
    {
        if (dateTime is null) return string.Empty;
        return dateTime.Value.ToString("dd MMMM yyyy");
    }
}