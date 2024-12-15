using BlogWithCleanArchCQRSAndMediator.Domain.Repository;
using MediatR;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Queries.GetBlogs;

public class GetBlogsQuery: IRequest<List<BlogDto>>
{

}

public class GetBlogsQueryHandler : IRequestHandler<GetBlogsQuery, List<BlogDto>>
{
    private readonly IBlogRepository _blogRepository;
    public GetBlogsQueryHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<List<BlogDto>> Handle(GetBlogsQuery request, CancellationToken cancellationToken)
    {
        var blogs = await _blogRepository.GetAllBlogsAsync();
        var blogDtos = blogs.Select(blog => new BlogDto { Id = blog.Id, Author = blog.Author, Description = blog.Description, Name = blog.Name })
        .ToList();
    
        return blogDtos;
    }
}