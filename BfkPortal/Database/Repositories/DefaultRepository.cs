using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class DefaultRepository
    {
        public ApplicationDbContext Context { get; }

        public  IConfiguration Configuration { get; }

        public DefaultRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
        }
    }
}
