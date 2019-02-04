using System;
using System.Collections.Generic;
using BfkPortal.Core.Models;

namespace BfkPortal.Web.Contracts
{
    public interface IHolidaysService
    {
        IEnumerable<Holiday> All(int? year = null);

        bool IsHoliday(DateTime date);
    }
}