using System.Data.Entity;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Model
{
    public class UrlShorteningServiceContext : DbContext
    {
        public UrlShorteningServiceContext()
            : base("name=UrlShorteningServiceModelConnectionString")
        {
        }

        public virtual DbSet<UrlMapping> UrlMappings { get; set; }
    }
}
