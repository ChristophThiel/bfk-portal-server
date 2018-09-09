using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BfkPortal.Database.Contracts;
using BfkPortal.Models;
using BfkPortal.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace BfkPortal.Database.Repositories
{
    public class OfferRepository : BaseRepository, IOfferRepository
    {
        public OfferRepository(ApplicationDbContext context) : base(context) { }

        public bool Add(Offer entity)
        {
            try
            {
                Context.Offers.Add(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var entity = await Context.Offers.FindAsync(id);
            if (entity == null)
                return false;

            Context.Offers.Remove(entity);
            return true;
        }

        public bool Update(Offer entity)
        {
            try
            {
                Context.Offers.Update(entity);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<Offer> Find(int id)
        {
            return await Context.Offers
                .Include(o => o.Sender)
                .Include(o => o.SenderAppointment)
                .Include(o => o.Receiver)
                .Include(o => o.ReceiverAppointment)
                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<List<Offer>> All()
        {
            return await Context.Offers
                .Include(o => o.ReceiverAppointment)
                .ThenInclude(a => a.OrganisationParticipants)
                .ThenInclude(ao => ao.Organisation)

                .Include(o => o.ReceiverAppointment)
                .ThenInclude(a => a.UserParticipants)
                .ThenInclude(au => au.User)
                .ThenInclude(u => u.Roles)
                .ThenInclude(ur => ur.Role)

                .Include(o => o.ReceiverAppointment)
                .ThenInclude(a => a.UserParticipants)
                .ThenInclude(au => au.User)
                .ThenInclude(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)

                .Include(o => o.ReceiverAppointment)
                .ThenInclude(a => a.Owner)
                .ThenInclude(u => u.Roles)
                .ThenInclude(ur => ur.Role)

                .Include(o => o.ReceiverAppointment)
                .ThenInclude(a => a.Owner)
                .ThenInclude(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)

                .Include(o => o.Receiver)

                .Include(o => o.SenderAppointment)
                .ThenInclude(a => a.OrganisationParticipants)
                .ThenInclude(ao => ao.Organisation)

                .Include(o => o.SenderAppointment)
                .ThenInclude(a => a.UserParticipants)
                .ThenInclude(au => au.User)
                .ThenInclude(u => u.Roles)
                .ThenInclude(ur => ur.Role)

                .Include(o => o.SenderAppointment)
                .ThenInclude(a => a.UserParticipants)
                .ThenInclude(au => au.User)
                .ThenInclude(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)

                .Include(o => o.SenderAppointment)
                .ThenInclude(a => a.Owner)
                .ThenInclude(u => u.Roles)
                .ThenInclude(ur => ur.Role)

                .Include(o => o.SenderAppointment)
                .ThenInclude(a => a.Owner)
                .ThenInclude(u => u.Organisations)
                .ThenInclude(uo => uo.Organisation)

                .Include(o => o.Sender)

                .ToListAsync();
        }

        public List<string> Status() => 
            Enum.GetValues(typeof(OfferStatus))
                .Cast<OfferStatus>()
                .Select(t => t.ToString())
                .ToList();
    }
}
