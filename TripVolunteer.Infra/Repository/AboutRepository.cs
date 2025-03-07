using Dapper;  
using System.Data; 
using TripVolunteer.Core.Common;  
using TripVolunteer.Core.Data;  
using TripVolunteer.Core.Repository;  

namespace TripVolunteer.Infra.Repository  
{
    public class AboutRepository : IAboutRepository  
    {
        private readonly IDbContext _dbContext;  

        public AboutRepository(IDbContext dbContext)  
        {
            _dbContext = dbContext;  
        }


        public  List<Staticabout>GetAll()  
        {
            IEnumerable<Staticabout> result = _dbContext.Connection.Query<Staticabout>("about_package.GetAllabout", commandType: CommandType.StoredProcedure); 
            return result.ToList();  
        }




        public void CreateAbout(Staticabout aboutus)  
        {
            var p = new DynamicParameters();  
            p.Add("about_title", aboutus.Title1, dbType: DbType.String, direction: ParameterDirection.Input); 
            p.Add("about_image", aboutus.Img1path, dbType: DbType.String, direction: ParameterDirection.Input);  
            p.Add("about_content", aboutus.Content, dbType: DbType.String, direction: ParameterDirection.Input);  

           var result = _dbContext.Connection.Execute("about_package.createabout", p, commandType: CommandType.StoredProcedure);  
        }



        public void DeleteAbout(int aboutId)  
        {
            var p = new DynamicParameters();  
            p.Add("about_id", aboutId, dbType: DbType.Int32, direction: ParameterDirection.Input);  

            var result = _dbContext.Connection.Execute("about_package.deleteabout", p, commandType: CommandType.StoredProcedure);  
        }



        public Staticabout GetAboutById(int aboutId)

        {
            var p = new DynamicParameters();  
            p.Add("about_id", aboutId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Staticabout> result = _dbContext.Connection.Query<Staticabout>("about_package.getaboutbyid", p, commandType: CommandType.StoredProcedure);  
            return result.FirstOrDefault();  //return one object
        }

     

        public void UpdateAbout(Staticabout aboutus)  
        {
            var p = new DynamicParameters(); 
            p.Add("about_id", aboutus.Id, dbType: DbType.Int32, direction: ParameterDirection.Input);  
            p.Add("about_title", aboutus.Title1, dbType: DbType.String, direction: ParameterDirection.Input);  
            p.Add("about_image", aboutus.Img1path, dbType: DbType.String, direction: ParameterDirection.Input);  
            p.Add("about_content", aboutus.Content, dbType: DbType.String, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("about_package.updateabout", p, commandType: CommandType.StoredProcedure);  
        }
    }
}
