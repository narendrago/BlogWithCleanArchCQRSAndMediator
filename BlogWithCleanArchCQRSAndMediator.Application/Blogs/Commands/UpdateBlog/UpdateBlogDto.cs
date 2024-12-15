using System;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.UpdateBlog;

public class UpdateBlogDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}
