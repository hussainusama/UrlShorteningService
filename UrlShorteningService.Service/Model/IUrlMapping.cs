namespace UrlShorteningService.Service.Model
{
    public interface IUrlMapping
    {
        int Id { get; set; }
        string Url { get; set; }
    }
}