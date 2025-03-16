using System.Collections.Generic;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IAboutRepository
    {
        List<Staticabout> GetAll();
        void UpdateAbout(Staticabout aboutus);
        void CreateAbout(Staticabout aboutus);
        void DeleteAbout(int aboutId);
        Staticabout GetAboutById(int aboutId);
    }
}
