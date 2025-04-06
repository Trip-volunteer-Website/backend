using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripController : ControllerBase
    {
        private readonly ITripService tripService;
        private readonly ITripRequestService tripRequest;
        public TripController(ITripService tripService, ITripRequestService tripRequest)
        {
            this.tripService = tripService;
            this.tripRequest = tripRequest;
        }



        [HttpGet]
        public List<Trip> GetAllTrips()
        {
            return tripService.GetAllTrips();

        }


        [HttpGet]
        [Route("gettripbyid/{id}")]
        public Trip GetTripById(int id)
        {
            return tripService.GetTripById(id);
        }


        [HttpPost]
        public void CreateTrip(Trip trip)
        {
            tripService.CreateTrip(trip);
        }


        [HttpPut]
        public void UpdateTrip(Trip trip)
        {
            tripService.UpdateTrip(trip);

        }

        [HttpDelete]
        [Route("deletetrip/{tripId}")]
        public void DeleteTrip(int tripId)
        {
            tripService.DeleteTrip(tripId);
        }

        [HttpGet]
        [Route("maxvolunteeranduser/{tripid}")]
        public IActionResult GetMaxVolunteersAndUsers(int tripid)
        {
            var result = tripService.GetMaxVolunteersAndUsers(tripid);

            return Ok(new { MaxVolunteers = result.MaxVolunteers, MaxUsers = result.MaxUsers });
        }


        [HttpGet]
        [Route("minage/{tripId}")]
        public int GetMinAge(int tripId)
        {
            return tripService.GetMinAge(tripId);

        }


        [HttpGet]
        [Route("location/{tripId}")]
        public IActionResult GetLocation(int tripId)
        {
            var location = tripService.GetLocation(tripId);
            if (location == default)
            {
                return NotFound("Location not found");
            }
            return Ok(new { Longitude = location.Longitude, Latitude = location.Latitude });
        }


        [HttpGet]
        [Route("TripsBetweenInterval")]
        public IActionResult GetTripsBetweenInterval([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
        {


            var trips = tripService.GetTripsBetweenInterval(startDate, endDate);



            return Ok(trips);
        }


        [HttpPut]
        [Route("Location/{tripId}")]
        public void SetLocation(int tripId, double longitude, double latitude)
        {
            tripService.SetLocation(tripId, longitude, latitude);
        }


        [HttpGet("availableSeats")]
        public IActionResult GetAvailableSeats(int tripId)
        {
            var (maxVolunteers, maxUsers) = tripService.GetMaxVolunteersAndUsers(tripId);

            var allRequests = tripRequest.GetAllTripRequests();
            if (allRequests == null)
            {
                return NotFound("No trip requests found.");
            }

            int acceptedVolunteers = allRequests
                .Count(r => r.Tripid == tripId && r.Requesttype.ToLower() == "volunteer" && r.Status == "approved");

            int acceptedUsers = allRequests
                .Count(r => r.Tripid == tripId && r.Requesttype.ToLower() == "user" && r.Status == "approved");

            var result = new
            {
                tripid = tripId,
                userSeats = maxUsers - acceptedUsers,
                volunteerSeats = maxVolunteers - acceptedVolunteers
            };

            return Ok(result);
        }



        //[HttpPost]
        //public async Task<IActionResult> CreateTrip([FromBody] Trip trip)
        //{
        //    if (trip == null || string.IsNullOrEmpty(trip.Location))
        //    {
        //        Console.WriteLine("⚠️ Received invalid trip data or missing location.");
        //        return BadRequest("Invalid trip data or location is missing.");
        //    }

        //    Console.WriteLine($"📍 Received Location: {trip.Location}");

        //    try
        //    {
        //        var coordinates = await GetCoordinatesAsync(trip.Location);

        //        if (coordinates.Latitude == 0 && coordinates.Longitude == 0)
        //        {
        //            Console.WriteLine("⚠️ Could not retrieve valid coordinates.");
        //            return BadRequest("Could not find location coordinates.");
        //        }

        //        trip.Latitude = (decimal?)coordinates.Latitude;
        //        trip.Longitude = (decimal?)coordinates.Longitude;

        //        tripService.CreateTrip(trip);
        //        return Ok(new { message = "Trip created successfully!", trip.Latitude, trip.Longitude });
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine($"❌ Error creating trip: {ex.Message}");
        //        return StatusCode(500, "An error occurred while creating the trip.");
        //    }
        //}


        //private async Task<(double Latitude, double Longitude)> GetCoordinatesAsync(string address)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        string url = $"https://nominatim.openstreetmap.org/search?format=json&q={Uri.EscapeDataString(address)}";
        //        Console.WriteLine($"🔍 Testing URL: {url}");

        //        var response = await client.GetAsync(url);
        //        if (!response.IsSuccessStatusCode)
        //        {
        //            Console.WriteLine($"❌ API Request Failed: {response.StatusCode}");
        //            Console.WriteLine($"Response Content: {await response.Content.ReadAsStringAsync()}");
        //            return (0, 0);
        //        }

        //        string json = await response.Content.ReadAsStringAsync();
        //        Console.WriteLine($"📩 API Response: {json}");

        //        var data = Newtonsoft.Json.JsonConvert.DeserializeObject<List<dynamic>>(json);

        //        if (data == null || data.Count == 0)
        //        {
        //            Console.WriteLine("❌ No coordinates found for this location.");
        //            return (0, 0);
        //        }

        //        try
        //        {
        //            double lat = double.Parse((string)data[0]["lat"]);
        //            double lon = double.Parse((string)data[0]["lon"]);
        //            Console.WriteLine($"✅ Found Coordinates: {lat}, {lon}");
        //            return (lat, lon);
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine($"❌ Parsing Error: {ex.Message}");
        //            return (0, 0);
        //        }
        //    }
        //}



    }
}