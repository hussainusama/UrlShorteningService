using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Service.Services
{
    public interface IUrlMappingService
    {
        Task<int> AddAsync(string url);
        Task<UrlMapping> GetAsync(int id);
    }
}