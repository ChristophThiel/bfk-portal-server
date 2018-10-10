using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Contracts
{
    public interface IGenericService<TModel, in TViewModel, out TModelDto> 
        where TModel : IEntityObject where TViewModel : IEntityViewModel
    {
        ModelStateDictionary ModelState { get; }

        Task<int> Add(TViewModel viewModel);

        Task Remove(int id);

        Task Update(TViewModel viewModel);

        IEnumerable<TModelDto> All();

        Task<TModel> CastViewModelToModel(TViewModel viewModel);
    }
}
