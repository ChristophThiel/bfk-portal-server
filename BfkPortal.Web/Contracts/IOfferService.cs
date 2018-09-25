using System.Collections.Generic;
using BfkPortal.Core.Models;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IOfferService : IGenericService<Offer, OfferViewModel, OfferDto>
    {
        IEnumerable<string> Status();
    }
}
