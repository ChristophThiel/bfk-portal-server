using BfkPortal.Web.ViewModels.DataTransferObjects;
using BfkPortal.Web.ViewModels;
using BfkPortal.Core.Models;
using System.Threading.Tasks;
using BfkPortal.Core.Contracts;
using System.Collections;
using System.Collections.Generic;
using System;

namespace BfkPortal.Web.Contracts
{
    public interface IAppointmentService : IBaseService<Appointment, AppointmentViewModel, AppointmentDto>
    {
        Task<IEnumerable<KeyValuePair<DateTime, int>>> Distribute(int month);

        Task OfferDuty(int appointmentId);

        Task Participate(int appointmentId, int particpantId);

        Task TakeDuty(int appointmentId, string email);

        Task Unparticipate(int appointmentId, int participantId);
    }
}
