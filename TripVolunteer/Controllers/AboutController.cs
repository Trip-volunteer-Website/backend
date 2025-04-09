using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.API.Controllers;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;
using TripVolunteer.Infra.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService aboutService;
        public AboutController(IAboutService aboutService)
        {
            this.aboutService = aboutService; 
        }

        [HttpGet]
        public List<Staticabout>GetAllabout()
        {
            return aboutService.GetAll();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public Staticabout GetAboutById(int id)
        {
            return aboutService.GetAboutById(id);

        }

        [HttpPost]
        public void createAbout(Staticabout about) 
        { 
         aboutService.CreateAbout(about);
        
        
        
        }

        [HttpPut]
        public void updateAbout(Staticabout about)
        {
            aboutService.UpdateAbout(about);
        }

        [HttpDelete]
        [Route("deleteabout/{id}")]
        public void deleteAbout(int id)
        {
            aboutService.DeleteAbout(id);
        }


        [HttpPost]
        [Route("UploudeImage")]
        public Staticabout UploudeImage()
        {
            var file = Request.Form.Files[0];
            var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\images", filename);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            { file.CopyTo(stream); }
            Staticabout item = new Staticabout();
            item.Img1path = filename;
            return item;
        }
    }
}
