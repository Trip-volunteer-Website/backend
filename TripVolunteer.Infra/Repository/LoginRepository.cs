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

namespace TripVolunteer.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly IDbContext _dbConext;

        public LoginRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }
        public List<Login> GetAllLogin()
        {
            IEnumerable<Login> result = _dbConext.Connection
                                      .Query<Login>("login_package.GetAlllogin"
                                      , commandType: CommandType.StoredProcedure);
                     
            return result.ToList();
        }

        public void CreateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("user_name", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("log_password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("role_id", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_id", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.
                          Execute("login_package.makelogin", 
                          p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteLogin(int id)
        {
            var p = new DynamicParameters();
            p.Add("login_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("login_package.deletelogin", p, commandType: CommandType.StoredProcedure);
        }
        public void UpdateLogin(Login login)
        {
            var p = new DynamicParameters();
            p.Add("login_id", login.Loginid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_name", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("log_password", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("role_id", login.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_id", login.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.
                         Execute("login_package.updatelogin", 
                         p, commandType: CommandType.StoredProcedure);
        }


        public Login GetLoginById(int id)
        {
            var p = new DynamicParameters();
            p.Add("login_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Login> result = _dbConext.Connection.Query<Login>
                ("login_package.getloginbyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }
        public Login Auth(Login login)
        {
            var p = new DynamicParameters();
            p.Add("user_name", login.Username, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("pass", login.Password, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbConext.Connection
                          .Query<Login>("login_package.userLogin", p,
                           commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }
    }
}
