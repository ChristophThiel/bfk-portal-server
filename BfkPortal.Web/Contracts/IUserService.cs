using System.Collections.Generic;
using BfkPortal.Core.Models;
using BfkPortal.Web.ViewModels;
using BfkPortal.Web.ViewModels.DataTransferObjects;

namespace BfkPortal.Web.Contracts
{
    public interface IUserService //: IGenericService<User, UserViewModel, UserDto>
    {
        IEnumerable<string> Roles();
    }
}
