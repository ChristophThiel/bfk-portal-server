using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace BfkPortal.Web.Services.Converters
{
    public class OfferViewModelToOfferConverter : IConverter<OfferViewModel, Offer>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;

        public OfferViewModelToOfferConverter(IUnitOfWork unitOfWork, UserManager<User> userManager)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
        }

        public async Task<Offer> Convert(OfferViewModel source)
        {
            var destination = await _unitOfWork.Offers.FindAsync(source.Id);
            if (destination == null)
                destination = new Offer();

            destination.Status = source.Status ?? OfferStatus.Pending;
            destination.Sender = await _userManager.FindByIdAsync(source.SenderId.ToString());
            destination.Receiver = await _userManager.FindByIdAsync(source.ReceiverId.ToString());
            destination.SenderAppointment = await _unitOfWork.Appointments.FindAsync(source.SenderAppointmentId.Value);
            destination.ReceiverAppointment = await _unitOfWork.Appointments.FindAsync(source.ReceiverAppointmentId.Value);

            return destination;
        }
    }
}
