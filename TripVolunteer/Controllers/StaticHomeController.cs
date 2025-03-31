using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticHomeController : ControllerBase
    {
        private readonly IStaticHomeService staticHomeService;

        public StaticHomeController(IStaticHomeService staticHomeService)
        {
            this.staticHomeService = staticHomeService;
        }

        [HttpGet]
        public List<Statichome> GetAlStatichome()
        {
            return staticHomeService.GetAllStaticHome();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Statichome GetStatichomeById(int id)
        {

            return staticHomeService.getStaticHomeById(id);
        }

        [HttpPost]
        public void CreateStatichome(Statichome statichome)
        {
            staticHomeService.addStaticHome(statichome);
        }
        [HttpPut]
        public void UpdateStatichome(Statichome statichome)
        {
            staticHomeService.updateStaticHome(statichome);
        }

        [HttpDelete]
        [Route("DeleteStatichome/{id}")]
        public void DeleteStatichome(int id)
        {
            staticHomeService.deleteStaticHome(id);
        }
        [HttpPost]
        [Route("UploudImage/{imgName}")]
        public Statichome UploudImage(string imgName)
        {
            var file = Request.Form.Files[0]; // Get the first uploaded file
            var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\images", filename);

            // Save the file
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Statichome item = new Statichome();

            if (imgName == "img1path")
            {
                item.Img1path = filename;
            }
            else if (imgName == "img2path")
            {
                item.Img2path = filename;
            }
            else if (imgName == "img3path")
            {
                item.Img3path = filename;
            }
            else
            {
                throw new ArgumentException("Invalid imgName provided.");
            }

            return item;
        }
    }
}
