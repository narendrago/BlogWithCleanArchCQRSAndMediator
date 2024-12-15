using System;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Commands.CreateBlog;

public class NewBlogDto
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}
