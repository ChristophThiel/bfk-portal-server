using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;

namespace BfkPortal.Web.Services.Converters
{
    public class OrganisationViewModelToOrganisationConverter : IConverter<OrganisationViewModel, Organisation>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OrganisationViewModelToOrganisationConverter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Organisation> Convert(OrganisationViewModel source)
        {
            Organisation destination;
            if (source.Id.HasValue)
                destination = await _unitOfWork.Organisations.FindAsync(source.Id.Value) ?? new Organisation();
            else
                destination = new Organisation();

            destination.Name = source.Name;
            destination.IsDeleted = source.IsDeleted ?? false;

            var users = source.Memberships
                .Select(m => _unitOfWork.Users.FindAsync(m).Result)
                .Where(u => u != null);
            foreach (var user in users)
            {
                destination.Memberships.Add(new Membership
                {
                    Organisation = destination,
                    User = user
                });
            }

            return destination;
        }
    }
}
