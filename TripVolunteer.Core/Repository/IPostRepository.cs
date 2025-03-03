using TripVolunteer.Core.Data;

namespace TripVolunteer.Core.Repository
{
    public interface IPostRepository
    {
        List<Post> GetAllPosts();
        void makePost(Post post);
        void deletePost(int id);
        public void updatePost(Post post);
        Post getPostById(int id);
    }
}
