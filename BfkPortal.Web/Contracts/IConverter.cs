using System.Threading.Tasks;

namespace BfkPortal.Web.Contracts
{
    public interface IConverter<TSource, TDestination>
    {
        Task<TDestination> Convert(TSource source);
    }
}
