using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
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
            var destination = await _unitOfWork.Offers.FindAsync(source.Id);
            if (destination == null)
                destination = new Offer();

            destination.Status = source.Status ?? OfferStatus.Pending;
            destination.Sender = await _unitOfWork.Users.FindAsync(source.SenderId.Value);
            destination.Receiver = await _unitOfWork.Users.FindAsync(source.ReceiverId.Value);
            destination.SenderAppointment = await _unitOfWork.Appointments.FindAsync(source.SenderAppointmentId.Value);
            destination.ReceiverAppointment = await _unitOfWork.Appointments.FindAsync(source.ReceiverAppointmentId.Value);

            return destination;
        }
    }
}
