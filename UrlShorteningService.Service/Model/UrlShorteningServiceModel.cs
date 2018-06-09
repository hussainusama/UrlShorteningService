using System.Data.Entity;

namespace UrlShorteningService.Service.Model
{
    public partial class UrlShorteningServiceModel : DbContext
    {
        public UrlShorteningServiceModel()
            : base("name=UrlShorteningServiceModelConnectionString")
        {
        }

        public virtual DbSet<UrlMapping> UrlMappings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
