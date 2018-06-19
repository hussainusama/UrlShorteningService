using UrlShorteningService.Model.UnitsOfWork;

namespace UrlShorteningService.Model.Factories
{
    public class UnitOfWorkFactory : IUnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new UrlShorteningServiceContext());
        }
    }
}