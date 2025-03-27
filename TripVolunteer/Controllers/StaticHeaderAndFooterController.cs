using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaticHeaderAndFooterController : ControllerBase
    {
        private readonly IStaticHeaderAndFooterService staticHeaderAndFooterService;

        public StaticHeaderAndFooterController(IStaticHeaderAndFooterService staticHeaderAndFooterService)
        {
            this.staticHeaderAndFooterService = staticHeaderAndFooterService;
        }

        [HttpGet]
        public List<Staticheaderandfooter> GetAlStaticHeaderAndFooter()
        {
            return staticHeaderAndFooterService.GetAllhf();
        }
        [HttpGet]
        [Route("getbyId/{id}")]
        public Staticheaderandfooter GetStaticheaderandfooterById(int id)
        {

            return staticHeaderAndFooterService.gethfbyid(id);
        }

        [HttpPost]
        public void CreateStaticheaderandfooter(Staticheaderandfooter staticheaderandfooter)
        {
            staticHeaderAndFooterService.createhf(staticheaderandfooter);
        }
        [HttpPut]
        public void UpdateStaticheaderandfooter(Staticheaderandfooter staticheaderandfooter)
        {
            staticHeaderAndFooterService.updatehf(staticheaderandfooter);
        }

        [HttpDelete]
        [Route("DeleteStaticheaderandfooter{id}")]
        public void DeleteStaticheaderandfooter(int id)
        {
            staticHeaderAndFooterService.deletehf(id);
        }

        [HttpPost]
        [Route("UploudImage")]
        public Staticheaderandfooter UploudImage()
        {
            var file = Request.Form.Files[0];
            var filename = Guid.NewGuid().ToString() + "_" + file.FileName;
            var fullpath = Path.Combine("C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\images", filename);
            using (var stream = new FileStream(fullpath, FileMode.Create))
            {
                file.CopyTo(stream);
            }
            Staticheaderandfooter item = new Staticheaderandfooter();
            item.Logo = filename;
            return item;
        }
    }

}
