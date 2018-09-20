using System.Threading.Tasks;

namespace BfkPortal.Core.Contracts
{
    public interface IUserService<out TModel, in TViewModel>
    {
        Task<int> Add(TViewModel viewModel);
    }
}
