using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class StaticHeaderAndFooterService : IStaticHeaderAndFooterService
    {

        private readonly IStaticHeaderAndFooterRepository _staticheaderAndFooterRepository;
        public StaticHeaderAndFooterService(IStaticHeaderAndFooterRepository
        staticheaderAndFooterRepository)
        {
            _staticheaderAndFooterRepository = staticheaderAndFooterRepository;
        }

        public void createhf(Staticheaderandfooter staticheaderandfooter)
        {
            _staticheaderAndFooterRepository.createhf(staticheaderandfooter);
        }

        public void deletehf(int id)
        {
            _staticheaderAndFooterRepository.deletehf(id);
        }

        public List<Staticheaderandfooter> GetAllhf()
        {
            return _staticheaderAndFooterRepository.GetAllhf();
        }

        public Staticheaderandfooter gethfbyid(int id)
        {
            return _staticheaderAndFooterRepository.gethfbyid(id);
        }

        public void updatehf(Staticheaderandfooter staticheaderandfooter)
        {
            _staticheaderAndFooterRepository.updatehf(staticheaderandfooter);
        }
    }
}
