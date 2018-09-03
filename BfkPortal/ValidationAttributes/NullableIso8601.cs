using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BfkPortal.ValidationAttributes
{
    public class NullableIso8601 : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var dateTime = value as string;
            if (string.IsNullOrEmpty(dateTime))
                return true;

            if (string.IsNullOrWhiteSpace(dateTime))
                return false;
            
            return Regex.IsMatch(dateTime, "\\d{4}(-\\d{2}){2}T(\\d{2}:){2}\\d{2}") && DateTime.TryParse(dateTime, null, DateTimeStyles.RoundtripKind, out _);
        }
    }
}
