
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripRequestController : ControllerBase
    {
        private readonly ITripRequestService _tripRequestService;
        public TripRequestController(ITripRequestService tripRequestService)
        {
            _tripRequestService = tripRequestService;
        }

        [HttpGet("all")]
        public List<Triprequest> GetAllTripRequests()
        {
            return _tripRequestService.GetAllTripRequests();
        }

        [HttpGet]
        [Route("getbyid/{id}")]
        public Triprequest GetTriprequestByID(int id)
        {
            return _tripRequestService.GetTriprequestById(id);
        }


        [HttpDelete]
        [Route("deleteTripReq/{id}")]
        public void DeleteTripRequest(int id)
        {
            _tripRequestService.deleteTripRequest(id);
        }

        [HttpPost]
        public void CreateTripRequest(Triprequest triprequest)
        {
            _tripRequestService.CreateTripRequest(triprequest);
        }

        [HttpPut]
        public void UpdateTripRequest(Triprequest triprequest)
        {
            _tripRequestService.CreateTripRequest(triprequest);
        }

        [HttpGet]
        [Route("getReq_status&Type/{id}")]
        public Triprequest GetRequestStatusAndType(int id)
        {
            return _tripRequestService.GetRequestStatusAndType(id);
        }

        [HttpPost]
        [Route("setCV/{id}/{cv_file_path}")]
        public void SetCV(int Id, string cv_file_path)
        {
            _tripRequestService.SetCV(Id, cv_file_path);
        }

        [HttpGet]
        [Route("getCv/{id}")]
        public Triprequest GetCV(int id)
        {
            return _tripRequestService.GetCV(id);
        }






    }
}
