﻿// Appointment Update (all participants), Offer (all UserBwst), Register(new User), ResetPassword,
// Offer Add (Receiver), Update (Receiver), (Reply)

using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IEmailService
    {
        Task Send(string to, string from, string subject, string content);

        Task Send(string[] to, string from, string subject, string content);
    }
}