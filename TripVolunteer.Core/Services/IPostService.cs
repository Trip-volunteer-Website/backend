using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Services
{
    public interface IPostService
    {
        List<Post> GetAllPosts();
        void makePost(Post post);
        void deletePost(int id);
        public void updatePost(Post post);
        Post getPostById(int id);
    }
}
