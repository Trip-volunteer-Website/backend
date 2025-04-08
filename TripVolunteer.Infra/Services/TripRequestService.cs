using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class TripRequestService : ITripRequestService
    {
        private readonly ITripRequestRepository _tripRequestRepo;
        public TripRequestService(ITripRequestRepository tripRequestRepo)
        {
            _tripRequestRepo = tripRequestRepo;
        }
        public void CreateTripRequest(Triprequest triprequest)
        {
            _tripRequestRepo.CreateTripRequest(triprequest);
        }

        public void deleteTripRequest(int request_id)
        {
            _tripRequestRepo.deleteTripRequest(request_id);
        }

        public List<Triprequest> GetAllTripRequests()
        {
            return _tripRequestRepo.GetAllTripRequests();
        }

        public Triprequest GetCV(int request_id)
        {
            return _tripRequestRepo.GetCV(request_id);
        }

        public Triprequest GetRequestStatusAndType(int request_id)
        {
            return _tripRequestRepo.GetRequestStatusAndType(request_id);
        }

        public Triprequest GetTriprequestById(int request_id)
        {
            return _tripRequestRepo.GetTriprequestById(request_id);
        }

        public void SetCV(int request_Id, string cv_file_path)
        {
            _tripRequestRepo.SetCV(request_Id, cv_file_path);
        }

        public void UpdateTripRequest(Triprequest triprequest)
        {
            _tripRequestRepo.UpdateTripRequest(triprequest);
        }
        public void UpdateTripRequestPayment(decimal Requestid, decimal Paymentid)
        {
            _tripRequestRepo.UpdateTripRequestPayment(Requestid, Paymentid);
        }
    }
}
