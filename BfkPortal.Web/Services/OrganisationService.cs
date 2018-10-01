using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public class OrganisationService : GenericService<Organisation, OrganisationViewModel, OrganisationDto>, IOrganisationService
    {
        public OrganisationService(ModelStateDictionary modelState) : base(modelState) { }

        public override IEnumerable<OrganisationDto> All() => UnitOfWork.Organisations.All().Select(o => new OrganisationDto(o));

        public override async Task<Organisation> CastViewModelToModel(OrganisationViewModel viewModel)
        {
            var entity = new Organisation
            {
                Name = viewModel.Name,
                IsDeleted = viewModel.IsDeleted ?? false
            };

            foreach (var membershipId in viewModel.Memberships)
            {
                var user = await UnitOfWork.Users.FindAsync(membershipId);
                if (user == null)
                    ModelState.AddModelError("User Id", "An user with this id does not exist!");
                else
                    entity.Memberships.Add(new Membership
                    {
                        Organisation = entity,
                        User = user
                    });
            }

            foreach (var participationsId in viewModel.Participations)
            {
                var appointment = await UnitOfWork.Appointments.FindAsync(participationsId);
                if (appointment == null)
                    ModelState.AddModelError("Appointment Id", "An appointment with this id does not exist!");
                else
                    entity.Participations.Add(new Participation
                    {
                        Appointment = appointment,
                        Organisation = entity
                    });
            }

            return entity;
        }

        public override async Task Remove(int id)
        {
            var entity = await UnitOfWork.Organisations.FindAsync(id);
            if (entity == null)
                ModelState.AddModelError("Organisation Id", $"An organistation with the id {id} does not exist!");

            entity.IsDeleted = true;
            UnitOfWork.Organisations.Update(entity);
            await UnitOfWork.SaveChangesAsync();
        }
    }
}
