namespace MotoPlanck.Domain.Core.Enums
{
    public static class EnumExtensions
    {
        public static T ToEnum<T>(this string value, bool ignoreCase = true) where T : struct
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new ArgumentException("Value cannot be null or empty.", nameof(value));
            }

            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("T must be an enumerated type");
            }

            if (Enum.TryParse(value, ignoreCase, out T result))
            {
                return result;
            }
            else
            {
                throw new ArgumentException($"Unable to convert '{value}' to enum '{typeof(T)}'.");
            }
        }
    }
}
