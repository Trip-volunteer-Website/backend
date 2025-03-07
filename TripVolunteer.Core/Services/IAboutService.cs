using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IAboutService
    {
        List<Staticabout> GetAll();
        void UpdateAbout(Staticabout aboutus);
        void CreateAbout(Staticabout aboutus);
        void DeleteAbout(int aboutId);
        Staticabout GetAboutById(int aboutId);

    }
}
