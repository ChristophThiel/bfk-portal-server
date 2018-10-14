using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IGenericService<TModel, TViewModel, TModelDto> 
        where TModel : class where TViewModel : IEntityViewModel
    {
        Task<int> AddAsync(TViewModel viewModel);

        Task RemoveAsync(int id);

        Task<int> UpdateAsync(TViewModel viewModel);

        Task<TModelDto> FindAsync(int id);

        IEnumerable<TModelDto> All();
    }
}
