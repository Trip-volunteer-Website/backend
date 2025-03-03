using TripVolunteer.Core.Data;
using TripVolunteer.Core.Repository;
using TripVolunteer.Core.Services;

namespace TripVolunteer.Infra.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;
        public PostService(IPostRepository
        postRepository)
        {
            _postRepository = postRepository;
        }

        public void deletePost(int id)
        {
            _postRepository.deletePost(id);
        }

        public List<Post> GetAllPosts()
        {
            return _postRepository.GetAllPosts();
        }

        public Post getPostById(int id)
        {
            return _postRepository.getPostById(id);
        }

        public void makePost(Post post)
        {
            _postRepository.makePost(post);
        }

        public void updatePost(Post post)
        {
            _postRepository.updatePost(post);
        }
    }
}
