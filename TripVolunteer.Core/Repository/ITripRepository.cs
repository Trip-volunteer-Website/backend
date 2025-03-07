using System.Collections.Generic;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface ITripRepository
    {
        List<Trip> GetAllTrips();
        void CreateTrip(Trip trip);
        void UpdateTrip(Trip trip);
        void DeleteTrip(int tripId);
        Trip GetTripById(int tripId);
        (int MaxVolunteers, int MaxUsers) GetMaxVolunteersAndUsers(int tripId);
        int GetMinAge(int tripId);
        (double Longitude, double Latitude) GetLocation(int tripId);
        List<Trip> GetTripsBetweenInterval(DateTime startDate, DateTime endDate);
        void SetLocation(int tripId, double longitude, double latitude);
    }
}
