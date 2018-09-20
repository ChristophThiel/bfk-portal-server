using System;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Text.RegularExpressions;

namespace BfkPortal.Web.Validations
{
    public class Iso8601 : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value is string dateTime)
                return Regex.IsMatch(dateTime, "\\d{4}(-\\d{2}){2}T(\\d{2}:){2}\\d{2}") && DateTime.TryParse(dateTime, null, DateTimeStyles.RoundtripKind, out _);
            return false;
        }
    }
}
