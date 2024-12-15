using BlogWithCleanArchCQRSAndMediator.Application.Blogs.Queries.GetBlogs;
using BlogWithCleanArchCQRSAndMediator.Domain.Repository;
using MediatR;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Queries.GetBlogById;

public class GetBlogByIdQuery: IRequest<BlogDto>
{
    public int BlogId { get; set; }
}

public class GetBlogByIdQueryHandler : IRequestHandler<GetBlogByIdQuery, BlogDto>
{
    private readonly IBlogRepository _blogRepository;
    public GetBlogByIdQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<BlogDto> Handle(GetBlogByIdQuery request, CancellationToken cancellationToken)
    {
        var blog = await _blogRepository.GetByIdAsync(request.BlogId);
        var blogDto = new BlogDto() { Id = blog.Id, Author = blog.Author, Description = blog.Description, Name = blog.Name };

        return blogDto;
    }
}