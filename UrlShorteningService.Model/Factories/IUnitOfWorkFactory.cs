using UrlShorteningService.Model.UnitsOfWork;

namespace UrlShorteningService.Model.Factories
{
    public interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
