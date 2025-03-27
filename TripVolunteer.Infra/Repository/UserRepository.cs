using Dapper;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly IDbContext _dbConext;

        public UserRepository(IDbContext dbConext)
        {

            _dbConext = dbConext;

        }  
        public List<Userr> GetAllUser()
        {
            IEnumerable<Userr> result = _dbConext.Connection.Query<Userr>
               ("userr_package.GetAllUser", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }
        public int CreateUser(Userr userr)
        {
            var p = new DynamicParameters();
            p.Add("user_EMAIL", userr.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_phone", userr.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_fname", userr.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_lname", userr.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_country", userr.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_Path", userr.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_age", userr.Age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("role_Id", userr.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("userId", dbType: DbType.Int32, direction: ParameterDirection.Output); // Correct output parameter

            _dbConext.Connection.Execute("userr_package.makeuser", p, commandType: CommandType.StoredProcedure);

            // Retrieve and return the userId
            return p.Get<int>("userId");
        }

        public void DeleteUser(int id)
        {
            var p = new DynamicParameters();
            p.Add("user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbConext.Connection.Execute("userr_package.deleteuser", p, commandType: CommandType.StoredProcedure);

        }



        public Userr GetUserById(int id)
        {
            var p = new DynamicParameters();
            p.Add("user_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Userr> result = _dbConext.Connection.Query<Userr>
                ("userr_package.getuserbyid", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void UpdateUser(Userr userr)
        {
            var p = new DynamicParameters();
            p.Add("user_id", userr.Userid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("user_EMAIL", userr.Email, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_phone", userr.Phone, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_fname", userr.Fname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_lname", userr.Lname, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_country", userr.Country, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("image_Path", userr.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("user_age", userr.Age, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("role_Id", userr.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
        
            var result = _dbConext.Connection.Execute("userr_package.updateuser", p, commandType: CommandType.StoredProcedure);
        }



        public string GetEmailUsingCursor(int userId)
        {
            using var connection = new OracleConnection(_dbConext.Connection.ConnectionString);
            using var command = new OracleCommand("USERR_PACKAGE.getEmail", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("user_id", OracleDbType.Int32, userId, ParameterDirection.Input);
            command.Parameters.Add("cur_item", OracleDbType.RefCursor, ParameterDirection.Output);

            connection.Open();
            using var reader = command.ExecuteReader();

            return reader.Read() ? reader.GetString(0) : null;
        }


      

        public List<Userr> GetFirstAndLastName()
        {
            IEnumerable<Userr> result = _dbConext.Connection.Query<Userr>
                ("userr_package.getFirstAndLastName", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public int GetAge(int userId)
        {
            using var connection = new OracleConnection(_dbConext.Connection.ConnectionString);
            using var command = new OracleCommand("USERR_PACKAGE.getAge", connection)
            {
                CommandType = CommandType.StoredProcedure
            };

            command.Parameters.Add("user_id", OracleDbType.Int32, userId, ParameterDirection.Input);
            command.Parameters.Add("cur_item", OracleDbType.RefCursor, ParameterDirection.Output);

            connection.Open();
            using var reader = command.ExecuteReader();

            return reader.Read() ? reader.GetInt32(0) : 0; // Default to 0 if no age found
        }

    }
}
