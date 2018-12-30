using System;
using System.Linq;
using System.Collections.Generic;
using BfkPortal.Web.Contracts;
using Microsoft.Extensions.Configuration;
using BfkPortal.Core.Models;

namespace BfkPortal.Web.Services
{
    public class HolidaysService : IHolidaysService
    {
        private readonly IConfiguration _configuration;

        public HolidaysService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IEnumerable<Holiday> All(int? year)
        {
            var calculationYear = year.HasValue ? year.Value : DateTime.Now.Year;

            var easter = CalculateEaster(calculationYear);

            var holidays = _configuration.GetSection("Holidays").Get<List<Holiday>>();
            foreach (var holiday in holidays)
            {
                if (!int.TryParse(holiday.Date, out var days))
                    yield return new Holiday
                    {
                        Name = holiday.Name,
                        Date = DateTime.Parse(holiday.Date.Replace("YYYY", calculationYear.ToString()), null, System.Globalization.DateTimeStyles.RoundtripKind).ToString("s")
                    };
                else
                    yield return new Holiday
                    {
                        Name = holiday.Name,
                        Date = easter.AddDays(days).ToString("s")
                    };
            }
        }

        private DateTime CalculateEaster(int year)
        {
            var a = year % 19;
            var b = year % 4;
            var c = year % 7;
            var k = year / 100;
            var p = (8 * k + 13) / 25;
            var q = k / 4;
            var m = (15 + k - p - q) % 30;
            var d = (19 * a + m) % 30;
            var n = (4 + k - q) % 7;
            var e = (2 * b + 4 * c + 6 * d + n) % 7;
            var days = 22 + d + e;
            return days >= 31 ? new DateTime(year, 4, days - 31) : new DateTime(year, 3, days);
        }
    }
}