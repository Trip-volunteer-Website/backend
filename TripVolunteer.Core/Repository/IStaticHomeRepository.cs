using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;


namespace TripVolunteer.Core.Repository
{
    public interface IStaticHomeRepository
    {
        List<Statichome> GetAllStaticHome();
        void addStaticHome(Statichome statichome);
        void deleteStaticHome(int id);
        public void updateStaticHome(Statichome statichome);
        Statichome getStaticHomeById(int id);
    }
}
