using BfkPortal.Web.ViewModels.DataTransferObjects;
using System.Collections.Generic;

namespace BfkPortal.Web.Contracts
{
    public interface IUserService
    {
        IEnumerable<UserDto> All();

        IEnumerable<string> Roles();
    }
}
