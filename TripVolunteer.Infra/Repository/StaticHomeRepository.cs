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
    public class StaticHomeRepository : IStaticHomeRepository
    {
        private readonly IDbContext _dbContext;

        public StaticHomeRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void addStaticHome(Statichome statichome)
        {
            var p = new DynamicParameters();
            p.Add("title_1", statichome.Title1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("title_2", statichome.Title2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("title_3", statichome.Title3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_1", statichome.P1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_2", statichome.P2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_3", statichome.P3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img1_path", statichome.Img1path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img2_path", statichome.Img2path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img3_path", statichome.Img3path, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("statichome_package.addStaticHome", p, commandType: CommandType.StoredProcedure);

        }

        public void deleteStaticHome(int id)
        {
            var p = new DynamicParameters();
            p.Add("static_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("statichome_package.deleteStaticHome", p, commandType: CommandType.StoredProcedure);
        }

        public List<Statichome> GetAllStaticHome()
        {
            IEnumerable<Statichome> result = _dbContext.Connection.Query<Statichome>
            ("statichome_package.GetAllStaticHome", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Statichome getStaticHomeById(int id)
        {
            var p = new DynamicParameters();
            p.Add("static_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Statichome> result = _dbContext.Connection.Query<Statichome>
                ("statichome_package.getStaticHomeById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void updateStaticHome(Statichome statichome)
        {
            var p = new DynamicParameters();
            p.Add("static_id", statichome.Id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("title_1", statichome.Id, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("title_1", statichome.Title1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("title_2", statichome.Title2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("title_3", statichome.Title3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_1", statichome.P1, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_2", statichome.P2, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_3", statichome.P3, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img1_path", statichome.Img1path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img2_path", statichome.Img2path, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("img3_path", statichome.Img3path, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("statichome_package.updateStaticHome", p, commandType: CommandType.StoredProcedure);

        }
    }
}
