using Dapper;
using System.Data;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class StaticHeaderAndFooterRepository : IStaticHeaderAndFooterRepository
    {
        private readonly IDbContext _dbContext;

        public StaticHeaderAndFooterRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void createhf(Staticheaderandfooter staticheaderandfooter)
        {
            var p = new DynamicParameters();
            p.Add("hf_email", staticheaderandfooter.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_number", staticheaderandfooter.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("hf_name", staticheaderandfooter.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("hf_logo", staticheaderandfooter.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("hf_location", staticheaderandfooter.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("hf_content", staticheaderandfooter.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("headerandfooter_package.createhf", p, commandType: CommandType.StoredProcedure);

        }

        public void deletehf(int id)
        {
            var p = new DynamicParameters();
            p.Add("hf_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("headerandfooter_package.deletehf", p, commandType: CommandType.StoredProcedure);

        }

        public List<Staticheaderandfooter> GetAllhf()
        {
            IEnumerable<Staticheaderandfooter> result = _dbContext.Connection.Query<Staticheaderandfooter>
            ("headerandfooter_package.GetAllhf", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Staticheaderandfooter gethfbyid(int id)
        {
            var p = new DynamicParameters();
            p.Add("post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Staticheaderandfooter> result = _dbContext.Connection.Query<Staticheaderandfooter>
                ("headerandfooter_package.gethfbyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void updatehf(Staticheaderandfooter staticheaderandfooter)
        {
            var p = new DynamicParameters();
            p.Add("hf_id", staticheaderandfooter.Id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("hf_email", staticheaderandfooter.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("phone_number", staticheaderandfooter.Phonenumber, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("hf_name", staticheaderandfooter.Name, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("hf_logo", staticheaderandfooter.Logo, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("hf_location", staticheaderandfooter.Location, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("hf_content", staticheaderandfooter.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("headerandfooter_package.createhf", p, commandType: CommandType.StoredProcedure);

        }
    }
}
