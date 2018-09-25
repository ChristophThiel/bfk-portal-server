using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Models.Enums;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace BfkPortal.Web.Services
{
    public class OfferService : GenericService<Offer, OfferViewModel, OfferDto>, IOfferService
    {
        public OfferService(ModelStateDictionary modelState) : base(modelState) { }

        public override IEnumerable<OfferDto> All() => UnitOfWork.Offers.All().Select(o => new OfferDto(o));

        public override async Task<Offer> CastViewModelToModel(OfferViewModel viewModel)
        {
            var entity = new Offer
            {
                Status = viewModel.Status ?? OfferStatus.Pending,
                Sender = await UnitOfWork.Users.FindAsync(viewModel.SenderId.Value),
                Receiver = await UnitOfWork.Users.FindAsync(viewModel.ReceiverId.Value),
                SenderAppointment = await UnitOfWork.Appointments.FindAsync(viewModel.SenderAppointmentId.Value),
                ReceiverAppointment = await UnitOfWork.Appointments.FindAsync(viewModel.ReceiverAppointmentId.Value),
            };

            return entity;
        }

        public IEnumerable<string> Status() => Enum.GetNames(typeof(OfferStatus));
    }
}
