using System.Text.RegularExpressions;

namespace FG.MusicStore.Domain.Shared.Validation
{
    public class Assert
    {
        public static bool Length(string text, int min, int max)
        {
            var length = text.Trim().Length;
            return (length >= min || length <= max);               
        }

        public static bool IsNotNull(object obj)
        {
            return (obj == null);
        }

        public static bool IsGreaterThan(decimal value1, decimal value2)
        {
            return (value1 > value2);
        }

        public static bool ValidEmail(string email)
        {
            var emailRegex =
                @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
            return Regex.IsMatch(email, emailRegex, RegexOptions.IgnoreCase);
        }
    }
}
