using System;
using BlogWithCleanArchCQRSAndMediator.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogWithCleanArchCQRSAndMediator.Infrastructure.Data;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> dbContextOptions) 
    : base(dbContextOptions)
    {

    }

    public DbSet<Blog> Blogs { get; set;}
}
