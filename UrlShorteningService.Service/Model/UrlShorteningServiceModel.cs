using System.Data.Entity;
using UrlShorteningService.Service.Model.Types;

namespace UrlShorteningService.Service.Model
{
    public partial class UrlShorteningServiceModel : DbContext
    {
        public UrlShorteningServiceModel()
            : base("name=UrlShorteningServiceModelConnectionString")
        {
        }

        public virtual DbSet<UrlMapping> UrlMappings { get; set; }
    }
}
