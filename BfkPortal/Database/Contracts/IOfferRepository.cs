using System.Collections.Generic;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IOfferRepository : IBaseRepository<Offer>
    {
        List<string> Status();
    }
}
