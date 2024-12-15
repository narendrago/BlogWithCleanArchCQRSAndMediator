using System;
using BlogWithCleanArchCQRSAndMediator.Domain.Entity;
using BlogWithCleanArchCQRSAndMediator.Domain.Repository;
using BlogWithCleanArchCQRSAndMediator.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace BlogWithCleanArchCQRSAndMediator.Infrastructure.Repository;

public class BlogRepository : IBlogRepository
{
    private readonly BlogDbContext _blogDbContext;
    public BlogRepository(BlogDbContext blogDbContext){
        _blogDbContext = blogDbContext;
    }


    public async Task<Blog> CreateAsync(Blog blog)
    {
        await _blogDbContext.Blogs.AddAsync(blog);
        await _blogDbContext.SaveChangesAsync();
        return blog;
    }

    public async Task<int> DeleteAsync(int id)
    {
        return await _blogDbContext.Blogs
        .Where(b => b.Id == id)
        .ExecuteDeleteAsync();
    }

    public async Task<List<Blog>> GetAllBlogsAsync()
    {
        return await _blogDbContext.Blogs.ToListAsync();
    }

    public async Task<Blog> GetByIdAsync(int id)
    {
        return await _blogDbContext.Blogs
        .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<int> UpdateAsync(int id, Blog blog)
    {
        return await _blogDbContext.Blogs
        .Where(b => b.Id == id)
        .ExecuteUpdateAsync(setters => setters
        .SetProperty(b => b.Name, blog.Name)
        .SetProperty(b => b.Author, blog.Author)
        .SetProperty(b => b.Description, blog.Description)
        );
    }
}
