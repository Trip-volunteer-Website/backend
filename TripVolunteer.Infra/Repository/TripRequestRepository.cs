using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;

namespace TripVolunteer.Infra.Repository
{
    public class TripRequestRepository : ITripRequestRepository
    {
        private readonly IDbContext _dbContext;

        public TripRequestRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void CreateTripRequest(Triprequest triprequest)
        {
            var p = new DynamicParameters();
            p.Add("user_id", triprequest.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("trip_id", triprequest.Tripid, DbType.Int32, ParameterDirection.Input);
            p.Add("request_type", triprequest.Requesttype, DbType.String, ParameterDirection.Input);
            p.Add("cv_file_path", triprequest.Cvfilepath, DbType.String, ParameterDirection.Input); 
            p.Add("Request_status", triprequest.Status ?? "pending", DbType.String, ParameterDirection.Input); 
            p.Add("payment_id", triprequest.Paymentid, DbType.Int32, ParameterDirection.Input); 
            p.Add("request_date", triprequest.Requestedat ?? DateTime.Now, DbType.DateTime, ParameterDirection.Input);

            _dbContext.Connection.Execute("tripRequest_package.makeTripRequest", p, commandType: CommandType.StoredProcedure);
        }

        public void deleteTripRequest(int requestid)
        {
            var p = new DynamicParameters();
            p.Add("request_id", requestid, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("tripRequest_package.deleteTripRequest", p, commandType: CommandType.StoredProcedure);
        }

        public List<Triprequest> GetAllTripRequests()
        {
            IEnumerable<Triprequest> result = _dbContext.Connection.Query<Triprequest>(
               "tripRequest_package.GetAllTripRequests", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Triprequest GetCV(int requestid)
        {
            var p = new DynamicParameters();
            p.Add("request_Id", requestid, DbType.Int32, ParameterDirection.Input);

            return _dbContext.Connection.QueryFirstOrDefault<Triprequest>(
                "tripRequest_package.GetCV", p, commandType: CommandType.StoredProcedure);
        }

        public Triprequest GetRequestStatusAndType(int requestid)
        {
            var p = new DynamicParameters();
            p.Add("p_requestid", requestid, DbType.Int32, ParameterDirection.Input);

            return _dbContext.Connection.QueryFirstOrDefault<Triprequest>(
                "tripRequest_package.GetRequestStatusAndType", p, commandType: CommandType.StoredProcedure);
        }

        public Triprequest GetTriprequestById(int requestid)
        {
            var p = new DynamicParameters();
            p.Add("request_id", requestid, DbType.Int32, ParameterDirection.Input);

            IEnumerable<Triprequest> result = _dbContext.Connection.Query<Triprequest>(
               "tripRequest_package.getTripRequestById",p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void SetCV(int requestId, string cvfilepath)
        {
            var p = new DynamicParameters();
            p.Add("request_Id", requestId, DbType.Int32, ParameterDirection.Input);
            p.Add("cv_file_path", cvfilepath, DbType.String, ParameterDirection.Input);
            _dbContext.Connection.Execute("tripRequest_package.SetCV", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateTripRequest(Triprequest triprequest)
        {
            var p = new DynamicParameters();
            p.Add("request_id", triprequest.Requestid, DbType.Int32, ParameterDirection.Input);
            p.Add("user_id", triprequest.Userid, DbType.Int32, ParameterDirection.Input);
            p.Add("trip_id", triprequest.Tripid, DbType.Int32, ParameterDirection.Input);
            p.Add("request_type", triprequest.Requesttype, DbType.String, ParameterDirection.Input);
            p.Add("cv_file_path", triprequest.Cvfilepath, DbType.String, ParameterDirection.Input);
            p.Add("Request_status", triprequest.Status, DbType.String, ParameterDirection.Input);
            p.Add("payment_id", triprequest.Paymentid, DbType.Int32, ParameterDirection.Input);
            _dbContext.Connection.Execute("tripRequest_package.updateTripRequest", p, commandType: CommandType.StoredProcedure);
        }
    }
}
