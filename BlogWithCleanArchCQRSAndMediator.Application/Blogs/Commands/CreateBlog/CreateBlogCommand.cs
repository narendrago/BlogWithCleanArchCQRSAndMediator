using BlogWithCleanArchCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using BlogWithCleanArchCQRSAndMediator.Domain.Entity;
using BlogWithCleanArchCQRSAndMediator.Domain.Repository;
using MediatR;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.CreateBlog;

public class CreateBlogCommand: IRequest<BlogDto>
{
    public NewBlogDto NewBlogDto { get; set; }
}

public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogDto>
{
    private readonly IBlogRepository _blogRepository;
    public CreateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<BlogDto> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog(){ Name = request.NewBlogDto.Name, Description = request.NewBlogDto.Description, Author = request.NewBlogDto.Author };
        var newBlog = await _blogRepository.CreateAsync(blog);
        var blogDto = new BlogDto() { Id = newBlog.Id, Name = blog.Name, Description = newBlog.Description, Author = newBlog.Author };
        
        return blogDto;
    }
}