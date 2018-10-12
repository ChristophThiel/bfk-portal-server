using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using BfkPortal.Persistence.Contracts;

namespace BfkPortal.Web.Contracts
{
    public interface IGenericService<TModel, TViewModel, TModelDto> 
        where TModel : class where TViewModel : IEntityViewModel
    {
        IUnitOfWork UnitOfWork { get; }

        IConverter<TViewModel, TModel> ViewModelToModelConverter { get; }

        IConverter<TModel, TModelDto> ModelToDtoConverter { get; }

        Task<int> AddAsync(TViewModel viewModel);

        Task RemoveAsync(int id);

        Task UpdateAsync(TViewModel viewModel);

        Task<TModelDto> FindAsync(int id);

        IEnumerable<TModelDto> All();
    }
}
