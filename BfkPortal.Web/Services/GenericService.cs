using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services
{
    public abstract class GenericService<TModel, TViewModel, TModelDto> : IGenericService<TModel, TViewModel, TModelDto>
        where TModel : IEntityObject where TViewModel : IEntityViewModel
    {
        public IUnitOfWork UnitOfWork { get; }

        public IConverter<TViewModel, TModel> ViewModelToModelConverter { get; set; }

        public GenericService(IUnitOfWork unitOfWork, IConverter<TViewModel, TModel> viewModelToModelConverter)
        {
            UnitOfWork = unitOfWork;
            ViewModelToModelConverter = viewModelToModelConverter;
        }

        public Task<int> AddAsync(TViewModel viewModel)
        {
            var entity = await ViewModelToModelConverter.Convert(viewModel);
        }

        public IEnumerable<TModelDto> All()
        {
            throw new System.NotImplementedException();
        }

        public Task<TModelDto> FindAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        /*public IUnitOfWork UnitOfWork { get; }
        
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

        public Task<int> AddAsync(TViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateAsync(TViewModel viewModel)
        {
            throw new System.NotImplementedException();
        }

        public Task<TModelDto> FindAsync()
        {
            throw new System.NotImplementedException();
        }*/
    }
}
