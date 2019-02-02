using System.Collections.Generic;
using System.Threading.Tasks;

namespace BfkPortal.Core.Contracts
{
    public interface IBaseService<TModel, TViewModel, TModelDto> 
        where TModel : IEntityObject where TViewModel : IEntityViewModel
    {
        Task<int> Add(TViewModel viewModel);

        IEnumerable<TModelDto> All();

        Task<TModelDto> Find(int id);

        Task Remove(int id);

        Task<int> Update(TViewModel viewModel);
    }
}
