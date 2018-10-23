using System.Collections.Generic;
using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using BfkPortal.Core.Models;
using BfkPortal.Core.Models.Enums;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IOfferService : IBaseService<Offer, OfferViewModel, OfferDto>
    {
        Task Reply(int offerId, OfferStatus status);

        IEnumerable<string> Status();
    }
}
