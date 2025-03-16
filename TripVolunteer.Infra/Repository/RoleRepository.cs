using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Dapper;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class RoleRepository : IRoleRepository
    {
        private readonly IDbContext _dbContext;

        public RoleRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Role> GetAllRole()
        {
            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("role_Package.GetAllrole", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Role GetRoleById(int id)
        {
            var p = new DynamicParameters();
            p.Add("role_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Role> result = _dbContext.Connection.Query<Role>("role_Package.getrolebyid", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void CreateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

           var result= _dbContext.Connection.Execute("role_Package.makerole", p, commandType: CommandType.StoredProcedure);
        }

        public void UpdateRole(Role role)
        {
            var p = new DynamicParameters();
            p.Add("role_id", role.Roleid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("role_name", role.Rolename, dbType: DbType.String, direction: ParameterDirection.Input);

           var result= _dbContext.Connection.Execute("role_Package.updaterole", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteRole(int id)
        {
            var p = new DynamicParameters();
            p.Add("role_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

          var result=  _dbContext.Connection.Execute("role_Package.deleterole", p, commandType: CommandType.StoredProcedure);
        }
    }
}
