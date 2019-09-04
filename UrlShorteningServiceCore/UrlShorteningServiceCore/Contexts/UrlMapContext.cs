using System.IO;
using UrlShorteningService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace UrlShorteningService.Contexts
{
    public class UrlMapContext : DbContext
    {
        public UrlMapContext(DbContextOptions<UrlMapContext> options) : base(options)
        {
        }

        public virtual DbSet<UrlMap> UrlMaps { get; set; }

    }
}
