using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace BfkPortal.ValidationAttributes
{
    public class Iso8601 : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string dateTime)
                return DateTime.TryParse(dateTime, null, DateTimeStyles.RoundtripKind, out _);
            return false;
        }
    }
}
