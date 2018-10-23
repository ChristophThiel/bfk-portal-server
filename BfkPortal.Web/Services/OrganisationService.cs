using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services
{
    public class OrganisationService : IOrganisationService
    {
        private readonly IUnitOfWork _unitOfWork;
        private IConverter<OrganisationViewModel, Organisation> _viewModelToModelConverter;
        private IConverter<Organisation, OrganisationDto> _modelToDtoConverter;

        public OrganisationService(IUnitOfWork unitOfWork,
            IConverter<OrganisationViewModel, Organisation> viewModelToModelConverter,
            IConverter<Organisation, OrganisationDto> modelToDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _viewModelToModelConverter = viewModelToModelConverter;
            _modelToDtoConverter = modelToDtoConverter;
        }

        public async Task<int> Add(OrganisationViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Organisations.Add(model);

            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }

        public IEnumerable<OrganisationDto> All()
        {
            var organisations = _unitOfWork.Organisations.All()
                .Select(o => _modelToDtoConverter.Convert(o).Result);
            return organisations;
        }

        public async Task<OrganisationDto> Find(int id)
        {
            return await _modelToDtoConverter.Convert(await _unitOfWork.Organisations.FindAsync(id));
        }

        public async Task Remove(int id)
        {
            _unitOfWork.Organisations.Remove(await _unitOfWork.Organisations.FindAsync(id));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<int> Update(OrganisationViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Organisations.Update(model);

            await _unitOfWork.SaveChangesAsync();

            return model.Id;
        }
    }
}
