using HolidayApi.Models;
using System;
using System.Collections.Generic;

namespace HolidayApi
{
    public class HolidayCalculator
    {
        public int Year { get; set; }

        public DateTime NewYear { get; set; }

        public DateTime ThreeHolyKings { get; set; }

        public DateTime Easter { get; set; }

        public DateTime EasterMonday { get; set; }

        public DateTime StateHoliday { get; set; }

        public DateTime AscensionOfChrist { get; set; }

        public DateTime WhitMonday { get; set; }

        public DateTime CorpusChristi { get; set; }

        public DateTime AssumptionDay { get; set; }

        public DateTime NationalHoliday { get; set; }

        public DateTime AllSaintsDay { get; set; }

        public DateTime MaryConception { get; set; }

        public DateTime ChristmasEve { get; set; }

        public DateTime ChristmasDay { get; set; }

        public DateTime BoxingDay { get; set; }

        public HolidayCalculator(int? year)
        {
            Year = year ?? DateTime.Now.Year;
            CalculateEaster();
            NewYear = new DateTime(Year, 1, 1);
            ThreeHolyKings = new DateTime(Year, 1, 6);
            EasterMonday = Easter.AddDays(1);
            StateHoliday = new DateTime(Year, 5, 1);
            AscensionOfChrist = Easter.AddDays(39);
            WhitMonday = Easter.AddDays(50);
            CorpusChristi = Easter.AddDays(60);
            AssumptionDay = new DateTime(Year, 8, 15);
            NationalHoliday = new DateTime(Year, 10, 26);
            AllSaintsDay = new DateTime(Year, 11, 1);
            MaryConception = new DateTime(Year, 12, 8);
            ChristmasEve = new DateTime(Year, 12, 24);
            ChristmasDay = new DateTime(Year, 12, 25);
            BoxingDay = new DateTime(Year, 12, 26);
        }

        public IEnumerable<Holiday> ExportHolidays()
        {
            return new[]
                {
                    new Holiday
                    {
                        Name = "Neujahr",
                        Date = NewYear
                    },
                    new Holiday
                    {
                        Name = "Heilige Drei Könige",
                        Date = ThreeHolyKings
                    },
                    new Holiday
                    {
                        Name = "Ostern",
                        Date = Easter
                    },
                    new Holiday
                    {
                        Name = "Ostermontag",
                        Date = EasterMonday
                    },
                    new Holiday
                    {
                        Name = "Staatsfeiertag",
                        Date = StateHoliday
                    },
                    new Holiday
                    {
                        Name = "Christi Himmelfahrt",
                        Date = AscensionOfChrist
                    },
                    new Holiday
                    {
                        Name = "Pfingstmontag",
                        Date = WhitMonday
                    },
                    new Holiday
                    {
                        Name = "Fronleichnam",
                        Date = CorpusChristi
                    },
                    new Holiday
                    {
                        Name = "Maria Himmelfahrt",
                        Date = AssumptionDay
                    },
                    new Holiday
                    {
                        Name = "Nationalfeiertag",
                        Date = NationalHoliday
                    },
                    new Holiday
                    {
                        Name = "Allerheiligen",
                        Date = AllSaintsDay
                    },
                    new Holiday
                    {
                        Name = "Maria Empfängnis",
                        Date = MaryConception
                    },
                    new Holiday
                    {
                        Name = "Heilig Abend",
                        Date = ChristmasEve
                    },
                    new Holiday
                    {
                        Name = "Weihnachten",
                        Date = ChristmasDay
                    },
                    new Holiday
                    {
                        Name = "Stefanitag",
                        Date = BoxingDay
                    }
                };
        }

        private void CalculateEaster()
        {
            var a = Year % 19;
            var b = Year % 4;
            var c = Year % 7;
            var k = Year / 100;
            var p = (8 * k + 13) / 25;
            var q = k / 4;
            var m = (15 + k - p - q) % 30;
            var d = (19 * a + m) % 30;
            var n = (4 + k - q) % 7;
            var e = (2 * b + 4 * c + 6 * d + n) % 7;
            var days = 22 + d + e;
            if (days >= 31)
                Easter = new DateTime(Year, 4, days - 31);
            else
                Easter = new DateTime(Year, 3, days);
        }
    }
}
