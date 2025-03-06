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
        [Route("UploudImage")]
        public Statichome UploudImage()
        {
            var file = Request.Form.Files[0];
            var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("Images", filename);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Statichome item = new Statichome();
            item.P1 = file.FileName;
            item.P2 = file.FileName;
            item.P3 = file.FileName;
            return item;
        }
    }
}
