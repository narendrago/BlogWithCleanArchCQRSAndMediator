using System;

namespace BlogWithCleanArchCQRSAndMediator.Application.Blogs.Queries.GetBlogs;

public class BlogDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Author { get; set; }
}
