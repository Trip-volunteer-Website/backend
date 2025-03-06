using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
