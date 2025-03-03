using Dapper;
using System.Data;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class GalleryRepository : IGalleryRepository
    {
        private readonly IDbContext _dbContext;

        public GalleryRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void addImage(Gallery gallery)
        {
            var p = new DynamicParameters();
            p.Add("image_path", gallery.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("gallery_package.addImage", p, commandType: CommandType.StoredProcedure);
        }

        public void deleteImage(int id)
        {
            var p = new DynamicParameters();
            p.Add("image_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("gallery_package.deleteImage", p, commandType: CommandType.StoredProcedure);

        }

        public List<Gallery> GetAllImages()
        {
            IEnumerable<Gallery> result = _dbContext.Connection.Query<Gallery>
            ("gallery_package.GetAllImages", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Gallery getImageById(int id)
        {
            var p = new DynamicParameters();
            p.Add("image_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Gallery> result = _dbContext.Connection.Query<Gallery>
                ("gallery_package.getImageById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void updateImage(Gallery gallery)
        {
            var p = new DynamicParameters();
            p.Add("image_id", gallery.Imageid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image_path", gallery.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("gallery_package.updateImage", p, commandType: CommandType.StoredProcedure);

        }
    }
}
