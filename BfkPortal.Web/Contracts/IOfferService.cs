using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IOfferService : IGenericService<Offer, OfferViewModel, OfferDto>
    {
        IEnumerable<string> Status();

        Task ReplyAsync(int offerId, OfferStatus status);
    }
}
