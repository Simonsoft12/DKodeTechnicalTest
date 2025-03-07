namespace MyAPI.Data.Helpers
{
    public static class StringHelper
    {
        public static bool IsDispatchedWithin24Hours(string shipping)
        {
            if (!string.IsNullOrEmpty(shipping))
            {
                if (shipping.Contains("24h"))// Records such as '24h' and 'Wysylka w 24h'
                {
                    return true;
                }
            }

            return false;
        }


        public static decimal? ParseNullableDecimal(string value)
        {
            value = value.Replace(",", ".");

            return decimal.TryParse(value, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out decimal result)
                ? result
                : null;
        }
    }
}
