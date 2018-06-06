namespace UrlShorteningService.Service.Encoders
{
    public interface IBase62Encoder
    {
        string Encode(int val);

        int Decode(string val);
    }
}