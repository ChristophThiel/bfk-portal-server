using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Persistence.Contracts;

namespace BfkPortal.Web.Contracts
{
    public interface IGenericService<in TViewModel, TModelDto> 
        where TViewModel : IEntityViewModel
    {
        IUnitOfWork UnitOfWork { get; }

        Task<int> AddAsync(TViewModel viewModel);

        Task RemoveAsync(int id);

        Task UpdateAsync(TViewModel viewModel);

        Task<TModelDto> FindAsync();

        IEnumerable<TModelDto> All();
    }
}
