using System.Threading.Tasks;
using UrlShorteningService.Model.Factories;
using UrlShorteningService.Model.Types;

namespace UrlShorteningService.Service.Services
{
    public class UrlMappingService : IUrlMappingService
    {
        private readonly IUnitOfWorkFactory _unitOfWorkFactory;

        public UrlMappingService(IUnitOfWorkFactory unitOfWorkFactory)
        {
            _unitOfWorkFactory = unitOfWorkFactory;
        }

        public async Task<int> AddAsync(string url)
        {
            return await CreateAndSaveMappingToDataBase(url);
        }

        private async Task<int> CreateAndSaveMappingToDataBase(string longUrl)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                UrlMapping mapping = unitOfWork.UrlMappingsRepository.Create();
                mapping.Url = longUrl;
                unitOfWork.UrlMappingsRepository.Add(mapping);
                await unitOfWork.SaveChangesAsync();
                return mapping.Id;
            }
        }

        public async Task<UrlMapping> GetAsync(int id)
        {
            using (var unitOfWork = _unitOfWorkFactory.Create())
            {
                return await unitOfWork.UrlMappingsRepository.GetByKeyAsync(id);
            }
        }
    }
}