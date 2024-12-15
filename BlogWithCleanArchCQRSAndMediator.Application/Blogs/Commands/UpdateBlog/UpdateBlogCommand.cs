using BlogWithCleanArchCQRSAndMediator.Domain.Entity;
using BlogWithCleanArchCQRSAndMediator.Domain.Repository;
using MediatR;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.UpdateBlog;

public class UpdateBlogCommand: IRequest<int>
{
    public int BlogId { get; set; }
    public UpdateBlogDto UpdateBlogDto { get; set; }
}

public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;
    public UpdateBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
    {
        var blog = new Blog(){ Name = request.UpdateBlogDto.Name, Description = request.UpdateBlogDto.Description, Author = request.UpdateBlogDto.Author };
        return await _blogRepository.UpdateAsync(request.BlogId, blog);
    }
}