﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Communication.DataTransferObjects;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class OrganisationRepository : DefaultRepository, IOrganisationRepository
    {
        public OrganisationRepository(ApplicationDbContext context, IConfiguration configuration) : base(context, configuration) { }

        public async Task<Organisation> Find(int id) => await Context.Organisations.FindAsync(id);

        public async Task<IEnumerable<OrganisationDto>> All()
        {
            return await Context.Organisations.Select(o => new OrganisationDto
            {
                Id = o.Id,
                Name = o.Name,
                IsDeleted = o.IsDeleted
            }).ToListAsync();
        }
    }
}
