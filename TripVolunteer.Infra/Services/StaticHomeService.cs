using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class StaticHomeService : IStaticHomeService
    {
        private readonly IStaticHomeRepository _staticHomeRepository;
        public StaticHomeService(IStaticHomeRepository
        staticHomeRepository)
        {
            _staticHomeRepository = staticHomeRepository;
        }

        public void addStaticHome(Statichome statichome)
        {
            _staticHomeRepository.addStaticHome(statichome);
        }

        public void deleteStaticHome(int id)
        {
            _staticHomeRepository.deleteStaticHome(id);
        }

        public List<Statichome> GetAllStaticHome()
        {
            return _staticHomeRepository.GetAllStaticHome();
        }

        public Statichome getStaticHomeById(int id)
        {
            return _staticHomeRepository.getStaticHomeById(id);
        }

        public void updateStaticHome(Statichome statichome)
        {
            _staticHomeRepository.updateStaticHome(statichome);
        }
    }
}
