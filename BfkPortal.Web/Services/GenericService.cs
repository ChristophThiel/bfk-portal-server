using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using BfkPortal.Persistence;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public abstract class GenericService<TModel, TViewModel, TModelDto> : IGenericService<TModel, TViewModel, TModelDto>
        where TModel : IEntityObject where TViewModel : IBaseViewModel
    {
        private readonly IGenericRepository<TModel> _repository;

        public IUnitOfWork UnitOfWork { get; }

        public ModelStateDictionary ModelState { get; }

        protected GenericService(ModelStateDictionary modelState)
        {
            ModelState = modelState;
            UnitOfWork = new UnitOfWork();
            _repository = UnitOfWork.GetRepository<TModel>();
        }

        public virtual async Task<int> Add(TViewModel viewModel)
        {
            var entity = await CastViewModelToModel(viewModel);

            _repository.Add(entity);
            await UnitOfWork.SaveChangesAsync();

            return entity.Id;
        }

        public abstract IEnumerable<TModelDto> All();

        public abstract Task<TModel> CastViewModelToModel(TViewModel viewModel);

        public virtual async Task Remove(int id)
        {
            var entity = await _repository.FindAsync(id);
            if (entity == null)
                ModelState.AddModelError("Id", "An entity with this id does not exist!");
            else
            {
                _repository.Remove(entity);
            }

            await UnitOfWork.SaveChangesAsync();
        }

        public async Task Update(TViewModel viewModel)
        {
            var entity = await CastViewModelToModel(viewModel);
            entity.Id = viewModel.Id;

            _repository.Update(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
