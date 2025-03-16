using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class AboutService : IAboutService
    {
        private readonly IAboutRepository _aboutRepository;
        public AboutService(IAboutRepository aboutRepository)
        {
            _aboutRepository = aboutRepository;
        }

        public void CreateAbout(Staticabout aboutus)
        {
            _aboutRepository.CreateAbout(aboutus);  
        }

        public void DeleteAbout(int aboutId)
        {
               _aboutRepository.DeleteAbout(aboutId);      
        }

        public Staticabout GetAboutById(int aboutId)
        {
           return _aboutRepository.GetAboutById(aboutId);
        }

       public List<Staticabout>GetAll()
        {
            return _aboutRepository.GetAll();
        }

        public void UpdateAbout(Staticabout aboutus)
        {
            _aboutRepository.UpdateAbout(aboutus);
        }
    }
}
