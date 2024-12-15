using BlogWithCleanArchCQRSAndMediator.Domain.Repository;
using MediatR;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.DeleteBlog;

public class DeleteBlogCommand: IRequest<int>
{
    public int BlogId { get; set; }
}

public class DeleteBlogCommandHandler : IRequestHandler<DeleteBlogCommand, int>
{
    private readonly IBlogRepository _blogRepository;
    public DeleteBlogCommandHandler(IBlogRepository blogRepository)
    {
        _blogRepository = blogRepository;
    }

    public async Task<int> Handle(DeleteBlogCommand request, CancellationToken cancellationToken)
    {
        return await _blogRepository.DeleteAsync(request.BlogId);
    }
}