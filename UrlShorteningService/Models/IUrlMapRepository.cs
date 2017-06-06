namespace UrlShorteningService.Models
{
    public interface IUrlMapRepository
    {
        void Insert(UrlMap entity);
        void Delete(UrlMap entity);
        UrlMap GetById(int id);
    }
}