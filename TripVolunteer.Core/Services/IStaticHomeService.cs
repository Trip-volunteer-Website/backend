using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IStaticHomeService
    {
        List<Statichome> GetAllStaticHome();
        void addStaticHome(Statichome statichome);
        void deleteStaticHome(int id);
        public void updateStaticHome(Statichome statichome);
        Statichome getStaticHomeById(int id);
    }
}
