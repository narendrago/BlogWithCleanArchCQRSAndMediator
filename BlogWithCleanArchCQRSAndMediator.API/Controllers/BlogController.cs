using BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.CreateBlog;
using BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.DeleteBlog;
using BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.UpdateBlog;
using BlogWithCleanArchCQRSAndMediator.Application.Blogs.Queries.GetBlogById;
using BlogWithCleanArchCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Mvc;

namespace BlogWithCleanArchCQRSAndMediator.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpPost]
        public async Task<BlogDto> Create(NewBlogDto newBlogDto)
        {
            var createBlogCommand = new CreateBlogCommand()
            {
                NewBlogDto = newBlogDto
            };

            return await Mediator.Send(createBlogCommand);
        }

       [HttpPost]
        public async Task<int> Delete(int blogId)
        {
            var deleteBlogCommand = new DeleteBlogCommand()
            {
                BlogId = blogId
            };

            return await Mediator.Send(deleteBlogCommand);
        }

       [HttpPost]
        public async Task<int> Update(UpdateBlogDto updateBlogDto)
        {
            var updateBlogCommand = new UpdateBlogCommand()
            {
                UpdateBlogDto = updateBlogDto
            };

            return await Mediator.Send(updateBlogCommand);
        }

        [HttpGet]
        public async Task<List<BlogDto>> GetBlogs()
        {
            var getBlogsQuery = new GetBlogsQuery();
            return await Mediator.Send(getBlogsQuery);
        }

        [HttpGet]
        public async Task<BlogDto> GetBlogById()
        {
            var getBlogByIdQuery = new GetBlogByIdQuery();
            return await Mediator.Send(getBlogByIdQuery);
        }
    }
}
