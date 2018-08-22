﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.DataTransferObjects;

namespace BfkPortal.Database.Contracts
{
    public interface IOrganisationRepository
    {
        Task<IEnumerable<OrganisationDto>> All();
    }
}
