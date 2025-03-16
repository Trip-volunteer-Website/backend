using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;
using TripVolunteer.Infra.Repository;

namespace TripVolunteer.Infra.Services
{
    public class TripService : ITripService
    {
        private readonly ITripRepository _tripRepository;
        public TripService(ITripRepository tripRepository)
        {
            _tripRepository = tripRepository;
        }
        public void CreateTrip(Trip trip)
        {
            _tripRepository.CreateTrip(trip);
        }

        public void DeleteTrip(int tripId)
        {
            _tripRepository.DeleteTrip(tripId);
        }

        public List<Trip>GetAllTrips()
        {
            return _tripRepository.GetAllTrips();
        }

        public (double Longitude, double Latitude) GetLocation(int tripId)
        {
            return _tripRepository.GetLocation(tripId);
        }



        public (int MaxVolunteers, int MaxUsers) GetMaxVolunteersAndUsers(int tripId)
        {
            return _tripRepository.GetMaxVolunteersAndUsers(tripId);
        }

        public int GetMinAge(int tripId)
        {
           return _tripRepository.GetMinAge(tripId);
        }

      public  Trip GetTripById(int tripId)
        {
         return  _tripRepository.GetTripById(tripId);
        }

       public List<Trip> GetTripsBetweenInterval(DateTime startDate, DateTime endDate)
        {
          return _tripRepository.GetTripsBetweenInterval(startDate, endDate);
        }

       public void SetLocation(int tripId, double longitude, double latitude)
        {
            _tripRepository.SetLocation(tripId, longitude, latitude);
        }

       public void UpdateTrip(Trip trip)
        {
            _tripRepository.UpdateTrip(trip);
        }
    }
}
