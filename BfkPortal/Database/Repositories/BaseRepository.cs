using Microsoft.Extensions.Configuration;

namespace BfkPortal.Database.Repositories
{
    public class BaseRepository
    {
        public ApplicationDbContext Context { get; }

        public IConfiguration Configuration { get; }

        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public BaseRepository(ApplicationDbContext context, IConfiguration configuration)
        {
            Context = context;
            Configuration = configuration;
        }
    }
}
