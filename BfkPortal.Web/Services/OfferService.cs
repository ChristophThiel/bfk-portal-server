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
using Microsoft.AspNetCore.Hosting;

namespace BfkPortal.Web.Services
{
    public class OfferService : IOfferService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IHostingEnvironment _environment;
        private readonly IEmailService _emailService;
        private readonly IConverter<OfferViewModel, Offer> _viewModelToModelConverter;
        private readonly IConverter<Offer, OfferDto> _modelToDtoConverter;

        public OfferService(IUnitOfWork unitOfWork, IHostingEnvironment environment, IEmailService emailService, IConverter<OfferViewModel, Offer> viewModelToModel,
            IConverter<Offer, OfferDto> modelToDtoConverter)
        {
            _unitOfWork = unitOfWork;
            _environment = environment;
            _emailService = emailService;
            _viewModelToModelConverter = viewModelToModel;
            _modelToDtoConverter = modelToDtoConverter;
        }

        public async Task<int> Add(OfferViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Offers.Add(model);

            await _unitOfWork.SaveChangesAsync();

            var receiver = await _unitOfWork.Users.FindAsync(model.ReceiverId);
            var sender = await _unitOfWork.Users.FindAsync(model.SenderId);
            var receiverAppointment = await _unitOfWork.Appointments.FindAsync(model.ReceiverAppointmentId);
            var senderAppointment = await _unitOfWork.Appointments.FindAsync(model.SenderAppointmentId);

            var content = System.IO.File.ReadAllText(System.IO.Path.Combine(_environment.ContentRootPath, Constants.WwwRoot, Constants.EmailTemplateFoldername, Constants.OfferedEmailFilename))
              .Replace("@NAME@", receiver.Name)
              .Replace("@OFFER_SENDER_NAME@", sender.Name)
              .Replace("@OFFER_RECEIVER_DATE@", receiverAppointment.From.ToString("MM.dd.yyyy"))
              .Replace("@OFFER_SENDER_DATE@", senderAppointment.From.ToString("MM.dd.yyyy"));
            await _emailService.Send(receiver.Email, Constants.OfferedEmailSubject, content);
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
            var offer = await _unitOfWork.Offers.FindAsync(offerId, nameof(Offer.Receiver), nameof(Offer.Sender));
            if (status == OfferStatus.Declined)
            {
                offer.Status = OfferStatus.Declined;
                _unitOfWork.Offers.Update(offer);

                await _unitOfWork.SaveChangesAsync();
            }
            else if (status == OfferStatus.Accepted)
            {
                offer.Status = OfferStatus.Accepted;
                _unitOfWork.Offers.Update(offer);

                var receiverAppointment = await _unitOfWork.Appointments.FindAsync(offer.ReceiverAppointmentId);
                var senderAppointment = await _unitOfWork.Appointments.FindAsync(offer.SenderAppointmentId);

                receiverAppointment.Owner = offer.Sender;
                senderAppointment.Owner = offer.Receiver;

                _unitOfWork.Appointments.Update(receiverAppointment);
                _unitOfWork.Appointments.Update(senderAppointment);

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
