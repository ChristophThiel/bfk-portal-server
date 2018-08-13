using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.DataTransferObjects;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IShiftRepository
    {
        Task Add(Shift shift);

        Task Delete(int id);

        Task Update(ShiftDto shift);

        Task<IEnumerable<ShiftDto>> All();

        Task<IEnumerable<ShiftDto>> All(int userId);
    }
}
