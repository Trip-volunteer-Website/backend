using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface ITripRequestService
    {
        List<Triprequest> GetAllTripRequests();
        void CreateTripRequest(Triprequest triprequest);
        void UpdateTripRequest(Triprequest triprequest);
        void deleteTripRequest(int request_id);
        Triprequest GetTriprequestById(int request_id);
        Triprequest GetRequestStatusAndType(int request_id);
        void SetCV(int request_Id, string cv_file_path);
        Triprequest GetCV(int request_id);
        public void UpdateTripRequestPayment(decimal Requestid,decimal Paymentid);
    }
}
