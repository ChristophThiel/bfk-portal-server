using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Models;

namespace BfkPortal.Database.Contracts
{
    public interface IUserOrganisationRepository
    {
        Task Add(UserOrganisation userOrganisation);
    }
}
