using Dapper;
using System.Data;
using TripVolunteer.Core.Common;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;

namespace TripVolunteer.Infra.Repository
{
    public class PostRepository : IPostRepository
    {
        private readonly IDbContext _dbContext;

        public PostRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }

        public void deletePost(int id)
        {
            var p = new DynamicParameters();
            p.Add("post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("post_package.deletePost", p, commandType: CommandType.StoredProcedure);

        }

        public List<Post> GetAllPosts()
        {
            IEnumerable<Post> result = _dbContext.Connection.Query<Post>
           ("post_package.GetAllPosts", commandType: CommandType.StoredProcedure);

            return result.ToList();
        }

        public Post getPostById(int id)
        {
            var p = new DynamicParameters();
            p.Add("post_id", id, dbType: DbType.Int32, direction: ParameterDirection.Input);

            IEnumerable<Post> result = _dbContext.Connection.Query<Post>
                ("post_package.getPostById", p, commandType: CommandType.StoredProcedure);

            return result.FirstOrDefault();
        }

        public void makePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("image_path", post.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("post_title", post.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("post_content", post.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("created_at", post.Createdat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("post_package.makePost", p, commandType: CommandType.StoredProcedure);

        }

        public void updatePost(Post post)
        {
            var p = new DynamicParameters();
            p.Add("post_id", post.Postid, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("image_path", post.Imagepath, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("post_title", post.Title, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("post_content", post.Content, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("created_at", post.Createdat, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("post_package.updatePost", p, commandType: CommandType.StoredProcedure);

        }
    }
}
