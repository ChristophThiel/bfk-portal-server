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
    public class OfferService : IOfferService // : GenericService<Offer, OfferViewModel, OfferDto>, IOfferService
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

        public async Task<int> AddAsync(OfferViewModel viewModel)
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

        public async Task<OfferDto> FindAsync(int id)
        {
            var offer = await _unitOfWork.Offers.FindAsync(id, nameof(Offer.Receiver), nameof(Offer.ReceiverAppointment),
                nameof(Offer.SenderAppointment), nameof(Offer.Sender));
            return await _modelToDtoConverter.Convert(offer);
        }

        public async Task RemoveAsync(int id)
        {
            _unitOfWork.Offers.Remove(await _unitOfWork.Offers.FindAsync(id));

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task ReplyAsync(int offerId, OfferStatus status)
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

        public async Task<int> UpdateAsync(OfferViewModel viewModel)
        {
            var model = await _viewModelToModelConverter.Convert(viewModel);
            _unitOfWork.Offers.Update(model);

            await _unitOfWork.SaveChangesAsync();
            return model.Id;
        }

        /* public OfferService(ModelStateDictionary modelState) : base(modelState) { }

        #region Override Methods

        public override IEnumerable<OfferDto> All()
        {
            var offers = UnitOfWork.Offers.All();
            foreach (var offer in offers)
            {
                UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.Receiver));
                UnitOfWork.Users.LoadCollectionAsync(offer.Receiver, nameof(offer.Receiver.Entitlements));
                foreach (var entitlement in offer.Receiver.Entitlements)
                    UnitOfWork.Entitlements.LoadReferenceAsync(entitlement, nameof(entitlement.Role));

                UnitOfWork.Users.LoadCollectionAsync(offer.Receiver,
                    nameof(offer.Receiver.Memberships));
                foreach (var membership in offer.Receiver.Memberships)
                    UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));

                UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.ReceiverAppointment));
                UnitOfWork.Appointments.LoadCollectionAsync(offer.ReceiverAppointment,
                    nameof(offer.ReceiverAppointment.Participations));
                foreach (var participation in offer.ReceiverAppointment.Participations)
                {
                    if (offer.ReceiverAppointment.AreParticipantsOrganisations.Value)
                        UnitOfWork.Participations.LoadReferenceAsync(participation, nameof(participation.Organisation));
                    else
                    {
                        UnitOfWork.Participations.LoadReferenceAsync(participation, nameof(participation.User));
                        UnitOfWork.Users.LoadCollectionAsync(participation.User,
                            nameof(participation.User.Entitlements));
                        foreach (var entitlement in participation.User.Entitlements)
                            UnitOfWork.Entitlements.LoadReferenceAsync(entitlement, nameof(entitlement.Role));
                        UnitOfWork.Users.LoadCollectionAsync(participation.User,
                            nameof(participation.User.Memberships));
                        foreach (var membership in participation.User.Memberships)
                            UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));
                    }
                }

                UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.Sender));
                UnitOfWork.Users.LoadCollectionAsync(offer.Sender, nameof(offer.Sender.Entitlements));
                foreach (var entitlement in offer.Sender.Entitlements)
                    UnitOfWork.Entitlements.LoadReferenceAsync(entitlement, nameof(entitlement.Role));
                UnitOfWork.Users.LoadCollectionAsync(offer.Sender,
                    nameof(offer.Sender.Memberships));
                foreach (var membership in offer.Sender.Memberships)
                    UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));

                UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.SenderAppointment));
                UnitOfWork.Appointments.LoadCollectionAsync(offer.SenderAppointment,
                    nameof(offer.SenderAppointment.Participations));
                foreach (var participation in offer.SenderAppointment.Participations)
                {
                    if (offer.SenderAppointment.AreParticipantsOrganisations.Value)
                        UnitOfWork.Participations.LoadReferenceAsync(participation, nameof(participation.Organisation));
                    else
                    {
                        UnitOfWork.Participations.LoadReferenceAsync(participation, nameof(participation.User));
                        UnitOfWork.Users.LoadCollectionAsync(participation.User,
                            nameof(participation.User.Entitlements));
                        foreach (var entitlement in participation.User.Entitlements)
                            UnitOfWork.Entitlements.LoadReferenceAsync(entitlement, nameof(entitlement.Role));
                        UnitOfWork.Users.LoadCollectionAsync(participation.User,
                            nameof(participation.User.Memberships));
                        foreach (var membership in participation.User.Memberships)
                            UnitOfWork.Memberships.LoadReferenceAsync(membership, nameof(membership.Organisation));
                    }
                }
            }

            return offers.Select(o => new OfferDto(o));
        } 

        public override async Task<Offer> CastViewModelToModel(OfferViewModel viewModel)
        {
            var entity = new Offer
            {
                Status = viewModel.Status.Value,
                Sender = await UnitOfWork.Users.FindAsync(viewModel.SenderId.Value),
                Receiver = await UnitOfWork.Users.FindAsync(viewModel.ReceiverId.Value),
                SenderAppointment = await UnitOfWork.Appointments.FindAsync(viewModel.SenderAppointmentId.Value),
                ReceiverAppointment = await UnitOfWork.Appointments.FindAsync(viewModel.ReceiverAppointmentId.Value),
            };

            return entity;
        }

        #endregion

        public IEnumerable<string> Status() => Enum.GetNames(typeof(OfferStatus));

        public async Task ReplyAsync(int offerId, OfferStatus status)
        {
            if (status == OfferStatus.Pending)
                return;

            var offer = await UnitOfWork.Offers.FindAsync(offerId);
            if (offer == null)
            {
                ModelState.AddModelError("Offer Id", "An offer with this id does not exist!");
                return;
            }

            if (status == OfferStatus.Declined)
                UnitOfWork.Offers.Remove(offer);
            else
            {
                await UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.Sender));
                await UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.Receiver));
                await UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.SenderAppointment));
                await UnitOfWork.Offers.LoadReferenceAsync(offer, nameof(offer.ReceiverAppointment));

                offer.SenderAppointment.Owner = offer.Receiver;
                offer.ReceiverAppointment.Owner = offer.Sender;
            }

            await UnitOfWork.SaveChangesAsync();
        }*/
    }
}
