using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TripVolunteer.Core.Data;
using TripVolunteer.Core.Services;

namespace TripVolunteer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService _postService;

        public PostController(IPostService postService)
        {
            _postService = postService;
        }

        [HttpGet]
        public List<Post> GetAllPosts()
        {
            return _postService.GetAllPosts();
        }

        [HttpGet]
        [Route("GetPostById/{id}")]
        public Post GetPostById(int id)
        {
            return _postService.getPostById(id);
        }



        [HttpPost]
        [Route("uploadImage")]
        public Post UploadImage()
        {
            var file = Request.Form.Files[0];


            // Generate unique file name
            var fileName = Guid.NewGuid().ToString() + "_" + file.FileName;


            var fullPath = Path.Combine("C:\\Users\\Digi\\Desktop\\edit front\\frontend\\src\\assets\\images", fileName);

            using (var stream = new FileStream(fullPath, FileMode.Create))
            {
                file.CopyTo(stream);
            }

            Post item = new Post();
            item.Imagepath = fileName;

            return item;
        }
        [HttpPost]
        public void CreatePost(Post post)
        {
            _postService.makePost(post);
        }

        [HttpPut]
        public void UpdatePost(Post post)
        {
            _postService.updatePost(post);
        }

        [HttpDelete]
        [Route("DeletePost/{id}")]
        public void DeletePost(int id)
        {
            _postService.deletePost(id);
        }
    }
}
