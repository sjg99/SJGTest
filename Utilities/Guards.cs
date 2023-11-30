using Utilities.Exceptions;

namespace Utilities
{
    public class Guards
    {
        public static void Require(bool expression, string message)
        {
            if (!expression)
            {
                throw new CustomException(message);
            }
        }
        public static T RequireNotNull<T>(T value, string message)
        {
            return value ?? throw new CustomException(message);
        }
        public static string RequireString(string value, string message)
        {
            return !string.IsNullOrWhiteSpace(value) ? value : throw new CustomException(message);
        }
    }
}
