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
            var destination = await _unitOfWork.Organisations.FindAsync(source.Id);
            if (destination == null)
                destination = new Organisation();

            destination.Name = source.Name;
            destination.IsDeleted = source.IsDeleted ?? false;

            foreach (var userId in source.Memberships)
            {
                var user = await _unitOfWork.Users.FindAsync(userId);
                destination.Memberships.Add(new Membership
                {
                    Organisation = destination,
                    User = user
                });
            }

            foreach (var appointmentId in source.Participations)
            {
                var appointment = await _unitOfWork.Appointments.FindAsync(appointmentId);
                destination.Participations.Add(new Participation
                {
                    Organisation = destination,
                    Appointment = appointment
                });
            }

            return destination;
        }
    }
}
