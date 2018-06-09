namespace UrlShorteningService.Service.Model.Types
{
    public interface IUrlMapping
    {
        int Id { get; set; }
        string Url { get; set; }
    }
}