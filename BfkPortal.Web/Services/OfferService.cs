using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Persistence.Contracts;
using BfkPortal.Web.Contracts;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IConverter<OfferViewModel, Offer> _viewModelToModelConverter;
        private readonly IConverter<Offer, OfferDto> _modelToDtoConverter;

        public OfferService(IUnitOfWork unitOfWork, IConverter<OfferViewModel, Offer> viewModelToModel,
            IConverter<Offer, OfferDto> modelToDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _viewModelToModelConverter = viewModelToModel;
            _modelToDtoConverter = modelToDtoConverter;
        }

        public async Task<int> Add(OfferViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Offers.Add(model);

            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }

        public IEnumerable<OfferDto> All()
        {
            return _unitOfWork.Offers.All(nameof(Offer.Receiver), nameof(Offer.ReceiverAppointment),
                nameof(Offer.SenderAppointment), nameof(Offer.Sender))
                .Select(o => _modelToDtoConverter.Convert(o).Result);
        }

        public async Task<OfferDto> Find(int id)
        {
            var offer = await _unitOfWork.Offers.FindAsync(id, nameof(Offer.Receiver), nameof(Offer.ReceiverAppointment),
                nameof(Offer.SenderAppointment), nameof(Offer.Sender));
            return await _modelToDtoConverter.Convert(offer);
        }

        public async Task Remove(int id)
        {
            _unitOfWork.Offers.Remove(await _unitOfWork.Offers.FindAsync(id));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task Reply(int offerId, OfferStatus status)
        {
            if (status == OfferStatus.Declined)
                _unitOfWork.Offers.Remove(await _unitOfWork.Offers.FindAsync(offerId));
            else if (status == OfferStatus.Accepted)
            {
                var offer = await _unitOfWork.Offers.FindAsync(offerId, nameof(Offer.Receiver), nameof(Offer.Sender));

                var receiverAppointment = await _unitOfWork.Appointments.FindAsync(offer.ReceiverAppointmentId);
                var senderAppointment = await _unitOfWork.Appointments.FindAsync(offer.SenderAppointmentId);

                receiverAppointment.Owner = offer.Sender;
                senderAppointment.Owner = offer.Receiver;

                _unitOfWork.Appointments.Update(receiverAppointment);
                _unitOfWork.Appointments.Update(senderAppointment);

                _unitOfWork.Offers.Remove(offer);

                await _unitOfWork.SaveChangesAsync();
            }
        }

        public IEnumerable<string> Status()
        {
            return Enum.GetNames(typeof(OfferStatus));
        }

        public async Task<int> Update(OfferViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Offers.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }
    }
}
