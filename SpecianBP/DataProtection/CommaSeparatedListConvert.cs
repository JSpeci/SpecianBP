using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SpecianBP.DataProtection
{
    public static class CommaSeparatedListConvert
    {
        private const string _comma = ",";
        private static char[] _commaChars = new[] { _comma[0] };

        public static List<string> FromCommaSeparatedString(string commaSeparatedString)
        {
            if (string.IsNullOrWhiteSpace(commaSeparatedString))
            {
                return new List<string>();
            }
            return commaSeparatedString
                .Split(_commaChars)
                .Select(i => i?.Trim())
                .ToList();
        }

        public static string ToCommaSeparatedString(IEnumerable<string> list)
        {
            if (list == null || list.Any() == false)
            {
                return "";
            }
            return string.Join(_comma, list);
        }
    }
}
