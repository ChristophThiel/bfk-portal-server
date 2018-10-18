using System;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;

namespace BfkPortal.Web.Services.Converters
{
    public class OfferViewModelToOfferConverter : IConverter<OfferViewModel, Offer>
    {
        private readonly IUnitOfWork _unitOfWork;

        public OfferViewModelToOfferConverter(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Offer> Convert(OfferViewModel source)
        {
            Offer destination;
            if (source.Id.HasValue)
                destination = await _unitOfWork.Offers.FindAsync(source.Id.Value) ?? new Offer();
            else
                destination = new Offer();

            // Nullable but required
            destination.Status = source.Status.Value;
            destination.SenderAppointment = await _unitOfWork.Appointments.FindAsync(source.SenderAppointmentId.Value) ?? throw new Exception();
            destination.ReceiverAppointment = await _unitOfWork.Appointments.FindAsync(source.ReceiverAppointmentId.Value) ?? throw new Exception();
            destination.Sender = await _unitOfWork.Users.FindAsync(source.SenderId.Value) ?? throw new Exception();
            destination.Receiver = await _unitOfWork.Users.FindAsync(source.ReceiverId.Value) ?? throw new Exception();

            return destination;
        }
    }
}
