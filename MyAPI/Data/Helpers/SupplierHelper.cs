namespace MyAPI.Data.Helpers
{
    public static class SupplierHelper
    {
        public static string? GetCategoryPart(string category, int index)
        {
            if (string.IsNullOrWhiteSpace(category)) return null;
            var parts = category.Split('|').Select(c => c.Trim()).ToArray();
            return parts.Length > index ? parts[index] : null;
        }
    }
}
