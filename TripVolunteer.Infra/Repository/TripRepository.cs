using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Repository
{
    public class TripRepository : ITripRepository
    {
        private readonly IDbContext _dbContext;

        public TripRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void CreateTrip(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("trip_Name", trip.Tripname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("trip_location", trip.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("start_Date", trip.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("end_Date", trip.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("trip_price", trip.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("min_age", trip.Minage, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_description", trip.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("max_volunteers", trip.Maxvolunteers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("max_users", trip.Maxusers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_status", trip.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("trip_longitude", trip.Longitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("trip_latitude", trip.Latitude, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("trip_package.maketrip", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTrip(int tripId)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            int result = _dbContext.Connection.Execute("trip_package.deletetrip", p, commandType: CommandType.StoredProcedure);
        }

        public List<Trip> GetAllTrips()
        {
            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trip_package.GetAlltrip", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }
        //********************************************************************************************
        public (double Longitude, double Latitude) GetLocation(int tripId)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return _dbContext.Connection
                .Query<(double Longitude, double Latitude)>("trip_package.getLocation", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }
        //***********************************************************************************

        public (int MaxVolunteers, int MaxUsers) GetMaxVolunteersAndUsers(int tripId)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            return _dbContext.Connection
                .Query<(int MaxVolunteers, int MaxUsers)>("trip_package.getMaxVolunteersAndUsers", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();
        }

        //*********************************************************************************************
        public int GetMinAge(int tripId)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            int result = _dbContext.Connection
                .Query<int>("trip_package.getMinAge", p, commandType: CommandType.StoredProcedure)
                .FirstOrDefault();

            return result;
        }



        public Trip GetTripById(int tripId)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trip_package.gettripbyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public List<Trip> GetTripsBetweenInterval(DateTime startDate, DateTime endDate)
        {
            var p = new DynamicParameters();
            p.Add("start_date", startDate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("end_date", endDate, dbType: DbType.Date, direction: ParameterDirection.Input);

            IEnumerable<Trip> result = _dbContext.Connection.Query<Trip>("trip_package.GettripBetweenInterval", p, commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public void SetLocation(int tripId, double longitude, double latitude)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", tripId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_longitude", longitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("trip_latitude", latitude, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("trip_package.SetLocation", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTrip(Trip trip)
        {
            var p = new DynamicParameters();
            p.Add("trip_id", trip.Tripid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_Name", trip.Tripname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("trip_location", trip.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("start_Date", trip.Startdate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("end_Date", trip.Enddate, dbType: DbType.Date, direction: ParameterDirection.Input);
            p.Add("trip_price", trip.Price, dbType: DbType.Decimal, direction: ParameterDirection.Input);
            p.Add("min_age", trip.Minage, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_description", trip.Description, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("max_volunteers", trip.Maxvolunteers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("max_users", trip.Maxusers, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("trip_status", trip.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("trip_longitude", trip.Longitude, dbType: DbType.Double, direction: ParameterDirection.Input);
            p.Add("trip_latitude", trip.Latitude, dbType: DbType.Double, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("trip_package.updatetrip", p, commandType: CommandType.StoredProcedure);
        }
    }
}
