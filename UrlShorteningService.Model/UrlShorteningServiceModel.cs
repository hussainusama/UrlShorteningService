using System.Data.Entity;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Model
{
    public class UrlShorteningServiceModel : DbContext
    {
        public UrlShorteningServiceModel()
            : base("name=UrlShorteningServiceModelConnectionString")
        {
        }

        public virtual DbSet<UrlMapping> UrlMappings { get; set; }
    }
}
