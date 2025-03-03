using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IStaticHeaderAndFooterRepository
    {
        List<Staticheaderandfooter> GetAllhf();
        void createhf(Staticheaderandfooter staticheaderandfooter);
        void deletehf(int id);
        public void updatehf(Staticheaderandfooter staticheaderandfooter);
        Staticheaderandfooter gethfbyid(int id);
    }
}
